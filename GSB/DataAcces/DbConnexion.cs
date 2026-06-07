using MySql.Data.MySqlClient;

namespace GSB.Ordonnances.DataAccess
{
    /// <summary>
    /// Point d'entrée unique pour obtenir une connexion à la base.
    /// </summary>
    public static class DbConnexion
    {
        // Chaîne de connexion vers le conteneur Docker MySQL.
        // (Voir le PDF "MLD et MySQL" pour la mise en place.)
        private const string CHAINE_CONNEXION =
        "Server=localhost;" +
        "Port=3306;" +
        "Database=gsb_ordonnances;" +
        "Uid=gsb;" +
        "Pwd=gsbpass;";
        /// <summary>
        /// Ouvre une nouvelle connexion à la base et la retourne.
        /// L'appelant est responsable de la fermer (utilisez "using").
        /// </summary>
        public static MySqlConnection Ouvrir()
        {
            MySqlConnection cnx = new MySqlConnection(CHAINE_CONNEXION);
            cnx.Open();
            return cnx;
        }
    }
}

