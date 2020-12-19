using MailSenderWPF.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderWPF.Models
{
    public class Recipient : Person, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    if (Name == "") return "Пустое имя";
                    if (Name.Length < 3) return "Слишком короткое имя";
                }

                return "";
            }

	    }

        public string Error => throw new NotImplementedException();

        public override string Name 
        {
            get => base.Name;
            set
            {
                //if (value == "")
                //    throw new ArgumentException("Пустое имя", nameof(value));
                //if (value.Length < 3)
                //    throw new ArgumentException("Слишком короткое имя", nameof(value));

                base.Name = value;
            }
        }
    }
}
