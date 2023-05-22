namespace Leo_Espedilla_BSIT_2A
{
    partial class LogInForm
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
            tbxUserName = new TextBox();
            tbxPassword = new TextBox();
            btnLogin = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(162, 64);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 0;
            label1.Text = "USERNAME:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(162, 135);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 1;
            label2.Text = "PASSWORD:";
            // 
            // tbxUserName
            // 
            tbxUserName.BackColor = Color.FromArgb(255, 255, 128);
            tbxUserName.Location = new Point(266, 55);
            tbxUserName.Name = "tbxUserName";
            tbxUserName.Size = new Size(288, 23);
            tbxUserName.TabIndex = 2;
            tbxUserName.Text = "Enter Username";
            tbxUserName.Click += tbxUserName_Click;
            tbxUserName.TextChanged += tbxUserName_TextChanged;
            // 
            // tbxPassword
            // 
            tbxPassword.BackColor = Color.FromArgb(255, 255, 128);
            tbxPassword.Location = new Point(269, 136);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(288, 23);
            tbxPassword.TabIndex = 3;
            tbxPassword.Text = "Enter Password";
            tbxPassword.Click += tbxPassword_Click;
            tbxPassword.TextChanged += tbxPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(371, 192);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnSignIn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.home;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(86, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 48);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources._lock;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(86, 118);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(54, 48);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(tbxUserName);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(tbxPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.ForeColor = Color.FromArgb(255, 128, 0);
            panel1.Location = new Point(259, 252);
            panel1.Name = "panel1";
            panel1.Size = new Size(653, 291);
            panel1.TabIndex = 0;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.canva_GE1VgGXfWV4;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1107, 691);
            Controls.Add(panel1);
            Name = "LogInForm";
            Text = "LogInForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbxUserName;
        private TextBox tbxPassword;
        private Button btnLogin;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel1;
    }
}