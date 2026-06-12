using System;
using System.Windows.Forms;
using GSB.Models;
using GSB.Ordonnances.Controllers;
using MySql.Data.MySqlClient;

namespace GSB
{
    public partial class Connexion : Form
    {
        // Contrôleur d'authentification dédié à ce formulaire
        private AuthController _authController;

        public Connexion()
        {
            InitializeComponent();
            _authController = new AuthController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rpps = textBox_id.Text.Trim();
            string motDePasse = textBox_mdp.Text;

            // Validation de la saisie avant tout appel à la base
            if (string.IsNullOrEmpty(rpps) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez saisir votre identifiant (RPPS) et votre mot de passe.",
                    "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Doctor? medecin = _authController.Authentifier(rpps, motDePasse);

                if (medecin == null)
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect.",
                        "Échec de la connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // On garde le médecin connecté en session : il sera le
                // prescripteur des ordonnances créées ensuite.
                Session.MedecinConnecte = medecin;

                Recherche_patient pageCréation = new Recherche_patient();
                // Quand la fenêtre principale se ferme, on ferme aussi celle-ci
                // (sinon l'application resterait ouverte de façon invisible).
                pageCréation.FormClosed += (s, args) => this.Close();
                pageCréation.Show();
                this.Hide();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Redirection vers la page de création de compte médecin
            Sign_up pageCréation = new Sign_up();
            pageCréation.FormClosed += (s, args) => this.Show();
            pageCréation.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}
