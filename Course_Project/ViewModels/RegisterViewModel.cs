using Course_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Course_Project.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        //public string UserEmail { get; set; }

        public bool Register(string email, string name, string surname, string password, string role)
        {
            if (UserStorage.FindUser(email) != null)
                return false;

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
