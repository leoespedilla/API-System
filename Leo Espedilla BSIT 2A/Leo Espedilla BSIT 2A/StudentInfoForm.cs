using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leo_Espedilla_BSIT_2A
{
    public partial class StudentInfoForm : Form
    {
        public StudentInfoForm()
        {
            InitializeComponent();
        }



        private void StudentInfoForm_Load(object sender, EventArgs e)
        {
            lblID.Hide();
            ConnectAPI.cbxViewRoom(cbxRoom);
            ConnectAPI.dgvViewing("Student_Information", dgvStudentInfo);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] column = { "studentFirstName", "studentMiddleName", "studentLastName", "birthdate", "age", "gender", "address", "contactNumber", "emailAddress", "parentName", "parentAddress", "parentContactNumber", "roomID" };
            string[] data = { tbxFname.Text, tbxMname.Text, tbxLname.Text, dtpBirthdate.Value.ToString("yyyy-dd-MM"), tbxAge.Text, cbxGender.Text, tbxAddress.Text, tbxContact.Text, tbxEmail.Text, tbxPName.Text, tbxPaddress.Text, tbxParentContact.Text,Convert.ToString (cbxRoom.SelectedValue) };
            ConnectAPI.saveData("Student_Information", column, data);
            ConnectAPI.dgvViewing("Student_Information", dgvStudentInfo);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ConnectAPI.deleteData("Student_Information", lblID.Text);
            ConnectAPI.dgvViewing("Student_Information", dgvStudentInfo);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            tbxFname.Text = "";
            tbxMname.Text = "";
            tbxLname.Text = "";
            tbxAddress.Text = "";
            tbxAge.Text = "";
            tbxContact.Text = "";
            tbxEmail.Text = "";
            tbxPName.Text = "";
            tbxPaddress.Text = "";
            tbxContact.Text = "";

        }

        private void dgvStudentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblID.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbxFname.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbxMname.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbxLname.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbxGender.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbxAddress.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[7].Value.ToString();
                dtpBirthdate.Value = Convert.ToDateTime(dgvStudentInfo.Rows[e.RowIndex].Cells[4].Value.ToString());
                tbxAge.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbxContact.Text = (dgvStudentInfo.Rows[e.RowIndex].Cells[8].Value.ToString());
                tbxEmail.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[9].Value.ToString();
                tbxPName.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[10].Value.ToString();
                tbxPaddress.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[11].Value.ToString();
                tbxParentContact.Text = dgvStudentInfo.Rows[e.RowIndex].Cells[12].Value.ToString();
                cbxRoom.SelectedValue = dgvStudentInfo.Rows[e.RowIndex].Cells[13].Value.ToString();

            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //InfoDB.SaveUpdateDeleteData("INSERT INTO `student_information`( `STUDENT_FIRST_NAME`, `STUDENT_MIDDLE_NAME`, `STUDENT_LAST_NAME`, `BIRTHDATE`, `AGE`, `GENDER`, `ADDRESS`, `CONTACT_NUMBER`, `EMAIL_ADDRESS`, `PARENT_NAME`, `PARENT_ADDRESS`, `PARENT_CONTACT_NUMBER`, `ROOM_ID`) VALUES ('" + tbxFname.Text + "','" + tbxMname.Text + "','" + tbxLname.Text + "','" + dtpBirthdate.Value.ToString("yyyy-dd-MM") + "','" + tbxAge.Text + "','" + cbxGender.Text + "','" + tbxAddress.Text + "','" + tbxContact.Text + "','" + tbxEmail.Text + "','" + tbxPName.Text + "','" + tbxPaddress.Text + "','" + tbxParentContact.Text + "','" + cbxRoom.SelectedValue + "')");
            //InfoDB.dgvViewing("SELECT * FROM `student_information` ", dgvStudentInfo);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ConnectAPI.searchData(tbxSearch.Text, dgvStudentInfo);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
