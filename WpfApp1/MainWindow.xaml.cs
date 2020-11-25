using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            Sender mailSender = new Sender();
            mailSender.Email = tbEmail.Text;
            mailSender.DisplayName = tbDisplayName.Text;
            mailSender.Login = tbLogin.Text;
            mailSender.Password = tbPassword.Password;
            mailSender.SmtpServer = tbSmtpServer.Text;
            mailSender.SmtpPort = Convert.ToInt16(tbSmtpPort.Text);

            string recipient = tbRecipient.Text;

            Msg message = new Msg();
            message.Subject = tbSubject.Text;
            message.Body = tbBody.Text;

            Mailer.Send(mailSender, recipient, message);
        }
    }
}
