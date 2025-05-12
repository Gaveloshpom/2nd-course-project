using Course_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Course_Project.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        //public string UserEmail { get; set; }


        public bool Register(string email, string name, string surname, string password, string role)
        {
            var emailError = ValidationHelper.ValidateEmail(email);
            var passwordError = ValidationHelper.ValidatePassword(password);
            var nameError = ValidationHelper.ValidateName(name);
            var surnameError = ValidationHelper.ValidateSurname(surname);

            if (emailError != null  || nameError != null || surnameError != null || passwordError != null)
            {
                MessageBox.Show(
                    $"{emailError ?? ""}\n{nameError ?? ""}\n{surnameError ?? ""}\n{passwordError ?? ""}",
                    "Помилка реєстрації",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }

            if (UserStorage.FindUser(email) != null)
            {
                MessageBox.Show("Користувач з таким Email вже існує");
                return false;
            }

            var user = new RegisteredUser
            {
                Email = email,
                Name = name,
                Surname = surname,
                Password = password,
                Role = role
            };

            UserStorage.Users.Add(user);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
