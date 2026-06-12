using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;
using GSB.Models;

namespace GSB.Ordonnances.Controllers
{
    public class MedecinController
    {
        /// <summary>
        /// Recupere tous les medecins de la base, tries par nom puis prenom.
        /// </summary>
        public List<Doctor> ObtenirTousLesMedecins()
        {
            List<Doctor> medecins = new List<Doctor>();
            string sql = "SELECT numMedecin, nom, prenom, email, dateNaissance, numeroRPPS, specialite " +
                         "FROM MEDECIN " +
                         "ORDER BY nom, prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    Doctor m = new Doctor(
                        lecteur.IsDBNull(lecteur.GetOrdinal("email")) ? "" : lecteur.GetString("email"),
                        lecteur.GetString("numeroRPPS"),
                        "",                                  // le hash ne sort jamais de l'authentification
                        lecteur.GetString("nom"),
                        lecteur.GetString("prenom"),
                        lecteur.GetDateTime("dateNaissance")
                    );
                    m.Id = lecteur.GetInt32("numMedecin");
                    m.Specialite = lecteur.GetString("specialite");
                    medecins.Add(m);
                }
            }
            return medecins;
        }

        /// <summary>
        /// INSERT parametre d'un medecin. Le mot de passe recu est deja un hash bcrypt.
        /// Retourne l'identifiant genere (LAST_INSERT_ID).
        /// </summary>
        public int AjouterMedecin(Doctor medecin)
        {
            string sql = "INSERT INTO MEDECIN (nom, prenom, email, dateNaissance, numeroRPPS, specialite, motDePasse) " +
                         "VALUES (@nom, @prenom, @email, @dateNaissance, @numeroRPPS, @specialite, @motDePasse); " +
                         "SELECT LAST_INSERT_ID();";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@nom", medecin.Name);
                cmd.Parameters.AddWithValue("@prenom", medecin.Firstname);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(medecin.Email) ? (object)DBNull.Value : medecin.Email);
                cmd.Parameters.AddWithValue("@dateNaissance", medecin.Birthdate);
                cmd.Parameters.AddWithValue("@numeroRPPS", medecin.getRpps());
                cmd.Parameters.AddWithValue("@specialite", medecin.Specialite);
                cmd.Parameters.AddWithValue("@motDePasse", medecin.getPassword());

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                medecin.Id = id;
                return id;
            }
        }
    }
}
