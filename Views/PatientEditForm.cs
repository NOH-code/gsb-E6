using System;
using System.Globalization;
using System.Windows.Forms;
using GSB_Ordonnances.Controllers;
using GSB_Ordonnances.Models;
using MySql.Data.MySqlClient;

namespace GSB_Ordonnances.Views
{
    /// <summary>
    /// Formulaire modal d'édition d'un patient (création ou modification).
    /// </summary>
    public partial class PatientEditForm : Form
    {
        private readonly PatientController _patientController;
        private readonly bool _estModification;
        private int _idPatient;

        /// <summary>Mode création : champs vides.</summary>
        public PatientEditForm()
        {
            InitializeComponent();
            _patientController = new PatientController();
            _estModification = false;
            this.Text = "Nouveau patient";
        }

        /// <summary>Mode modification : pré-remplit les champs avec le patient fourni.</summary>
        public PatientEditForm(Patient patient) : this()
        {
            _estModification = true;
            _idPatient = patient.Id;
            this.Text = "Modification du patient";

            txtNom.Text = patient.Nom;
            txtPrenom.Text = patient.Prenom;
            txtNumeroSecu.Text = patient.NumeroSecu;
            txtDateNaissance.Text = patient.DateNaissance.ToString("dd/MM/yyyy");
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // --- Validation côté interface (avant l'écriture en base) ---
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            string numeroSecu = txtNumeroSecu.Text.Trim();
            if (numeroSecu.Length != 13)
            {
                MessageBox.Show("Le numéro de sécurité sociale doit faire exactement 13 caractères.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            DateTime dateNaissance;
            if (!DateTime.TryParseExact(txtDateNaissance.Text.Trim(), "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out dateNaissance))
            {
                MessageBox.Show("La date de naissance doit être au format jj/mm/aaaa.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // --- Écriture en base ---
            try
            {
                Patient patient = new Patient(
                    txtNom.Text.Trim(),
                    txtPrenom.Text.Trim(),
                    dateNaissance,
                    numeroSecu);

                if (_estModification)
                {
                    patient.Id = _idPatient;
                    _patientController.ModifierPatient(patient);
                }
                else
                {
                    _patientController.AjouterPatient(patient);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("Ce numéro de sécurité sociale existe déjà.",
                    "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement.\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
