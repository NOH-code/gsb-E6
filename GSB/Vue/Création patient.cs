using GSB.Models;
using GSB.Ordonnances.Controllers;
using MySql.Data.MySqlClient;
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
    public partial class Création_patient : Form
    {
        // Contrôleur patient dédié à ce formulaire
        private PatientController _patientController;

        public Création_patient()
        {
            InitializeComponent();
            _patientController = new PatientController();

            // Valeurs proposées pour le sexe (la propriété Sexe du modèle est un bool)
            comboBox_sex.Items.Clear();
            comboBox_sex.Items.Add("Homme");
            comboBox_sex.Items.Add("Femme");
            comboBox_sex.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = textBox_nom.Text.Trim();
            string prenom = textBox_prénom.Text.Trim();
            string numeroSecu = textBox_numsécu.Text.Trim();
            DateTime dateNaissance = dateTimePicker_ddn.Value.Date;

            // Validation de la saisie avant l'écriture en base
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
            {
                MessageBox.Show("Le nom et le prénom sont obligatoires.",
                    "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numeroSecu.Length != 13)
            {
                MessageBox.Show("Le numéro de sécurité sociale doit contenir exactement 13 caractères.",
                    "Saisie invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dateNaissance >= DateTime.Today)
            {
                MessageBox.Show("La date de naissance doit être dans le passé.",
                    "Saisie invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construction de l'objet métier complet (poids, taille, sexe et
            // pathologie ne sont pas persistés : la table PATIENT ne les stocke pas).
            Patient patient = new Patient(
                (double)numericUpDown_poids.Value,
                (double)numericUpDown_taille.Value,
                comboBox_sex.SelectedIndex == 0,
                textBox_pathologie.Text.Trim(),
                numeroSecu,
                nom,
                prenom,
                dateNaissance
            );

            try
            {
                int id = _patientController.AjouterPatient(patient);

                MessageBox.Show($"Patient {patient.Presentation()} créé avec le numéro {id}.",
                    "Patient créé", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Permet au formulaire appelant (ShowDialog) de rafraîchir sa liste
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                // Violation de la contrainte UNIQUE sur numeroSecu
                MessageBox.Show("Un patient avec ce numéro de sécurité sociale existe déjà.",
                    "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker_ddn_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
