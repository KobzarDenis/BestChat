using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class RegistredUsers
    {
        string databaseName;
        SQLiteConnection connection;

        public RegistredUsers()
        {
            this.databaseName = @"Users.db";
            this.connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
        }

        public bool Create( string name,string login, string password)
        {
            if (FindUser(name, login) == false)
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO 'RegistredUsers' ('name','login','password' ) VALUES ('" + name + "','" + login + "','" + password + "');", connection);
                command.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public string Read(string login, string password)
        {
            string nameUser = "";
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'RegistredUsers' WHERE login = '"+login+"' AND "+"password = '"+password+"';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                nameUser = record["name"].ToString();
            }
            Console.WriteLine(nameUser);
            if (nameUser != "" && nameUser != null)
                return nameUser;
            else
                return "Not registred";
        }

        private bool FindUser(string name, string login)
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
    }
}
