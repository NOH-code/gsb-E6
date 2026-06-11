namespace GSB_Ordonnances.Views
{
    partial class PatientListForm
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
            this.lblRecherche = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.lblAllergie = new System.Windows.Forms.Label();
            this.cmbAllergie = new System.Windows.Forms.ComboBox();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.btnNouveauPatient = new System.Windows.Forms.Button();
            this.btnVoirDetail = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnNouvelleOrdonnance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.SuspendLayout();
            //
            // lblRecherche
            //
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Location = new System.Drawing.Point(16, 19);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(36, 15);
            this.lblRecherche.TabIndex = 0;
            this.lblRecherche.Text = "Nom :";
            //
            // txtRecherche
            //
            this.txtRecherche.Location = new System.Drawing.Point(58, 16);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(160, 23);
            this.txtRecherche.TabIndex = 1;
            //
            // lblAllergie
            //
            this.lblAllergie.AutoSize = true;
            this.lblAllergie.Location = new System.Drawing.Point(236, 19);
            this.lblAllergie.Name = "lblAllergie";
            this.lblAllergie.Size = new System.Drawing.Size(52, 15);
            this.lblAllergie.TabIndex = 2;
            this.lblAllergie.Text = "Allergie :";
            //
            // cmbAllergie
            //
            this.cmbAllergie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllergie.Location = new System.Drawing.Point(294, 16);
            this.cmbAllergie.Name = "cmbAllergie";
            this.cmbAllergie.Size = new System.Drawing.Size(160, 23);
            this.cmbAllergie.TabIndex = 3;
            //
            // btnRechercher
            //
            this.btnRechercher.Location = new System.Drawing.Point(470, 15);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(100, 25);
            this.btnRechercher.TabIndex = 4;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(576, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 25);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Réinitialiser";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // dgvPatients
            //
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Location = new System.Drawing.Point(16, 52);
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(660, 360);
            this.dgvPatients.TabIndex = 6;
            this.dgvPatients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellDoubleClick);
            //
            // btnNouveauPatient
            //
            this.btnNouveauPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNouveauPatient.Location = new System.Drawing.Point(16, 424);
            this.btnNouveauPatient.Name = "btnNouveauPatient";
            this.btnNouveauPatient.Size = new System.Drawing.Size(130, 32);
            this.btnNouveauPatient.TabIndex = 7;
            this.btnNouveauPatient.Text = "Nouveau patient";
            this.btnNouveauPatient.UseVisualStyleBackColor = true;
            this.btnNouveauPatient.Click += new System.EventHandler(this.btnNouveauPatient_Click);
            //
            // btnVoirDetail
            //
            this.btnVoirDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoirDetail.Location = new System.Drawing.Point(152, 424);
            this.btnVoirDetail.Name = "btnVoirDetail";
            this.btnVoirDetail.Size = new System.Drawing.Size(110, 32);
            this.btnVoirDetail.TabIndex = 8;
            this.btnVoirDetail.Text = "Voir la fiche";
            this.btnVoirDetail.UseVisualStyleBackColor = true;
            this.btnVoirDetail.Click += new System.EventHandler(this.btnVoirDetail_Click);
            //
            // btnSupprimer
            //
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSupprimer.Location = new System.Drawing.Point(268, 424);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(110, 32);
            this.btnSupprimer.TabIndex = 9;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            //
            // btnNouvelleOrdonnance
            //
            this.btnNouvelleOrdonnance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNouvelleOrdonnance.Location = new System.Drawing.Point(506, 424);
            this.btnNouvelleOrdonnance.Name = "btnNouvelleOrdonnance";
            this.btnNouvelleOrdonnance.Size = new System.Drawing.Size(170, 32);
            this.btnNouvelleOrdonnance.TabIndex = 10;
            this.btnNouvelleOrdonnance.Text = "Nouvelle ordonnance";
            this.btnNouvelleOrdonnance.UseVisualStyleBackColor = true;
            this.btnNouvelleOrdonnance.Click += new System.EventHandler(this.btnNouvelleOrdonnance_Click);
            //
            // PatientListForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 472);
            this.Controls.Add(this.btnNouvelleOrdonnance);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnVoirDetail);
            this.Controls.Add(this.btnNouveauPatient);
            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.cmbAllergie);
            this.Controls.Add(this.lblAllergie);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.lblRecherche);
            this.MinimumSize = new System.Drawing.Size(708, 511);
            this.Name = "PatientListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSB Ordonnances — Patients";
            this.Load += new System.EventHandler(this.PatientListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Label lblAllergie;
        private System.Windows.Forms.ComboBox cmbAllergie;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Button btnNouveauPatient;
        private System.Windows.Forms.Button btnVoirDetail;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnNouvelleOrdonnance;
    }
}
