using System;
using System.Windows.Forms;
using GSB.Models;
using GSB.Ordonnances.Controllers;
using MySql.Data.MySqlClient;

namespace GSB
{
    public partial class Sign_up : Form
    {
        // Contrôleur médecin dédié à ce formulaire
        private MedecinController _medecinController;

        public Sign_up()
        {
            InitializeComponent();
            _medecinController = new MedecinController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = textBox_nom.Text.Trim();
            string prenom = textBox_prénom.Text.Trim();
            string rpps = textBox_rpps.Text.Trim();
            string email = textBox_mail.Text.Trim();
            string specialite = textBox_specialite.Text.Trim();
            string mdp = textBox_mdp.Text;
            string confirmation = textBox_mdp2.Text;
            DateTime dateNaissance = dateTimePicker_ddn.Value.Date;

            // Validation de la saisie avant l'écriture en base
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(rpps) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(specialite) ||
                string.IsNullOrEmpty(mdp) || string.IsNullOrEmpty(confirmation))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rpps.Length != 11)
            {
                MessageBox.Show("Le numéro RPPS doit contenir exactement 11 caractères.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!email.Contains('@') || !email.Contains('.'))
            {
                MessageBox.Show("L'adresse email n'est pas valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (mdp != confirmation)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateNaissance >= DateTime.Today)
            {
                MessageBox.Show("La date de naissance doit être dans le passé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Le mot de passe est haché (bcrypt) : jamais stocké en clair.
                    string hash = BCrypt.Net.BCrypt.HashPassword(mdp);

                    Doctor medecin = new Doctor(email, rpps, hash, nom, prenom, dateNaissance);
                    medecin.Specialite = specialite;
                    _medecinController.AjouterMedecin(medecin);

                    string infos = $"Inscription réussie !\n\nNom : {nom}\nPrénom : {prenom}\nRPPS : {rpps}\nSpécialité : {specialite}";
                    MessageBox.Show(infos, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Retour à l'écran de connexion (la Connexion se réaffiche via FormClosed)
                    this.Close();
                }
                catch (MySqlException ex) when (ex.Number == 1062)
                {
                    // Violation d'une contrainte UNIQUE (numeroRPPS ou email)
                    MessageBox.Show("Un médecin avec ce numéro RPPS ou cet email existe déjà.",
                        "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur lors de l'enregistrement :\n" + ex.Message,
                        "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retour à l'écran de connexion (réaffiché via l'événement FormClosed)
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
