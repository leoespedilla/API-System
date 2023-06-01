using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Leo_Espedilla_BSIT_2A
{
    public partial class MonthlyPaymentForm : Form
    {
        public MonthlyPaymentForm()
        {
            InitializeComponent();

        }

        private void MonthlyPaymentForm_Load(object sender, EventArgs e)
        {
           ConnectAPI.cbxViewStudent(cbxStudent);
           ConnectAPI.dgvViewing("MontlyPayment", dgvPayment);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentInfoForm studentInfoForm = new StudentInfoForm();
            studentInfoForm.Show();
            this.Hide();
        }

        private void tbxElectricity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            string [] column = { "STUDENT_ID","PAYMENT","DATE" };
            string[] data = { Convert.ToString(cbxStudent.SelectedValue) , tbxPayment.Text , dtpMonthlyPayment.Value.ToString("yyyy-dd-MM") };
            ConnectAPI.saveData("monthly_payment",column,data);

        }
    }
}
