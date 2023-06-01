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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Boolean verifyAccount = ConnectAPI.AccountVerifier(tbxUserName, tbxPassword);
            if (verifyAccount)
            {
                Instantiate.display.MainForm(this);
            }
            else
            {



            }


        }
        public void MainForm(Form formName)
        {
            MainForm form = new MainForm();


        }

        private void tbxUserName_TextChanged(object sender, EventArgs e)
        {


        }

        private void tbxUserName_Click(object sender, EventArgs e)
        {
            tbxUserName.SelectAll();
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {

            tbxPassword.PasswordChar = '*';
        }

        private void tbxPassword_Click(object sender, EventArgs e)
        {
            tbxPassword.SelectAll();
        }
    }
}