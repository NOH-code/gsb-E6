using MySql.Data.MySqlClient;

namespace GSB_Ordonnances.DataAccess
{
    /// <summary>
    /// Couche d'accès aux données : seul endroit du projet où la chaîne de connexion apparaît.
    /// L'appelant gère la fermeture de la connexion via un bloc using.
    /// </summary>
    public static class DbConnexion
    {
        /// <summary>Chaîne de connexion vers la base MySQL (Docker).</summary>
        private const string ChaineConnexion =
            "Server=localhost;Port=3306;Database=gsb_ordonnances;Uid=gsb;Pwd=gsbpass;";

        /// <summary>
        /// Crée une MySqlConnection avec la chaîne ci-dessus, l'ouvre et la retourne.
        /// </summary>
        public static MySqlConnection Ouvrir()
        {
            MySqlConnection connexion = new MySqlConnection(ChaineConnexion);
            connexion.Open();
            return connexion;
        }
    }
}
