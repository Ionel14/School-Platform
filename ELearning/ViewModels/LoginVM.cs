using ELearning.Models.BusinessLogicLayer;
using ELearning.Models.BusinessLogicLayer.Dtos;
using ELearning.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfMVVMAgendaEF.Helpers;

namespace ELearning.ViewModels
{
    internal class LoginVM : BaseVM
    {

        private MainWindow window;

        public LoginVM(MainWindow window) {
            this.window = window;
        }

        private string email = "Admin";
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private string password = "Admin";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand<UserDto>(DataService.personBLL.Login);
                }
                return submitCommand;
            }
            set
            {
                submitCommand = value;
            }
        }

    }
}
