namespace Leo_Espedilla_BSIT_2A
{
    partial class RoomInformation
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
            dgvRoomInfo = new DataGridView();
            label1 = new Label();
            btnBack = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnUpdate = new Button();
            label2 = new Label();
            label3 = new Label();
            tbxRoomNumber = new TextBox();
            tbxOccupancy = new TextBox();
            label4 = new Label();
            lblRoomId = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvRoomInfo).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRoomInfo
            // 
            dgvRoomInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomInfo.Location = new Point(411, 97);
            dgvRoomInfo.Name = "dgvRoomInfo";
            dgvRoomInfo.RowTemplate.Height = 25;
            dgvRoomInfo.Size = new Size(432, 536);
            dgvRoomInfo.TabIndex = 0;
            dgvRoomInfo.CellClick += dgvRoomInfo_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft YaHei UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(439, 50);
            label1.TabIndex = 1;
            label1.Text = "ROOM INFORMATION";
            // 
            // btnBack
            // 
            btnBack.BackgroundImage = Properties.Resources._340;
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.Location = new Point(788, 657);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(55, 30);
            btnBack.TabIndex = 8;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ButtonShadow;
            btnDelete.BackgroundImageLayout = ImageLayout.Center;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(51, 454);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(290, 23);
            btnDelete.TabIndex = 31;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonShadow;
            btnSave.BackgroundImageLayout = ImageLayout.Center;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(51, 402);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(290, 23);
            btnSave.TabIndex = 32;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ButtonShadow;
            btnUpdate.BackgroundImageLayout = ImageLayout.Center;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Location = new Point(51, 348);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(290, 23);
            btnUpdate.TabIndex = 33;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(0, 124);
            label2.Name = "label2";
            label2.Size = new Size(127, 21);
            label2.TabIndex = 34;
            label2.Text = "Room Number:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(3, 216);
            label3.Name = "label3";
            label3.Size = new Size(98, 21);
            label3.TabIndex = 35;
            label3.Text = "Occupancy:";
            // 
            // tbxRoomNumber
            // 
            tbxRoomNumber.Location = new Point(136, 122);
            tbxRoomNumber.Name = "tbxRoomNumber";
            tbxRoomNumber.Size = new Size(232, 23);
            tbxRoomNumber.TabIndex = 36;
            // 
            // tbxOccupancy
            // 
            tbxOccupancy.Location = new Point(136, 216);
            tbxOccupancy.Name = "tbxOccupancy";
            tbxOccupancy.Size = new Size(232, 23);
            tbxOccupancy.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(3, 34);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 38;
            label4.Text = "Room ID:";
            // 
            // lblRoomId
            // 
            lblRoomId.AutoSize = true;
            lblRoomId.BackColor = Color.Transparent;
            lblRoomId.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblRoomId.ForeColor = Color.White;
            lblRoomId.Location = new Point(123, 34);
            lblRoomId.Name = "lblRoomId";
            lblRoomId.Size = new Size(101, 17);
            lblRoomId.TabIndex = 40;
            lblRoomId.Text = "sample room id";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(tbxOccupancy);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(tbxRoomNumber);
            panel1.Controls.Add(lblRoomId);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 97);
            panel1.Name = "panel1";
            panel1.Size = new Size(393, 496);
            panel1.TabIndex = 44;
            // 
            // RoomInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._0001;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(851, 699);
            Controls.Add(panel1);
            Controls.Add(btnBack);
            Controls.Add(label1);
            Controls.Add(dgvRoomInfo);
            DoubleBuffered = true;
            Name = "RoomInformation";
            Text = "RoomInformation";
            Load += RoomInformation_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRoomInfo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRoomInfo;
        private Label label1;
        private Button btnBack;
        private Button btnDelete;
        private Button btnSave;
        private Button btnUpdate;
        private Label label2;
        private Label label3;
        private TextBox tbxRoomNumber;
        private TextBox tbxOccupancy;
        private Label label4;
        private Label lblRoomId;
        private Panel panel1;
    }
}