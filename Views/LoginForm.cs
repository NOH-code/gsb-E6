using System;
using System.Windows.Forms;
using GSB_Ordonnances.Controllers;
using GSB_Ordonnances.Models;

namespace GSB_Ordonnances.Views
{
    /// <summary>
    /// Fenêtre de connexion du médecin (authentification par RPPS + mot de passe).
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly MedecinController _medecinController;

        /// <summary>Médecin connecté (disponible après une connexion réussie).</summary>
        public Medecin MedecinConnecte { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _medecinController = new MedecinController();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string rpps = txtRPPS.Text.Trim();
            string motDePasse = txtMotDePasse.Text;

            if (string.IsNullOrWhiteSpace(rpps) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Saisis ton numéro RPPS et ton mot de passe.",
                    "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Medecin medecin = _medecinController.Authentifier(rpps, motDePasse);
                if (medecin == null)
                {
                    MessageBox.Show("Numéro RPPS ou mot de passe incorrect.",
                        "Connexion refusée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MedecinConnecte = medecin;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base.\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
