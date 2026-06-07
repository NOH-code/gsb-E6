namespace GSB
{
    partial class Connexion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_login = new Button();
            label1 = new Label();
            textBox_id = new TextBox();
            label2 = new Label();
            textBox_mdp = new TextBox();
            button_signup = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // button_login
            // 
            button_login.Location = new Point(210, 260);
            button_login.Name = "button_login";
            button_login.Size = new Size(368, 63);
            button_login.TabIndex = 0;
            button_login.Text = "Se connecter";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(207, 23);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 1;
            label1.Text = "Identifiant";
            // 
            // textBox_id
            // 
            textBox_id.Location = new Point(207, 72);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(150, 31);
            textBox_id.TabIndex = 2;
            textBox_id.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 6;
            // 
            // textBox_mdp
            // 
            textBox_mdp.Location = new Point(207, 175);
            textBox_mdp.Name = "textBox_mdp";
            textBox_mdp.Size = new Size(241, 31);
            textBox_mdp.TabIndex = 4;
            // 
            // button_signup
            // 
            button_signup.Location = new Point(207, 358);
            button_signup.Name = "button_signup";
            button_signup.Size = new Size(368, 34);
            button_signup.TabIndex = 5;
            button_signup.Text = "Créer un compte";
            button_signup.UseVisualStyleBackColor = true;
            button_signup.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(210, 129);
            label3.Name = "label3";
            label3.Size = new Size(120, 25);
            label3.TabIndex = 7;
            label3.Text = "Mot de passe";
            label3.Click += label3_Click;
            // 
            // Connexion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(button_signup);
            Controls.Add(textBox_mdp);
            Controls.Add(label2);
            Controls.Add(textBox_id);
            Controls.Add(label1);
            Controls.Add(button_login);
            Name = "Connexion";
            Text = "Se connecter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_login;
        private Label label1;
        private TextBox textBox_id;
        private Label label2;
        private TextBox textBox_mdp;
        private Button button_signup;
        private Label label3;
    }
}
