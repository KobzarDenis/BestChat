using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ClientComands
    {
        private static object block = new object();
        public static BannedUsers banedUsers;
        public static RegistredUsers registredUsers;

        public static void Authorization(string login, string password, Client client)
        {
            client.name = registredUsers.Read(login, password);
            OnlineUsers.onlineUsers.Add(client);
            Content content = new Content("Authorization", login, client.name, banedUsers.FindUsers(login).ToString());
            string sms = content.GetContent(content);
            SendMessage(sms, OnlineUsers.onlineUsers.First(c => c.login == login));
            if (client.name == "" || client.name == "Not registred")
                OnlineUsers.onlineUsers.Remove(client);
        }

        public static void SignUP(string name, string login, string password, Client client)
        {
            if (registredUsers.Create(name, login, password) == true)
            {
                Content content = new Content("SignUP", "*", "*", "Success");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            else
            {
                Content content = new Content("SignUP", "*", "*", "No success");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
        }

        public static void InviteToDialog(string login, string nameDialog)
        {
            Content content = new Content("Invite", login, nameDialog, "*");
            string sms = content.GetContent(content);

            ListOfDialogs.GetListDialogs().First(d => d.NameDialog == nameDialog).dialog.Add(OnlineUsers.onlineUsers.First(c => c.name == login));
            SendMessage(sms, OnlineUsers.onlineUsers.First(c => c.name == login));
        }

        public static void NewMessage(string nameDialog, string message, string login)
        {
            Content content = new Content("SendMessage", login, nameDialog, message);
            string sms = content.GetContent(content);

            ListOfDialogs.GetListDialogs().First(d => d.NameDialog == nameDialog).messages.Add(message);
            foreach (Client client in ListOfDialogs.GetListDialogs().First(d =>d.NameDialog == nameDialog).dialog)
            {
                if (client != null)
                {
                        SendMessage(sms, client);
                }
            }
        }

        public static void PrivatMessage(string senderLogin, string takerLogin, string message)
        {
            Content content = new Content("PrivatMessage", senderLogin, senderLogin, message);
            string sms = content.GetContent(content);
            SendMessage(sms, OnlineUsers.onlineUsers.First(u => u.name == takerLogin));
        }

        public static void ShowOnlineUsers(Client client)
        {
            Content content = new Content("ShowOnlineUsers", "*", "*", "");
            foreach (Client cl in OnlineUsers.onlineUsers)
            {
                    if(cl.role!="admin" && cl.name!=client.name)
                    content.Message += cl.name + ";"; 
            }
            string sms = content.GetContent(content);
            SendMessage(sms, client);
        }

        public static void ShowBannedUsers(Client client)
        {
            Content content = new Content("ShowBannedUsers", "*", "*", "");
            foreach (string users in banedUsers.GetBannedList())
            {
                    var parts = users.Split('_');
                    content.Message += parts[0] + ";";
            }
            string sms = content.GetContent(content);
            SendMessage(sms, client);
        }

        public static void Banned(Client client)
        {
            Content content = new Content("Banned", "Server", "*", "*");
            string sms = content.GetContent(content);
            SendMessage(sms, client);
        }

        public static void Unbanned(Client client)
        {
            Content content = new Content("Unbaned", "Server", "*", "*");
            string sms = content.GetContent(content);
            SendMessage(sms, client);
        }

        public static void ShowAllUsersForAdmin(Client client)
        {
            Content content = new Content("ShowAllUsersForAdmin", "*", "*", "");
            foreach (Client cl in OnlineUsers.onlineUsers)
            {
                if (cl.role != "admin" && cl.login != client.login)
                    content.Message += cl.login + ";";
            }
            string sms = content.GetContent(content);
            SendMessage(sms, client);
        }

        public static void ShowAllDialogs(Client client)
        {
            Content content = new Content("ShowAllDialogs", "*", "*", "");
            foreach (Dialog dialog in ListOfDialogs.GetListDialogs())
            {
                if(!dialog.PrivatDialog)
                    content.Message += dialog.NameDialog + ";";
            }
            string sms = content.GetContent(content);
            SendMessage(sms, client);
        }

        public static void LogOut(string login)
        {
            OnlineUsers.onlineUsers.Remove(OnlineUsers.onlineUsers.First(c => c.name == login));
            foreach (Dialog dialog in ListOfDialogs.GetListDialogs())
            {
                foreach(Client client in dialog.dialog)
                {
                    if (client.name == login)
                    {
                        dialog.dialog.Remove(client);
                        return;
                    }
                }
            }
        }

        private static void SendMessage(string message, Client client)
        {
            if (client != null)
            {
                lock (block)
                {
                    NetworkStream networkStream = client.client.GetStream();
                    StreamWriter streamWriter = new StreamWriter(networkStream);
                    streamWriter.WriteLine(message);
                    streamWriter.Flush();
                }
            }
        }

    }
}
