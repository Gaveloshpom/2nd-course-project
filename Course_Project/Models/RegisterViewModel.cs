using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Models
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public string Username { get; set; }

        public bool Register(string password)
        {
            if (UserStorage.FindUser(Username) != null)
                return false;

            var user = new RegisteredUser
            {
                Username = Username,
                Password = password
            };

            UserStorage.Users.Add(user);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
