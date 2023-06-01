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
    public partial class RoomInformation : Form
    {
        public RoomInformation()
        {
            InitializeComponent();
        }

        private void RoomInformation_Load(object sender, EventArgs e)
        {
            ConnectAPI.dgvViewing("RoomInformation", dgvRoomInfo);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentInfoForm studentInfoForm = new StudentInfoForm();
            studentInfoForm.Show();
            this.Hide();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] column = { "roomNumber","occupancy" };
            string[] data = { tbxRoomNumber.Text , tbxOccupancy.Text };
            ConnectAPI.saveData("RoomInformation",column,data);
            ConnectAPI.dgvViewing("RoomInformation", dgvRoomInfo);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] column = { "roomNumber", "occupancy" };
            string[] data = { tbxRoomNumber.Text, tbxOccupancy.Text };
            ConnectAPI.updateData(column,data,lblRoomId.Text);
            ConnectAPI.dgvViewing("RoomInformation", dgvRoomInfo);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ConnectAPI.deleteData("RoomInformation",lblRoomId.Text);
            ConnectAPI.dgvViewing("RoomInformation", dgvRoomInfo);
        }

        private void dgvRoomInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblRoomId.Text = dgvRoomInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbxRoomNumber.Text = dgvRoomInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbxOccupancy.Text = dgvRoomInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
