namespace GSB
{
    partial class Création_patient
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
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label2 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            labelAllergies = new Label();
            label_titre = new Label();
            textBox_nom = new TextBox();
            textBox_prénom = new TextBox();
            dateTimePicker_ddn = new DateTimePicker();
            comboBox_sex = new ComboBox();
            numericUpDown_poids = new NumericUpDown();
            numericUpDown_taille = new NumericUpDown();
            textBox_numsécu = new TextBox();
            textBox_pathologie = new TextBox();
            clbAllergies = new CheckedListBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_poids).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_taille).BeginInit();
            SuspendLayout();
            //
            // label_titre
            //
            label_titre.AutoSize = true;
            label_titre.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label_titre.Location = new Point(40, 20);
            label_titre.Name = "label_titre";
            label_titre.Size = new Size(250, 38);
            label_titre.TabIndex = 0;
            label_titre.Text = "Nouveau patient";
            //
            // label8
            //
            label8.AutoSize = true;
            label8.Location = new Point(40, 80);
            label8.Name = "label8";
            label8.Size = new Size(52, 25);
            label8.TabIndex = 1;
            label8.Text = "Nom";
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Location = new Point(300, 80);
            label7.Name = "label7";
            label7.Size = new Size(74, 25);
            label7.TabIndex = 2;
            label7.Text = "Prénom";
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(40, 160);
            label6.Name = "label6";
            label6.Size = new Size(154, 25);
            label6.TabIndex = 3;
            label6.Text = "Date de naissance";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(300, 160);
            label2.Name = "label2";
            label2.Size = new Size(45, 25);
            label2.TabIndex = 4;
            label2.Text = "Sexe";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(40, 240);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 5;
            label5.Text = "Poids (kg)";
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(300, 240);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 6;
            label3.Text = "Taille (cm)";
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(40, 320);
            label4.Name = "label4";
            label4.Size = new Size(225, 25);
            label4.TabIndex = 7;
            label4.Text = "Numéro de sécurité sociale";
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(40, 400);
            label1.Name = "label1";
            label1.Size = new Size(114, 25);
            label1.TabIndex = 8;
            label1.Text = "Pathologie(s)";
            //
            // labelAllergies
            //
            labelAllergies.AutoSize = true;
            labelAllergies.Location = new Point(560, 80);
            labelAllergies.Name = "labelAllergies";
            labelAllergies.Size = new Size(80, 25);
            labelAllergies.TabIndex = 9;
            labelAllergies.Text = "Allergies";
            //
            // textBox_nom
            //
            textBox_nom.Location = new Point(40, 110);
            textBox_nom.Name = "textBox_nom";
            textBox_nom.Size = new Size(230, 31);
            textBox_nom.TabIndex = 10;
            //
            // textBox_prénom
            //
            textBox_prénom.Location = new Point(300, 110);
            textBox_prénom.Name = "textBox_prénom";
            textBox_prénom.Size = new Size(230, 31);
            textBox_prénom.TabIndex = 11;
            //
            // dateTimePicker_ddn
            //
            dateTimePicker_ddn.Format = DateTimePickerFormat.Short;
            dateTimePicker_ddn.Location = new Point(40, 190);
            dateTimePicker_ddn.Name = "dateTimePicker_ddn";
            dateTimePicker_ddn.Size = new Size(230, 31);
            dateTimePicker_ddn.TabIndex = 12;
            //
            // comboBox_sex
            //
            comboBox_sex.FormattingEnabled = true;
            comboBox_sex.Location = new Point(300, 190);
            comboBox_sex.Name = "comboBox_sex";
            comboBox_sex.Size = new Size(230, 33);
            comboBox_sex.TabIndex = 13;
            //
            // numericUpDown_poids
            //
            numericUpDown_poids.Location = new Point(40, 270);
            numericUpDown_poids.Name = "numericUpDown_poids";
            numericUpDown_poids.Size = new Size(150, 31);
            numericUpDown_poids.TabIndex = 14;
            //
            // numericUpDown_taille
            //
            numericUpDown_taille.Location = new Point(300, 270);
            numericUpDown_taille.Name = "numericUpDown_taille";
            numericUpDown_taille.Size = new Size(150, 31);
            numericUpDown_taille.TabIndex = 15;
            //
            // textBox_numsécu
            //
            textBox_numsécu.Location = new Point(40, 350);
            textBox_numsécu.Name = "textBox_numsécu";
            textBox_numsécu.Size = new Size(490, 31);
            textBox_numsécu.TabIndex = 16;
            //
            // textBox_pathologie
            //
            textBox_pathologie.Location = new Point(40, 430);
            textBox_pathologie.Name = "textBox_pathologie";
            textBox_pathologie.Size = new Size(490, 31);
            textBox_pathologie.TabIndex = 17;
            //
            // clbAllergies
            //
            clbAllergies.CheckOnClick = true;
            clbAllergies.FormattingEnabled = true;
            clbAllergies.Location = new Point(560, 110);
            clbAllergies.Name = "clbAllergies";
            clbAllergies.Size = new Size(240, 350);
            clbAllergies.TabIndex = 18;
            //
            // button1
            //
            button1.Location = new Point(40, 500);
            button1.Name = "button1";
            button1.Size = new Size(490, 55);
            button1.TabIndex = 19;
            button1.Text = "Créer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            //
            // Création_patient
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 590);
            Controls.Add(label_titre);
            Controls.Add(button1);
            Controls.Add(clbAllergies);
            Controls.Add(textBox_pathologie);
            Controls.Add(textBox_numsécu);
            Controls.Add(numericUpDown_taille);
            Controls.Add(numericUpDown_poids);
            Controls.Add(comboBox_sex);
            Controls.Add(dateTimePicker_ddn);
            Controls.Add(textBox_prénom);
            Controls.Add(textBox_nom);
            Controls.Add(labelAllergies);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "Création_patient";
            Text = "Nouveau patient";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_poids).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_taille).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_titre;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label labelAllergies;
        private Button button1;
        private TextBox textBox_pathologie;
        private TextBox textBox_numsécu;
        private TextBox textBox_prénom;
        private TextBox textBox_nom;
        private DateTimePicker dateTimePicker_ddn;
        private ComboBox comboBox_sex;
        private NumericUpDown numericUpDown_poids;
        private NumericUpDown numericUpDown_taille;
        private CheckedListBox clbAllergies;
    }
}
