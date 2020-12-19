using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderWPF.Models.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class EntityNamed : Entity
    {
        public virtual string Name { get; set; }
    }

    public abstract class Person : EntityNamed
    {
        public virtual string Email { get; set; }
    }
}
