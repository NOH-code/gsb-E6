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
        // Contrôleurs dédiés à ce formulaire
        private PatientController _patientController;
        private AllergieController _allergieController;

        public Création_patient()
        {
            InitializeComponent();
            _patientController = new PatientController();
            _allergieController = new AllergieController();

            // Valeurs proposées pour le sexe (la propriété Sexe du modèle est un bool)
            comboBox_sex.Items.Clear();
            comboBox_sex.Items.Add("Homme");
            comboBox_sex.Items.Add("Femme");
            comboBox_sex.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sex.SelectedIndex = 0;

            // Poids et taille acceptent une décimale (ex : 72,5 kg / 178,0 cm)
            numericUpDown_poids.DecimalPlaces = 1;
            numericUpDown_poids.Maximum = 400;
            numericUpDown_taille.DecimalPlaces = 1;
            numericUpDown_taille.Maximum = 280;

            ChargerAllergies();
        }

        /// <summary>
        /// Remplit la liste à cocher avec le référentiel des allergies.
        /// </summary>
        private void ChargerAllergies()
        {
            try
            {
                clbAllergies.Items.Clear();
                foreach (Allergie a in _allergieController.ObtenirToutesLesAllergies())
                {
                    clbAllergies.Items.Add(a); // affichage via Allergie.ToString()
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Impossible de charger les allergies :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            // pathologie sont désormais persistés en base).
            Patient patient = new Patient(
                (double)numericUpDown_poids.Value,
                (double)numericUpDown_taille.Value,
                comboBox_sex.SelectedIndex == 0,        // index 0 = Homme = true
                textBox_pathologie.Text.Trim(),
                numeroSecu,
                nom,
                prenom,
                dateNaissance
            );

            try
            {
                int id = _patientController.AjouterPatient(patient);

                // Enregistrement des allergies cochées (table ETRE_ALLERGIQUE)
                List<int> codesAllergie = new List<int>();
                foreach (object item in clbAllergies.CheckedItems)
                {
                    if (item is Allergie a)
                    {
                        codesAllergie.Add(a.Id);
                    }
                }
                if (codesAllergie.Count > 0)
                {
                    _allergieController.DefinirAllergiesPatient(id, codesAllergie);
                }

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
    }
}
