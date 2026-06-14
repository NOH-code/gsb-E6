namespace GSB
{
    partial class Recherche_patient
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            labelAllergies = new Label();
            comboBoxPatient = new ComboBox();
            buttonAddPatient = new Button();
            textBoxName = new TextBox();
            textBoxFirstname = new TextBox();
            textBoxBirthdate = new TextBox();
            textBoxSexe = new TextBox();
            textBoxTaille = new TextBox();
            textBoxPoids = new TextBox();
            textBoxNumSecu = new TextBox();
            textBoxPathologie = new TextBox();
            clbAllergies = new CheckedListBox();
            buttonModifierPatient = new Button();
            buttonSupprimerPatient = new Button();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(40, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 38);
            label1.TabIndex = 0;
            label1.Text = "Patient";
            //
            // comboBoxPatient
            //
            comboBoxPatient.FormattingEnabled = true;
            comboBoxPatient.Location = new Point(40, 65);
            comboBoxPatient.Name = "comboBoxPatient";
            comboBoxPatient.Size = new Size(300, 33);
            comboBoxPatient.TabIndex = 1;
            comboBoxPatient.SelectedIndexChanged += comboBoxPatient_SelectedIndexChanged;
            //
            // buttonAddPatient
            //
            buttonAddPatient.Location = new Point(356, 64);
            buttonAddPatient.Name = "buttonAddPatient";
            buttonAddPatient.Size = new Size(50, 35);
            buttonAddPatient.TabIndex = 2;
            buttonAddPatient.Text = "+";
            buttonAddPatient.UseVisualStyleBackColor = true;
            buttonAddPatient.Click += button1_Click;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(40, 130);
            label2.Name = "label2";
            label2.Size = new Size(52, 25);
            label2.TabIndex = 3;
            label2.Text = "Nom";
            //
            // textBoxName
            //
            textBoxName.Location = new Point(40, 160);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(230, 31);
            textBoxName.TabIndex = 4;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(300, 130);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 5;
            label3.Text = "Prénom";
            //
            // textBoxFirstname
            //
            textBoxFirstname.Location = new Point(300, 160);
            textBoxFirstname.Name = "textBoxFirstname";
            textBoxFirstname.Size = new Size(230, 31);
            textBoxFirstname.TabIndex = 6;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(40, 210);
            label4.Name = "label4";
            label4.Size = new Size(154, 25);
            label4.TabIndex = 7;
            label4.Text = "Date de naissance";
            //
            // textBoxBirthdate
            //
            textBoxBirthdate.Location = new Point(40, 240);
            textBoxBirthdate.Name = "textBoxBirthdate";
            textBoxBirthdate.Size = new Size(230, 31);
            textBoxBirthdate.TabIndex = 8;
            //
            // label8
            //
            label8.AutoSize = true;
            label8.Location = new Point(300, 210);
            label8.Name = "label8";
            label8.Size = new Size(45, 25);
            label8.TabIndex = 9;
            label8.Text = "Sexe";
            //
            // textBoxSexe
            //
            textBoxSexe.Location = new Point(300, 240);
            textBoxSexe.Name = "textBoxSexe";
            textBoxSexe.Size = new Size(230, 31);
            textBoxSexe.TabIndex = 10;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(40, 290);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 11;
            label5.Text = "Taille (cm)";
            //
            // textBoxTaille
            //
            textBoxTaille.Location = new Point(40, 320);
            textBoxTaille.Name = "textBoxTaille";
            textBoxTaille.Size = new Size(230, 31);
            textBoxTaille.TabIndex = 12;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(300, 290);
            label6.Name = "label6";
            label6.Size = new Size(90, 25);
            label6.TabIndex = 13;
            label6.Text = "Poids (kg)";
            //
            // textBoxPoids
            //
            textBoxPoids.Location = new Point(300, 320);
            textBoxPoids.Name = "textBoxPoids";
            textBoxPoids.Size = new Size(230, 31);
            textBoxPoids.TabIndex = 14;
            //
            // label9
            //
            label9.AutoSize = true;
            label9.Location = new Point(40, 370);
            label9.Name = "label9";
            label9.Size = new Size(225, 25);
            label9.TabIndex = 15;
            label9.Text = "Numéro de sécurité sociale";
            //
            // textBoxNumSecu
            //
            textBoxNumSecu.Location = new Point(40, 400);
            textBoxNumSecu.Name = "textBoxNumSecu";
            textBoxNumSecu.Size = new Size(490, 31);
            textBoxNumSecu.TabIndex = 16;
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Location = new Point(40, 450);
            label7.Name = "label7";
            label7.Size = new Size(96, 25);
            label7.TabIndex = 17;
            label7.Text = "Pathologie";
            //
            // textBoxPathologie
            //
            textBoxPathologie.Location = new Point(40, 480);
            textBoxPathologie.Name = "textBoxPathologie";
            textBoxPathologie.Size = new Size(490, 31);
            textBoxPathologie.TabIndex = 18;
            //
            // labelAllergies
            //
            labelAllergies.AutoSize = true;
            labelAllergies.Location = new Point(560, 130);
            labelAllergies.Name = "labelAllergies";
            labelAllergies.Size = new Size(80, 25);
            labelAllergies.TabIndex = 19;
            labelAllergies.Text = "Allergies";
            //
            // clbAllergies
            //
            clbAllergies.CheckOnClick = true;
            clbAllergies.FormattingEnabled = true;
            clbAllergies.Location = new Point(560, 160);
            clbAllergies.Name = "clbAllergies";
            clbAllergies.Size = new Size(240, 351);
            clbAllergies.TabIndex = 20;
            //
            // buttonModifierPatient
            //
            buttonModifierPatient.Location = new Point(40, 530);
            buttonModifierPatient.Name = "buttonModifierPatient";
            buttonModifierPatient.Size = new Size(230, 50);
            buttonModifierPatient.TabIndex = 21;
            buttonModifierPatient.Text = "Modifier";
            buttonModifierPatient.UseVisualStyleBackColor = true;
            //
            // buttonSupprimerPatient
            //
            buttonSupprimerPatient.Location = new Point(300, 530);
            buttonSupprimerPatient.Name = "buttonSupprimerPatient";
            buttonSupprimerPatient.Size = new Size(230, 50);
            buttonSupprimerPatient.TabIndex = 22;
            buttonSupprimerPatient.Text = "Supprimer";
            buttonSupprimerPatient.UseVisualStyleBackColor = false;
            buttonSupprimerPatient.BackColor = Color.FromArgb(220, 53, 69);
            buttonSupprimerPatient.ForeColor = Color.White;
            buttonSupprimerPatient.FlatStyle = FlatStyle.Flat;
            //
            // label10
            //
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label10.Location = new Point(40, 610);
            label10.Name = "label10";
            label10.Size = new Size(269, 30);
            label10.TabIndex = 22;
            label10.Text = "Historique des ordonnances";
            //
            // button3
            //
            button3.Location = new Point(750, 605);
            button3.Name = "button3";
            button3.Size = new Size(50, 35);
            button3.TabIndex = 23;
            button3.Text = "+";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            //
            // dataGridView1
            //
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 650);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(760, 150);
            dataGridView1.TabIndex = 24;
            //
            // Recherche_patient
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 820);
            Controls.Add(button3);
            Controls.Add(label10);
            Controls.Add(dataGridView1);
            Controls.Add(buttonSupprimerPatient);
            Controls.Add(buttonModifierPatient);
            Controls.Add(clbAllergies);
            Controls.Add(labelAllergies);
            Controls.Add(textBoxPathologie);
            Controls.Add(label7);
            Controls.Add(textBoxNumSecu);
            Controls.Add(label9);
            Controls.Add(textBoxPoids);
            Controls.Add(label6);
            Controls.Add(textBoxTaille);
            Controls.Add(label5);
            Controls.Add(textBoxSexe);
            Controls.Add(label8);
            Controls.Add(textBoxBirthdate);
            Controls.Add(label4);
            Controls.Add(textBoxFirstname);
            Controls.Add(label3);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(buttonAddPatient);
            Controls.Add(comboBoxPatient);
            Controls.Add(label1);
            StartPosition = FormStartPosition.CenterScreen;
            Name = "Recherche_patient";
            Text = "Recherche de patient";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label labelAllergies;
        private ComboBox comboBoxPatient;
        private Button buttonAddPatient;
        private TextBox textBoxName;
        private TextBox textBoxFirstname;
        private TextBox textBoxBirthdate;
        private TextBox textBoxSexe;
        private TextBox textBoxTaille;
        private TextBox textBoxPoids;
        private TextBox textBoxNumSecu;
        private TextBox textBoxPathologie;
        private CheckedListBox clbAllergies;
        private Button buttonModifierPatient;
        private Button buttonSupprimerPatient;
        private DataGridView dataGridView1;
        private Button button3;
    }
}
