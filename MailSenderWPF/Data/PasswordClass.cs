using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderWPF.Data
{
    public static class PasswordClass
    {
        public static string Encode(string password)
        {
            var result = "";
            foreach (var ch in password)
            {
                var newCh = ch;
                newCh--;
                result += newCh;
            }

            return result;
        }

        public static string Decode(string codedPassword)
        {
            var result = "";
            foreach (var ch in codedPassword)
            {
                var newCh = ch;
                newCh++;
                result += newCh;
            }

            return result;
        }

    }
}
