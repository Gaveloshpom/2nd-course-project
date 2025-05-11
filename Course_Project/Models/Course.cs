using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

//namespace Course_Project.Models
//{
//    public class Course
//    {
//        public string Title { get; set; }
//        public string Description { get; set; }

//        public List<Author> AuthorList { get; set; } = new List<Author>();
//        public List<Lecture> LectureList { get; set; } = new List<Lecture>();
//        public List<Practice> PracticeList { get; set; } = new List<Practice>();
//    }
//}

namespace Course_Project.Models
{
    [JsonObject]
    public class Course : INotifyPropertyChanged
    {
        private string title;
        private string description;
        private string status = "В розробці";
        [JsonProperty]
        public List<int> Ratings { get; set; } = new List<int>();

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
        public string Status
        {
            get => status;
            set { status = value; OnPropertyChanged(nameof(Status)); }
        }

        [JsonProperty]
        public List<string> AuthorEmailList { get; set; } = new List<string>();

        [JsonProperty]
        public List<Lecture> LectureList { get; set; } = new List<Lecture>();

        [JsonProperty]
        public List<Practice> PracticeList { get; set; } = new List<Practice>();

        [JsonIgnore]
        public double Rating => Ratings != null && Ratings.Any()
        ? Math.Round(Ratings.Average(), 1)
        : 0.0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

