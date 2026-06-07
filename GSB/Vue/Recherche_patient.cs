using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    public partial class Recherche_patient : Form
    {
        public Recherche_patient()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Création_patient pageCréationPatient = new Création_patient();
            pageCréationPatient.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Créateur_d_ordo pageCréationOrdo = new Créateur_d_ordo();
            pageCréationOrdo.Show();
            this.Hide();
        }

        private void comboBoxPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
