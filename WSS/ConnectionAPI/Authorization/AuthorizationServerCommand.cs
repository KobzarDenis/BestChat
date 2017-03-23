using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSS.AdminSettings;
using WSS.ConnectionAPI;
using WSS.DialogsAPI;

namespace WSS
{
    public class AuthorizationServerCommand
    {
        static AuthorizationClient clientAuth = AuthorizationClient.GetInstance();


        public static void Authorization(string login, string password, Client client)
        {
            try
            {
                ContentFromAuthorizationServer content = new ContentFromAuthorizationServer("Authorization", "*", login, password);
                string sms = content.GetContent(content);
                string callback = clientAuth.Say(sms);
                content = content.SetContent(callback);
                if (content.Name != "Not registred")
                {
                    client.name = content.Name;
                }
                client.client.Send(callback);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "AuthorizationServerCommand - Authorization");
            }
            Log.Add(login, "Authorization", "AuthorizationServerCommand - Authorization");
        }

        public static void SignUP(string name, string login, string password, Client client)
        {
            try
            {
                ContentFromAuthorizationServer content = new ContentFromAuthorizationServer("SignUP", name, login, password);
                string sms = content.GetContent(content);
                client.client.Send(clientAuth.Say(sms));
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "AuthorizationServerCommand - SignUP");
            }
            Log.Add(login, "SignUP", "AuthorizationServerCommand - SignUP");
        }

        public static void ForgotPassword(string login, string email,  Client client)
        {
            try
            {
                ContentFromAuthorizationServer content = new ContentFromAuthorizationServer("ForgotPassword", "*", login, "*");
                string sms = content.GetContent(content);
                string callback = clientAuth.Say(sms);
                client.client.Send(callback);
                content = content.SetContent(callback);
                SendToEmail.ForgotPassword(content.Password, email);
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "AuthorizationServerCommand - ForgotPassword");
            }
            Log.Add(login, "ForgotPassword", "AuthorizationServerCommand - ForgotPassword");
        }

        public static void ChangePassword(string login, string newPass, Client client)
        {
            try
            {
                ContentFromAuthorizationServer content = new ContentFromAuthorizationServer("ChangePassword", "*", login, newPass);
                string sms = content.GetContent(content);
                client.client.Send(clientAuth.Say(sms));
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "AuthorizationServerCommand - ChangePassword");
            }
            Log.Add(login, "ChangePassword", "AuthorizationServerCommand - ChangePassword");
        }
    }
}