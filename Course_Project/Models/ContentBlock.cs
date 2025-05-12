using System.ComponentModel;

namespace Course_Project.Models
{
    public class ContentBlock : INotifyPropertyChanged
    {
        public string Type { get; set; }
        public Lecture LectureData { get; set; }
        public Practice PracticeData { get; set; }
        public int Id { get; set; }
        public string Title => Type == "Лекція" ? LectureData?.Title : PracticeData?.Title;
        public int Likes => Type == "Лекція" ? LectureData?.Likes ?? 0 : PracticeData?.Likes ?? 0;
        public int Dislikes => Type == "Лекція" ? LectureData?.Dislikes ?? 0 : PracticeData?.Dislikes ?? 0;

        public void Refresh()
        {
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Likes));
            OnPropertyChanged(nameof(Dislikes));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

