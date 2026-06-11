namespace GSB_Ordonnances.Views
{
    partial class PatientEditForm
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
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblNumeroSecu = new System.Windows.Forms.Label();
            this.txtNumeroSecu = new System.Windows.Forms.TextBox();
            this.lblDateNaissance = new System.Windows.Forms.Label();
            this.txtDateNaissance = new System.Windows.Forms.TextBox();
            this.lblFormatDate = new System.Windows.Forms.Label();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblNom
            //
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(24, 25);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 15);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom";
            //
            // txtNom
            //
            this.txtNom.Location = new System.Drawing.Point(160, 22);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(200, 23);
            this.txtNom.TabIndex = 1;
            //
            // lblPrenom
            //
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(24, 61);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(46, 15);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prénom";
            //
            // txtPrenom
            //
            this.txtPrenom.Location = new System.Drawing.Point(160, 58);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(200, 23);
            this.txtPrenom.TabIndex = 3;
            //
            // lblNumeroSecu
            //
            this.lblNumeroSecu.AutoSize = true;
            this.lblNumeroSecu.Location = new System.Drawing.Point(24, 97);
            this.lblNumeroSecu.Name = "lblNumeroSecu";
            this.lblNumeroSecu.Size = new System.Drawing.Size(130, 15);
            this.lblNumeroSecu.TabIndex = 4;
            this.lblNumeroSecu.Text = "N° sécu (13 caractères)";
            //
            // txtNumeroSecu
            //
            this.txtNumeroSecu.Location = new System.Drawing.Point(160, 94);
            this.txtNumeroSecu.MaxLength = 13;
            this.txtNumeroSecu.Name = "txtNumeroSecu";
            this.txtNumeroSecu.Size = new System.Drawing.Size(200, 23);
            this.txtNumeroSecu.TabIndex = 5;
            //
            // lblDateNaissance
            //
            this.lblDateNaissance.AutoSize = true;
            this.lblDateNaissance.Location = new System.Drawing.Point(24, 133);
            this.lblDateNaissance.Name = "lblDateNaissance";
            this.lblDateNaissance.Size = new System.Drawing.Size(96, 15);
            this.lblDateNaissance.TabIndex = 6;
            this.lblDateNaissance.Text = "Date de naissance";
            //
            // txtDateNaissance
            //
            this.txtDateNaissance.Location = new System.Drawing.Point(160, 130);
            this.txtDateNaissance.Name = "txtDateNaissance";
            this.txtDateNaissance.Size = new System.Drawing.Size(200, 23);
            this.txtDateNaissance.TabIndex = 7;
            //
            // lblFormatDate
            //
            this.lblFormatDate.AutoSize = true;
            this.lblFormatDate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFormatDate.Location = new System.Drawing.Point(160, 156);
            this.lblFormatDate.Name = "lblFormatDate";
            this.lblFormatDate.Size = new System.Drawing.Size(110, 15);
            this.lblFormatDate.TabIndex = 8;
            this.lblFormatDate.Text = "Format : jj/mm/aaaa";
            //
            // btnEnregistrer
            //
            this.btnEnregistrer.Location = new System.Drawing.Point(160, 190);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(110, 32);
            this.btnEnregistrer.TabIndex = 9;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            //
            // btnAnnuler
            //
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(276, 190);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(84, 32);
            this.btnAnnuler.TabIndex = 10;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            //
            // PatientEditForm
            //
            this.AcceptButton = this.btnEnregistrer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.lblFormatDate);
            this.Controls.Add(this.txtDateNaissance);
            this.Controls.Add(this.lblDateNaissance);
            this.Controls.Add(this.txtNumeroSecu);
            this.Controls.Add(this.lblNumeroSecu);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblNom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patient";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblNumeroSecu;
        private System.Windows.Forms.TextBox txtNumeroSecu;
        private System.Windows.Forms.Label lblDateNaissance;
        private System.Windows.Forms.TextBox txtDateNaissance;
        private System.Windows.Forms.Label lblFormatDate;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}
