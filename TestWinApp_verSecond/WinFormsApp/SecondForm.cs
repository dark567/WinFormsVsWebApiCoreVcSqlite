using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            InitializeComponent();
        }

        private void SecondForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + Login_e.Value;
            AddRowsIntoList();
            CalcAndShowCountUsers();
        }

        private void AddRowsIntoList()
        {
            string sqlExpression = "SELECT name, cityId FROM Users";
            using (var connection = new SqliteConnection($"Data Source={db_puth.Value}"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var name = reader.GetValue(0);
                            var cityId = reader.GetInt16(1);

                            listBoxUsers.Items.Add($"{name}, {GetCityFromId(cityId)}");
                        }
                    }
                }
            }
        }

        private string GetCityFromId(int cityId)
        {
            using (var connection = new SqliteConnection($"Data Source={db_puth.Value}"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT name from City where _id = '"+ cityId + "'";
                var nameCity = command.ExecuteScalar().ToString();
                if (nameCity != null)
                    return nameCity;
            }

            return "";
        }

        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalcAndShowCountUsers()
        {
            using (var connection = new SqliteConnection($"Data Source={db_puth.Value}"))
            {
                long countUsers = 0;

                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT count(*) from users";
                usersCount.Value = (long)command.ExecuteScalar();
                this.labelCountUsers.Text = $"{usersCount.Value} пользователей";
            }
        }
    }
}
