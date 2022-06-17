using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    class DataBase
    {
        public bool ExecuteCommand(MySqlCommand command)
        {
            bool bl = true;
            try
            {
                Variables.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception x) { MessageBox.Show(x.ToString()); bl = false; }
            if (Variables.Connection.State == ConnectionState.Open)
                Variables.Connection.Close();
            return bl;
        }
        public void FillConnection(string server, string port, string database, string username, string password)
        {
            Variables.Connection = new MySqlConnection(@"Server = " + server + "; Port = " + port + "; DataBase = '" + database + "'; user ID = '" + username + "'; Password = '" + password + "'; CharSet=utf8 ");
        }
        public bool TestConnection()
        {
            bool success = true;
            try
            {
                Variables.Connection.Open();
            }
            catch
            {
                MessageBox.Show("Подключение не удалось.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            if (Variables.Connection.State == ConnectionState.Open)
                Variables.Connection.Close();
            return success;
        }
        public void SaveConnection(string server, string port, string database, string username, string password)
        {
            if(!(Directory.Exists(Path.GetDirectoryName(Variables.filepath))))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Variables.filepath));
                using (FileStream fs = File.Create(Variables.filepath)) { }
            }
            else if(!(File.Exists(Variables.filepath)))
                using (FileStream fs = File.Create(Variables.filepath)) { }
            try
            {
                using(FileStream fs= File.Open(Variables.filepath, FileMode.Open)) { fs.SetLength(0); }
                using (StreamWriter sw = new StreamWriter(Variables.filepath))
                {
                    sw.WriteLine(server);
                    sw.WriteLine(port);
                    sw.WriteLine(database);
                    sw.WriteLine(username);
                    sw.WriteLine(password);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно получить доступ к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadConnection(TextBox server, TextBox port, TextBox database, TextBox username, TextBox password)
        {
            if (File.Exists(Variables.filepath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(Variables.filepath))
                    {
                        server.Text = sr.ReadLine();
                        port.Text = sr.ReadLine();
                        database.Text = sr.ReadLine();
                        username.Text = sr.ReadLine();
                        password.Text = sr.ReadLine();
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно получить думтуп к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Файл сохранения не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void OpenDirectory()
        {
            if (Directory.Exists(Path.GetDirectoryName(Variables.filepath)))
            {
                Process.Start(Path.GetDirectoryName(Variables.filepath));
            }
            else
                MessageBox.Show("Файл сохранения не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void FillTable(DataTable dt, DataGridView dgv)
        {
            if (dt.Columns.Count == dgv.Columns.Count)
                try
                {
                    dgv.Rows.Clear();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dgv.Rows.Add();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dgv.Rows[j].Cells[i].Value = dt.Rows[j][i].ToString();
                        }
                    }
                }
                catch (Exception x) { MessageBox.Show(x.ToString()); }
            else
                MessageBox.Show("Количество столбцов в таблицу базы данных и DataGridView не равны.", "СООБЩЕНИЕ ПРОГРАММИСТУ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public DataTable Selecting(string sql)
        {
            DataTable result = new DataTable();
            try
            {
                Variables.Connection.Open();
                MySqlCommand command = new MySqlCommand(sql, Variables.Connection);
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception x) { MessageBox.Show(x.ToString()); }
            if (Variables.Connection.State == ConnectionState.Open)
                Variables.Connection.Close();
            return result;
        }
        public DataTable Select(string table)
        {
            return Selecting("SELECT * FROM '" + table + "'");
        }
        public DataTable Select(string table, string attributes)
        {
            return Selecting("SELECT " + attributes + " FROM '" + table + "'");
        }
        public DataTable Select(string table, string attributes, string where)
        {
            return Selecting("SELECT " + attributes + " FROM '" + table + "' WHERE " + where);
        }
        public void FillUsers(DataTable dt, DataGridView dgv)
        {
            DataTable dtclone = dt.Clone();
            dtclone.Columns[14].DataType = typeof(string);
            dtclone.Columns[16].DataType = typeof(string);
            dtclone.Columns[18].DataType = typeof(string);
            foreach (DataRow row in dt.Rows)
                dtclone.ImportRow(row);
            dt.Dispose();
            foreach (DataRow row in dtclone.Rows)
            {
                if (!(row[14].ToString() == ""))//Автор
                {
                    DataTable dt2 = Select("users", "surname,name,patronymic", "id = '" + Convert.ToInt32(row[14]) + "'");
                    row[14] = dt2.Rows[0][0] + " " + dt2.Rows[0][1] + " " + dt2.Rows[0][2];
                }
                if (!(row[16].ToString() == ""))//Изменивший
                {
                    DataTable dt2 = Select("users", "surname,name,patronymic", "id = '" + Convert.ToInt32(row[16]) + "'");
                    row[16] = dt2.Rows[0][0] + " " + dt2.Rows[0][1] + " " + dt2.Rows[0][2];
                }
                if (!(row[18].ToString() == ""))//Автор
                {
                    DataTable dt2 = Select("users", "surname,name,patronymic", "id = '" + Convert.ToInt32(row[18]) + "'");
                    row[18] = dt2.Rows[0][0] + " " + dt2.Rows[0][1] + " " + dt2.Rows[0][2];
                }
            }
            FillTable(dtclone, dgv);
        }
        public bool InsertUsers(string role, string surname, string name, string patronymic, string login, string password, string passport, string contact, DateTime birthdate, string address)
        {
            string sql = "INSERT INTO 'users' (role, suname, name, patonymic, login, password, passport, contact, birthdate, address, enabled, createddate, author) " +
                "VALUES(@ROLE, @SURNAME, @NAME, @PATRONYMIC, @LOGIN, @PASSWORD, @PASSPORT, @CONTACT, @BIRTHDATE, @ADDRESS, @ENABLED, NOW(), @AUTHOR)";
            MySqlCommand command = new MySqlCommand(sql, Variables.Connection);
            command.Parameters.AddWithValue("@ROLE", role);
            command.Parameters.AddWithValue("@SURNAME", surname);
            command.Parameters.AddWithValue("@NAME", name);
            command.Parameters.AddWithValue("@PATRONYMIC", patronymic);
            command.Parameters.AddWithValue("@LOGIN", login);
            command.Parameters.AddWithValue("@PASSWORD", password);
            command.Parameters.AddWithValue("@PASSPORT", passport);
            command.Parameters.AddWithValue("@CONTACT", contact);
            command.Parameters.AddWithValue("@BIRTHDATE", birthdate);
            command.Parameters.AddWithValue("@ADDRESS", address);
            command.Parameters.AddWithValue("@ENABLED", 1);
            command.Parameters.AddWithValue("@AUTHOR", Variables.User.ID);
            return ExecuteCommand(command);
        }
        public bool UpdateUsers(int id, string surname, string name, string patronymic, string login, string password, string passport, string contact, string birthdate, string address)
        {
            string sql = "UPDATE 'users' SET" +
                "surname = '" + surname + "'," +
                "name = '" + name + "'," +
                "patronymic = '" + patronymic + "'," +
                "login = '" + login + "'," +
                "password = '" + password + "'," +
                "passport = '" + passport + "'," +
                "contact = '" + contact + "'," +
                "birthdate = '" + birthdate + "'," +
                "address = '" + address + "'," +
                "editdate = NOW(), " +
                "editor = '" + Variables.User.ID + "'," +
                "WHERE id = '" + id + "'";
            MySqlCommand command = new MySqlCommand(sql, Variables.Connection);
            return ExecuteCommand(command);
        }
        public bool DeleteRecord(int id, string table)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE '" + table + "' SET enabled = '0', disabledate = NOW(), disabler = '" + Variables.User.ID + "' WHERE ID = '" + id + "'", Variables.Connection);
            if (table == "users")
            {
                if (Select(table, "isActive", "id = '" + id + "'").Rows[0][0].ToString() == "False")
                    return ExecuteCommand(cmd);
                else
                {
                    MessageBox.Show("Пользователь активен в данный момент", "Удаление не удалось", MessageBoxButtons.OK);
                    return false;
                }
            }
            else
                return ExecuteCommand(cmd);
        }
        public bool RestoreRecord(int id, string table)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE '" + table + "'SET enabled = '1', disabledate = NULL WHERE ID = '" + id + "'", Variables.Connection);
            return ExecuteCommand(cmd);
        }
        public void ChangePass(string old, string newpass)
        {
            if (Select("users", "*", "password = '" + old + "' AND id = '" + Variables.User.ID + "'").Rows.Count == 1)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE 'users' SET password = '" + newpass + "'WHERE ID = '" + Variables.User.ID + "'", Variables.Connection);
                ExecuteCommand(cmd);
                ActiveUpdater.MakeActive();
                MessageBox.Show("Пароль успешно изменён.", "Пароль изменён", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Неверно введён старый пароль.", "Пароль не изменён", MessageBoxButtons.OK);
        }
        public bool AuthCheck(string login, string password)
        {
            DataTable result = Select("users", "*", "login='" + login + "'AND password'" + password + "'AND enabled = 1");
            if (result.Rows.Count == 1)
            {
                Variables.User.Fill(Convert.ToInt32(result.Rows[0][0]), result.Rows[0][2].ToString() + " " + result.Rows[0][3].ToString() + " " + result.Rows[0][4].ToString(), login, result.Rows[0][1].ToString());
                return true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка");
                return false;
            }
        }
    }
}