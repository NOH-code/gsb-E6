using GSB.Models;
using GSB.Ordonnances.Controllers;
using GSB.Ordonnances;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace GSB.Vue
{
    public partial class PatientListForm : Form
    {
        // Un contrôleur dédié à ce formulaire (préfixé _patient... car
        // d'autres contrôleurs peuvent arriver sur cette vue)
        private PatientController _patientController;
        public PatientListForm()
        {
            InitializeComponent();
            _patientController = new PatientController();
        }
        private void PatientListForm_Load(object sender, EventArgs e)
        {
            ChargerPatients();
        }
        private void ChargerPatients()
        {
            try
            {
                List<Patient> patients = _patientController.ObtenirTousLesPatients();
                AfficherPatients(patients);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Impossible de charger les patients :\n" + ex.Message,
                    "Erreur base de données",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Affiche une liste de patients dans la grille (utilisé par le
        /// chargement initial, la recherche et le reset).
        /// </summary>
        private void AfficherPatients(List<Patient> patients)
        {
            // Optimisation des performances UI : suspend le redessin pendant la modification
            dgvPatients.SuspendLayout();

            // 1. Nettoyage absolu : supprime toute colonne créée par erreur dans le Designer
            dgvPatients.Columns.Clear();
            dgvPatients.Rows.Clear();

            // 2. Création des 5 (et uniques) colonnes présentes dans la table SQL
            dgvPatients.Columns.Add("Id", "N°");
            dgvPatients.Columns.Add("Nom", "Nom");
            dgvPatients.Columns.Add("Prenom", "Prénom");
            dgvPatients.Columns.Add("DateNaissance", "Date de naissance");
            dgvPatients.Columns.Add("NumeroSecu", "N° Sécurité sociale");

            // 3. Redimensionnement spécifique
            dgvPatients.Columns["Id"].Width = 50;

            // 4. Remplissage des données
            foreach (Patient p in patients)
            {

                dgvPatients.Rows.Add(
                    p.Id,
                    p.Name,
                    p.Firstname,
                    p.Birthdate.ToShortDateString(),
                    p.NumeroSecu
                );
            }

            // 5. Paramètres visuels globaux
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPatients.ReadOnly = true;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Restaure le redessin de l'interface graphique
            dgvPatients.ResumeLayout();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string motCle = txtRecherche.Text.Trim();
            try
            {
                // Version sécurisée : la saisie passe par un paramètre @motCle,
                // jamais par concaténation (protection contre l'injection SQL).
                List<Patient> patients = _patientController.ObtenirPatientsParNom(motCle);
                AfficherPatients(patients);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                "Erreur SQL :\n" + ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRecherche.Text = "";
            ChargerPatients();
        }

        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
