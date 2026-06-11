using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Ordonnances.Controllers;
using GSB_Ordonnances.Models;

namespace GSB_Ordonnances.Views
{
    /// <summary>
    /// Liste des ordonnances d'un patient (maître-détail) : la grille du haut affiche
    /// l'historique, celle du bas les lignes de l'ordonnance sélectionnée.
    /// Reçoit l'identifiant du PATIENT dans son constructeur.
    /// </summary>
    public partial class OrdonnanceListForm : Form
    {
        private readonly int _idPatient;
        private readonly OrdonnanceController _ordonnanceController;

        public OrdonnanceListForm(int idPatient)
        {
            InitializeComponent();
            _idPatient = idPatient;
            _ordonnanceController = new OrdonnanceController();
        }

        private void OrdonnanceListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvOrdonnances.DataSource = _ordonnanceController.ObtenirHistorique(_idPatient);
                PersonnaliserColonnesOrdonnances();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des ordonnances.\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonnaliserColonnesOrdonnances()
        {
            if (dgvOrdonnances.Columns.Contains("Id"))
                dgvOrdonnances.Columns["Id"].HeaderText = "N°";
            if (dgvOrdonnances.Columns.Contains("DateEmission"))
            {
                dgvOrdonnances.Columns["DateEmission"].HeaderText = "Date";
                dgvOrdonnances.Columns["DateEmission"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvOrdonnances.Columns.Contains("NomMedecin"))
                dgvOrdonnances.Columns["NomMedecin"].HeaderText = "Médecin";
            if (dgvOrdonnances.Columns.Contains("NomPatient"))
                dgvOrdonnances.Columns["NomPatient"].HeaderText = "Patient";
        }

        private void dgvOrdonnances_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdonnances.CurrentRow == null)
                return;

            OrdonnanceResume resume = dgvOrdonnances.CurrentRow.DataBoundItem as OrdonnanceResume;
            if (resume == null)
                return;

            try
            {
                List<LignePrescription> lignes = _ordonnanceController.ObtenirLignes(resume.Id);
                dgvLignes.DataSource = lignes;
                PersonnaliserColonnesLignes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des lignes.\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// La colonne Medicament (objet) afficherait le nom du type : on la masque et on
        /// affiche la colonne texte NomMedicament à la place.
        /// </summary>
        private void PersonnaliserColonnesLignes()
        {
            if (dgvLignes.Columns.Contains("Medicament"))
                dgvLignes.Columns["Medicament"].Visible = false;
            if (dgvLignes.Columns.Contains("NomMedicament"))
                dgvLignes.Columns["NomMedicament"].HeaderText = "Médicament";
            if (dgvLignes.Columns.Contains("Posologie"))
                dgvLignes.Columns["Posologie"].HeaderText = "Posologie";
            if (dgvLignes.Columns.Contains("DureeJours"))
                dgvLignes.Columns["DureeJours"].HeaderText = "Durée (jours)";
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
