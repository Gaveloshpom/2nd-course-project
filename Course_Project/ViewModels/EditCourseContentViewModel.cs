using Course_Project.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Course_Project.ViewModels
{
    public class EditCourseContentViewModel : INotifyPropertyChanged
    {
        private readonly Course _course;

        public ObservableCollection<ContentBlock> ContentItems { get; set; }

        private ContentBlock _selectedItem;
        public ContentBlock SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddLectureCommand { get; }
        public ICommand AddPracticeCommand { get; }
        public ICommand DeletePointCommand { get; }
        public ICommand RenamePointCommand { get; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }

        public EditCourseContentViewModel(Course course)
        {
            _course = course;
            ContentItems = new ObservableCollection<ContentBlock>(_course.ContentBlocks);

            AddLectureCommand = new RelayCommand(_ => AddLecture());
            AddPracticeCommand = new RelayCommand(_ => AddPractice());
            DeletePointCommand = new RelayCommand(_ => DeleteSelected(), _ => SelectedItem != null);
            RenamePointCommand = new RelayCommand(_ => RenamePoint(), _ => SelectedItem != null);
            MoveUpCommand = new RelayCommand(_ => MoveUp(), _ => CanMoveUp());
            MoveDownCommand = new RelayCommand(_ => MoveDown(), _ => CanMoveDown());
        }

        private void AddLecture()
        {
            var lecture = new Lecture { Title = "Нова лекція", Text = "" };
            var block = new ContentBlock { Type = "Лекція", LectureData = lecture };
            ContentItems.Add(block);
            SaveAndRefresh();
        }

        private void AddPractice()
        {
            var practice = new Practice { Title = "Нова практика", Question = "", Answer = "" };
            var block = new ContentBlock { Type = "Практика", PracticeData = practice };
            ContentItems.Add(block);
            SaveAndRefresh();
        }

        private void DeleteSelected()
        {
            if (SelectedItem == null) return;
            ContentItems.Remove(SelectedItem);
            SaveAndRefresh();
        }

        private void RenamePoint()
        {
            if (SelectedItem == null) return;

            string input = Microsoft.VisualBasic.Interaction.InputBox("Нова назва:", "Редагування", SelectedItem.Title);
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (SelectedItem.Type == "Лекція")
                    SelectedItem.LectureData.Title = input;
                else if (SelectedItem.Type == "Практика")
                    SelectedItem.PracticeData.Title = input;

                SelectedItem.Refresh(); // ⬅️ оновлюємо відображення
                SaveAndRefresh();
            }
        }

        private void MoveUp()
        {
            int index = ContentItems.IndexOf(SelectedItem);
            if (index > 0)
            {
                ContentItems.Move(index, index - 1);
                SaveAndRefresh();
            }
        }

        private bool CanMoveUp() => SelectedItem != null && ContentItems.IndexOf(SelectedItem) > 0;

        private void MoveDown()
        {
            int index = ContentItems.IndexOf(SelectedItem);
            if (index < ContentItems.Count - 1)
            {
                ContentItems.Move(index, index + 1);
                SaveAndRefresh();
            }
        }

        private bool CanMoveDown() => SelectedItem != null && ContentItems.IndexOf(SelectedItem) < ContentItems.Count - 1;

        private void SaveAndRefresh()
        {
            _course.ContentBlocks = ContentItems.ToList();
            CourseService.UpdateCourse(_course);
            RefreshIds();
        }

        private void RefreshIds()
        {
            int index = 1;
            foreach (var item in ContentItems)
            {
                item.Id = index++;
                item.Refresh(); // оновлення UI
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
