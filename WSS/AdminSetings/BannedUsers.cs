﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Data.Common;
using WSS.DialogsAPI;
using WSS.ConnectionAPI;
using System.Web;

namespace WSS.AdminSettings
{
    public class BannedUsers
    {
        private List<string> list;

        string databaseName;
        SQLiteConnection connection;

        public BannedUsers()
        {
                list = new List<string>();
                databaseName = HttpContext.Current.Server.MapPath("/App_Data/BannedUsers.db");
                connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                connection.Open();
        }

        public void Ban(string login, string time)
        {
            try
            {
                OnlineUsers.onlineUsers.First(u => u.login == login).Ban = true;

                SQLiteCommand command = new SQLiteCommand("INSERT INTO 'Banned' ('value','time' ) VALUES ('" + login + "','" + time + "');", connection);
                command.ExecuteNonQuery();
                Read();
                ClientComands.Banned(OnlineUsers.onlineUsers.First(u => u.login == login));
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "BannedUsers - Ban");
            }
            Log.Add("admin", "Ban", "BannedUsers - Ban");
        }

        public void Read()
        {
            try
            {
                list = new List<string>();
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Banned';", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    string nameUser = record["value"].ToString();
                    string time = record["time"].ToString();
                    string result = nameUser + "_" + time;
                    list.Add(result);
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "BannedUsers - Read");
            }
        }

        public List<string> GetBannedList()
        {
            try
            {
                Read();
                return list;
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "BannedUsers - GetBannedList");
                return null;
            }
        }

        public void Unban(string login)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand("DELETE FROM Banned WHERE value= '" + login + "';", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                Read();
                if (OnlineUsers.onlineUsers.Any(u => u.login == login))
                    ClientComands.Unbanned(OnlineUsers.onlineUsers.First(u => u.login == login));
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "BannedUsers - Unban");
            }
            Log.Add("admin", "Unban", "BannedUsers - Unban");
        }

        public void AutomaticUnban()
        {
            try
            {
                while (true)
                {
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Banned';", connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    foreach (DbDataRecord record in reader)
                    {
                        string nameUser = record["value"].ToString();
                        string time = record["time"].ToString();
                        if (time != "forever" && time != "Forever")
                        {
                            DateTime dateNow = DateTime.Now;
                            DateTime dateInDB = Convert.ToDateTime(time);
                            if (dateInDB <= dateNow)
                            {
                                Unban(nameUser);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "BannedUsers - AutomaticUnban");
            }
        }

        public bool FindUsers(string login)
        {
            try
            {
                foreach (string user in list)
                {
                    var parts = user.Split(':');
                    if (parts[0] == login)
                        return true;
                }
                return false;
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "BannedUsers - FindUsers");
                return false;
            }
        }
    }
}
