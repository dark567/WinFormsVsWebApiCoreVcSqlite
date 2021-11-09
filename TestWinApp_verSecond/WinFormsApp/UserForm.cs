using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();

            var response = GetUsers(url.Value + "/Users");
            Thread.Sleep(TimeSpan.FromSeconds(20));

            //while (response.Result == null)
            //{
            //    Thread.Sleep(TimeSpan.FromSeconds(1));
            //}

            foreach (var item in response as IEnumerable<User>)
            {
                userRow.Items.Add(item.Name);
            }

            //string sqlExpression = "SELECT name FROM Users";
            //using (var connection = new SqliteConnection($"Data Source={db_puth.Value}"))
            //{
            //    connection.Open();

            //    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            //    using (SqliteDataReader reader = command.ExecuteReader())
            //    {
            //        if (reader.HasRows)
            //        {
            //            while (reader.Read()) 
            //            {
            //                var name = reader.GetValue(0);
            //                userRow.Items.Add(name);
            //            }
            //        }
            //    }
            //}


            Login_e.Value = this.userRow.Text;
        }

        static async Task<IEnumerable<User>> GetUsers(string url)
        {
            using (var http = new HttpClient())
            {
                var result = await http.GetAsync(new Uri(url));
                result.EnsureSuccessStatusCode();
                var users = await result.Content.ReadAsAsync<IEnumerable<User>>();

                foreach (var user in users)
                {
                  
                }
                return users;
            }
        }

        private void userRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            Login_e.Value = this.userRow.Text;
            this.buttonOK.Enabled = string.IsNullOrEmpty(Login_e.Value) ? false : true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
