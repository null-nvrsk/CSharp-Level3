using MailSenderWPF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderWPF.ViewModels
{
    class ViewModelLocator
    {
        public MainViewModel MainWindowModel => App.Services.GetRequiredService<MainViewModel>();
    }
}
