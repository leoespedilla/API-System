using Google.Protobuf.WellKnownTypes;
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
    public partial class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            lblID.Hide();
            label7.Hide();
            InfoDB.dgvViewing("SELECT * FROM `reservation`", dgvReservation);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InfoDB.SaveUpdateDeleteData("INSERT INTO `reservation`( `STUDENT_NAME`, `RESERVATION_DATE`, `ADVANCE_PAYMENT`) VALUES ('" + tbxStudentFullName.Text + "','" + dtpReservationDate.Value.ToString("yyyy-dd-MM") + "','" + tbxAdvancePayment.Text + "')");
            InfoDB.dgvViewing("SELECT * FROM `reservation` ", dgvReservation);

        }

        private void dgvReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblID.Text = dgvReservation.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbxStudentFullName.Text = dgvReservation.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpReservationDate.Value = Convert.ToDateTime(dgvReservation.Rows[e.RowIndex].Cells[2].Value.ToString());
                tbxAdvancePayment.Text = dgvReservation.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            InfoDB.SaveUpdateDeleteData("UPDATE `reservation` SET `STUDENT_NAME`='" + tbxStudentFullName.Text + "',`RESERVATION_DATE`='" + dtpReservationDate.Value.ToString("yyyy-dd-MM") + "',`ADVANCE_PAYMENT`='" + tbxAdvancePayment.Text + "' WHERE RESERVATION_ID=" + lblID.Text);
            InfoDB.dgvViewing("SELECT * FROM `reservation` ", dgvReservation);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            InfoDB.SaveUpdateDeleteData("DELETE FROM `reservation` WHERE RESERVATION_ID=" + lblID.Text);
            InfoDB.dgvViewing("SELECT * FROM `reservation` ", dgvReservation);
        }
    }
}
