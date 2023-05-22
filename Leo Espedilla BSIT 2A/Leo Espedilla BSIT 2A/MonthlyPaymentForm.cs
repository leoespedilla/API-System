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
            InfoDB.cbxViewStudent(cbxStudent);
            InfoDB.dgvViewing(" SELECT concat(`STUDENT_FIRST_NAME`,' ', `STUDENT_MIDDLE_NAME`,' ', `STUDENT_LAST_NAME`) as name,monthly_payment.PAYMENT,Date_Format(monthly_payment.DATE , '%d-%m-%Y') as 'Payment' FROM `student_information` INNER JOIN monthly_payment on monthly_payment.STUDENT_ID=student_information.STUDENT_ID", dgvPayment);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void tbxElectricity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            InfoDB.SaveUpdateDeleteData("INSERT INTO `monthly_payment`( `STUDENT_ID`, `PAYMENT`, `DATE`) VALUES ('" + cbxStudent.SelectedValue + "','" + tbxPayment.Text + "','" + dtpMonthlyPayment.Value.ToString("yyyy-dd-MM") + "')");

        }
    }
}
