using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public static class Mailer
    {
        public static List<string> GetMail(string text)
        {
            return new List<string>();
        }

        public static void Send(Sender sender, string recipient, Msg msg)
        {
            try
            {
                using (MailMessage mailMsg = new MailMessage(sender.Email, recipient, msg.Subject, msg.Body))
                {
                    mailMsg.From = new MailAddress(sender.Email, sender.DisplayName); // Адрес отправителя
                    mailMsg.Sender = mailMsg.From;

                    SmtpClient client = new SmtpClient();
                    client.Host = sender.SmtpServer;
                    client.Port = sender.SmtpPort;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    
                    client.Credentials = new NetworkCredential(sender.Login, sender.Password); // Ваши логин и пароль
                    client.Send(mailMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
