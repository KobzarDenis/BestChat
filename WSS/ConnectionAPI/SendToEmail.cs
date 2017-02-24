using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace WSS.ConnectionAPI
{
    public class SendToEmail
    {
        public static void ForgotPassword(string login, string mail)
        {
            RegistredUsers registredUsers = new RegistredUsers();

            SmtpClient Smtp = new SmtpClient("smtp.yandex.ru", 25);
            Smtp.Credentials = new NetworkCredential("best.chat.company@yandex.ru", "besthhat");
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("best.chat.company@yandex.ru");
            Message.To.Add(new MailAddress(mail));
            Message.Subject = "Пароль";
            Message.Body = "Ваш пароль : " + registredUsers.GetData(login);
            try
            {
                Smtp.Send(Message);
            }
            catch (SmtpException)
            {
                
            }
        }
    }
}