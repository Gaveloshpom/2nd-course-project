using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Course_Project.Models
{
    [JsonObject]
    public abstract class User : INotifyPropertyChanged
    {
        private string email;
        private string name;
        private string surname;
        private DateTime dateOfBirth;

        [JsonProperty]
        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(nameof(Email)); }
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
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set { dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); }
        }

        public abstract bool Authorize(string email, string password);
        public abstract void EditProfile(string newName, string newSurname);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
