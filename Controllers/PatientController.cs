using System;
using System.Collections.Generic;
using GSB_Ordonnances.DataAccess;
using GSB_Ordonnances.Models;
using MySql.Data.MySqlClient;

namespace GSB_Ordonnances.Controllers
{
    /// <summary>
    /// Contrôleur de la table PATIENT : lecture, recherche (paramétrée) et CRUD complet.
    /// </summary>
    public class PatientController
    {
        // --- Lecture ---

        /// <summary>
        /// Retourne tous les patients, triés par nom puis prénom.
        /// </summary>
        public List<Patient> ObtenirTousLesPatients()
        {
            List<Patient> liste = new List<Patient>();
            string sql =
                "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu " +
                "FROM PATIENT ORDER BY nom, prenom";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    liste.Add(MapperPatient(reader));
                }
            }
            return liste;
        }

        /// <summary>
        /// Retourne un patient par son identifiant, ou null s'il n'existe pas.
        /// </summary>
        public Patient ObtenirParId(int id)
        {
            string sql =
                "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu " +
                "FROM PATIENT WHERE numPatient = @id";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@id", id);
                using (var reader = commande.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapperPatient(reader);
                    }
                }
            }
            return null;
        }

        // --- Recherche ---

        /// <summary>
        /// ⚠ CONTRE-EXEMPLE PÉDAGOGIQUE — NE JAMAIS UTILISER EN PRODUCTION.
        /// Construit la requête par concaténation de la saisie utilisateur : vulnérable
        /// à l'injection SQL (OWASP A03). L'underscore dans le nom signale ce danger.
        /// Conservée comme contre-exemple ; aucun bouton ne doit l'appeler.
        /// </summary>
        public List<Patient> RechercherParNom_Vulnerable(string motCle)
        {
            List<Patient> liste = new List<Patient>();
            string sql =
                "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu " +
                "FROM PATIENT WHERE nom LIKE '%" + motCle + "%' ORDER BY nom, prenom";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    liste.Add(MapperPatient(reader));
                }
            }
            return liste;
        }

        /// <summary>
        /// Version saine : recherche par nom via un paramètre @motCle (pas de concaténation).
        /// Le moteur traite la saisie comme une donnée, jamais comme du code.
        /// </summary>
        public List<Patient> RechercherParNom(string motCle)
        {
            List<Patient> liste = new List<Patient>();
            string sql =
                "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu " +
                "FROM PATIENT WHERE nom LIKE @motCle ORDER BY nom, prenom";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@motCle", "%" + motCle + "%");
                using (var reader = commande.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(MapperPatient(reader));
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Recherche croisée nom + allergie : JOIN PATIENT / ETRE_ALLERGIQUE / ALLERGIE,
        /// deux paramètres. DISTINCT évite les doublons si plusieurs allergies correspondent.
        /// </summary>
        public List<Patient> RechercherParNomEtAllergie(string motCle, string libelleAllergie)
        {
            List<Patient> liste = new List<Patient>();
            string sql =
                "SELECT DISTINCT p.numPatient, p.nom, p.prenom, p.dateNaissance, p.numeroSecu " +
                "FROM PATIENT p " +
                "JOIN ETRE_ALLERGIQUE ea ON ea.numPatient = p.numPatient " +
                "JOIN ALLERGIE a ON a.codeAllergie = ea.codeAllergie " +
                "WHERE p.nom LIKE @motCle AND a.libelle = @libelle " +
                "ORDER BY p.nom, p.prenom";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@motCle", "%" + motCle + "%");
                commande.Parameters.AddWithValue("@libelle", libelleAllergie);
                using (var reader = commande.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(MapperPatient(reader));
                    }
                }
            }
            return liste;
        }

        // --- Écriture (CRUD) ---

        /// <summary>
        /// INSERT paramétré, puis récupère l'id généré via LAST_INSERT_ID(). Retourne l'id.
        /// La colonne numPatient n'est pas listée : MySQL la génère (AUTO_INCREMENT).
        /// </summary>
        public int AjouterPatient(Patient p)
        {
            string sql =
                "INSERT INTO PATIENT (nom, prenom, dateNaissance, numeroSecu) " +
                "VALUES (@nom, @prenom, @dateNaissance, @numeroSecu); " +
                "SELECT LAST_INSERT_ID();";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@nom", p.Nom);
                commande.Parameters.AddWithValue("@prenom", p.Prenom);
                commande.Parameters.AddWithValue("@dateNaissance", p.DateNaissance);
                commande.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);

                object resultat = commande.ExecuteScalar();
                int id = Convert.ToInt32(resultat);
                p.Id = id;
                return id;
            }
        }

        /// <summary>
        /// UPDATE paramétré AVEC la clause WHERE numPatient = @id.
        /// Sans le WHERE, tous les patients prendraient les mêmes valeurs.
        /// </summary>
        public void ModifierPatient(Patient p)
        {
            string sql =
                "UPDATE PATIENT " +
                "SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, numeroSecu = @numeroSecu " +
                "WHERE numPatient = @id";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@nom", p.Nom);
                commande.Parameters.AddWithValue("@prenom", p.Prenom);
                commande.Parameters.AddWithValue("@dateNaissance", p.DateNaissance);
                commande.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);
                commande.Parameters.AddWithValue("@id", p.Id);

                commande.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// DELETE paramétré par id. Lève une MySqlException (code 1451) si le patient a des
        /// ordonnances (ON DELETE RESTRICT) : à intercepter côté formulaire.
        /// </summary>
        public void SupprimerPatient(int id)
        {
            string sql = "DELETE FROM PATIENT WHERE numPatient = @id";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@id", id);
                commande.ExecuteNonQuery();
            }
        }

        // --- Mapping privé ---

        /// <summary>Construit un Patient à partir de la ligne courante du reader.</summary>
        private Patient MapperPatient(MySqlDataReader reader)
        {
            Patient patient = new Patient(
                reader.GetString("nom"),
                reader.GetString("prenom"),
                reader.GetDateTime("dateNaissance"),
                reader.GetString("numeroSecu"));
            patient.Id = reader.GetInt32("numPatient");
            return patient;
        }
    }
}
