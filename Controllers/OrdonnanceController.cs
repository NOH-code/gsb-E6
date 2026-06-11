using System;
using System.Collections.Generic;
using GSB_Ordonnances.DataAccess;
using GSB_Ordonnances.Models;
using MySql.Data.MySqlClient;

namespace GSB_Ordonnances.Controllers
{
    /// <summary>
    /// Contrôleur des ordonnances. L'enregistrement touche deux tables (ORDONNANCE et
    /// CONTENIR) en N+1 requêtes : il doit être atomique, d'où la transaction.
    /// </summary>
    public class OrdonnanceController
    {
        // --- Lecture ---

        /// <summary>
        /// Historique des ordonnances d'un patient (chargement léger, SANS les lignes).
        /// JOIN ORDONNANCE / MEDECIN / PATIENT pour afficher les noms.
        /// </summary>
        public List<OrdonnanceResume> ObtenirHistorique(int numPatient)
        {
            List<OrdonnanceResume> liste = new List<OrdonnanceResume>();
            string sql =
                "SELECT o.numOrdonnance, o.dateEmission, " +
                "       m.nom AS nomMedecin, m.prenom AS prenomMedecin, " +
                "       p.nom AS nomPatient, p.prenom AS prenomPatient " +
                "FROM ORDONNANCE o " +
                "JOIN MEDECIN m ON m.numMedecin = o.numMedecin " +
                "JOIN PATIENT p ON p.numPatient = o.numPatient " +
                "WHERE o.numPatient = @numPatient " +
                "ORDER BY o.dateEmission DESC";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@numPatient", numPatient);
                using (var reader = commande.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrdonnanceResume resume = new OrdonnanceResume();
                        resume.Id = reader.GetInt32("numOrdonnance");
                        resume.DateEmission = reader.GetDateTime("dateEmission");
                        resume.NomMedecin = "Dr " +
                            reader.GetString("prenomMedecin") + " " +
                            reader.GetString("nomMedecin").ToUpper();
                        resume.NomPatient =
                            reader.GetString("prenomPatient") + " " +
                            reader.GetString("nomPatient").ToUpper();
                        liste.Add(resume);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Lignes de prescription d'une ordonnance (JOIN CONTENIR / MEDICAMENT).
        /// </summary>
        public List<LignePrescription> ObtenirLignes(int numOrdonnance)
        {
            List<LignePrescription> liste = new List<LignePrescription>();
            string sql =
                "SELECT c.posologie, c.dureeJours, " +
                "       med.codeMedicament, med.nom, med.dosage " +
                "FROM CONTENIR c " +
                "JOIN MEDICAMENT med ON med.codeMedicament = c.codeMedicament " +
                "WHERE c.numOrdonnance = @numOrdonnance";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@numOrdonnance", numOrdonnance);
                using (var reader = commande.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Medicament medicament = new Medicament(
                            reader.GetString("nom"),
                            reader.GetString("dosage"));
                        medicament.Id = reader.GetInt32("codeMedicament");

                        LignePrescription ligne = new LignePrescription(
                            medicament,
                            reader.GetString("posologie"),
                            reader.GetInt32("dureeJours"));
                        liste.Add(ligne);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Charge une ordonnance complète (en-tête + lignes) pour l'affichage du détail.
        /// </summary>
        public Ordonnance ObtenirOrdonnance(int numOrdonnance)
        {
            Ordonnance ordonnance = null;
            string sql =
                "SELECT o.numOrdonnance, o.dateEmission, " +
                "       m.numMedecin, m.nom AS nomMed, m.prenom AS prenomMed, m.dateNaissance AS ddnMed, " +
                "       m.numeroRPPS, m.specialite, m.motDePasse, " +
                "       p.numPatient, p.nom AS nomPat, p.prenom AS prenomPat, " +
                "       p.dateNaissance AS ddnPat, p.numeroSecu " +
                "FROM ORDONNANCE o " +
                "JOIN MEDECIN m ON m.numMedecin = o.numMedecin " +
                "JOIN PATIENT p ON p.numPatient = o.numPatient " +
                "WHERE o.numOrdonnance = @numOrdonnance";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@numOrdonnance", numOrdonnance);
                using (var reader = commande.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Medecin medecin = new Medecin(
                            reader.GetString("nomMed"),
                            reader.GetString("prenomMed"),
                            reader.GetDateTime("ddnMed"),
                            reader.GetString("numeroRPPS"),
                            reader.GetString("specialite"),
                            reader.GetString("motDePasse"));
                        medecin.Id = reader.GetInt32("numMedecin");

                        Patient patient = new Patient(
                            reader.GetString("nomPat"),
                            reader.GetString("prenomPat"),
                            reader.GetDateTime("ddnPat"),
                            reader.GetString("numeroSecu"));
                        patient.Id = reader.GetInt32("numPatient");

                        ordonnance = new Ordonnance(medecin, patient);
                        ordonnance.Id = reader.GetInt32("numOrdonnance");
                        ordonnance.DateEmission = reader.GetDateTime("dateEmission");
                    }
                }
            }

            // Lignes chargées séparément pour ne pas multiplier les lignes du reader.
            if (ordonnance != null)
            {
                foreach (LignePrescription ligne in ObtenirLignes(numOrdonnance))
                {
                    ordonnance.AjouterLigne(ligne);
                }
            }
            return ordonnance;
        }

        // --- Écriture transactionnelle ---

        /// <summary>
        /// Enregistre une ordonnance et ses lignes dans une transaction unique.
        /// INSERT dans ORDONNANCE (récupère le numéro via LAST_INSERT_ID), puis un INSERT
        /// dans CONTENIR par ligne. Commit si tout passe, Rollback + throw sinon.
        /// Retourne le numéro d'ordonnance généré.
        /// </summary>
        public int EnregistrerOrdonnance(Ordonnance ord)
        {
            using (var connexion = DbConnexion.Ouvrir())
            using (var transaction = connexion.BeginTransaction())
            {
                try
                {
                    // 1) En-tête de l'ordonnance
                    string sqlEntete =
                        "INSERT INTO ORDONNANCE (dateEmission, numMedecin, numPatient) " +
                        "VALUES (@date, @numMedecin, @numPatient); " +
                        "SELECT LAST_INSERT_ID();";

                    int numOrdonnance;
                    using (var commande = new MySqlCommand(sqlEntete, connexion, transaction))
                    {
                        commande.Parameters.AddWithValue("@date", ord.DateEmission);
                        commande.Parameters.AddWithValue("@numMedecin", ord.Prescripteur.Id);
                        commande.Parameters.AddWithValue("@numPatient", ord.Patient.Id);
                        numOrdonnance = Convert.ToInt32(commande.ExecuteScalar());
                    }

                    // 2) Une ligne CONTENIR par médicament prescrit
                    string sqlLigne =
                        "INSERT INTO CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours) " +
                        "VALUES (@numOrdonnance, @codeMedicament, @posologie, @dureeJours)";

                    foreach (LignePrescription ligne in ord.Lignes)
                    {
                        using (var commande = new MySqlCommand(sqlLigne, connexion, transaction))
                        {
                            commande.Parameters.AddWithValue("@numOrdonnance", numOrdonnance);
                            commande.Parameters.AddWithValue("@codeMedicament", ligne.Medicament.Id);
                            commande.Parameters.AddWithValue("@posologie", ligne.Posologie);
                            commande.Parameters.AddWithValue("@dureeJours", ligne.DureeJours);
                            commande.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();   // tout passe → on valide
                    ord.Id = numOrdonnance;
                    return numOrdonnance;
                }
                catch
                {
                    transaction.Rollback(); // un échec → on annule tout
                    throw;                  // on propage l'erreur à l'interface
                }
            }
        }

        /// <summary>
        /// Modifie une ordonnance en transaction : met à jour l'en-tête, supprime les lignes
        /// existantes de CONTENIR puis ré-insère les nouvelles (stratégie « efface et réécris »).
        /// </summary>
        public void ModifierOrdonnance(Ordonnance ord)
        {
            using (var connexion = DbConnexion.Ouvrir())
            using (var transaction = connexion.BeginTransaction())
            {
                try
                {
                    // 1) Met à jour l'en-tête
                    string sqlEntete =
                        "UPDATE ORDONNANCE " +
                        "SET dateEmission = @date, numMedecin = @numMedecin, numPatient = @numPatient " +
                        "WHERE numOrdonnance = @numOrdonnance";
                    using (var commande = new MySqlCommand(sqlEntete, connexion, transaction))
                    {
                        commande.Parameters.AddWithValue("@date", ord.DateEmission);
                        commande.Parameters.AddWithValue("@numMedecin", ord.Prescripteur.Id);
                        commande.Parameters.AddWithValue("@numPatient", ord.Patient.Id);
                        commande.Parameters.AddWithValue("@numOrdonnance", ord.Id);
                        commande.ExecuteNonQuery();
                    }

                    // 2) Supprime les anciennes lignes
                    string sqlDelete = "DELETE FROM CONTENIR WHERE numOrdonnance = @numOrdonnance";
                    using (var commande = new MySqlCommand(sqlDelete, connexion, transaction))
                    {
                        commande.Parameters.AddWithValue("@numOrdonnance", ord.Id);
                        commande.ExecuteNonQuery();
                    }

                    // 3) Ré-insère les nouvelles lignes
                    string sqlLigne =
                        "INSERT INTO CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours) " +
                        "VALUES (@numOrdonnance, @codeMedicament, @posologie, @dureeJours)";
                    foreach (LignePrescription ligne in ord.Lignes)
                    {
                        using (var commande = new MySqlCommand(sqlLigne, connexion, transaction))
                        {
                            commande.Parameters.AddWithValue("@numOrdonnance", ord.Id);
                            commande.Parameters.AddWithValue("@codeMedicament", ligne.Medicament.Id);
                            commande.Parameters.AddWithValue("@posologie", ligne.Posologie);
                            commande.Parameters.AddWithValue("@dureeJours", ligne.DureeJours);
                            commande.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Supprime une ordonnance. Le ON DELETE CASCADE sur CONTENIR efface ses lignes.
        /// </summary>
        public void SupprimerOrdonnance(int numOrdonnance)
        {
            string sql = "DELETE FROM ORDONNANCE WHERE numOrdonnance = @numOrdonnance";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@numOrdonnance", numOrdonnance);
                commande.ExecuteNonQuery();
            }
        }
    }
}
