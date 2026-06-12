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
    public partial class Créateur_d_ordo : Form
    {
        // Contrôleurs dédiés à ce formulaire
        private MedicamentController _medicamentController;
        private OrdonnanceController _ordonnanceController;
        private MedecinController _medecinController;

        // Le patient destinataire de l'ordonnance et les lignes en cours de saisie
        private Patient? _patient;
        private List<Prescription> _lignes;

        public Créateur_d_ordo()
        {
            InitializeComponent();
            _medicamentController = new MedicamentController();
            _ordonnanceController = new OrdonnanceController();
            _medecinController = new MedecinController();
            _lignes = new List<Prescription>();

            // Câblage des événements non générés par le Designer
            this.Load += Créateur_d_ordo_Load;
            button2.Click += button2_Click;   // Valider la ligne
            button3.Click += button3_Click;   // Valider l'ordonnance
            button1.Click += button1_Click;   // Retirer la ligne sélectionnée
            button1.Text = "Retirer la ligne";
            button1.AutoSize = true;

            // La grille des lignes est pilotée par le code, pas par la saisie directe
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Constructeur utilisé par Recherche_patient : on connaît déjà le patient.
        /// </summary>
        public Créateur_d_ordo(Patient patient) : this()
        {
            _patient = patient;
        }

        private void Créateur_d_ordo_Load(object? sender, EventArgs e)
        {
            try
            {
                // Liste déroulante des médicaments (affichage via Presentation/ToString)
                comboBox1.DataSource = _medicamentController.ObtenirTousLesMedicaments();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Impossible de charger les médicaments :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Unités proposées pour la durée, la dose et la fréquence
            comboBox2.DataSource = new List<string> { "jour(s)", "semaine(s)", "mois" };
            comboBox3.DataSource = new List<string> { "mg", "g", "ml", "cp" };
            comboBox4.DataSource = new List<string> { "/jour", "/sem." };
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

            // Bornes de saisie raisonnables
            numericUpDown1.Minimum = 1; numericUpDown1.Maximum = 10000;  // dose
            numericUpDown2.Minimum = 1; numericUpDown2.Maximum = 365;    // durée
            numericUpDown3.Minimum = 1; numericUpDown3.Maximum = 24;     // fréquence

            ConfigurerColonnesLignes();

            this.Text = _patient != null
                ? $"Nouvelle ordonnance — {_patient.Presentation()}"
                : "Nouvelle ordonnance";
        }

        /// <summary>
        /// Colonnes de la grille récapitulative des lignes de prescription.
        /// </summary>
        private void ConfigurerColonnesLignes()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Medicament", "Médicament");
            dataGridView1.Columns.Add("Posologie", "Posologie");
            dataGridView1.Columns.Add("Duree", "Durée (jours)");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Bouton "Valider" (ligne) : ajoute le médicament saisi à la liste des lignes.
        /// </summary>
        private void button2_Click(object? sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not Medoc medicament)
            {
                MessageBox.Show("Sélectionnez un médicament.", "Saisie incomplète",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Posologie lisible construite à partir de la dose et de la fréquence
            string posologie = $"{numericUpDown1.Value} {comboBox3.Text}, {numericUpDown3.Value} fois {comboBox4.Text}";

            // Durée convertie en jours selon l'unité choisie
            int facteur = comboBox2.SelectedIndex switch
            {
                1 => 7,    // semaines
                2 => 30,   // mois
                _ => 1     // jours
            };
            int dureeJours = (int)numericUpDown2.Value * facteur;

            Prescription ligne = new Prescription(medicament, posologie, dureeJours);
            _lignes.Add(ligne);
            dataGridView1.Rows.Add(medicament.Presentation(), posologie, dureeJours);
        }

        /// <summary>
        /// Bouton "Retirer la ligne" : supprime la ligne sélectionnée de la grille.
        /// </summary>
        private void button1_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int index = dataGridView1.CurrentRow.Index;
            _lignes.RemoveAt(index);
            dataGridView1.Rows.RemoveAt(index);
        }

        /// <summary>
        /// Bouton "Valider" (ordonnance) : enregistre l'en-tête et toutes les
        /// lignes en une seule transaction (tout ou rien).
        /// </summary>
        private void button3_Click(object? sender, EventArgs e)
        {
            if (_patient == null)
            {
                MessageBox.Show("Aucun patient sélectionné : ouvrez ce formulaire depuis la fiche patient.",
                    "Patient manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_lignes.Count == 0)
            {
                MessageBox.Show("Ajoutez au moins une ligne de prescription.",
                    "Ordonnance vide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Le prescripteur est le médecin connecté (gardé en Session à la connexion)
            Doctor? prescripteur = Session.MedecinConnecte;
            try
            {
                if (prescripteur == null)
                {
                    // Filet de sécurité si le formulaire est ouvert sans passer par la connexion
                    prescripteur = _medecinController.ObtenirTousLesMedecins().FirstOrDefault();
                }
                if (prescripteur == null)
                {
                    MessageBox.Show("Aucun médecin disponible pour signer l'ordonnance.",
                        "Prescripteur manquant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Ordonnance ordonnance = new Ordonnance(prescripteur, _patient);
                foreach (Prescription ligne in _lignes)
                {
                    ordonnance.AjouterLigne(ligne);
                }

                int numOrdonnance = _ordonnanceController.AjouterOrdonnance(ordonnance);

                MessageBox.Show($"Ordonnance n°{numOrdonnance} enregistrée ({_lignes.Count} ligne(s)).",
                    "Ordonnance enregistrée", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                // Grâce au Rollback du contrôleur, rien n'a été enregistré à moitié
                MessageBox.Show("Échec de l'enregistrement, aucune donnée n'a été écrite :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
