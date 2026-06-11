namespace GSB_Ordonnances.Views
{
    partial class OrdonnanceEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMedecin = new System.Windows.Forms.Label();
            this.cmbMedecin = new System.Windows.Forms.ComboBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.lblLignes = new System.Windows.Forms.Label();
            this.dgvLignes = new System.Windows.Forms.DataGridView();
            this.btnAjouterLigne = new System.Windows.Forms.Button();
            this.btnSupprimerLigne = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).BeginInit();
            this.SuspendLayout();
            //
            // lblMedecin
            //
            this.lblMedecin.AutoSize = true;
            this.lblMedecin.Location = new System.Drawing.Point(16, 21);
            this.lblMedecin.Name = "lblMedecin";
            this.lblMedecin.Size = new System.Drawing.Size(56, 15);
            this.lblMedecin.TabIndex = 0;
            this.lblMedecin.Text = "Médecin :";
            //
            // cmbMedecin
            //
            this.cmbMedecin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedecin.Location = new System.Drawing.Point(100, 18);
            this.cmbMedecin.Name = "cmbMedecin";
            this.cmbMedecin.Size = new System.Drawing.Size(240, 23);
            this.cmbMedecin.TabIndex = 1;
            //
            // lblPatient
            //
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(360, 21);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(50, 15);
            this.lblPatient.TabIndex = 2;
            this.lblPatient.Text = "Patient :";
            //
            // cmbPatient
            //
            this.cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatient.Location = new System.Drawing.Point(420, 18);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(240, 23);
            this.cmbPatient.TabIndex = 3;
            //
            // lblLignes
            //
            this.lblLignes.AutoSize = true;
            this.lblLignes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLignes.Location = new System.Drawing.Point(16, 58);
            this.lblLignes.Name = "lblLignes";
            this.lblLignes.Size = new System.Drawing.Size(160, 15);
            this.lblLignes.TabIndex = 4;
            this.lblLignes.Text = "Lignes de prescription";
            //
            // dgvLignes
            //
            this.dgvLignes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLignes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLignes.Location = new System.Drawing.Point(16, 78);
            this.dgvLignes.Name = "dgvLignes";
            this.dgvLignes.RowHeadersVisible = false;
            this.dgvLignes.Size = new System.Drawing.Size(644, 240);
            this.dgvLignes.TabIndex = 5;
            //
            // btnAjouterLigne
            //
            this.btnAjouterLigne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAjouterLigne.Location = new System.Drawing.Point(16, 330);
            this.btnAjouterLigne.Name = "btnAjouterLigne";
            this.btnAjouterLigne.Size = new System.Drawing.Size(120, 30);
            this.btnAjouterLigne.TabIndex = 6;
            this.btnAjouterLigne.Text = "Ajouter une ligne";
            this.btnAjouterLigne.UseVisualStyleBackColor = true;
            this.btnAjouterLigne.Click += new System.EventHandler(this.btnAjouterLigne_Click);
            //
            // btnSupprimerLigne
            //
            this.btnSupprimerLigne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSupprimerLigne.Location = new System.Drawing.Point(142, 330);
            this.btnSupprimerLigne.Name = "btnSupprimerLigne";
            this.btnSupprimerLigne.Size = new System.Drawing.Size(130, 30);
            this.btnSupprimerLigne.TabIndex = 7;
            this.btnSupprimerLigne.Text = "Supprimer la ligne";
            this.btnSupprimerLigne.UseVisualStyleBackColor = true;
            this.btnSupprimerLigne.Click += new System.EventHandler(this.btnSupprimerLigne_Click);
            //
            // btnEnregistrer
            //
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnregistrer.Location = new System.Drawing.Point(456, 330);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(110, 30);
            this.btnEnregistrer.TabIndex = 8;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            //
            // btnAnnuler
            //
            this.btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(572, 330);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(88, 30);
            this.btnAnnuler.TabIndex = 9;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            //
            // OrdonnanceEditForm
            //
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(676, 376);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimerLigne);
            this.Controls.Add(this.btnAjouterLigne);
            this.Controls.Add(this.dgvLignes);
            this.Controls.Add(this.lblLignes);
            this.Controls.Add(this.cmbPatient);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.cmbMedecin);
            this.Controls.Add(this.lblMedecin);
            this.MinimumSize = new System.Drawing.Size(692, 415);
            this.Name = "OrdonnanceEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouvelle ordonnance";
            this.Load += new System.EventHandler(this.OrdonnanceEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMedecin;
        private System.Windows.Forms.ComboBox cmbMedecin;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.Label lblLignes;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.Button btnAjouterLigne;
        private System.Windows.Forms.Button btnSupprimerLigne;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}
