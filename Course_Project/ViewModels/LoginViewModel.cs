using Course_Project.Models;
using Maket_View_test_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string Username { get; set; }

        public bool Login(string password)
        {
            var user = UserStorage.FindUser(Username);
            if (user != null && user.Password == password)
            {
                App.CurrentUser = user;
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
