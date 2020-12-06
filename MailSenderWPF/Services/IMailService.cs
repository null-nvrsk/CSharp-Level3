using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderWPF.Services
{
    public interface IMailService
    {
        IMailSender GetSender(string Server, int Port, bool IsSSL, string Login, string Password);
    }

    public interface IMailSender
    {
        void Send(string from, string recipient, string subject, string body);
    }
}
