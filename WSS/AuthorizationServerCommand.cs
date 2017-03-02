using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSS.AdminSettings;
using WSS.ConnectionAPI;

namespace WSS
{
    public class AuthorizationServerCommand
    {
        static AuthorizationClient clientAuth = AuthorizationClient.GetInstance();


        public static void Authorization(string login, string password, Client client)
        {
            ContentFromAuthorizationServer content = new ContentFromAuthorizationServer("Authorization", "*", login, password);
            string sms = content.GetContent(content);
            client.client.Send(clientAuth.Say(sms));
        }

        public static void SignUP(string name, string login, string password, Client client)
        {
            ContentFromAuthorizationServer content = new ContentFromAuthorizationServer("SignUP", name , login, password);
            string sms = content.GetContent(content);
            client.client.Send(clientAuth.Say(sms));
        }

        public static void ForgotPassword(string login, string email,  Client client)
        {
            ContentFromAuthorizationServer content = new ContentFromAuthorizationServer("ForgotPassword", "*", login, "*");
            string sms = content.GetContent(content);
            string callback = clientAuth.Say(sms);
            client.client.Send(callback);
            content = content.SetContent(callback);
            SendToEmail.ForgotPassword(content.Password, email);
        }

        public static void ChangePassword(string login, string newPass, Client client)
        {
            ContentFromAuthorizationServer content = new ContentFromAuthorizationServer("ChangePassword", "*", login, newPass);
            string sms = content.GetContent(content);
            client.client.Send(clientAuth.Say(sms));
        }
    }
}