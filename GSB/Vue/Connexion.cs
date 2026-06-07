using System;
using System.Windows.Forms;

namespace GSB
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recherche_patient pageCréation = new Recherche_patient();
            pageCréation.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Redirection vers la page de création de patient
            Sign_up pageCréation = new Sign_up();
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