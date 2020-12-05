using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Support
{
    public class Mailer
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool IsSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        public void SendMail(string sender, string recipient, string subject, string body)
        {
            try
            {
                using (MailMessage mailMsg = new MailMessage(sender, recipient))
                {
                    mailMsg.From = new MailAddress(sender); // Адрес отправителя
                    mailMsg.Sender = mailMsg.From;
                    mailMsg.Subject = subject;
                    mailMsg.Body = body;

                    SmtpClient client = new SmtpClient();
                    client.Host = SmtpServer;
                    client.Port = SmtpPort;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = IsSSL;

                    client.Credentials = new NetworkCredential(Login, Password); // Ваши логин и пароль
                    client.Send(mailMsg);
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}
