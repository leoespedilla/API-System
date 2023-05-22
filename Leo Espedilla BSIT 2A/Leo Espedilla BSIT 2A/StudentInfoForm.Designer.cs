namespace Leo_Espedilla_BSIT_2A
{
    partial class StudentInfoForm
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
            dgvStudentInfo = new DataGridView();
            label1 = new Label();
            label13 = new Label();
            btnSearch = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            tbxSearch = new TextBox();
            dtpBirthdate = new DateTimePicker();
            tbxPaddress = new TextBox();
            tbxPName = new TextBox();
            tbxEmail = new TextBox();
            tbxContact = new TextBox();
            tbxAddress = new TextBox();
            tbxLname = new TextBox();
            tbxMname = new TextBox();
            tbxFname = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbxRoom = new ComboBox();
            btnBack = new Button();
            label14 = new Label();
            cbxGender = new ComboBox();
            tbxAge = new TextBox();
            label15 = new Label();
            tbxParentContact = new TextBox();
            btnClear = new Button();
            panel1 = new Panel();
            lblID = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStudentInfo).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvStudentInfo
            // 
            dgvStudentInfo.BackgroundColor = Color.Silver;
            dgvStudentInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentInfo.Location = new Point(435, 99);
            dgvStudentInfo.Name = "dgvStudentInfo";
            dgvStudentInfo.RowTemplate.Height = 25;
            dgvStudentInfo.Size = new Size(649, 545);
            dgvStudentInfo.TabIndex = 0;
            dgvStudentInfo.CellClick += dgvStudentInfo_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(232, 1);
            label1.Name = "label1";
            label1.Size = new Size(695, 65);
            label1.TabIndex = 1;
            label1.Text = "STUDENT's      INFORMATION";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(448, 66);
            label13.Name = "label13";
            label13.Size = new Size(77, 30);
            label13.TabIndex = 13;
            label13.Text = "Name:";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Gold;
            btnSearch.Cursor = Cursors.AppStarting;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.Location = new Point(917, 69);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 27;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ButtonShadow;
            btnAdd.BackgroundImageLayout = ImageLayout.Center;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(6, 552);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(197, 23);
            btnAdd.TabIndex = 28;
            btnAdd.Text = "UPDATE";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonShadow;
            btnSave.BackgroundImageLayout = ImageLayout.Center;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(115, 581);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(197, 23);
            btnSave.TabIndex = 29;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ButtonShadow;
            btnDelete.BackgroundImageLayout = ImageLayout.Center;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(209, 552);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(197, 23);
            btnDelete.TabIndex = 30;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // tbxSearch
            // 
            tbxSearch.BackColor = Color.FromArgb(224, 224, 224);
            tbxSearch.Location = new Point(531, 69);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(368, 23);
            tbxSearch.TabIndex = 31;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.CalendarMonthBackground = Color.Silver;
            dtpBirthdate.CalendarTitleBackColor = Color.Silver;
            dtpBirthdate.Location = new Point(157, 225);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(238, 23);
            dtpBirthdate.TabIndex = 69;
            // 
            // tbxPaddress
            // 
            tbxPaddress.BackColor = Color.FromArgb(224, 224, 224);
            tbxPaddress.Location = new Point(157, 411);
            tbxPaddress.Name = "tbxPaddress";
            tbxPaddress.Size = new Size(238, 23);
            tbxPaddress.TabIndex = 66;
            // 
            // tbxPName
            // 
            tbxPName.BackColor = Color.FromArgb(224, 224, 224);
            tbxPName.Location = new Point(157, 370);
            tbxPName.Name = "tbxPName";
            tbxPName.Size = new Size(238, 23);
            tbxPName.TabIndex = 65;
            // 
            // tbxEmail
            // 
            tbxEmail.BackColor = Color.FromArgb(224, 224, 224);
            tbxEmail.Location = new Point(157, 331);
            tbxEmail.Name = "tbxEmail";
            tbxEmail.Size = new Size(238, 23);
            tbxEmail.TabIndex = 64;
            // 
            // tbxContact
            // 
            tbxContact.BackColor = Color.FromArgb(224, 224, 224);
            tbxContact.Location = new Point(157, 293);
            tbxContact.Name = "tbxContact";
            tbxContact.Size = new Size(238, 23);
            tbxContact.TabIndex = 63;
            // 
            // tbxAddress
            // 
            tbxAddress.BackColor = Color.FromArgb(224, 224, 224);
            tbxAddress.Location = new Point(157, 184);
            tbxAddress.Name = "tbxAddress";
            tbxAddress.Size = new Size(238, 23);
            tbxAddress.TabIndex = 62;
            // 
            // tbxLname
            // 
            tbxLname.BackColor = Color.FromArgb(224, 224, 224);
            tbxLname.Location = new Point(157, 112);
            tbxLname.Name = "tbxLname";
            tbxLname.Size = new Size(238, 23);
            tbxLname.TabIndex = 61;
            // 
            // tbxMname
            // 
            tbxMname.BackColor = Color.FromArgb(224, 224, 224);
            tbxMname.Location = new Point(157, 73);
            tbxMname.Name = "tbxMname";
            tbxMname.Size = new Size(238, 23);
            tbxMname.TabIndex = 60;
            // 
            // tbxFname
            // 
            tbxFname.BackColor = Color.FromArgb(224, 224, 224);
            tbxFname.Location = new Point(157, 39);
            tbxFname.Name = "tbxFname";
            tbxFname.Size = new Size(238, 23);
            tbxFname.TabIndex = 59;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Gold;
            label12.Location = new Point(4, 217);
            label12.Name = "label12";
            label12.Size = new Size(86, 45);
            label12.TabIndex = 58;
            label12.Text = "Birthdate:";
            label12.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Gold;
            label11.Location = new Point(4, 250);
            label11.Name = "label11";
            label11.Size = new Size(44, 45);
            label11.TabIndex = 57;
            label11.Text = "Age:";
            label11.UseCompatibleTextRendering = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Gold;
            label10.Location = new Point(3, 400);
            label10.Name = "label10";
            label10.Size = new Size(153, 45);
            label10.TabIndex = 56;
            label10.Text = "Parent's Address:";
            label10.UseCompatibleTextRendering = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Gold;
            label9.Location = new Point(3, 365);
            label9.Name = "label9";
            label9.Size = new Size(133, 45);
            label9.TabIndex = 55;
            label9.Text = "Parent's Name:";
            label9.UseCompatibleTextRendering = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Gold;
            label8.Location = new Point(6, 142);
            label8.Name = "label8";
            label8.Size = new Size(73, 45);
            label8.TabIndex = 54;
            label8.Text = "Gender:";
            label8.UseCompatibleTextRendering = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Gold;
            label7.Location = new Point(6, 327);
            label7.Name = "label7";
            label7.Size = new Size(131, 45);
            label7.TabIndex = 53;
            label7.Text = "Email Address:";
            label7.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Gold;
            label6.Location = new Point(3, 282);
            label6.Name = "label6";
            label6.Size = new Size(146, 45);
            label6.TabIndex = 52;
            label6.Text = "Contact Number:";
            label6.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Gold;
            label5.Location = new Point(6, 180);
            label5.Name = "label5";
            label5.Size = new Size(79, 45);
            label5.TabIndex = 51;
            label5.Text = "Address:";
            label5.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(6, 101);
            label4.Name = "label4";
            label4.Size = new Size(100, 45);
            label4.TabIndex = 50;
            label4.Text = "Last Name:";
            label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(0, 73);
            label3.Name = "label3";
            label3.Size = new Size(120, 45);
            label3.TabIndex = 49;
            label3.Tag = "";
            label3.Text = "Middle Name:";
            label3.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(2, 38);
            label2.Name = "label2";
            label2.Size = new Size(102, 45);
            label2.TabIndex = 48;
            label2.Text = "First Name:";
            label2.UseCompatibleTextRendering = true;
            // 
            // cbxRoom
            // 
            cbxRoom.FormattingEnabled = true;
            cbxRoom.Location = new Point(157, 493);
            cbxRoom.Name = "cbxRoom";
            cbxRoom.Size = new Size(238, 23);
            cbxRoom.TabIndex = 70;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(1029, 656);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(55, 30);
            btnBack.TabIndex = 71;
            btnBack.Text = "BACK";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Gold;
            label14.Location = new Point(6, 482);
            label14.Name = "label14";
            label14.Size = new Size(131, 45);
            label14.TabIndex = 72;
            label14.Text = "Room Number:";
            label14.UseCompatibleTextRendering = true;
            // 
            // cbxGender
            // 
            cbxGender.FormattingEnabled = true;
            cbxGender.Items.AddRange(new object[] { "Male", "Female" });
            cbxGender.Location = new Point(157, 148);
            cbxGender.Name = "cbxGender";
            cbxGender.Size = new Size(238, 23);
            cbxGender.TabIndex = 73;
            // 
            // tbxAge
            // 
            tbxAge.BackColor = Color.FromArgb(224, 224, 224);
            tbxAge.Location = new Point(157, 260);
            tbxAge.Name = "tbxAge";
            tbxAge.Size = new Size(238, 23);
            tbxAge.TabIndex = 74;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.Gold;
            label15.Location = new Point(3, 437);
            label15.Name = "label15";
            label15.Size = new Size(135, 45);
            label15.TabIndex = 75;
            label15.Text = "Parent Contact:";
            label15.UseCompatibleTextRendering = true;
            // 
            // tbxParentContact
            // 
            tbxParentContact.BackColor = Color.FromArgb(224, 224, 224);
            tbxParentContact.Location = new Point(157, 448);
            tbxParentContact.Name = "tbxParentContact";
            tbxParentContact.Size = new Size(238, 23);
            tbxParentContact.TabIndex = 76;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.Location = new Point(345, 519);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(50, 27);
            btnClear.TabIndex = 77;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(tbxParentContact);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(tbxAge);
            panel1.Controls.Add(cbxGender);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(cbxRoom);
            panel1.Controls.Add(dtpBirthdate);
            panel1.Controls.Add(tbxPaddress);
            panel1.Controls.Add(tbxPName);
            panel1.Controls.Add(tbxEmail);
            panel1.Controls.Add(tbxContact);
            panel1.Controls.Add(tbxAddress);
            panel1.Controls.Add(tbxLname);
            panel1.Controls.Add(tbxMname);
            panel1.Controls.Add(tbxFname);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(417, 610);
            panel1.TabIndex = 78;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.BackColor = Color.Transparent;
            lblID.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            lblID.ForeColor = Color.Gold;
            lblID.Location = new Point(18, 9);
            lblID.Name = "lblID";
            lblID.Size = new Size(0, 42);
            lblID.TabIndex = 78;
            lblID.UseCompatibleTextRendering = true;
            // 
            // StudentInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._0001;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1107, 691);
            Controls.Add(lblID);
            Controls.Add(panel1);
            Controls.Add(btnBack);
            Controls.Add(tbxSearch);
            Controls.Add(btnSearch);
            Controls.Add(label13);
            Controls.Add(label1);
            Controls.Add(dgvStudentInfo);
            DoubleBuffered = true;
            Name = "StudentInfoForm";
            Text = "StudentInfoForm";
            Load += StudentInfoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentInfo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStudentInfo;
        private Label label1;
        private Label label13;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnSave;
        private Button btnDelete;
        private TextBox tbxSearch;
        private DateTimePicker dtpBirthdate;
        private TextBox tbxPaddress;
        private TextBox tbxPName;
        private TextBox tbxEmail;
        private TextBox tbxContact;
        private TextBox tbxAddress;
        private TextBox tbxLname;
        private TextBox tbxMname;
        private TextBox tbxFname;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cbxRoom;
        private Button btnBack;
        private Label label14;
        private ComboBox cbxGender;
        private TextBox tbxAge;
        private Label label15;
        private TextBox tbxParentContact;
        private Button btnClear;
        private Panel panel1;
        private Label lblID;
    }
}