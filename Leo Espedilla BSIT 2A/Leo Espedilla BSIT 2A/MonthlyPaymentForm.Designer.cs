namespace Leo_Espedilla_BSIT_2A
{
    partial class MonthlyPaymentForm
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
            dgvPayment = new DataGridView();
            btnAddPayment = new Button();
            btnBack = new Button();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label9 = new Label();
            tbxPayment = new TextBox();
            dtpMonthlyPayment = new DateTimePicker();
            cbxStudent = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPayment).BeginInit();
            SuspendLayout();
            // 
            // dgvPayment
            // 
            dgvPayment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayment.Location = new Point(12, 99);
            dgvPayment.Name = "dgvPayment";
            dgvPayment.RowTemplate.Height = 25;
            dgvPayment.Size = new Size(433, 567);
            dgvPayment.TabIndex = 0;
            // 
            // btnAddPayment
            // 
            btnAddPayment.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddPayment.Location = new Point(500, 512);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(193, 27);
            btnAddPayment.TabIndex = 3;
            btnAddPayment.Text = "ADD PAYMENT";
            btnAddPayment.UseVisualStyleBackColor = true;
            btnAddPayment.Click += btnAddPayment_Click;
            // 
            // btnBack
            // 
            btnBack.BackgroundImage = Properties.Resources._340;
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.Location = new Point(677, 645);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(55, 30);
            btnBack.TabIndex = 7;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(451, 259);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 8;
            label2.Text = "Payment:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 24);
            label5.Name = "label5";
            label5.Size = new Size(331, 50);
            label5.TabIndex = 11;
            label5.Text = "Monthly Payment";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Gold;
            label6.Location = new Point(451, 384);
            label6.Name = "label6";
            label6.Size = new Size(50, 21);
            label6.TabIndex = 12;
            label6.Text = "Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Gold;
            label9.Location = new Point(451, 130);
            label9.Name = "label9";
            label9.Size = new Size(124, 21);
            label9.TabIndex = 15;
            label9.Text = "Student Name:";
            // 
            // tbxPayment
            // 
            tbxPayment.Location = new Point(581, 257);
            tbxPayment.Name = "tbxPayment";
            tbxPayment.Size = new Size(169, 23);
            tbxPayment.TabIndex = 18;
            // 
            // dtpMonthlyPayment
            // 
            dtpMonthlyPayment.Location = new Point(581, 382);
            dtpMonthlyPayment.Name = "dtpMonthlyPayment";
            dtpMonthlyPayment.Size = new Size(169, 23);
            dtpMonthlyPayment.TabIndex = 23;
            // 
            // cbxStudent
            // 
            cbxStudent.FormattingEnabled = true;
            cbxStudent.Location = new Point(581, 132);
            cbxStudent.Name = "cbxStudent";
            cbxStudent.Size = new Size(169, 23);
            cbxStudent.TabIndex = 24;
            // 
            // MonthlyPaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._0001;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(766, 702);
            Controls.Add(cbxStudent);
            Controls.Add(dtpMonthlyPayment);
            Controls.Add(tbxPayment);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(btnAddPayment);
            Controls.Add(dgvPayment);
            DoubleBuffered = true;
            Name = "MonthlyPaymentForm";
            Text = "MonthlyPaymentForm";
            Load += MonthlyPaymentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPayment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPayment;
        private Button btnAddPayment;
        private Button btnBack;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label9;
        private TextBox tbxPayment;
        private DateTimePicker dtpMonthlyPayment;
        private ComboBox cbxStudent;
    }
}