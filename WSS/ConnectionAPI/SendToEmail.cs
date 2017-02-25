using System.Net.Mail;
using System.Net;

namespace WSS.ConnectionAPI
{
    public class SendToEmail
    {
        public static void ForgotPassword(string login, string mail)
        {
            RegistredUsers registredUsers = new RegistredUsers();
            string pass = registredUsers.GetData(login);
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
    }
}