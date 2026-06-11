using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Ordonnances.Controllers;
using GSB_Ordonnances.Models;
using MySql.Data.MySqlClient;

namespace GSB_Ordonnances.Views
{
    /// <summary>
    /// Écran principal : liste des patients, recherche, filtre allergie et accès aux
    /// actions CRUD ainsi qu'à la création d'ordonnance.
    /// </summary>
    public partial class PatientListForm : Form
    {
        private readonly PatientController _patientController;
        private readonly AllergieController _allergieController;

        public PatientListForm()
        {
            InitializeComponent();
            _patientController = new PatientController();
            _allergieController = new AllergieController();
        }

        private void PatientListForm_Load(object sender, EventArgs e)
        {
            ChargerAllergies();
            RafraichirListe();
        }

        /// <summary>Remplit la combo des allergies (avec une entrée vide « Toutes »).</summary>
        private void ChargerAllergies()
        {
            List<string> libelles = _allergieController.ObtenirLibelles();
            cmbAllergie.Items.Clear();
            cmbAllergie.Items.Add(""); // « toutes les allergies »
            foreach (string libelle in libelles)
            {
                cmbAllergie.Items.Add(libelle);
            }
            cmbAllergie.SelectedIndex = 0;
        }

        /// <summary>Méthode centrale : recharge la grille selon les filtres courants.</summary>
        private void RafraichirListe()
        {
            string motCle = txtRecherche.Text.Trim();
            string allergie = cmbAllergie.SelectedItem == null ? "" : cmbAllergie.SelectedItem.ToString();

            List<Patient> patients;
            if (!string.IsNullOrEmpty(allergie))
            {
                patients = _patientController.RechercherParNomEtAllergie(motCle, allergie);
            }
            else if (!string.IsNullOrEmpty(motCle))
            {
                patients = _patientController.RechercherParNom(motCle);
            }
            else
            {
                patients = _patientController.ObtenirTousLesPatients();
            }

            dgvPatients.DataSource = patients;
            PersonnaliserColonnes();
        }

        /// <summary>
        /// Réglage des colonnes : TOUJOURS appelé après l'affectation du DataSource.
        /// Masque les colonnes techniques qui font doublon (NomComplet, Allergies).
        /// </summary>
        private void PersonnaliserColonnes()
        {
            if (dgvPatients.Columns.Contains("NomComplet"))
                dgvPatients.Columns["NomComplet"].Visible = false;
            if (dgvPatients.Columns.Contains("Allergies"))
                dgvPatients.Columns["Allergies"].Visible = false;

            if (dgvPatients.Columns.Contains("Id"))
                dgvPatients.Columns["Id"].HeaderText = "N°";
            if (dgvPatients.Columns.Contains("Nom"))
                dgvPatients.Columns["Nom"].HeaderText = "Nom";
            if (dgvPatients.Columns.Contains("Prenom"))
                dgvPatients.Columns["Prenom"].HeaderText = "Prénom";
            if (dgvPatients.Columns.Contains("DateNaissance"))
            {
                dgvPatients.Columns["DateNaissance"].HeaderText = "Naissance";
                dgvPatients.Columns["DateNaissance"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvPatients.Columns.Contains("NumeroSecu"))
                dgvPatients.Columns["NumeroSecu"].HeaderText = "N° sécu";
        }

        /// <summary>Retourne le patient actuellement sélectionné, ou null.</summary>
        private Patient PatientSelectionne()
        {
            if (dgvPatients.CurrentRow == null)
                return null;
            return dgvPatients.CurrentRow.DataBoundItem as Patient;
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            RafraichirListe();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            if (cmbAllergie.Items.Count > 0)
                cmbAllergie.SelectedIndex = 0;
            RafraichirListe();
        }

        private void btnNouveauPatient_Click(object sender, EventArgs e)
        {
            using (PatientEditForm form = new PatientEditForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    RafraichirListe();
            }
        }

        private void btnVoirDetail_Click(object sender, EventArgs e)
        {
            Patient patient = PatientSelectionne();
            if (patient == null)
            {
                MessageBox.Show("Sélectionne un patient.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (PatientDetailForm form = new PatientDetailForm(patient.Id))
            {
                form.ShowDialog(this);
            }
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            Patient patient = PatientSelectionne();
            if (patient == null)
                return;

            using (PatientEditForm form = new PatientEditForm(patient))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    RafraichirListe();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            Patient patient = PatientSelectionne();
            if (patient == null)
            {
                MessageBox.Show("Sélectionne un patient.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "Supprimer le patient " + patient.NomComplet + " ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmation != DialogResult.Yes)
                return;

            try
            {
                _patientController.SupprimerPatient(patient.Id);
                RafraichirListe();
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show("Ce patient a des ordonnances : supprime-les d'abord.",
                    "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression.\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNouvelleOrdonnance_Click(object sender, EventArgs e)
        {
            using (OrdonnanceEditForm form = new OrdonnanceEditForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    MessageBox.Show("Ordonnance enregistrée.", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
