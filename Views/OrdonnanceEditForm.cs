using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Ordonnances.Controllers;
using GSB_Ordonnances.Models;

namespace GSB_Ordonnances.Views
{
    /// <summary>
    /// Formulaire de saisie d'une nouvelle ordonnance : choix du médecin et du patient,
    /// puis saisie des lignes (médicament + posologie + durée). L'enregistrement est
    /// transactionnel (voir OrdonnanceController.EnregistrerOrdonnance).
    /// </summary>
    public partial class OrdonnanceEditForm : Form
    {
        private readonly MedecinController _medecinController;
        private readonly PatientController _patientController;
        private readonly MedicamentController _medicamentController;
        private readonly OrdonnanceController _ordonnanceController;

        private List<Medicament> _medicaments;

        public OrdonnanceEditForm()
        {
            InitializeComponent();
            _medecinController = new MedecinController();
            _patientController = new PatientController();
            _medicamentController = new MedicamentController();
            _ordonnanceController = new OrdonnanceController();
        }

        private void OrdonnanceEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Combos médecin / patient — DisplayMember sur la PROPRIÉTÉ NomComplet.
                List<Medecin> medecins = _medecinController.ObtenirTousLesMedecins();
                cmbMedecin.DisplayMember = "NomComplet";
                cmbMedecin.ValueMember = "Id";
                cmbMedecin.DataSource = medecins;
                cmbMedecin.SelectedIndex = -1;

                List<Patient> patients = _patientController.ObtenirTousLesPatients();
                cmbPatient.DisplayMember = "NomComplet";
                cmbPatient.ValueMember = "Id";
                cmbPatient.DataSource = patients;
                cmbPatient.SelectedIndex = -1;

                _medicaments = _medicamentController.ObtenirTousLesMedicaments();
                ConfigurerColonnesLignes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données.\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configure les colonnes de la grille des lignes : une colonne ComboBox pour le
        /// médicament (sans DataPropertyName pour éviter les FormatException), deux colonnes
        /// texte pour la posologie et la durée.
        /// </summary>
        private void ConfigurerColonnesLignes()
        {
            dgvLignes.AutoGenerateColumns = false;
            dgvLignes.Columns.Clear();

            DataGridViewComboBoxColumn colMedicament = new DataGridViewComboBoxColumn();
            colMedicament.Name = "Medicament";
            colMedicament.HeaderText = "Médicament";
            colMedicament.DataSource = _medicaments;
            colMedicament.DisplayMember = "Libelle";
            colMedicament.ValueMember = "Id";
            colMedicament.FlatStyle = FlatStyle.Flat;
            colMedicament.Width = 220;

            DataGridViewTextBoxColumn colPosologie = new DataGridViewTextBoxColumn();
            colPosologie.Name = "Posologie";
            colPosologie.HeaderText = "Posologie";
            colPosologie.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn colDuree = new DataGridViewTextBoxColumn();
            colDuree.Name = "DureeJours";
            colDuree.HeaderText = "Durée (jours)";
            colDuree.Width = 100;

            dgvLignes.Columns.Add(colMedicament);
            dgvLignes.Columns.Add(colPosologie);
            dgvLignes.Columns.Add(colDuree);

            dgvLignes.AllowUserToAddRows = false;
        }

        private void btnAjouterLigne_Click(object sender, EventArgs e)
        {
            dgvLignes.Rows.Add();
        }

        private void btnSupprimerLigne_Click(object sender, EventArgs e)
        {
            if (dgvLignes.CurrentRow != null && !dgvLignes.CurrentRow.IsNewRow)
            {
                dgvLignes.Rows.Remove(dgvLignes.CurrentRow);
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // --- Validation ---
            Medecin medecin = cmbMedecin.SelectedItem as Medecin;
            Patient patient = cmbPatient.SelectedItem as Patient;

            if (medecin == null)
            {
                MessageBox.Show("Sélectionne un médecin.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (patient == null)
            {
                MessageBox.Show("Sélectionne un patient.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvLignes.Rows.Count == 0)
            {
                MessageBox.Show("Ajoute au moins une ligne de prescription.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Construction de l'ordonnance + lecture manuelle des cellules ---
            Ordonnance ordonnance = new Ordonnance(medecin, patient);

            foreach (DataGridViewRow row in dgvLignes.Rows)
            {
                if (row.IsNewRow)
                    continue;

                object valeurMedicament = row.Cells["Medicament"].Value;
                if (valeurMedicament == null)
                {
                    MessageBox.Show("Chaque ligne doit avoir un médicament sélectionné.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idMedicament = Convert.ToInt32(valeurMedicament);
                Medicament medicament = _medicaments.Find(m => m.Id == idMedicament);

                string posologie = row.Cells["Posologie"].Value == null
                    ? "" : row.Cells["Posologie"].Value.ToString().Trim();
                if (string.IsNullOrEmpty(posologie))
                {
                    MessageBox.Show("Chaque ligne doit avoir une posologie.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int dureeJours;
                int.TryParse(
                    row.Cells["DureeJours"].Value == null ? "" : row.Cells["DureeJours"].Value.ToString(),
                    out dureeJours);
                if (dureeJours <= 0)
                {
                    MessageBox.Show("La durée (en jours) doit être un nombre supérieur à 0.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ordonnance.AjouterLigne(new LignePrescription(medicament, posologie, dureeJours));
            }

            if (ordonnance.Lignes.Count == 0)
            {
                MessageBox.Show("Ajoute au moins une ligne de prescription.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Enregistrement (transaction) ---
            try
            {
                _ordonnanceController.EnregistrerOrdonnance(ordonnance);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de l'ordonnance.\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
