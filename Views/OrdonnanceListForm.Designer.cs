namespace GSB_Ordonnances.Views
{
    partial class OrdonnanceListForm
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
            this.lblOrdonnances = new System.Windows.Forms.Label();
            this.dgvOrdonnances = new System.Windows.Forms.DataGridView();
            this.lblLignes = new System.Windows.Forms.Label();
            this.dgvLignes = new System.Windows.Forms.DataGridView();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdonnances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).BeginInit();
            this.SuspendLayout();
            //
            // lblOrdonnances
            //
            this.lblOrdonnances.AutoSize = true;
            this.lblOrdonnances.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdonnances.Location = new System.Drawing.Point(16, 14);
            this.lblOrdonnances.Name = "lblOrdonnances";
            this.lblOrdonnances.Size = new System.Drawing.Size(85, 15);
            this.lblOrdonnances.TabIndex = 0;
            this.lblOrdonnances.Text = "Ordonnances";
            //
            // dgvOrdonnances
            //
            this.dgvOrdonnances.AllowUserToAddRows = false;
            this.dgvOrdonnances.AllowUserToDeleteRows = false;
            this.dgvOrdonnances.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdonnances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdonnances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdonnances.Location = new System.Drawing.Point(16, 34);
            this.dgvOrdonnances.MultiSelect = false;
            this.dgvOrdonnances.Name = "dgvOrdonnances";
            this.dgvOrdonnances.ReadOnly = true;
            this.dgvOrdonnances.RowHeadersVisible = false;
            this.dgvOrdonnances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdonnances.Size = new System.Drawing.Size(620, 170);
            this.dgvOrdonnances.TabIndex = 1;
            this.dgvOrdonnances.SelectionChanged += new System.EventHandler(this.dgvOrdonnances_SelectionChanged);
            //
            // lblLignes
            //
            this.lblLignes.AutoSize = true;
            this.lblLignes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLignes.Location = new System.Drawing.Point(16, 218);
            this.lblLignes.Name = "lblLignes";
            this.lblLignes.Size = new System.Drawing.Size(146, 15);
            this.lblLignes.TabIndex = 2;
            this.lblLignes.Text = "Lignes de l'ordonnance";
            //
            // dgvLignes
            //
            this.dgvLignes.AllowUserToAddRows = false;
            this.dgvLignes.AllowUserToDeleteRows = false;
            this.dgvLignes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLignes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLignes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLignes.Location = new System.Drawing.Point(16, 238);
            this.dgvLignes.MultiSelect = false;
            this.dgvLignes.Name = "dgvLignes";
            this.dgvLignes.ReadOnly = true;
            this.dgvLignes.RowHeadersVisible = false;
            this.dgvLignes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLignes.Size = new System.Drawing.Size(620, 170);
            this.dgvLignes.TabIndex = 3;
            //
            // btnFermer
            //
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Location = new System.Drawing.Point(546, 416);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(90, 32);
            this.btnFermer.TabIndex = 4;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            //
            // OrdonnanceListForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 460);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.dgvLignes);
            this.Controls.Add(this.lblLignes);
            this.Controls.Add(this.dgvOrdonnances);
            this.Controls.Add(this.lblOrdonnances);
            this.MinimumSize = new System.Drawing.Size(668, 499);
            this.Name = "OrdonnanceListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ordonnances du patient";
            this.Load += new System.EventHandler(this.OrdonnanceListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdonnances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblOrdonnances;
        private System.Windows.Forms.DataGridView dgvOrdonnances;
        private System.Windows.Forms.Label lblLignes;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.Button btnFermer;
    }
}
