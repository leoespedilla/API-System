using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Leo_Espedilla_BSIT_2A
{
    internal class DisplayForm
    {

        public void LogInForm(Form formName)
        {
            LogInForm form = new LogInForm();
            formName.Close();
            form.Show();

        }
        public void MainForm(Form formName)
        {
            MainForm form = new MainForm();
            formName.Hide();
            form.Show();
        }
        public void MonthlyPaymentForm(Form formName)
        {
            MonthlyPaymentForm form = new MonthlyPaymentForm();
            formName.Hide();
            form.Show();
        }
        public void ReservationForm(Form formName)
        {
            ReservationForm form = new ReservationForm();
            formName.Hide();
            form.Show();
        }
        public void RoomInformation(Form formName)
        {
            RoomInformation form = new RoomInformation();
            formName.Hide();
            form.Show();
        }
        public void StudentInfoForm(Form formName)
        {
            RoomInformation form = new RoomInformation();
            formName.Hide();
            form.Show();
        }


    }
}
