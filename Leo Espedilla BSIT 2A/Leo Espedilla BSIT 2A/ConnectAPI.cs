using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.ComponentModel;
using System.Net;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Drawing;



namespace Leo_Espedilla_BSIT_2A
{
    internal class ConnectAPI
    {
        public static void dgvViewing(string displayData, DataGridView dgv)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("bhtables", RestSharp.Method.Get );
                request.AddHeader("authorization", Instantiate.InfoUser.token);
                request.AddParameter("displayData", displayData);

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(response.Content);
                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = true;


                }
                else
                {
                    MessageBox.Show("Error fetching data");
                }
            }
            catch
            {

            }
        }
        public static void searchData(string searchData, DataGridView dgv)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("search", RestSharp.Method.Get);
                request.AddHeader("authorization", Instantiate.InfoUser.token);
                request.AddParameter("searchData", searchData);

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(response.Content);
                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = false;
                }
                else
                {
                    MessageBox.Show("Error fetching data");
                }
            }
            catch
            {

            }
        }
        public static void saveData(string tableName, string[] columnName, string[] data)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("bhinsert", RestSharp.Method.Get);
                request.AddHeader("authorization", Instantiate.InfoUser.token);

                request.AddQueryParameter("tableName", tableName);
                for (int i = 0; i < data.Length; i++)
                {
                    request.AddQueryParameter(columnName[i], data[i]);
                }
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {

                }
                else
                {
                    MessageBox.Show("Fill up incomplete" + response.ErrorMessage);
                }
            }
            catch
            {
            }
        }
        public static void updateData( string[] columnName, string[] data, string id)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("boardinghouse", RestSharp.Method.Get);
                request.AddHeader("authorization", Instantiate.InfoUser.token);

                request.AddQueryParameter("id", "id");
                for (int i = 0; i < columnName.Length; i++)
                {
                    request.AddQueryParameter(columnName[i], data[i]);
                }
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {

                }
                else
                {
                    MessageBox.Show("Fill up incomplete!!" + response.ErrorMessage);
                }
            }
            catch
            {
            }
        }
        public static void deleteData(string tableName, string id)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("bhdeletion", RestSharp.Method.Get);
                request.AddHeader("authorization", Instantiate.InfoUser.token);
                request.AddQueryParameter("tableName", tableName);
                request.AddQueryParameter("id", "id");
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                }
                else
                {
                    MessageBox.Show("Error: mmm" + response.ErrorMessage);
                }
            }
            catch
            {
            }
        }
       
        
        public static void cbxViewRoom(ComboBox cbxName)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("bhtables", RestSharp.Method.Get);
                request.AddHeader("authorization", Instantiate.InfoUser.token);
                request.AddParameter("displayData", "ROOM_NUMBER");
                var response = client.Execute(request);
                JArray jsonArray = JArray.Parse(response.Content);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                cbxName.DataSource = dt;
                cbxName.DisplayMember = "ROOM_NUMBER";
                cbxName.ValueMember = "ROOM_ID";
            }
            catch
            {

            }
        }
        public static void cbxViewStudent(ComboBox cbxName)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("bhtables", RestSharp.Method.Get);
                request.AddHeader("authorization", Instantiate.InfoUser.token);
                request.AddParameter("displayData", "name");
                var response = client.Execute(request);
                JArray jsonArray = JArray.Parse(response.Content);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                cbxName.DataSource = dt;
                cbxName.DisplayMember = "name";
                cbxName.ValueMember = "STUDENT_ID";
            }
            catch
            {

            }
        }
        public static Boolean AccountVerifier(TextBox username, TextBox password)
        {
            bool verify = false;
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("account", RestSharp.Method.Get);
                request.AddQueryParameter("username", username.Text);
                request.AddQueryParameter("password", password.Text);

                var response = client.Execute(request);
                if (response.ContentLength > 2)
                {
                    
                    JArray jsonArray = JArray.Parse(response.Content);
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                    verify = true;
                    Instantiate.InfoUser.token = (dt.Rows[0]["token"]).ToString();
                }
            }
            catch
            {
            }
            return verify;
        }
    }
}

