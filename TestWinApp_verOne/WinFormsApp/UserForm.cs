using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();

            string sqlExpression = "SELECT name FROM Users";
            using (var connection = new SqliteConnection($"Data Source={db_puth.Value}"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read()) 
                        {
                            var name = reader.GetValue(0);
                            userRow.Items.Add(name);
                        }
                    }
                }
            }


            Login_e.Value = this.userRow.Text;
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
