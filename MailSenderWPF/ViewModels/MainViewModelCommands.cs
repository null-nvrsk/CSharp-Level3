using MailSenderWPF.Data;
using MailSenderWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using MailSenderWPF.Commands;
using MailService;
using MailSenderWPF.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MailSenderWPF.ViewModels
{
    public partial class MainViewModel
    {
        public ICommand SendMessageCommand { get; set; }

        public ICommand AddServerCommand { get; set; }
        public ICommand EditServerCommand { get; set; }
        public ICommand DelServerCommand { get; set; }

        public ICommand AddSenderCommand { get; set; }
        public ICommand EditSenderCommand { get; set; }
        public ICommand DelSenderCommand { get; set; }

        public ICommand AddRecipientCommand { get; set; }
        public ICommand EditRecipientCommand { get; set; }
        public ICommand DelRecipientCommand { get; set; }


        //----------------------------------------------------
        public void AddServerCommand_Execute()
        {
            var random = new Random();

            var server = new Server() { Address = "server555.ru", Port = 31337, IsSSL = true };

            _mailSenderDb.Servers.Add(server);
            _mailSenderDb.SaveChanges();

            if (server.Id > 0) Servers.Add(server);
        }

        public bool AddServerCommand_CanExecute()
        {
            return true;
        }

        public void EditServerCommand_Execute()
        {
            SelectedServer.Port++;
 
            _mailSenderDb.Servers.Update(SelectedServer);
            _mailSenderDb.SaveChanges();

            
            OnPropertyChanged("Servers");
            OnPropertyChanged("SelectedServer");
            //var serverWindow = new ServerWindow();
            //serverWindow.ShowDialog();
        }

        public bool EditServerCommand_CanExecute()
        {
            if (SelectedServer is null) return false;
            return true;
        }

        public void DelServerCommand_Execute()
        {
            _mailSenderDb.Entry(SelectedServer).State = EntityState.Deleted;
            _mailSenderDb.Servers.Remove(SelectedServer);
            _mailSenderDb.SaveChanges();

            Servers.Remove(SelectedServer);
            SelectedServer = Servers.FirstOrDefault();
        }

        public bool DelServerCommand_CanExecute()
        {
            if (SelectedServer is null) return false;
            return true;
        }

        //----------------------------------------------------
        public void AddSenderCommand_Execute()
        {
            MessageBox.Show("Add sender");
        }

        public bool AddSenderCommand_CanExecute()
        {
            return true;
        }

        public void EditSenderCommand_Execute()
        {
            MessageBox.Show("edit");
        }

        public bool EditSenderCommand_CanExecute()
        {
            if (SelectedSender is null) return false;
            return true;
        }

        public void DelSenderCommand_Execute()
        {
            Senders.Remove(SelectedSender);
            SelectedSender = Senders.FirstOrDefault();
        }

        public bool DelSenderCommand_CanExecute()
        {
            if (SelectedSender is null) return false;
            return true;
        }

        //----------------------------------------------------
        public void AddRecipientCommand_Execute()
        {
            MessageBox.Show("Add recipient");
        }

        public bool AddRecipientCommand_CanExecute()
        {
            return true;
        }

        public void EditRecipientCommand_Execute()
        {
            MessageBox.Show("Edit recipient");
        }

        public bool EditRecipientCommand_CanExecute()
        {
            if (SelectedRecipient is null) return false;
            return true;
        }

        public void DelRecipientCommand_Execute()
        {
            Recipients.Remove(SelectedRecipient);
            SelectedRecipient = Recipients.FirstOrDefault();
        }

        public bool DelRecipientCommand_CanExecute()
        {
            if (SelectedRecipient is null) return false;
            return true;
        }

        //----------------------------------------------------
        public void SendMessageCommand_Execute()
        {
            var mailSender = _mailService.GetSender(SelectedServer.Address, SelectedServer.Port, SelectedServer.IsSSL, SelectedServer.Login, SelectedServer.Password);
            mailSender.Send(SelectedSender.Email, SelectedRecipient.Email, SelectedMessage.Subject, SelectedMessage.Body);
        }

        public bool SendMessageCommand_CanExecute()
        {
            if (SelectedServer != null && SelectedSender != null && SelectedRecipient != null && SelectedMessage != null) return true;

            return false;
        }
    }
}
