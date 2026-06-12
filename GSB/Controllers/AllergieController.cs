using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;
using GSB.Models;

namespace GSB.Ordonnances.Controllers
{
    public class AllergieController
    {
        /// <summary>
        /// Recupere toutes les allergies du referentiel (table ALLERGIE),
        /// triees par libelle.
        /// </summary>
        public List<Allergie> ObtenirToutesLesAllergies()
        {
            List<Allergie> allergies = new List<Allergie>();
            string sql = "SELECT codeAllergie, libelle FROM ALLERGIE ORDER BY libelle";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    Allergie a = new Allergie(lecteur.GetString("libelle"));
                    a.Id = lecteur.GetInt32("codeAllergie");
                    allergies.Add(a);
                }
            }
            return allergies;
        }

        /// <summary>
        /// Recupere les libelles d'allergie pour remplir une combo.
        /// </summary>
        public List<string> ObtenirLibelles()
        {
            List<string> libelles = new List<string>();
            foreach (Allergie a in ObtenirToutesLesAllergies())
            {
                libelles.Add(a.Libelle);
            }
            return libelles;
        }

        /// <summary>
        /// Recupere les identifiants (codeAllergie) des allergies d'un patient
        /// via la table de jointure ETRE_ALLERGIQUE.
        /// </summary>
        public List<int> ObtenirCodesAllergiesPatient(int numPatient)
        {
            List<int> codes = new List<int>();
            string sql = "SELECT codeAllergie FROM ETRE_ALLERGIQUE WHERE numPatient = @numPatient";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@numPatient", numPatient);
                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        codes.Add(lecteur.GetInt32("codeAllergie"));
                    }
                }
            }
            return codes;
        }

        /// <summary>
        /// Definit la liste des allergies d'un patient : strategie "efface et
        /// reecris" dans ETRE_ALLERGIQUE, en TRANSACTION (tout ou rien).
        /// </summary>
        public void DefinirAllergiesPatient(int numPatient, List<int> codesAllergie)
        {
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlTransaction transaction = cnx.BeginTransaction())
            {
                try
                {
                    // 1) On efface les associations existantes du patient
                    using (MySqlCommand suppr = new MySqlCommand(
                        "DELETE FROM ETRE_ALLERGIQUE WHERE numPatient = @numPatient", cnx, transaction))
                    {
                        suppr.Parameters.AddWithValue("@numPatient", numPatient);
                        suppr.ExecuteNonQuery();
                    }

                    // 2) On reinsere les allergies cochees
                    foreach (int codeAllergie in codesAllergie)
                    {
                        using (MySqlCommand ins = new MySqlCommand(
                            "INSERT INTO ETRE_ALLERGIQUE (numPatient, codeAllergie) VALUES (@numPatient, @codeAllergie)",
                            cnx, transaction))
                        {
                            ins.Parameters.AddWithValue("@numPatient", numPatient);
                            ins.Parameters.AddWithValue("@codeAllergie", codeAllergie);
                            ins.ExecuteNonQuery();
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
    }
}
