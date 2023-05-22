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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStudIn_Click(object sender, EventArgs e)
        {
            StudentInfoForm studentInfoForm = new StudentInfoForm();
            studentInfoForm.Show();
            this.Hide();
        }

        private void btnRoomInfo_Click(object sender, EventArgs e)
        {
            RoomInformation roomInformation = new RoomInformation();

            roomInformation.Show();
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            MonthlyPaymentForm monthlyPaymentForm = new MonthlyPaymentForm();
            monthlyPaymentForm.Show();
            this.Hide();
        }

        private void btnReserv_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm();
            reservationForm.Show();
            this.Hide();

        }
    }
}
