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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnReserv);
            panel1.Controls.Add(btnPayment);
            panel1.Controls.Add(btnRoomInfo);
            panel1.Controls.Add(btnStudIn);
            panel1.Location = new Point(237, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(636, 438);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(29, 105);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(282, 265);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnReserv
            // 
            btnReserv.BackColor = Color.Black;
            btnReserv.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReserv.ForeColor = Color.Gold;
            btnReserv.Location = new Point(368, 327);
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
            btnPayment.Location = new Point(368, 251);
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
            btnRoomInfo.Location = new Point(368, 175);
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
            btnStudIn.Location = new Point(368, 105);
            btnStudIn.Name = "btnStudIn";
            btnStudIn.Size = new Size(211, 43);
            btnStudIn.TabIndex = 0;
            btnStudIn.Text = "Student Information";
            btnStudIn.UseVisualStyleBackColor = false;
            btnStudIn.Click += btnStudIn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._0001;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1107, 691);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "MainForm";
            Text = "MainForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnReserv;
        private Button btnPayment;
        private Button btnRoomInfo;
        private Button btnStudIn;
        private PictureBox pictureBox1;
    }
}