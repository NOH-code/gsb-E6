using GSB.Models;
using GSB.Ordonnances.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GSB
{
    /// <summary>
    /// Affiche le détail d'une ordonnance (ses lignes de prescription) et
    /// permet de la supprimer. Construit entièrement par code (pas de Designer).
    /// Retourne DialogResult.OK si l'ordonnance a été supprimée.
    /// </summary>
    public class OrdonnanceDetailForm : Form
    {
        private readonly int _numOrdonnance;
        private readonly OrdonnanceController _ordonnanceController;

        private ListBox lstLignes;
        private Button btnSupprimer;
        private Button btnFermer;
        private Label labelTitre;

        public OrdonnanceDetailForm(int numOrdonnance, List<Prescription> lignes)
        {
            _numOrdonnance = numOrdonnance;
            _ordonnanceController = new OrdonnanceController();

            ConstruireInterface();

            foreach (Prescription ligne in lignes)
            {
                lstLignes.Items.Add(
                    $"{ligne.getMedicament().Presentation()}  —  {ligne.getName()}  —  {ligne.getDurée()} jour(s)");
            }
            if (lignes.Count == 0)
            {
                lstLignes.Items.Add("(aucune ligne)");
            }
        }

        private void ConstruireInterface()
        {
            this.Text = $"Détail de l'ordonnance n°{_numOrdonnance}";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(560, 420);

            labelTitre = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(20, 20),
                Text = $"Ordonnance n°{_numOrdonnance}"
            };

            lstLignes = new ListBox
            {
                Location = new Point(20, 70),
                Size = new Size(520, 270),
                IntegralHeight = false
            };

            btnSupprimer = new Button
            {
                Location = new Point(20, 355),
                Size = new Size(250, 45),
                Text = "Supprimer l'ordonnance",
                UseVisualStyleBackColor = false,
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSupprimer.Click += btnSupprimer_Click;

            btnFermer = new Button
            {
                Location = new Point(290, 355),
                Size = new Size(250, 45),
                Text = "Fermer",
                UseVisualStyleBackColor = true,
                DialogResult = DialogResult.Cancel
            };

            this.Controls.Add(labelTitre);
            this.Controls.Add(lstLignes);
            this.Controls.Add(btnSupprimer);
            this.Controls.Add(btnFermer);
            this.CancelButton = btnFermer;
        }

        private void btnSupprimer_Click(object? sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(
                $"Voulez-vous vraiment supprimer l'ordonnance n°{_numOrdonnance} ?\n" +
                "Cette action est définitive et supprime aussi ses lignes de prescription.",
                "Confirmer la suppression",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _ordonnanceController.SupprimerOrdonnance(_numOrdonnance);
                MessageBox.Show("Ordonnance supprimée.", "Suppression",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Signale à l'appelant qu'un rafraîchissement est nécessaire
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de la suppression :\n" + ex.Message,
                    "Erreur base de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
