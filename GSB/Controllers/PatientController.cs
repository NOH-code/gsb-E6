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

        /// <summary>
        /// INSERT parametre d'un patient, puis recuperation de l'id genere
        /// via LAST_INSERT_ID() (avec ExecuteScalar). Retourne l'id.
        /// </summary>
        public int AjouterPatient(Patient p)
        {
            string sql = "INSERT INTO PATIENT (nom, prenom, dateNaissance, numeroSecu) " +
                         "VALUES (@nom, @prenom, @dateNaissance, @numeroSecu); " +
                         "SELECT LAST_INSERT_ID();";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@nom", p.Name);
                cmd.Parameters.AddWithValue("@prenom", p.Firstname);
                cmd.Parameters.AddWithValue("@dateNaissance", p.Birthdate);
                cmd.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                p.Id = id;
                return id;
            }
        }

        /// <summary>
        /// UPDATE parametre. La clause WHERE numPatient = @id est vitale :
        /// sans elle, tous les patients de la base seraient ecrases.
        /// </summary>
        public void ModifierPatient(Patient p)
        {
            string sql = "UPDATE PATIENT " +
                         "SET nom = @nom, prenom = @prenom, " +
                         "    dateNaissance = @dateNaissance, numeroSecu = @numeroSecu " +
                         "WHERE numPatient = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@nom", p.Name);
                cmd.Parameters.AddWithValue("@prenom", p.Firstname);
                cmd.Parameters.AddWithValue("@dateNaissance", p.Birthdate);
                cmd.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);
                cmd.Parameters.AddWithValue("@id", p.Id);

                int lignesAffectees = cmd.ExecuteNonQuery();
                if (lignesAffectees != 1)
                {
                    throw new InvalidOperationException(
                        $"La modification du patient {p.Id} a affecté {lignesAffectees} ligne(s) au lieu de 1.");
                }
            }
        }

        /// <summary>
        /// DELETE parametre par id. Si le patient a des ordonnances, MySQL refuse
        /// (ON DELETE RESTRICT, erreur 1451) : a intercepter cote interface.
        /// </summary>
        public void SupprimerPatient(int id)
        {
            string sql = "DELETE FROM PATIENT WHERE numPatient = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}