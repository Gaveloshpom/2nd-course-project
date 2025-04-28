using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Course_Project.Models
{
    [JsonObject]
    public class Course : INotifyPropertyChanged
    {
        private string title;
        private string description;

        [JsonProperty]
        public string Title
        {
            get => title;
            set { title = value; OnPropertyChanged(nameof(Title)); }
        }

        [JsonProperty]
        public string Description
        {
            get => description;
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }

        [JsonProperty]
        public List<Author> AuthorList { get; set; } = new List<Author>();

        [JsonProperty]
        public List<Lecture> LectureList { get; set; } = new List<Lecture>();

        [JsonProperty]
        public List<Practice> PracticeList { get; set; } = new List<Practice>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

