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
            textBoxName = new TextBox();
            textBoxFirstname = new TextBox();
            buttonAddPatient = new Button();
            textBoxBirthdate = new TextBox();
            textBoxTaille = new TextBox();
            textBoxPoids = new TextBox();
            textBoxSexe = new TextBox();
            textBoxPathologie = new TextBox();
            textBoxNumSecu = new TextBox();
            comboBoxPatient = new ComboBox();
            buttonModifierPatient = new Button();
            dataGridView1 = new DataGridView();
            label10 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 0;
            label1.Text = "Patient";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 107);
            label2.Name = "label2";
            label2.Size = new Size(52, 25);
            label2.TabIndex = 1;
            label2.Text = "Nom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 107);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 2;
            label3.Text = "Prénom";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 259);
            label4.Name = "label4";
            label4.Size = new Size(154, 25);
            label4.TabIndex = 3;
            label4.Text = "Date de naissance";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(278, 259);
            label5.Name = "label5";
            label5.Size = new Size(54, 25);
            label5.TabIndex = 4;
            label5.Text = "Taille ";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(493, 259);
            label6.Name = "label6";
            label6.Size = new Size(55, 25);
            label6.TabIndex = 5;
            label6.Text = "Poids";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(278, 367);
            label7.Name = "label7";
            label7.Size = new Size(96, 25);
            label7.TabIndex = 6;
            label7.Text = "Pathologie";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(64, 367);
            label8.Name = "label8";
            label8.Size = new Size(48, 25);
            label8.TabIndex = 7;
            label8.Text = "Sexe";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(64, 484);
            label9.Name = "label9";
            label9.Size = new Size(225, 25);
            label9.TabIndex = 8;
            label9.Text = "Numéro de sécurité sociale";
            label9.Click += label9_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(64, 158);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(213, 31);
            textBoxName.TabIndex = 9;
            // 
            // textBoxFirstname
            // 
            textBoxFirstname.Location = new Point(332, 158);
            textBoxFirstname.Name = "textBoxFirstname";
            textBoxFirstname.Size = new Size(226, 31);
            textBoxFirstname.TabIndex = 10;
            // 
            // buttonAddPatient
            // 
            buttonAddPatient.Location = new Point(493, 47);
            buttonAddPatient.Name = "buttonAddPatient";
            buttonAddPatient.Size = new Size(65, 33);
            buttonAddPatient.TabIndex = 11;
            buttonAddPatient.Text = "+";
            buttonAddPatient.UseVisualStyleBackColor = true;
            buttonAddPatient.Click += button1_Click;
            // 
            // textBoxBirthdate
            // 
            textBoxBirthdate.Location = new Point(64, 304);
            textBoxBirthdate.Name = "textBoxBirthdate";
            textBoxBirthdate.Size = new Size(150, 31);
            textBoxBirthdate.TabIndex = 12;
            // 
            // textBoxTaille
            // 
            textBoxTaille.Location = new Point(278, 304);
            textBoxTaille.Name = "textBoxTaille";
            textBoxTaille.Size = new Size(150, 31);
            textBoxTaille.TabIndex = 13;
            // 
            // textBoxPoids
            // 
            textBoxPoids.Location = new Point(496, 304);
            textBoxPoids.Name = "textBoxPoids";
            textBoxPoids.Size = new Size(150, 31);
            textBoxPoids.TabIndex = 14;
            // 
            // textBoxSexe
            // 
            textBoxSexe.Location = new Point(64, 419);
            textBoxSexe.Name = "textBoxSexe";
            textBoxSexe.Size = new Size(150, 31);
            textBoxSexe.TabIndex = 15;
            // 
            // textBoxPathologie
            // 
            textBoxPathologie.Location = new Point(278, 419);
            textBoxPathologie.Name = "textBoxPathologie";
            textBoxPathologie.Size = new Size(150, 31);
            textBoxPathologie.TabIndex = 16;
            // 
            // textBoxNumSecu
            // 
            textBoxNumSecu.Location = new Point(64, 538);
            textBoxNumSecu.Name = "textBoxNumSecu";
            textBoxNumSecu.Size = new Size(327, 31);
            textBoxNumSecu.TabIndex = 17;
            // 
            // comboBoxPatient
            // 
            comboBoxPatient.FormattingEnabled = true;
            comboBoxPatient.Location = new Point(64, 47);
            comboBoxPatient.Name = "comboBoxPatient";
            comboBoxPatient.Size = new Size(268, 33);
            comboBoxPatient.TabIndex = 18;
            comboBoxPatient.SelectedIndexChanged += comboBoxPatient_SelectedIndexChanged;
            // 
            // buttonModifierPatient
            // 
            buttonModifierPatient.Location = new Point(493, 511);
            buttonModifierPatient.Name = "buttonModifierPatient";
            buttonModifierPatient.Size = new Size(153, 58);
            buttonModifierPatient.TabIndex = 19;
            buttonModifierPatient.Text = "Modifier";
            buttonModifierPatient.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(64, 710);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(582, 185);
            dataGridView1.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(64, 654);
            label10.Name = "label10";
            label10.Size = new Size(235, 25);
            label10.TabIndex = 22;
            label10.Text = "Historique des ordonnances";
            // 
            // button3
            // 
            button3.Location = new Point(548, 654);
            button3.Name = "button3";
            button3.Size = new Size(98, 44);
            button3.TabIndex = 23;
            button3.Text = "+";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Recherche_patient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 940);
            Controls.Add(button3);
            Controls.Add(label10);
            Controls.Add(dataGridView1);
            Controls.Add(buttonModifierPatient);
            Controls.Add(comboBoxPatient);
            Controls.Add(textBoxNumSecu);
            Controls.Add(textBoxPathologie);
            Controls.Add(textBoxSexe);
            Controls.Add(textBoxPoids);
            Controls.Add(textBoxTaille);
            Controls.Add(textBoxBirthdate);
            Controls.Add(buttonAddPatient);
            Controls.Add(textBoxFirstname);
            Controls.Add(textBoxName);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private TextBox textBoxName;
        private TextBox textBoxFirstname;
        private Button buttonAddPatient;
        private TextBox textBoxBirthdate;
        private TextBox textBoxTaille;
        private TextBox textBoxPoids;
        private TextBox textBoxSexe;
        private TextBox textBoxPathologie;
        private TextBox textBoxNumSecu;
        private ComboBox comboBoxPatient;
        private Button buttonModifierPatient;
        private DataGridView dataGridView1;
        private Label label10;
        private Button button3;
    }
}