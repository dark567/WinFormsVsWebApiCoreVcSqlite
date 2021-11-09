using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class FirstForm : Form
    {
        public readonly string fileIniPath = Application.StartupPath + @"\set.ini";
        static HttpClient client = new HttpClient();

        private const string APP_PATH = "https://localhost:44342";

        public FirstForm()
        {
            InitializeComponent();
        }

        private void FirstForm_Load(object sender, EventArgs e)
        {
            #region write ini
            try
            {
                if (File.Exists(fileIniPath))
                {
                    //Создание объекта, для работы с файлом
                    INIManager manager = new INIManager(fileIniPath);
                    //Получить значение по ключу name из секции main
                    db_puth.Value = manager.GetPrivateString("connection", "db");
                    url.Value = manager.GetPrivateString("connection", "url");
                    File.AppendAllText(Application.StartupPath + @"\AppLog.log", $"путь к db:{db_puth.Value} \n");
                }
                else
                {
                    File.AppendAllText(Application.StartupPath + @"\AppLog.log", $"File set.ini not found \n");
                    MessageBox.Show("File set.ini not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(Application.StartupPath + @"\AppLog.log", $"Exception: {ex.Message} \n");
                MessageBox.Show("Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            InitialDataBD();

            var response = GetUsers(url.Value + "/Users");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            var dialog = new UserForm();

            if ((dialog.ShowDialog() == DialogResult.OK))
            {
                try
                {
                    this.Text = this.Text + Login_e.Value;
                    CalcAndShowCountUsers();
                }
                catch (Exception ex)
                {
                    // отображаем ошибку
                    MessageBox.Show(ex.Message, "Error");
                    Application.Exit();
                }
            }
            else Application.Exit();

            //подсказка
            this.textBoxFIO.Text = "Введите фамилию имя";
            this.textBoxFIO.ForeColor = Color.Gray;
            this.textBoxSity.Text = "Введите город";
            this.textBoxSity.ForeColor = Color.Gray;
            this.btnSaveUser.Enabled = false;
        }

        static async Task<IEnumerable<User>> GetUsers(string url)
        {
            using (var http = new HttpClient())
            {
                var result = await http.GetAsync(new Uri(url));
                result.EnsureSuccessStatusCode();
                var users = await result.Content.ReadAsAsync<IEnumerable<User>>();
                return users;
            }
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// создание и заполнение бд
        /// </summary>
        private static void InitialDataBD()
        {
            using (var connection = new SqliteConnection($"Data Source={db_puth.Value}"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                if (!TableAlreadyExists(connection, "Users"))
                {
                    command.CommandText = "CREATE TABLE Users(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, CityId INTEGER NOT NULL)";
                    command.ExecuteNonQuery();
                }
                if (!TableAlreadyExists(connection, "City"))
                {
                    command.CommandText = "CREATE TABLE City(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL)";
                    command.ExecuteNonQuery();
                }

                if (!RowAlreadyExists(connection, "City", "Харьков"))
                {
                    command.CommandText = "INSERT INTO City (_id, Name) VALUES (1, 'Харьков')";
                    command.ExecuteNonQuery();
                }
                if (!RowAlreadyExists(connection, "City", "Киев"))
                {
                    command.CommandText = "INSERT INTO City (_id, Name) VALUES (2, 'Киев')";
                    command.ExecuteNonQuery();
                }

                if (!RowAlreadyExists(connection, "Users", "Иван Иванов"))
                {
                    command.CommandText = "INSERT INTO Users (Name, CityId) VALUES ('Иван Иванов', 1)";
                    command.ExecuteNonQuery();
                }
                if (!RowAlreadyExists(connection, "Users", "Петр Петров"))
                {
                    command.CommandText = "INSERT INTO Users (Name, CityId) VALUES ('Петр Петров', 2)";
                    command.ExecuteNonQuery();
                }
                if (!RowAlreadyExists(connection, "Users", "Василий Васильев"))
                {
                    command.CommandText = "INSERT INTO Users (Name, CityId) VALUES ('Василий Васильев', 1)";
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// проверка на существование таблицы
        /// </summary>
        /// <param name="openConnection"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool TableAlreadyExists(SqliteConnection openConnection, string tableName)
        {
            var sql =
            "SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "';";
            if (openConnection.State == System.Data.ConnectionState.Open)
            {
                SqliteCommand command = new SqliteCommand(sql, openConnection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new ArgumentException("Data.ConnectionState must be open");
            }
        }

        /// <summary>
        /// проверка на уникальность пользователя
        /// </summary>
        /// <param name="openConnection"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool RowAlreadyExists(SqliteConnection openConnection, string tableName, string userName)
        {
            var sql =
            "SELECT name FROM '" + tableName + "' WHERE name='" + userName + "';";
            if (openConnection.State == System.Data.ConnectionState.Open)
            {
                SqliteCommand command = new SqliteCommand(sql, openConnection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new ArgumentException("Data.ConnectionState must be open");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            SecondForm newMDIChild = new SecondForm();
            // Display the new form.
            newMDIChild.ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFIO_TextChanged(object sender, EventArgs e)
        {
            this.textBoxFIO.ForeColor = Color.Black;

            this.btnSaveUser.Enabled = this.textBoxFIO.Text == "" || this.textBoxSity.Text == "" || this.textBoxFIO.Text == "Введите фамилию имя" || this.textBoxSity.Text == "Введите город" ? false : true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFIO_Enter(object sender, EventArgs e)
        {
            this.textBoxFIO.Text = null;
            this.textBoxFIO.ForeColor = Color.Black;

            this.btnSaveUser.Enabled = this.textBoxFIO.Text == "" || this.textBoxSity.Text == "" || this.textBoxFIO.Text == "Введите фамилию имя" || this.textBoxSity.Text == "Введите город" ? false : true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSity_TextChanged(object sender, EventArgs e)
        {
            this.textBoxSity.ForeColor = Color.Black;

            this.btnSaveUser.Enabled = this.textBoxFIO.Text == "" || this.textBoxSity.Text == "" || this.textBoxFIO.Text == "Введите фамилию имя" || this.textBoxSity.Text == "Введите город" ? false : true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSity_Enter(object sender, EventArgs e)
        {
            this.textBoxSity.Text = null;
            this.textBoxSity.ForeColor = Color.Black;

            this.btnSaveUser.Enabled = this.textBoxFIO.Text == "" || this.textBoxSity.Text == "" || this.textBoxFIO.Text == "Введите фамилию имя" || this.textBoxSity.Text == "Введите город" ? false : true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == '-');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection($"Data Source={db_puth.Value}"))
            {
                long newCityID = 0;

                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;

                //добавить город если нет
                var City = FirstUpper(textBoxSity.Text.ToLower());
                if (!RowAlreadyExists(connection, "City", City))
                {
                    command.CommandText = "INSERT INTO City (Name) VALUES ('" + City + "'); "
                                        + "SELECT last_insert_rowid()";
                    newCityID = (long)command.ExecuteScalar();
                }
                else
                {
                    command.CommandText = "SELECT _id from City where Name = '" + City + "'";
                    newCityID = (long)command.ExecuteScalar();
                }

                //добавить пользователя если нет
                if (!RowAlreadyExists(connection, "Users", FirstUpper(textBoxFIO.Text.ToLower())))
                {
                    command.CommandText = "INSERT INTO Users (Name, CityId) VALUES ('" + FirstUpper(textBoxFIO.Text.ToLower()) + "', '" + newCityID + "')";
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show($"Пользователь {textBoxFIO.Text} уже есть!!!");
                }

                textBoxFIO.Text = "";
                textBoxSity.Text = "";
            }

            CalcAndShowCountUsers();
        }

        /// <summary>
        /// первая заглавная
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstUpper(string str)
        {
            string[] s = str.Split(' ');

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > 1)
                    s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1).ToLower();
                else s[i] = s[i].ToUpper();
            }
            return string.Join(" ", s);
        }
    }
}
