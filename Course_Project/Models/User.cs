using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Course_Project.Models
{
    [JsonObject]
    public abstract class User : INotifyPropertyChanged
    {
        private string email;
        private string password;
        private string name;
        private string surname;
        private string role;

        [JsonProperty]
        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        [JsonProperty]
        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }

        [JsonProperty]
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        [JsonProperty]
        public string Surname
        {
            get => surname;
            set { surname = value; OnPropertyChanged(nameof(Surname)); }
        }

        [JsonProperty]
        public string Role
        {
            get => role;
            set { role = value; OnPropertyChanged(nameof(Role)); }
        }

        public abstract bool Authorize(string email, string password);
        public abstract void EditProfile(string newName, string newSurname);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

