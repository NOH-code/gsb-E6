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
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            textBox_pathologie = new TextBox();
            textBox_numsécu = new TextBox();
            textBox_prénom = new TextBox();
            textBox_nom = new TextBox();
            dateTimePicker_ddn = new DateTimePicker();
            comboBox_sex = new ComboBox();
            numericUpDown_poids = new NumericUpDown();
            numericUpDown_taille = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_poids).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_taille).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 359);
            label4.Name = "label4";
            label4.Size = new Size(225, 25);
            label4.TabIndex = 6;
            label4.Text = "Numéro de sécurité sociale";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(291, 242);
            label1.Name = "label1";
            label1.Size = new Size(114, 25);
            label1.TabIndex = 7;
            label1.Text = "Pathologie(s)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 242);
            label2.Name = "label2";
            label2.Size = new Size(39, 25);
            label2.TabIndex = 8;
            label2.Text = "Sex";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(573, 158);
            label3.Name = "label3";
            label3.Size = new Size(49, 25);
            label3.TabIndex = 9;
            label3.Text = "Taille";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(391, 158);
            label5.Name = "label5";
            label5.Size = new Size(55, 25);
            label5.TabIndex = 10;
            label5.Text = "Poids";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(56, 158);
            label6.Name = "label6";
            label6.Size = new Size(154, 25);
            label6.TabIndex = 11;
            label6.Text = "Date de naissance";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(391, 52);
            label7.Name = "label7";
            label7.Size = new Size(74, 25);
            label7.TabIndex = 12;
            label7.Text = "Prénom";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(56, 52);
            label8.Name = "label8";
            label8.Size = new Size(52, 25);
            label8.TabIndex = 13;
            label8.Text = "Nom";
            // 
            // button1
            // 
            button1.Location = new Point(207, 491);
            button1.Name = "button1";
            button1.Size = new Size(368, 63);
            button1.TabIndex = 14;
            button1.Text = "Créer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox_pathologie
            // 
            textBox_pathologie.Location = new Point(288, 290);
            textBox_pathologie.Name = "textBox_pathologie";
            textBox_pathologie.Size = new Size(171, 31);
            textBox_pathologie.TabIndex = 24;
            textBox_pathologie.TextChanged += textBox5_TextChanged;
            // 
            // textBox_numsécu
            // 
            textBox_numsécu.Location = new Point(56, 413);
            textBox_numsécu.Name = "textBox_numsécu";
            textBox_numsécu.Size = new Size(312, 31);
            textBox_numsécu.TabIndex = 25;
            // 
            // textBox_prénom
            // 
            textBox_prénom.Location = new Point(391, 98);
            textBox_prénom.Name = "textBox_prénom";
            textBox_prénom.Size = new Size(168, 31);
            textBox_prénom.TabIndex = 26;
            // 
            // textBox_nom
            // 
            textBox_nom.Location = new Point(56, 98);
            textBox_nom.Name = "textBox_nom";
            textBox_nom.Size = new Size(168, 31);
            textBox_nom.TabIndex = 27;
            textBox_nom.TextChanged += textBox3_TextChanged;
            // 
            // dateTimePicker_ddn
            // 
            dateTimePicker_ddn.Location = new Point(56, 196);
            dateTimePicker_ddn.Name = "dateTimePicker_ddn";
            dateTimePicker_ddn.Size = new Size(276, 31);
            dateTimePicker_ddn.TabIndex = 28;
            dateTimePicker_ddn.ValueChanged += dateTimePicker_ddn_ValueChanged;
            // 
            // comboBox_sex
            // 
            comboBox_sex.FormattingEnabled = true;
            comboBox_sex.Location = new Point(56, 288);
            comboBox_sex.Name = "comboBox_sex";
            comboBox_sex.Size = new Size(154, 33);
            comboBox_sex.TabIndex = 30;
            // 
            // numericUpDown_poids
            // 
            numericUpDown_poids.Location = new Point(391, 196);
            numericUpDown_poids.Name = "numericUpDown_poids";
            numericUpDown_poids.Size = new Size(76, 31);
            numericUpDown_poids.TabIndex = 32;
            numericUpDown_poids.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // numericUpDown_taille
            // 
            numericUpDown_taille.Location = new Point(581, 196);
            numericUpDown_taille.Name = "numericUpDown_taille";
            numericUpDown_taille.Size = new Size(86, 31);
            numericUpDown_taille.TabIndex = 33;
            // 
            // Création_patient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 617);
            Controls.Add(numericUpDown_taille);
            Controls.Add(numericUpDown_poids);
            Controls.Add(comboBox_sex);
            Controls.Add(dateTimePicker_ddn);
            Controls.Add(textBox_nom);
            Controls.Add(textBox_prénom);
            Controls.Add(textBox_numsécu);
            Controls.Add(textBox_pathologie);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Name = "Création_patient";
            Text = "Création_patient";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_poids).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_taille).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button1;
        private TextBox textBox_pathologie;
        private TextBox textBox_numsécu;
        private TextBox textBox_prénom;
        private TextBox textBox_nom;
        private DateTimePicker dateTimePicker_ddn;
        private ComboBox comboBox_sex;
        private NumericUpDown numericUpDown_poids;
        private NumericUpDown numericUpDown_taille;
    }
}