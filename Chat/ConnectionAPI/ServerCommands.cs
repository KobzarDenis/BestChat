using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class ServerCommands
    {
        public static ClientAPI me;

        public ServerCommands()
        {

        }

        public static void Authorization(string login, string password)
        {
            Content content = new Content("Authorization", login, ClientAPI.Role, password, "*");
            string message = content.GetContent(content); 
            me.Say(message);
        }

        public static void SingUP(string name, string login, string password)
        {
            Content content = new Content("SignUP", name, ClientAPI.Role, login, password);
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void InviteToDialog(string dialog, string nameUsers)
        {
            Content content = new Content("Invite", nameUsers, ClientAPI.Role, dialog, "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void SendMessage(string dialog, string login, string sms)
        {
            Content content = new Content("SendMessage", login, ClientAPI.Role, dialog, sms);
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void SendPrivateMessage(string takerLogin, string sms)
        {
            Content content = new Content("PrivatMessage", ClientAPI.Login, ClientAPI.Role, takerLogin, sms);
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void CloseDialog(string dialog, string login)
        {
            Content content = new Content("CloseDialog", login, ClientAPI.Role, dialog, "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void ToComeIn_TheDialog(string dialog, string login)
        {
            Content content = new Content("ToComeIn", login, ClientAPI.Role, dialog, "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void ShowAllDialogs(string login)
        {
            Content content = new Content("ShowAllDialogs", login, ClientAPI.Role, "*", "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void ShowOnlineUsers(string login)
        {
            Content content = new Content("ShowOnlineUsers", login, ClientAPI.Role, "*", "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void CreateDialog(string login, string nameDialod)
        {
            Content content = new Content("CreateDialog", login, ClientAPI.Role, nameDialod, "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void LogOut(string login)
        {
            Content content = new Content("LogOut", login, ClientAPI.Role, "*", "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void ForgotPassword(string login, string email)
        {
            Content content = new Content("ForgotPassword", login, ClientAPI.Role, "*", email);
            string message = content.GetContent(content);
            me.Say(message);
        }

        #region Admin setings
        public static void Ban(string login, string time)
        {
            Content content = new Content("BanUser", login, ClientAPI.Role, "*", time);
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void Unban(string login)
        {
            Content content = new Content("UnbanUser", login, ClientAPI.Role, "*", "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void ShowBannedUsers()
        {
            Content content = new Content("ShowBannedUsers", ClientAPI.Login, ClientAPI.Role, "*", "*");
            string message = content.GetContent(content);
            me.Say(message);
        }

        public static void ShowAllUsersForAdmin()
        {
            Content content = new Content("ShowAllUsersForAdmin", ClientAPI.Login, ClientAPI.Role, "*", "*");
            string message = content.GetContent(content);
            me.Say(message);
        }
        #endregion
    }
}
