using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderWPF.Data
{
    public class MailContextFactory : IDesignTimeDbContextFactory<MailSenderDb>
    {
        public MailSenderDb CreateDbContext(string[] args)
        {
            const string connString = @"Data Source=.\MailSenderDB.sqlite;";

            var optionsBuilder = new DbContextOptionsBuilder<MailSenderDb>();
            optionsBuilder.UseSqlite(connString);

            return new MailSenderDb(optionsBuilder.Options);
        }
    }
}
