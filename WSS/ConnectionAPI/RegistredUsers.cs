using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WSS.ConnectionAPI
{
    class RegistredUsers
    {
        string databaseName;
        SQLiteConnection connection;

        public RegistredUsers()
        {
            databaseName = HttpContext.Current.Server.MapPath("/App_Data/Users.db");
            connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
        }

        public bool Create( string name,string login, string password)
        {
            try
            {
                if (FindUser(name, login) == false)
                {
                    SQLiteCommand command = new SQLiteCommand("INSERT INTO 'RegistredUsers' ('name','login','password' ) VALUES ('" + name + "','" + login + "','" + password + "');", connection);
                    command.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "RegistredUsers - Create");
                return false;
            }
        }

        public string Read(string login, string password)
        {
            try
            {
                string nameUser = "";
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'RegistredUsers' WHERE login = '" + login + "' AND " + "password = '" + password + "';", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    nameUser = record["name"].ToString();
                }
                if (nameUser != "" && nameUser != null)
                    return nameUser;
                else
                    return "Not registred";
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "RegistredUsers - Read");
                return null;
            }
        }

        public bool Update(string name, string newPass)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand("UPDATE 'RegistredUsers' SET password='" + newPass + "' WHERE name='" + name + "';", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "RegistredUsers - Update");
                return false;
            }
        }

        public string GetData(string login)
        {
            try
            {
                string pass = "";
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'RegistredUsers' WHERE login = '" + login + "';", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    pass = record["password"].ToString();
                }
                return pass;
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "RegistredUsers - GetData");
                return null;
            }
        }

        private bool FindUser(string name, string login)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'RegistredUsers';", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    if (name == record["name"].ToString() || login == record["login"].ToString())
                        return true;
                }

                return false;
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "RegistredUsers - FindUser");
                return false;
            }
        }
    }
}
