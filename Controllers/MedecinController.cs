using System;
using System.Collections.Generic;
using GSB_Ordonnances.DataAccess;
using GSB_Ordonnances.Models;
using MySql.Data.MySqlClient;

namespace GSB_Ordonnances.Controllers
{
    /// <summary>
    /// Contrôleur de la table MEDECIN : lecture de la liste et authentification.
    /// </summary>
    public class MedecinController
    {
        /// <summary>
        /// Retourne tous les médecins, triés par nom puis prénom.
        /// </summary>
        public List<Medecin> ObtenirTousLesMedecins()
        {
            List<Medecin> liste = new List<Medecin>();
            string sql =
                "SELECT numMedecin, nom, prenom, dateNaissance, numeroRPPS, specialite, motDePasse " +
                "FROM MEDECIN ORDER BY nom, prenom";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    Medecin medecin = new Medecin(
                        reader.GetString("nom"),
                        reader.GetString("prenom"),
                        reader.GetDateTime("dateNaissance"),
                        reader.GetString("numeroRPPS"),
                        reader.GetString("specialite"),
                        reader.GetString("motDePasse"));
                    medecin.Id = reader.GetInt32("numMedecin");
                    liste.Add(medecin);
                }
            }
            return liste;
        }

        /// <summary>
        /// Authentifie un médecin par son numéro RPPS, puis vérifie le mot de passe.
        /// On récupère TOUJOURS le médecin par RPPS (jamais le mot de passe dans le WHERE),
        /// puis on compare le mot de passe côté C#. Retourne le médecin si OK, null sinon.
        /// </summary>
        public Medecin Authentifier(string numeroRPPS, string motDePasseClair)
        {
            string sql =
                "SELECT numMedecin, nom, prenom, dateNaissance, numeroRPPS, specialite, motDePasse " +
                "FROM MEDECIN WHERE numeroRPPS = @rpps";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@rpps", numeroRPPS);
                using (var reader = commande.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null; // aucun médecin avec ce RPPS
                    }

                    string motDePasseStocke = reader.GetString("motDePasse");

                    // Le jeu de test stocke le mot de passe en clair ("secret"). En production,
                    // on stockerait un hash bcrypt et on utiliserait BCrypt.Verify(motDePasseClair,
                    // motDePasseStocke) après avoir installé le paquet BCrypt.Net-Next.
                    if (motDePasseClair != motDePasseStocke)
                    {
                        return null; // mauvais mot de passe
                    }

                    Medecin medecin = new Medecin(
                        reader.GetString("nom"),
                        reader.GetString("prenom"),
                        reader.GetDateTime("dateNaissance"),
                        reader.GetString("numeroRPPS"),
                        reader.GetString("specialite"),
                        motDePasseStocke);
                    medecin.Id = reader.GetInt32("numMedecin");
                    return medecin;
                }
            }
        }
    }
}
