namespace Leo_Espedilla_BSIT_2A
{
    partial class ReservationForm
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
            dgvReservation = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label6 = new Label();
            tbxStudentFullName = new TextBox();
            tbxAdvancePayment = new TextBox();
            btnClear = new Button();
            btnUpdate = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            dtpReservationDate = new DateTimePicker();
            label7 = new Label();
            lblID = new Label();
            label8 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvReservation).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReservation
            // 
            dgvReservation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservation.Location = new Point(15, 59);
            dgvReservation.Name = "dgvReservation";
            dgvReservation.RowTemplate.Height = 25;
            dgvReservation.Size = new Size(376, 596);
            dgvReservation.TabIndex = 0;
            dgvReservation.CellClick += dgvReservation_CellClick;
            dgvReservation.CellContentClick += dgvReservation_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(213, 47);
            label1.TabIndex = 1;
            label1.Text = "Reservation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(6, 173);
            label2.Name = "label2";
            label2.Size = new Size(145, 21);
            label2.TabIndex = 2;
            label2.Text = "Reservation Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(6, 295);
            label4.Name = "label4";
            label4.Size = new Size(152, 21);
            label4.TabIndex = 4;
            label4.Text = "Advance Payment:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Gold;
            label6.Location = new Point(3, 96);
            label6.Name = "label6";
            label6.Size = new Size(156, 21);
            label6.TabIndex = 6;
            label6.Text = "Student Full Name:";
            // 
            // tbxStudentFullName
            // 
            tbxStudentFullName.Location = new Point(164, 94);
            tbxStudentFullName.Name = "tbxStudentFullName";
            tbxStudentFullName.Size = new Size(222, 23);
            tbxStudentFullName.TabIndex = 7;
            // 
            // tbxAdvancePayment
            // 
            tbxAdvancePayment.Location = new Point(164, 295);
            tbxAdvancePayment.Name = "tbxAdvancePayment";
            tbxAdvancePayment.Size = new Size(222, 23);
            tbxAdvancePayment.TabIndex = 10;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(311, 423);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 15;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ButtonShadow;
            btnUpdate.BackgroundImageLayout = ImageLayout.Center;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Location = new Point(8, 465);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(190, 23);
            btnUpdate.TabIndex = 29;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonShadow;
            btnSave.BackgroundImageLayout = ImageLayout.Center;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(219, 465);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(190, 23);
            btnSave.TabIndex = 30;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ButtonShadow;
            btnDelete.BackgroundImageLayout = ImageLayout.Center;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(119, 505);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(190, 23);
            btnDelete.TabIndex = 31;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(781, 661);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(48, 35);
            btnBack.TabIndex = 32;
            btnBack.Text = "BACK";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dtpReservationDate
            // 
            dtpReservationDate.Location = new Point(164, 173);
            dtpReservationDate.Name = "dtpReservationDate";
            dtpReservationDate.Size = new Size(222, 23);
            dtpReservationDate.TabIndex = 34;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Gold;
            label7.Location = new Point(3, 41);
            label7.Name = "label7";
            label7.Size = new Size(115, 20);
            label7.TabIndex = 35;
            label7.Text = "Reservation Id:";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.BackColor = Color.Transparent;
            lblID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(136, 41);
            lblID.Name = "lblID";
            lblID.Size = new Size(62, 15);
            lblID.TabIndex = 36;
            lblID.Text = "Sample Id";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.ForeColor = Color.White;
            label8.Location = new Point(136, 45);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 37;
            label8.Text = "__________";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(dtpReservationDate);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(lblID);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(tbxAdvancePayment);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(tbxStudentFullName);
            panel1.Location = new Point(407, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(422, 596);
            panel1.TabIndex = 38;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._0001;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(833, 691);
            Controls.Add(panel1);
            Controls.Add(btnBack);
            Controls.Add(label1);
            Controls.Add(dgvReservation);
            DoubleBuffered = true;
            Name = "ReservationForm";
            Text = "ReservationForm";
            Load += ReservationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReservation).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReservation;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label6;
        private TextBox tbxStudentFullName;
        private TextBox tbxStartingDate;
        private TextBox tbxAdvancePayment;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnSave;
        private Button btnDelete;
        private Button btnBack;
        private DateTimePicker dtpReservationDate;
        private Label label7;
        private Label lblID;
        private Label label8;
        private Panel panel1;
    }
}