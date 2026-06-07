using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;
using GSB.Models;

namespace GSB.Ordonnances.Controllers
{
    public class PatientController
    {
        /// <summary>
        /// Recupere tous les patients de la base, tries par nom puis prenom.
        /// </summary>
        public List<Patient> ObtenirTousLesPatients()
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu " +
                         "FROM PATIENT " +
                         "ORDER BY nom, prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    Patient p = new Patient(
                        lecteur.GetString("nom"),
                        lecteur.GetString("prenom"),
                        lecteur.GetDateTime("dateNaissance"),
                        lecteur.GetString("numeroSecu")
                    );
                    p.Id = lecteur.GetInt32("numPatient");
                    patients.Add(p);
                }
            }
            return patients;
        }

        /// <summary>
        /// VERSION SECURISEE : Requete parametree par nom.
        /// La saisie utilisateur ne touche jamais le texte de la requete.
        /// </summary>
        public List<Patient> ObtenirPatientsParNom(string motCle)
        {
            List<Patient> liste = new List<Patient>();

            // Utilisation du parametre nomme @motCle
            string requete = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu " +
                             "FROM PATIENT " +
                             "WHERE nom LIKE @motCle " +
                             "ORDER BY nom, prenom";

            // CORRECTION 1 : Utilisation directe de votre utilitaire DbConnexion
            using (MySqlConnection connexion = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(requete, connexion))
            {
                // Liaison securisee du parametre utilisateur
                cmd.Parameters.AddWithValue("@motCle", motCle + "%");

                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        // CORRECTION 2 : Utilisation du constructeur existant
                        Patient p = new Patient(
                            lecteur.GetString("nom"),
                            lecteur.GetString("prenom"),
                            lecteur.GetDateTime("dateNaissance"),
                            lecteur.GetString("numeroSecu")
                        );

                        // Assignation de la propriete C# pour l'ID
                        p.Id = lecteur.GetInt32("numPatient");

                        liste.Add(p);
                    }
                }
            }
            return liste;
        }
    }
}