namespace Leo_Espedilla_BSIT_2A
{
    partial class MainForm
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnReserv = new Button();
            btnPayment = new Button();
            btnRoomInfo = new Button();
            btnStudIn = new Button();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnReserv);
            panel1.Controls.Add(btnPayment);
            panel1.Controls.Add(btnRoomInfo);
            panel1.Controls.Add(btnStudIn);
            panel1.Location = new Point(12, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(519, 438);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.BACKREMOVE;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(29, 105);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(224, 225);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnReserv
            // 
            btnReserv.BackColor = Color.Black;
            btnReserv.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReserv.ForeColor = Color.Gold;
            btnReserv.Location = new Point(280, 322);
            btnReserv.Name = "btnReserv";
            btnReserv.Size = new Size(211, 43);
            btnReserv.TabIndex = 3;
            btnReserv.Text = "Reservation";
            btnReserv.UseVisualStyleBackColor = false;
            btnReserv.Click += btnReserv_Click;
            // 
            // btnPayment
            // 
            btnPayment.BackColor = Color.Black;
            btnPayment.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPayment.ForeColor = Color.Gold;
            btnPayment.Location = new Point(280, 244);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(211, 43);
            btnPayment.TabIndex = 2;
            btnPayment.Text = "Monthly Payment";
            btnPayment.UseVisualStyleBackColor = false;
            btnPayment.Click += btnPayment_Click;
            // 
            // btnRoomInfo
            // 
            btnRoomInfo.BackColor = Color.Black;
            btnRoomInfo.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRoomInfo.ForeColor = Color.Gold;
            btnRoomInfo.Location = new Point(280, 171);
            btnRoomInfo.Name = "btnRoomInfo";
            btnRoomInfo.Size = new Size(211, 43);
            btnRoomInfo.TabIndex = 1;
            btnRoomInfo.Text = "Room Information";
            btnRoomInfo.UseVisualStyleBackColor = false;
            btnRoomInfo.Click += btnRoomInfo_Click;
            // 
            // btnStudIn
            // 
            btnStudIn.BackColor = Color.Black;
            btnStudIn.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnStudIn.ForeColor = Color.Gold;
            btnStudIn.Location = new Point(280, 105);
            btnStudIn.Name = "btnStudIn";
            btnStudIn.Size = new Size(211, 43);
            btnStudIn.TabIndex = 0;
            btnStudIn.Text = "Student Information";
            btnStudIn.UseVisualStyleBackColor = false;
            btnStudIn.Click += btnStudIn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Script MT Bold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Gold;
            label5.Location = new Point(90, 262);
            label5.Name = "label5";
            label5.Size = new Size(107, 25);
            label5.TabIndex = 7;
            label5.Text = "S . B . I . S";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Script MT Bold", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.Orange;
            label2.Location = new Point(447, 87);
            label2.Name = "label2";
            label2.Size = new Size(451, 44);
            label2.TabIndex = 4;
            label2.Text = "House  Information   System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Script MT Bold", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Orange;
            label1.Location = new Point(76, 29);
            label1.Name = "label1";
            label1.Size = new Size(483, 44);
            label1.TabIndex = 3;
            label1.Text = "Welcome  to  Student  Boarding";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.Gold;
            label13.Location = new Point(542, 554);
            label13.Name = "label13";
            label13.Size = new Size(404, 25);
            label13.TabIndex = 22;
            label13.Text = " personally, preparing them for a bright future.";
            label13.Click += label13_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.Gold;
            label12.Location = new Point(541, 509);
            label12.Name = "label12";
            label12.Size = new Size(488, 25);
            label12.TabIndex = 21;
            label12.Text = "home where students flourish academically, socially, and";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.Gold;
            label11.Location = new Point(588, 474);
            label11.Name = "label11";
            label11.Size = new Size(372, 25);
            label11.TabIndex = 20;
            label11.Text = "Creating a transformative home away from";
            label11.Click += label11_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Century Schoolbook", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.Gold;
            label10.Location = new Point(592, 437);
            label10.Name = "label10";
            label10.Size = new Size(109, 25);
            label10.TabIndex = 19;
            label10.Text = "VISION...";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Gold;
            label9.Location = new Point(541, 338);
            label9.Name = "label9";
            label9.Size = new Size(411, 25);
            label9.TabIndex = 18;
            label9.Text = " supportive and enriching boarding experience.";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Gold;
            label8.Location = new Point(688, 300);
            label8.Name = "label8";
            label8.Size = new Size(342, 25);
            label8.TabIndex = 17;
            label8.Text = "Empowering student success through a";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Gold;
            label7.Location = new Point(541, 300);
            label7.Name = "label7";
            label7.Size = new Size(151, 25);
            label7.TabIndex = 16;
            label7.Text = " academic goals.";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Gold;
            label6.Location = new Point(541, 257);
            label6.Name = "label6";
            label6.Size = new Size(473, 25);
            label6.TabIndex = 15;
            label6.Text = "where students can live and thrive while pursuing their";
            label6.Click += label6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(592, 222);
            label4.Name = "label4";
            label4.Size = new Size(472, 25);
            label4.TabIndex = 14;
            label4.Text = "to provide a safe, nurturing, and inclusive environment";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Schoolbook", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(592, 185);
            label3.Name = "label3";
            label3.Size = new Size(127, 25);
            label3.TabIndex = 13;
            label3.Text = "MISSION...";
            label3.Click += label3_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._0001;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1107, 691);
            Controls.Add(label13);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label12);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label11);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label10);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            DoubleBuffered = true;
            Name = "MainForm";
            Text = "MainForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnReserv;
        private Button btnPayment;
        private Button btnRoomInfo;
        private Button btnStudIn;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label3;
        private Label label6;
        private Label label4;
        private Label label2;
        private Label label1;
    }
}