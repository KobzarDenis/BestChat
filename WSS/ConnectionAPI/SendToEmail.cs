using System.Net.Mail;
using System.Net;
using System;

namespace WSS.ConnectionAPI
{
    public class SendToEmail
    {
        public static void ForgotPassword(string pass, string mail)
        {
            try
            {
                if (pass != "" && pass != null)
                {
                    SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 587);
                    Smtp.Credentials = new NetworkCredential("bestchat.helper@gmail.com", "bestchat");
                    MailMessage Message = new MailMessage();
                    Message.From = new MailAddress("bestchat.helper@gmail.com");
                    Message.To.Add(new MailAddress(mail));
                    Message.Subject = "Пароль";
                    Message.Body = "Ваш пароль : " + pass;
                    Smtp.EnableSsl = true;
                    Smtp.Send(Message);
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "SendToEmail - ForgotPassword");
            }
            Log.Add(mail, "ForgotPassword", "SendToEmail - ForgotPassword");
        }
    }
}