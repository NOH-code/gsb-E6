using System;
using System.Windows.Forms;
using GSB_Ordonnances.Views;

namespace GSB_Ordonnances
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// Affiche d'abord la fenêtre de connexion ; si l'authentification réussit,
        /// lance la liste des patients.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Pour développer sans passer par le login, commente le bloc ci-dessous et
            // décommente la ligne suivante :
            // Application.Run(new PatientListForm());

            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new PatientListForm());
            }
        }
    }
}
