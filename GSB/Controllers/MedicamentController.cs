using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;
using GSB.Models;

namespace GSB.Ordonnances.Controllers
{
    public class MedicamentController
    {
        /// <summary>
        /// Recupere tous les medicaments de la base, tries par nom.
        /// </summary>
        public List<Medoc> ObtenirTousLesMedicaments()
        {
            List<Medoc> medicaments = new List<Medoc>();
            string sql = "SELECT codeMedicament, nom, dosage " +
                         "FROM MEDICAMENT " +
                         "ORDER BY nom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    Medoc m = new Medoc(
                        lecteur.GetString("nom"),
                        lecteur.GetString("dosage")
                    );
                    m.Id = lecteur.GetInt32("codeMedicament");
                    medicaments.Add(m);
                }
            }
            return medicaments;
        }
    }
}
