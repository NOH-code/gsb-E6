namespace GSB_Ordonnances.Views
{
    partial class PatientDetailForm
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
            this.lblNom = new System.Windows.Forms.Label();
            this.lblNomValeur = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblPrenomValeur = new System.Windows.Forms.Label();
            this.lblDateNaissance = new System.Windows.Forms.Label();
            this.lblDateNaissanceValeur = new System.Windows.Forms.Label();
            this.lblNumeroSecu = new System.Windows.Forms.Label();
            this.lblNumeroSecuValeur = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblAgeValeur = new System.Windows.Forms.Label();
            this.lblAllergies = new System.Windows.Forms.Label();
            this.lstAllergies = new System.Windows.Forms.ListBox();
            this.lblHistorique = new System.Windows.Forms.Label();
            this.dgvHistorique = new System.Windows.Forms.DataGridView();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorique)).BeginInit();
            this.SuspendLayout();
            //
            // lblNom
            //
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNom.Location = new System.Drawing.Point(20, 20);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(38, 15);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom :";
            //
            // lblNomValeur
            //
            this.lblNomValeur.AutoSize = true;
            this.lblNomValeur.Location = new System.Drawing.Point(150, 20);
            this.lblNomValeur.Name = "lblNomValeur";
            this.lblNomValeur.Size = new System.Drawing.Size(12, 15);
            this.lblNomValeur.TabIndex = 1;
            this.lblNomValeur.Text = "-";
            //
            // lblPrenom
            //
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrenom.Location = new System.Drawing.Point(20, 48);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(56, 15);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prénom :";
            //
            // lblPrenomValeur
            //
            this.lblPrenomValeur.AutoSize = true;
            this.lblPrenomValeur.Location = new System.Drawing.Point(150, 48);
            this.lblPrenomValeur.Name = "lblPrenomValeur";
            this.lblPrenomValeur.Size = new System.Drawing.Size(12, 15);
            this.lblPrenomValeur.TabIndex = 3;
            this.lblPrenomValeur.Text = "-";
            //
            // lblDateNaissance
            //
            this.lblDateNaissance.AutoSize = true;
            this.lblDateNaissance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateNaissance.Location = new System.Drawing.Point(20, 76);
            this.lblDateNaissance.Name = "lblDateNaissance";
            this.lblDateNaissance.Size = new System.Drawing.Size(110, 15);
            this.lblDateNaissance.TabIndex = 4;
            this.lblDateNaissance.Text = "Date de naissance :";
            //
            // lblDateNaissanceValeur
            //
            this.lblDateNaissanceValeur.AutoSize = true;
            this.lblDateNaissanceValeur.Location = new System.Drawing.Point(150, 76);
            this.lblDateNaissanceValeur.Name = "lblDateNaissanceValeur";
            this.lblDateNaissanceValeur.Size = new System.Drawing.Size(12, 15);
            this.lblDateNaissanceValeur.TabIndex = 5;
            this.lblDateNaissanceValeur.Text = "-";
            //
            // lblNumeroSecu
            //
            this.lblNumeroSecu.AutoSize = true;
            this.lblNumeroSecu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumeroSecu.Location = new System.Drawing.Point(20, 104);
            this.lblNumeroSecu.Name = "lblNumeroSecu";
            this.lblNumeroSecu.Size = new System.Drawing.Size(54, 15);
            this.lblNumeroSecu.TabIndex = 6;
            this.lblNumeroSecu.Text = "N° sécu :";
            //
            // lblNumeroSecuValeur
            //
            this.lblNumeroSecuValeur.AutoSize = true;
            this.lblNumeroSecuValeur.Location = new System.Drawing.Point(150, 104);
            this.lblNumeroSecuValeur.Name = "lblNumeroSecuValeur";
            this.lblNumeroSecuValeur.Size = new System.Drawing.Size(12, 15);
            this.lblNumeroSecuValeur.TabIndex = 7;
            this.lblNumeroSecuValeur.Text = "-";
            //
            // lblAge
            //
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAge.Location = new System.Drawing.Point(20, 132);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(34, 15);
            this.lblAge.TabIndex = 8;
            this.lblAge.Text = "Âge :";
            //
            // lblAgeValeur
            //
            this.lblAgeValeur.AutoSize = true;
            this.lblAgeValeur.Location = new System.Drawing.Point(150, 132);
            this.lblAgeValeur.Name = "lblAgeValeur";
            this.lblAgeValeur.Size = new System.Drawing.Size(12, 15);
            this.lblAgeValeur.TabIndex = 9;
            this.lblAgeValeur.Text = "-";
            //
            // lblAllergies
            //
            this.lblAllergies.AutoSize = true;
            this.lblAllergies.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAllergies.Location = new System.Drawing.Point(360, 20);
            this.lblAllergies.Name = "lblAllergies";
            this.lblAllergies.Size = new System.Drawing.Size(62, 15);
            this.lblAllergies.TabIndex = 10;
            this.lblAllergies.Text = "Allergies :";
            //
            // lstAllergies
            //
            this.lstAllergies.FormattingEnabled = true;
            this.lstAllergies.ItemHeight = 15;
            this.lstAllergies.Location = new System.Drawing.Point(363, 40);
            this.lstAllergies.Name = "lstAllergies";
            this.lstAllergies.Size = new System.Drawing.Size(230, 124);
            this.lstAllergies.TabIndex = 11;
            //
            // lblHistorique
            //
            this.lblHistorique.AutoSize = true;
            this.lblHistorique.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistorique.Location = new System.Drawing.Point(20, 180);
            this.lblHistorique.Name = "lblHistorique";
            this.lblHistorique.Size = new System.Drawing.Size(173, 15);
            this.lblHistorique.TabIndex = 12;
            this.lblHistorique.Text = "Historique des ordonnances :";
            //
            // dgvHistorique
            //
            this.dgvHistorique.AllowUserToAddRows = false;
            this.dgvHistorique.AllowUserToDeleteRows = false;
            this.dgvHistorique.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorique.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorique.Location = new System.Drawing.Point(20, 200);
            this.dgvHistorique.MultiSelect = false;
            this.dgvHistorique.Name = "dgvHistorique";
            this.dgvHistorique.ReadOnly = true;
            this.dgvHistorique.RowHeadersVisible = false;
            this.dgvHistorique.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorique.Size = new System.Drawing.Size(573, 200);
            this.dgvHistorique.TabIndex = 13;
            this.dgvHistorique.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorique_CellDoubleClick);
            //
            // btnFermer
            //
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Location = new System.Drawing.Point(503, 412);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(90, 32);
            this.btnFermer.TabIndex = 14;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            //
            // PatientDetailForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 456);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.dgvHistorique);
            this.Controls.Add(this.lblHistorique);
            this.Controls.Add(this.lstAllergies);
            this.Controls.Add(this.lblAllergies);
            this.Controls.Add(this.lblAgeValeur);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblNumeroSecuValeur);
            this.Controls.Add(this.lblNumeroSecu);
            this.Controls.Add(this.lblDateNaissanceValeur);
            this.Controls.Add(this.lblDateNaissance);
            this.Controls.Add(this.lblPrenomValeur);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.lblNomValeur);
            this.Controls.Add(this.lblNom);
            this.MinimumSize = new System.Drawing.Size(629, 495);
            this.Name = "PatientDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fiche patient";
            this.Load += new System.EventHandler(this.PatientDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorique)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblNomValeur;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblPrenomValeur;
        private System.Windows.Forms.Label lblDateNaissance;
        private System.Windows.Forms.Label lblDateNaissanceValeur;
        private System.Windows.Forms.Label lblNumeroSecu;
        private System.Windows.Forms.Label lblNumeroSecuValeur;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblAgeValeur;
        private System.Windows.Forms.Label lblAllergies;
        private System.Windows.Forms.ListBox lstAllergies;
        private System.Windows.Forms.Label lblHistorique;
        private System.Windows.Forms.DataGridView dgvHistorique;
        private System.Windows.Forms.Button btnFermer;
    }
}
