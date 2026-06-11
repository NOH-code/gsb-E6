using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Ordonnances.Controllers;
using GSB_Ordonnances.Models;

namespace GSB_Ordonnances.Views
{
    /// <summary>
    /// Fiche détaillée d'un patient : informations, âge, allergies et historique des ordonnances.
    /// Reçoit l'identifiant du patient (et non l'objet) dans son constructeur.
    /// </summary>
    public partial class PatientDetailForm : Form
    {
        private readonly int _idPatient;
        private readonly PatientController _patientController;
        private readonly AllergieController _allergieController;
        private readonly OrdonnanceController _ordonnanceController;

        public PatientDetailForm(int idPatient)
        {
            InitializeComponent();
            _idPatient = idPatient;
            _patientController = new PatientController();
            _allergieController = new AllergieController();
            _ordonnanceController = new OrdonnanceController();
        }

        private void PatientDetailForm_Load(object sender, EventArgs e)
        {
            try
            {
                Patient patient = _patientController.ObtenirParId(_idPatient);
                if (patient == null)
                {
                    MessageBox.Show("Patient introuvable.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblNomValeur.Text = patient.Nom;
                lblPrenomValeur.Text = patient.Prenom;
                lblDateNaissanceValeur.Text = patient.DateNaissance.ToString("dd/MM/yyyy");
                lblNumeroSecuValeur.Text = patient.NumeroSecu;
                lblAgeValeur.Text = patient.CalculerAge() + " ans" +
                    (patient.EstMajeur() ? " (majeur)" : " (mineur)");

                ChargerAllergies();
                ChargerHistorique();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de la fiche.\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerAllergies()
        {
            lstAllergies.Items.Clear();
            List<Allergie> allergies = _allergieController.ObtenirAllergiesParPatient(_idPatient);
            if (allergies.Count == 0)
            {
                lstAllergies.Items.Add("(aucune allergie connue)");
                return;
            }
            foreach (Allergie allergie in allergies)
            {
                lstAllergies.Items.Add(allergie.Libelle);
            }
        }

        private void ChargerHistorique()
        {
            dgvHistorique.DataSource = _ordonnanceController.ObtenirHistorique(_idPatient);
            if (dgvHistorique.Columns.Contains("Id"))
                dgvHistorique.Columns["Id"].HeaderText = "N°";
            if (dgvHistorique.Columns.Contains("DateEmission"))
            {
                dgvHistorique.Columns["DateEmission"].HeaderText = "Date";
                dgvHistorique.Columns["DateEmission"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvHistorique.Columns.Contains("NomMedecin"))
                dgvHistorique.Columns["NomMedecin"].HeaderText = "Médecin";
            if (dgvHistorique.Columns.Contains("NomPatient"))
                dgvHistorique.Columns["NomPatient"].Visible = false; // c'est ce patient
        }

        private void dgvHistorique_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // On ouvre la liste des ordonnances DU PATIENT (et non l'Id de l'ordonnance).
            using (OrdonnanceListForm form = new OrdonnanceListForm(_idPatient))
            {
                form.ShowDialog(this);
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
