using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSB
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = textBox_nom.Text;
            string prenom = textBox_prénom.Text;
            string rpps = textBox_rpps.Text;
            string email = textBox_mail.Text;
            string mdp = textBox_mdp.Text;
            string confirmation = textBox_mdp2.Text;

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(rpps) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mdp) || string.IsNullOrEmpty(confirmation))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (mdp != confirmation)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string infos = $"Inscription réussie !\n\nNom : {nom}\nPrénom : {prenom}\nRPPS : {rpps}\nEmail : {email}";
                MessageBox.Show(infos, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connexion pageLogin = new Connexion();
            pageLogin.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}