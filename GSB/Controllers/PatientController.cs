using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;
using GSB.Models;

namespace GSB.Ordonnances.Controllers
{
    public class PatientController
    {
        // Liste des colonnes lues partout : factorisée pour rester cohérente.
        private const string COLONNES =
            "numPatient, nom, prenom, dateNaissance, numeroSecu, poids, taille, sexe, pathologie";

        /// <summary>
        /// Construit un Patient à partir de la ligne courante du lecteur.
        /// Les colonnes médicales (poids, taille, sexe, pathologie) sont
        /// nullables en base : on gère les valeurs NULL.
        /// </summary>
        private static Patient MapPatient(MySqlDataReader lecteur)
        {
            Patient p = new Patient(
                lecteur.GetString("nom"),
                lecteur.GetString("prenom"),
                lecteur.GetDateTime("dateNaissance"),
                lecteur.GetString("numeroSecu")
            );
            p.Id = lecteur.GetInt32("numPatient");
            p.Poids = lecteur.IsDBNull(lecteur.GetOrdinal("poids")) ? 0 : (double)lecteur.GetDecimal("poids");
            p.Taille = lecteur.IsDBNull(lecteur.GetOrdinal("taille")) ? 0 : (double)lecteur.GetDecimal("taille");
            p.Sexe = !lecteur.IsDBNull(lecteur.GetOrdinal("sexe")) && lecteur.GetBoolean("sexe");
            p.Pathologie = lecteur.IsDBNull(lecteur.GetOrdinal("pathologie")) ? "" : lecteur.GetString("pathologie");
            return p;
        }

        /// <summary>
        /// Ajoute les paramètres communs aux requêtes d'écriture (INSERT/UPDATE).
        /// </summary>
        private static void AjouterParametresPatient(MySqlCommand cmd, Patient p)
        {
            cmd.Parameters.AddWithValue("@nom", p.Name);
            cmd.Parameters.AddWithValue("@prenom", p.Firstname);
            cmd.Parameters.AddWithValue("@dateNaissance", p.Birthdate);
            cmd.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);
            cmd.Parameters.AddWithValue("@poids", p.Poids);
            cmd.Parameters.AddWithValue("@taille", p.Taille);
            cmd.Parameters.AddWithValue("@sexe", p.Sexe);
            cmd.Parameters.AddWithValue("@pathologie", p.Pathologie ?? "");
        }

        /// <summary>
        /// Recupere tous les patients de la base, tries par nom puis prenom.
        /// </summary>
        public List<Patient> ObtenirTousLesPatients()
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT " + COLONNES + " FROM PATIENT ORDER BY nom, prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    patients.Add(MapPatient(lecteur));
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
            string requete = "SELECT " + COLONNES + " FROM PATIENT " +
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
                        liste.Add(MapPatient(lecteur));
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
            string sql = "INSERT INTO PATIENT (nom, prenom, dateNaissance, numeroSecu, poids, taille, sexe, pathologie) " +
                         "VALUES (@nom, @prenom, @dateNaissance, @numeroSecu, @poids, @taille, @sexe, @pathologie); " +
                         "SELECT LAST_INSERT_ID();";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                AjouterParametresPatient(cmd, p);
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
                         "    dateNaissance = @dateNaissance, numeroSecu = @numeroSecu, " +
                         "    poids = @poids, taille = @taille, sexe = @sexe, pathologie = @pathologie " +
                         "WHERE numPatient = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                AjouterParametresPatient(cmd, p);
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
