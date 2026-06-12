namespace GSB.Vue
{
    partial class PatientListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPatients = new DataGridView();
            txtRecherche = new TextBox();
            btnRechercher = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPatients.ColumnHeadersHeight = 34;
            dgvPatients.Location = new Point(12, 189);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 62;
            dgvPatients.Size = new Size(776, 249);
            dgvPatients.TabIndex = 0;
            dgvPatients.CellContentClick += dgvPatients_CellContentClick;
            // 
            // txtRecherche
            // 
            txtRecherche.Location = new Point(12, 32);
            txtRecherche.Name = "txtRecherche";
            txtRecherche.Size = new Size(350, 31);
            txtRecherche.TabIndex = 1;
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new Point(564, 29);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(112, 34);
            btnRechercher.TabIndex = 2;
            btnRechercher.Text = "Rechercher";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(564, 84);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // PatientListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(btnRechercher);
            Controls.Add(txtRecherche);
            Controls.Add(dgvPatients);
            StartPosition = FormStartPosition.CenterScreen;
            Name = "PatientListForm";
            Text = "Liste des patients";
            Load += PatientListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPatients;
        private TextBox txtRecherche;
        private Button btnRechercher;
        private Button btnReset;
    }
}