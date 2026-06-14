using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;
using GSB.Models;

namespace GSB.Ordonnances.Controllers
{
    public class OrdonnanceController
    {
        /// <summary>
        /// Enregistre une ordonnance complete (en-tete + lignes) en TRANSACTION :
        /// INSERT dans ORDONNANCE (recupere le numero via LAST_INSERT_ID),
        /// puis un INSERT dans CONTENIR par ligne de prescription.
        /// Commit si tout passe, Rollback + throw sinon (atomicite).
        /// Retourne le numero d'ordonnance genere.
        /// </summary>
        public int AjouterOrdonnance(Ordonnance ord)
        {
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlTransaction transaction = cnx.BeginTransaction())
            {
                try
                {
                    // 1) L'en-tete de l'ordonnance
                    string sqlOrdonnance =
                        "INSERT INTO ORDONNANCE (dateEmission, numMedecin, numPatient) " +
                        "VALUES (@date, @numMedecin, @numPatient); " +
                        "SELECT LAST_INSERT_ID();";

                    int numOrdonnance;
                    using (MySqlCommand cmd = new MySqlCommand(sqlOrdonnance, cnx, transaction))
                    {
                        cmd.Parameters.AddWithValue("@date", ord.getDateOrdonnance());
                        cmd.Parameters.AddWithValue("@numMedecin", ord.getMedecin().Id);
                        cmd.Parameters.AddWithValue("@numPatient", ord.getPatient().Id);
                        numOrdonnance = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2) Une ligne CONTENIR par medicament prescrit
                    string sqlLigne =
                        "INSERT INTO CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours) " +
                        "VALUES (@numOrdonnance, @codeMedicament, @posologie, @dureeJours)";

                    foreach (Prescription ligne in ord.getPrescriptions())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sqlLigne, cnx, transaction))
                        {
                            cmd.Parameters.AddWithValue("@numOrdonnance", numOrdonnance);
                            cmd.Parameters.AddWithValue("@codeMedicament", ligne.getMedicament().Id);
                            cmd.Parameters.AddWithValue("@posologie", ligne.getName());
                            cmd.Parameters.AddWithValue("@dureeJours", (int)ligne.getDurée());
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();   // tout passe → on valide
                    ord.Id = numOrdonnance;
                    return numOrdonnance;
                }
                catch
                {
                    transaction.Rollback(); // un echec → on annule tout
                    throw;                  // on propage l'erreur a l'interface
                }
            }
        }

        /// <summary>
        /// Supprime une ordonnance par son numero. Les lignes de CONTENIR sont
        /// supprimees automatiquement (ON DELETE CASCADE sur la FK ordonnance).
        /// </summary>
        public void SupprimerOrdonnance(int numOrdonnance)
        {
            string sql = "DELETE FROM ORDONNANCE WHERE numOrdonnance = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", numOrdonnance);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Recupere les ordonnances d'un patient (chargement leger, sans les lignes),
        /// avec le nom du medecin prescripteur, triees de la plus recente a la plus ancienne.
        /// </summary>
        public List<Ordonnance> ObtenirOrdonnancesParPatient(int numPatient)
        {
            List<Ordonnance> ordonnances = new List<Ordonnance>();
            string sql = "SELECT o.numOrdonnance, o.dateEmission, " +
                         "       m.numMedecin, m.nom, m.prenom, m.specialite, m.numeroRPPS " +
                         "FROM ORDONNANCE o " +
                         "JOIN MEDECIN m ON m.numMedecin = o.numMedecin " +
                         "WHERE o.numPatient = @numPatient " +
                         "ORDER BY o.dateEmission DESC";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@numPatient", numPatient);

                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        Doctor medecin = new Doctor(
                            "",
                            lecteur.GetString("numeroRPPS"),
                            "",
                            lecteur.GetString("nom"),
                            lecteur.GetString("prenom"),
                            DateTime.MinValue
                        );
                        medecin.Id = lecteur.GetInt32("numMedecin");
                        medecin.Specialite = lecteur.GetString("specialite");

                        Ordonnance ord = new Ordonnance();
                        ord.Id = lecteur.GetInt32("numOrdonnance");
                        ord.setDateOrdonnance(lecteur.GetDateTime("dateEmission"));
                        ord.setMedecin(medecin);
                        ordonnances.Add(ord);
                    }
                }
            }
            return ordonnances;
        }

        /// <summary>
        /// Recupere les lignes (medicament + posologie + duree) d'une ordonnance
        /// via un JOIN CONTENIR / MEDICAMENT (chargement complet du detail).
        /// </summary>
        public List<Prescription> ObtenirLignesOrdonnance(int numOrdonnance)
        {
            List<Prescription> lignes = new List<Prescription>();
            string sql = "SELECT c.posologie, c.dureeJours, " +
                         "       md.codeMedicament, md.nom, md.dosage " +
                         "FROM CONTENIR c " +
                         "JOIN MEDICAMENT md ON md.codeMedicament = c.codeMedicament " +
                         "WHERE c.numOrdonnance = @numOrdonnance";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@numOrdonnance", numOrdonnance);

                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        Medoc medicament = new Medoc(
                            lecteur.GetString("nom"),
                            lecteur.GetString("dosage")
                        );
                        medicament.Id = lecteur.GetInt32("codeMedicament");

                        lignes.Add(new Prescription(
                            medicament,
                            lecteur.GetString("posologie"),
                            lecteur.GetInt32("dureeJours")
                        ));
                    }
                }
            }
            return lignes;
        }
    }
}
