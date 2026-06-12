namespace GSB
{
    partial class Sign_up
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
            button1 = new Button();
            button2 = new Button();
            textBox_mdp = new TextBox();
            textBox_mdp2 = new TextBox();
            textBox_mail = new TextBox();
            textBox_rpps = new TextBox();
            textBox_prénom = new TextBox();
            textBox_nom = new TextBox();
            label7 = new Label();
            dateTimePicker_ddn = new DateTimePicker();
            label8 = new Label();
            textBox_specialite = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(359, 142);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 2;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 142);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 3;
            label2.Text = "Num RPPS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(359, 57);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 4;
            label3.Text = "Prénom";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(107, 57);
            label4.Name = "label4";
            label4.Size = new Size(52, 25);
            label4.TabIndex = 5;
            label4.Text = "Nom";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(107, 227);
            label5.Name = "label5";
            label5.Size = new Size(120, 25);
            label5.TabIndex = 6;
            label5.Text = "Mot de passe";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(106, 312);
            label6.Name = "label6";
            label6.Size = new Size(222, 25);
            label6.TabIndex = 7;
            label6.Text = "Confirmer le mot de passe";
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Location = new Point(107, 397);
            label7.Name = "label7";
            label7.Size = new Size(154, 25);
            label7.TabIndex = 24;
            label7.Text = "Date de naissance";
            //
            // dateTimePicker_ddn
            //
            dateTimePicker_ddn.Format = DateTimePickerFormat.Short;
            dateTimePicker_ddn.Location = new Point(107, 425);
            dateTimePicker_ddn.Name = "dateTimePicker_ddn";
            dateTimePicker_ddn.Size = new Size(222, 31);
            dateTimePicker_ddn.TabIndex = 25;
            //
            // label8
            //
            label8.AutoSize = true;
            label8.Location = new Point(359, 397);
            label8.Name = "label8";
            label8.Size = new Size(94, 25);
            label8.TabIndex = 26;
            label8.Text = "Spécialité";
            //
            // textBox_specialite
            //
            textBox_specialite.Location = new Point(359, 425);
            textBox_specialite.Name = "textBox_specialite";
            textBox_specialite.Size = new Size(261, 31);
            textBox_specialite.TabIndex = 27;
            //
            // button1
            //
            button1.Location = new Point(176, 490);
            button1.Name = "button1";
            button1.Size = new Size(368, 63);
            button1.TabIndex = 8;
            button1.Text = "S'inscrire";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(176, 577);
            button2.Name = "button2";
            button2.Size = new Size(368, 44);
            button2.TabIndex = 9;
            button2.Text = "Se connecter";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox_mdp
            // 
            textBox_mdp.Location = new Point(107, 255);
            textBox_mdp.Name = "textBox_mdp";
            textBox_mdp.Size = new Size(513, 31);
            textBox_mdp.TabIndex = 18;
            textBox_mdp.UseSystemPasswordChar = true;
            // 
            // textBox_mdp2
            // 
            textBox_mdp2.Location = new Point(106, 353);
            textBox_mdp2.Name = "textBox_mdp2";
            textBox_mdp2.Size = new Size(514, 31);
            textBox_mdp2.TabIndex = 19;
            textBox_mdp2.UseSystemPasswordChar = true;
            // 
            // textBox_mail
            // 
            textBox_mail.Location = new Point(359, 183);
            textBox_mail.Name = "textBox_mail";
            textBox_mail.Size = new Size(261, 31);
            textBox_mail.TabIndex = 20;
            // 
            // textBox_rpps
            // 
            textBox_rpps.Location = new Point(107, 183);
            textBox_rpps.Name = "textBox_rpps";
            textBox_rpps.Size = new Size(222, 31);
            textBox_rpps.TabIndex = 21;
            // 
            // textBox_prénom
            // 
            textBox_prénom.Location = new Point(359, 96);
            textBox_prénom.Name = "textBox_prénom";
            textBox_prénom.Size = new Size(185, 31);
            textBox_prénom.TabIndex = 22;
            // 
            // textBox_nom
            // 
            textBox_nom.Location = new Point(107, 96);
            textBox_nom.Name = "textBox_nom";
            textBox_nom.Size = new Size(168, 31);
            textBox_nom.TabIndex = 23;
            // 
            // Sign_up
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 660);
            Controls.Add(textBox_specialite);
            Controls.Add(label8);
            Controls.Add(dateTimePicker_ddn);
            Controls.Add(label7);
            Controls.Add(textBox_nom);
            Controls.Add(textBox_prénom);
            Controls.Add(textBox_rpps);
            Controls.Add(textBox_mail);
            Controls.Add(textBox_mdp2);
            Controls.Add(textBox_mdp);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Sign_up";
            Text = "S'inscrire";
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
        private Button button1;
        private Button button2;
        private TextBox textBox_mdp;
        private TextBox textBox_mdp2;
        private TextBox textBox_mail;
        private TextBox textBox_rpps;
        private TextBox textBox_prénom;
        private TextBox textBox_nom;
        private Label label7;
        private DateTimePicker dateTimePicker_ddn;
        private Label label8;
        private TextBox textBox_specialite;
    }
}