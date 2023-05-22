using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Leo_Espedilla_BSIT_2A
{
    internal class InfoDB
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=boardinghouse";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connecgtion! \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
        public static void SaveUpdateDeleteData(string sql)
        {
            string query = sql;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error!!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void dgvViewing(string sqlQuery, DataGridView dgv)
        {
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
        public static Boolean AccountVerification(string username, string password)
        {
            Boolean verify = false;
            string query = "SELECT * FROM `account` where username='" + username + "' and password='" + password + "'";
            MySqlConnection con = InfoDB.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            try
            {
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    verify = true;

                }
                //close Data Reader
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error!!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //close Connection
            con.Close();
            return verify;
        }
        public static void cbxView( ComboBox cbxName)
        {
            {
                string sql = "SELECT ROOM_NUMBER, ROOM_ID FROM room_information";
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet benefitdata = new DataSet();
                adapter.Fill(benefitdata);

                con.Close();
                cbxName.DataSource = benefitdata.Tables[0];
                cbxName.DisplayMember = "ROOM_NUMBER";
                cbxName.ValueMember = "ROOM_ID";

            }

        }
        public static void cbxViewStudent(ComboBox cbxName)
        {
            string sql = "SELECT concat(`STUDENT_FIRST_NAME`,' ', `STUDENT_MIDDLE_NAME`,' ', `STUDENT_LAST_NAME`) as name, STUDENT_ID FROM `student_information`";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet benefitdata = new DataSet();
            adapter.Fill(benefitdata);

            con.Close();
            cbxName.DataSource = benefitdata.Tables[0];
            cbxName.DisplayMember = "name";
            cbxName.ValueMember = "STUDENT_ID";
        }
    }
}
