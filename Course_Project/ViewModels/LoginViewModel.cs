using Course_Project.Models;
using Maket_View_test_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Course_Project.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        //public string Username { get; set; }

        public bool Login(string email, string password)
        {
            var emailError = ValidationHelper.ValidateEmail(email);
            var passwordError = ValidationHelper.ValidatePassword(password);

            if (emailError != null || passwordError != null)
            {
                MessageBox.Show(
                    $"{emailError ?? ""}\n{passwordError ?? ""}",
                    "Помилка реєстрації",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }

            var user = UserStorage.FindUser(email);
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
