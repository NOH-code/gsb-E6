namespace GSB
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // L'application démarre sur l'écran de connexion : un médecin doit
            // s'authentifier avant d'accéder aux patients et aux ordonnances.
            Application.Run(new Connexion());
        }
    }
}
