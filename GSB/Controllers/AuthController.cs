using System;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;
using GSB.Models;

namespace GSB.Ordonnances.Controllers
{
    public class AuthController
    {
        /// <summary>
        /// Authentifie un médecin par son numéro RPPS et son mot de passe en clair.
        /// On récupère le médecin et son hash par RPPS (jamais de mot de passe
        /// dans la clause WHERE), puis on vérifie le mot de passe côté C#.
        /// Retourne le médecin si OK, null sinon.
        /// </summary>
        public Doctor? Authentifier(string numeroRPPS, string motDePasseClair)
        {
            Doctor? medecin = null;
            string? hashStocke = null;

            string sql = "SELECT numMedecin, nom, prenom, dateNaissance, numeroRPPS, specialite, motDePasse " +
                         "FROM MEDECIN " +
                         "WHERE numeroRPPS = @rpps";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@rpps", numeroRPPS);

                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    if (lecteur.Read())
                    {
                        medecin = new Doctor(
                            "",                                  // email (absent de la table MEDECIN)
                            lecteur.GetString("numeroRPPS"),
                            lecteur.GetString("motDePasse"),
                            lecteur.GetString("nom"),
                            lecteur.GetString("prenom"),
                            lecteur.GetDateTime("dateNaissance")
                        );
                        medecin.Id = lecteur.GetInt32("numMedecin");
                        medecin.Specialite = lecteur.GetString("specialite");
                        hashStocke = medecin.getPassword();
                    }
                }
            }

            if (medecin == null || string.IsNullOrEmpty(hashStocke))
            {
                return null;
            }

            // Cas normal : le mot de passe en base est un hash bcrypt ($2a$, $2b$...).
            if (hashStocke.StartsWith("$2"))
            {
                return BCrypt.Net.BCrypt.Verify(motDePasseClair, hashStocke) ? medecin : null;
            }

            // Compatibilité avec le jeu de test historique (mot de passe encore en clair) :
            // on accepte la connexion mais on migre immédiatement vers un hash bcrypt.
            if (hashStocke == motDePasseClair)
            {
                MettreAJourMotDePasse(medecin.Id, BCrypt.Net.BCrypt.HashPassword(motDePasseClair));
                return medecin;
            }

            return null;
        }

        /// <summary>
        /// Remplace le mot de passe stocké d'un médecin par un nouveau hash.
        /// </summary>
        private void MettreAJourMotDePasse(int numMedecin, string hash)
        {
            string sql = "UPDATE MEDECIN SET motDePasse = @hash WHERE numMedecin = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.Parameters.AddWithValue("@id", numMedecin);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
