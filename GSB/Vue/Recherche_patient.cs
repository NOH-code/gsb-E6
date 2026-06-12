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
    public partial class Recherche_patient : Form
    {
        // Contrôleurs dédiés à ce formulaire
        private PatientController _patientController;
        private OrdonnanceController _ordonnanceController;

        public Recherche_patient()
        {
            InitializeComponent();
            _patientController = new PatientController();
            _ordonnanceController = new OrdonnanceController();

            // Câblage des événements non générés par le Designer
            this.Load += Recherche_patient_Load;
            buttonModifierPatient.Click += buttonModifierPatient_Click;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            // La grille d'historique est en lecture seule : on n'édite pas dans les cellules
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Recherche_patient_Load(object? sender, EventArgs e)
        {
            ChargerPatients();
        }

        /// <summary>
        /// Remplit la liste déroulante avec tous les patients de la base.
        /// </summary>
        private void ChargerPatients()
        {
            try
            {
                List<Patient> patients = _patientController.ObtenirTousLesPatients();

                comboBoxPatient.DataSource = patients;
                comboBoxPatient.SelectedIndex = patients.Count > 0 ? 0 : -1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Impossible de charger les patients :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Retourne le patient actuellement sélectionné dans la liste (null sinon).
        /// </summary>
        private Patient? PatientSelectionne()
        {
            return comboBoxPatient.SelectedItem as Patient;
        }

        /// <summary>
        /// Remplit la fiche avec les informations du patient sélectionné.
        /// Taille, poids, sexe et pathologie ne sont pas stockés dans la table
        /// PATIENT : ces champs restent libres pour la consultation.
        /// </summary>
        private void AfficherFichePatient(Patient patient)
        {
            textBoxName.Text = patient.Name;
            textBoxFirstname.Text = patient.Firstname;
            textBoxBirthdate.Text = patient.Birthdate.ToShortDateString();
            textBoxNumSecu.Text = patient.NumeroSecu;
        }

        /// <summary>
        /// Charge l'historique des ordonnances du patient sélectionné
        /// dans la grille (motif maître-détail, chargement léger).
        /// </summary>
        private void ChargerOrdonnances(Patient patient)
        {
            try
            {
                List<Ordonnance> ordonnances = _ordonnanceController.ObtenirOrdonnancesParPatient(patient.Id);

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Add("Id", "N°");
                dataGridView1.Columns.Add("Date", "Date d'émission");
                dataGridView1.Columns.Add("Prescripteur", "Prescripteur");
                dataGridView1.Columns["Id"].Width = 50;

                foreach (Ordonnance ord in ordonnances)
                {
                    dataGridView1.Rows.Add(
                        ord.Id,
                        ord.getDateOrdonnance().ToString("dd/MM/yyyy HH:mm"),
                        ord.getMedecin().Presentation()
                    );
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Impossible de charger les ordonnances :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Patient? patient = PatientSelectionne();
            if (patient == null)
            {
                return;
            }
            AfficherFichePatient(patient);
            ChargerOrdonnances(patient);
        }

        /// <summary>
        /// Bouton "+" : création d'un nouveau patient (fenêtre modale).
        /// Si la création aboutit (DialogResult.OK), la liste est rafraîchie.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            using (Création_patient pageCréationPatient = new Création_patient())
            {
                if (pageCréationPatient.ShowDialog(this) == DialogResult.OK)
                {
                    ChargerPatients();
                }
            }
        }

        /// <summary>
        /// Bouton "Modifier" : enregistre les champs de la fiche
        /// dans la base pour le patient sélectionné.
        /// </summary>
        private void buttonModifierPatient_Click(object? sender, EventArgs e)
        {
            Patient? patient = PatientSelectionne();
            if (patient == null)
            {
                MessageBox.Show("Sélectionnez d'abord un patient.", "Aucun patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nom = textBoxName.Text.Trim();
            string prenom = textBoxFirstname.Text.Trim();
            string numeroSecu = textBoxNumSecu.Text.Trim();

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
            if (!DateTime.TryParse(textBoxBirthdate.Text.Trim(), out DateTime dateNaissance) ||
                dateNaissance >= DateTime.Today)
            {
                MessageBox.Show("La date de naissance est invalide (format attendu : jj/mm/aaaa).",
                    "Saisie invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            patient.Name = nom;
            patient.Firstname = prenom;
            patient.Birthdate = dateNaissance;
            patient.NumeroSecu = numeroSecu;

            try
            {
                _patientController.ModifierPatient(patient);
                MessageBox.Show("Patient modifié avec succès.", "Modification",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerPatients();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("Un autre patient possède déjà ce numéro de sécurité sociale.",
                    "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de la modification :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bouton "+" de l'historique : nouvelle ordonnance pour le patient
        /// sélectionné (fenêtre modale). Rafraîchit l'historique au retour.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            Patient? patient = PatientSelectionne();
            if (patient == null)
            {
                MessageBox.Show("Sélectionnez d'abord un patient.", "Aucun patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Créateur_d_ordo pageCréationOrdo = new Créateur_d_ordo(patient))
            {
                if (pageCréationOrdo.ShowDialog(this) == DialogResult.OK)
                {
                    ChargerOrdonnances(patient);
                }
            }
        }

        /// <summary>
        /// Double-clic sur une ordonnance : affiche son détail (lignes de prescription).
        /// </summary>
        private void dataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            object? valeurId = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            if (valeurId == null)
            {
                return;
            }

            try
            {
                int numOrdonnance = Convert.ToInt32(valeurId);
                List<Prescription> lignes = _ordonnanceController.ObtenirLignesOrdonnance(numOrdonnance);

                StringBuilder detail = new StringBuilder();
                detail.AppendLine($"Ordonnance n°{numOrdonnance}\n");
                foreach (Prescription ligne in lignes)
                {
                    detail.AppendLine($"• {ligne.getMedicament().Presentation()} — {ligne.getName()} — {ligne.getDurée()} jour(s)");
                }

                MessageBox.Show(detail.ToString(), "Détail de l'ordonnance",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Impossible de charger le détail :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
