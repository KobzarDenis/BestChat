using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WSS.AdminSettings;
using WSS.DialogsAPI;

namespace WSS.ConnectionAPI
{
    class ClientComands
    {
        private static object block = new object();
        public static BannedUsers banedUsers;
        public static RegistredUsers registredUsers;

        public static void Authorization(string login, string password, Client client)
        {
            try
            {
                client.name = registredUsers.Read(login, password);
                Content content = new Content("Authorization", client.name, login, "*", "*", banedUsers.FindUsers(login).ToString());
                string sms = content.GetContent(content);
                SendMessage(sms, OnlineUsers.onlineUsers.First(c => c.login == login));
                if (client.name == "" || client.name == "Not registred")
                    OnlineUsers.onlineUsers.Remove(client);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - Authorization");
            }
            Log.Add(login, "Authorization", "ClientComands - Authorization ");
        }

        public static void AuthorizationWithOtherService(Client client)
        {
            try
            {
                Content content = new Content("Authorization", client.name, "*", "*", "*", "*");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - AuthorizationWithOtherService");
            }
            Log.Add(client.name, "AuthorizationWithOtherService", "ClientComands - AuthorizationWithOtherService ");
        }

        public static void SignUP(string name, string login, string password, Client client)
        {
            try
            {
                if (registredUsers.Create(name, login, password) == true)
                {
                    Content content = new Content("SignUP", "*", "*", "*", "*", "Success");
                    string sms = content.GetContent(content);
                    SendMessage(sms, client);
                }
                else
                {
                    Content content = new Content("SignUP", "*", "*", "*", "*", "No success");
                    string sms = content.GetContent(content);
                    SendMessage(sms, client);
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - SignUP");
            }
            Log.Add(login, "SignUP", "ClientComands - SignUP ");
        }

        public static void InviteToDialog(string login, string nameDialog)
        {
            try
            {
                Content content = new Content("Invite", "*", login, "*", nameDialog, "*");
                string sms = content.GetContent(content);

                ListOfDialogs.GetListDialogs().First(d => d.NameDialog == nameDialog).dialog.Add(OnlineUsers.onlineUsers.First(c => c.name == login));
                SendMessage(sms, OnlineUsers.onlineUsers.First(c => c.name == login));
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - InviteToDialog");
            }
            Log.Add(login, "InviteToDialog", "ClientComands - InviteToDialog ");
        }

        public static void NewMessage(string nameDialog, string message, string login)
        {
            try
            {
                Content content = new Content("SendMessage", "*", login, "*", nameDialog, message);
                string sms = content.GetContent(content);

                ListOfDialogs.GetListDialogs().First(d => d.NameDialog == nameDialog).messages.Add(message);
                foreach (Client client in ListOfDialogs.GetListDialogs().First(d => d.NameDialog == nameDialog).dialog)
                {
                    if (client != null && client.name != login)
                    {
                        SendMessage(sms, client);
                    }
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - NewMessage");
            }
            Log.Add(login, "NewMessage", "ClientComands - NewMessage ");
        }

        public static void PrivatMessage(string senderLogin, string takerLogin, string message)
        {
            try
            {
                Content content = new Content("PrivatMessage", "*", senderLogin, "*", senderLogin, message);
                string sms = content.GetContent(content);
                SendMessage(sms, OnlineUsers.onlineUsers.First(u => u.name == takerLogin));
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - PrivatMessage");
            }
            Log.Add(senderLogin, "PrivatMessage", "ClientComands - PrivatMessage ");
        }

        public static void ShowOnlineUsers(Client client)
        {
            try
            {
                Content content = new Content("ShowOnlineUsers", "*", "*", "*", "*", "");
                foreach (Client cl in OnlineUsers.onlineUsers)
                {
                    if (cl.role != "admin" && cl.name != client.name && cl.name != "admin")
                        content.Message += cl.name + ";";
                }
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - ShowOnlineUsers");
            }
            Log.Add(client.name, "ShowOnlineUsers", "ClientComands - ShowOnlineUsers ");
        }

        public static void ShowBannedUsers(Client client)
        {
            try
            {
                Content content = new Content("ShowBannedUsers", "*", "*", "*", "*", "");
                foreach (string users in banedUsers.GetBannedList())
                {
                    var parts = users.Split('_');
                    content.Message += parts[0] + ";";
                }
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - ShowBannedUsers");
            }
            Log.Add(client.name, "ShowBannedUsers", "ClientComands - ShowBannedUsers ");
        }

        public static void Banned(Client client)
        {
            try
            {
                Content content = new Content("Banned", "Server", "*", "*", "*", "*");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - Banned");
            }
            Log.Add(client.name, "Banned", "ClientComands - Banned ");
        }

        public static void Unbanned(Client client)
        {
            try
            {
                Content content = new Content("Unbaned", "Server", "*", "*", "*", "*");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - Unbanned");
            }
            Log.Add(client.name, "Unbanned", "ClientComands - Unbanned ");
        }

        public static void ChangePassword(string login, string newPass,Client client)
        {
            try
            {
                if (registredUsers.Update(login, newPass))
                {
                    Content content = new Content("ChangePassword", "Server", "*", "*", "*", "*");
                    string sms = content.GetContent(content);
                    SendMessage(sms, client);
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - ChangePassword");
            }
            Log.Add(login, "ChangePassword", "ClientComands - ChangePassword ");
        }

        public static void ShowAllUsersForAdmin(Client client)
        {
            try
            {
                Content content = new Content("ShowAllUsersForAdmin", "*", "*", "", "*", "*");
                foreach (Client cl in OnlineUsers.onlineUsers)
                {
                    if (cl.role != "admin" && cl.login != client.login)
                        content.Message += cl.login + ";";
                }
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - ShowAllUsersForAdmin");
            }
            Log.Add(client.login, "ShowAllUsersForAdmin", "ClientComands - ShowAllUsersForAdmin ");
        }

        public static void ShowAllDialogs(Client client)
        {
            try
            {
                Content content = new Content("ShowAllDialogs", "*", "*", "", "*", "");
                foreach (Dialog dialog in ListOfDialogs.GetListDialogs())
                {
                    if (dialog.PrivatDialog == false)
                        content.Message += dialog.NameDialog + ";";
                }
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - ShowAllDialogs");
            }
            Log.Add(client.login, "ShowAllDialogs", "ClientComands - ShowAllDialogs ");
        }

        public static void LogOut(string login)
        {
            try
            {
                OnlineUsers.onlineUsers.Remove(OnlineUsers.onlineUsers.First(c => c.name == login));
                foreach (Dialog dialog in ListOfDialogs.GetListDialogs())
                {
                    foreach (Client client in dialog.dialog)
                    {
                        if (client.name == login)
                        {
                            dialog.dialog.Remove(client);
                            return;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - LogOut");
            }
            Log.Add(login, "LogOut", "ClientComands - LogOut ");
        }

        private static void SendMessage(string message, Client client)
        {
            try
            {
                if (client != null)
                {
                    lock (block)
                    {
                        client.client.Send(message);
                    }
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "ClientComands - SendMessage");
            }
        }

    }
}
