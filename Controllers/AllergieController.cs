using System.Collections.Generic;
using GSB_Ordonnances.DataAccess;
using GSB_Ordonnances.Models;
using MySql.Data.MySqlClient;

namespace GSB_Ordonnances.Controllers
{
    /// <summary>
    /// Contrôleur de la table ALLERGIE et de la table de jointure ETRE_ALLERGIQUE.
    /// </summary>
    public class AllergieController
    {
        /// <summary>
        /// Retourne toutes les allergies, triées par libellé.
        /// </summary>
        public List<Allergie> ObtenirToutesLesAllergies()
        {
            List<Allergie> liste = new List<Allergie>();
            string sql = "SELECT codeAllergie, libelle FROM ALLERGIE ORDER BY libelle";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    Allergie allergie = new Allergie(reader.GetString("libelle"));
                    allergie.Id = reader.GetInt32("codeAllergie");
                    liste.Add(allergie);
                }
            }
            return liste;
        }

        /// <summary>
        /// Retourne uniquement les libellés d'allergie (pour remplir une ComboBox de filtre).
        /// </summary>
        public List<string> ObtenirLibelles()
        {
            List<string> liste = new List<string>();
            string sql = "SELECT libelle FROM ALLERGIE ORDER BY libelle";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    liste.Add(reader.GetString("libelle"));
                }
            }
            return liste;
        }

        /// <summary>
        /// Retourne les allergies d'un patient donné (JOIN ETRE_ALLERGIQUE / ALLERGIE).
        /// </summary>
        public List<Allergie> ObtenirAllergiesParPatient(int numPatient)
        {
            List<Allergie> liste = new List<Allergie>();
            string sql =
                "SELECT a.codeAllergie, a.libelle " +
                "FROM ALLERGIE a " +
                "JOIN ETRE_ALLERGIQUE ea ON ea.codeAllergie = a.codeAllergie " +
                "WHERE ea.numPatient = @numPatient " +
                "ORDER BY a.libelle";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@numPatient", numPatient);
                using (var reader = commande.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Allergie allergie = new Allergie(reader.GetString("libelle"));
                        allergie.Id = reader.GetInt32("codeAllergie");
                        liste.Add(allergie);
                    }
                }
            }
            return liste;
        }
    }
}
