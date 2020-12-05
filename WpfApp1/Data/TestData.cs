﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderWPF.Models;

namespace MailSenderWPF.Data
{
    public static class TestData
    {
        public static List<Server> Servers 
        { 
            get
            {
                var result = new List<Server>();
                for (int i = 0; i < 10; i++)
                {
                    var server = new Server { Address = $"address{i}", Port = 10000 + i };
                    result.Add(server);    
                }
                return result;
            }
        }

        public static List<Sender> Senders
        {
            get
            {
                return Enumerable.Range(0, 10).Select(i => new Sender() { Email =  $"address{i}", DisplayName = $"name{i}" }).ToList();
            }
        }

        public static List<Recipient> Recipients
        {
            get
            {
                return Enumerable.Range(0, 10).Select(i => new Recipient() { Email = $"address{i}", Name = $"name{i}", Id = i }).ToList();
            }
        }

    }
}
