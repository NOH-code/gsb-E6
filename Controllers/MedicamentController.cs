using System.Collections.Generic;
using GSB_Ordonnances.DataAccess;
using GSB_Ordonnances.Models;
using MySql.Data.MySqlClient;

namespace GSB_Ordonnances.Controllers
{
    /// <summary>
    /// Contrôleur de la table MEDICAMENT.
    /// </summary>
    public class MedicamentController
    {
        /// <summary>
        /// Retourne tous les médicaments, triés par nom.
        /// </summary>
        public List<Medicament> ObtenirTousLesMedicaments()
        {
            List<Medicament> liste = new List<Medicament>();
            string sql = "SELECT codeMedicament, nom, dosage FROM MEDICAMENT ORDER BY nom";

            using (var connexion = DbConnexion.Ouvrir())
            using (var commande = new MySqlCommand(sql, connexion))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    Medicament medicament = new Medicament(
                        reader.GetString("nom"),
                        reader.GetString("dosage"));
                    medicament.Id = reader.GetInt32("codeMedicament");
                    liste.Add(medicament);
                }
            }
            return liste;
        }
    }
}
