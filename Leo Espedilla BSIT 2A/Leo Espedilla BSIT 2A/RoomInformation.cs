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
            InfoDB.dgvViewing("SELECT * FROM `room_information`", dgvRoomInfo);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InfoDB.SaveUpdateDeleteData("INSERT INTO `room_information`( `ROOM_NUMBER`, `OCCUPANCY`) VALUES ('" + tbxRoomNumber.Text + "','" + tbxOccupancy.Text + "')");
            InfoDB.dgvViewing("SELECT * FROM `room_information`", dgvRoomInfo);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            InfoDB.SaveUpdateDeleteData("UPDATE `room_information` SET `ROOM_NUMBER`='[value-2]',`OCCUPANCY`='[value-3]' WHERE ROOM_ID=" + lblRoomId.Text);
            InfoDB.dgvViewing("SELECT * FROM `room_information`", dgvRoomInfo);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            InfoDB.SaveUpdateDeleteData("DELETE FROM `room_information` WHERE ROOM_ID=" + lblRoomId.Text);
            InfoDB.dgvViewing("SELECT * FROM `room_information`", dgvRoomInfo);
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
