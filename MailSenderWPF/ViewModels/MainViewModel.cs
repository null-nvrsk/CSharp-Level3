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
using MailSenderWPF.Services;
using MailSenderWPF.ViewModels;

namespace MailSenderWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        #region Commands

        public ICommand SendMessageCommand { get; set; }
        //public ICommand DialogCommand { get; set; }
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
            MessageBox.Show("Add server");
        }

        public bool AddServerCommand_CanExecute()
        {
            return true;
        }

        public void EditServerCommand_Execute()
        {
            MessageBox.Show("Edit server");
        }

        public bool EditServerCommand_CanExecute()
        {
            if (SelectedServer is null) return false;
            return true;
        }

        public void DelServerCommand_Execute()
        {
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

        //public void DialogCommand_Execute(string text)
        //{
        //    MessageBox.Show(text);
        //}

        //public bool DialogCommand_CanExecute(string text)
        //{
        //    if (text is null) return false;
        //    return true;
        //}

        #endregion

        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        private string _title = "Our test window";

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Server> _servers;
        private ObservableCollection<Sender> _senders;
        private ObservableCollection<Recipient> _recipients;
        private ObservableCollection<Message> _messages;

        public ObservableCollection<Server> Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }

        public ObservableCollection<Sender> Senders
        {
            get { return _senders; }
            set { _senders = value; }
        }

        public ObservableCollection<Recipient> Recipients
        {
            get { return _recipients; }
            set { _recipients = value; }
        }

        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        private Server _selectedServer;
        private Sender _selectedSender;
        private Recipient _selectedRecipient;
        private Message _selectedMessage;

        public Server SelectedServer
        {
            get { return _selectedServer; }
            set { _selectedServer = value; OnPropertyChanged(); }
        }

        public Sender SelectedSender
        {
            get { return _selectedSender; }
            set { _selectedSender = value; OnPropertyChanged(); }
        }
        public Recipient SelectedRecipient
        {
            get { return _selectedRecipient; }
            set { _selectedRecipient = value; OnPropertyChanged(); }
        }
        public Message SelectedMessage
        {
            get { return _selectedMessage; }
            set { _selectedMessage = value; OnPropertyChanged(); }
        }

        private IMailService _mailService { get; set; }

        public MainViewModel(IMailService mailService)
        {
            _mailService = mailService;

            SendMessageCommand = new Command(SendMessageCommand_Execute, SendMessageCommand_CanExecute);
            //DialogCommand = new RelayCommand<string>(DialogCommand_Execute, DialogCommand_CanExecute);

            AddServerCommand = new Command(AddServerCommand_Execute, AddServerCommand_CanExecute);
            EditServerCommand = new Command(EditServerCommand_Execute, EditServerCommand_CanExecute);
            DelServerCommand = new Command(DelServerCommand_Execute, DelServerCommand_CanExecute);

            AddSenderCommand = new Command(AddSenderCommand_Execute, AddSenderCommand_CanExecute);
            EditSenderCommand = new Command(EditSenderCommand_Execute, EditSenderCommand_CanExecute);
            DelSenderCommand = new Command(DelSenderCommand_Execute, DelSenderCommand_CanExecute);


            AddRecipientCommand = new Command(AddRecipientCommand_Execute, AddRecipientCommand_CanExecute);
            EditRecipientCommand = new Command(EditRecipientCommand_Execute, EditRecipientCommand_CanExecute);
            DelRecipientCommand = new Command(DelRecipientCommand_Execute, DelRecipientCommand_CanExecute);

            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);
        }
    }
}
