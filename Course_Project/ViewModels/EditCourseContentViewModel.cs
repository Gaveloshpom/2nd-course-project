using Course_Project.Models;
using System;
using System.Collections.Generic;
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

        public ObservableCollection<CourseContentItem> ContentItems { get; set; }

        public CourseContentItem SelectedItem { get; set; }

        public ICommand AddLectureCommand { get; }
        public ICommand AddPracticeCommand { get; }
        public ICommand DeletePointCommand { get; }
        public ICommand RenamePointCommand { get; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }

        public EditCourseContentViewModel(Course course)
        {
            _course = course;

            ContentItems = new ObservableCollection<CourseContentItem>();
            BuildContentList();

            AddLectureCommand = new RelayCommand(_ => AddLecture());
            AddPracticeCommand = new RelayCommand(_ => AddPractice());
            DeletePointCommand = new RelayCommand(_ => DeleteSelected(), _ => SelectedItem != null);
            RenamePointCommand = new RelayCommand(_ => RenamePoint(), _ => SelectedItem != null);
            MoveUpCommand = new RelayCommand(_ => MoveUp(), _ => CanMoveUp());
            MoveDownCommand = new RelayCommand(_ => MoveDown(), _ => CanMoveDown());

        }

        private void BuildContentList()
        {
            ContentItems.Clear();
            int index = 1;

            foreach (var lecture in _course.LectureList ?? new List<Lecture>())
            {
                ContentItems.Add(new CourseContentItem
                {
                    Id = index++,
                    Point = lecture.Title,
                    Likes = lecture.Likes,
                    Dislikes = lecture.Dislikes,
                    Type = "Лекція",
                    OriginalItem = lecture
                });
            }

            foreach (var practice in _course.PracticeList ?? new List<Practice>())
            {
                ContentItems.Add(new CourseContentItem
                {
                    Id = index++,
                    Point = practice.Title,
                    Likes = practice.Likes,
                    Dislikes = practice.Dislikes,
                    Type = "Практика",
                    OriginalItem = practice
                });
            }
        }

        private void AddLecture()
        {
            var lecture = new Lecture { Title = "Нова лекція" };
            if (_course.LectureList == null) 
            {
                _course.LectureList = new List<Lecture>();
            }
            //_course.LectureList ??= new List<Lecture>();
            _course.LectureList.Add(lecture);
            CourseService.UpdateCourse(_course);
            BuildContentList();
        }

        private void AddPractice()
        {
            var practice = new Practice { Title = "Нова практика" };
            if (_course.PracticeList == null)
            {
                _course.PracticeList = new List<Practice>();
            }
            //_course.PracticeList ??= new List<Practice>();
            _course.PracticeList.Add(practice);
            CourseService.UpdateCourse(_course);
            BuildContentList();
        }

        private void DeleteSelected()
        {
            if (SelectedItem == null) return;

            if (SelectedItem.Type == "Лекція" && SelectedItem.OriginalItem is Lecture lecture)
            {
                _course.LectureList.Remove(lecture);
            }
            else if (SelectedItem.Type == "Практика" && SelectedItem.OriginalItem is Practice practice)
            {
                _course.PracticeList.Remove(practice);
            }

            CourseService.UpdateCourse(_course);
            BuildContentList();
        }

        private void RenamePoint()
        {
            if (SelectedItem == null) return;

            string input = Microsoft.VisualBasic.Interaction.InputBox("Нова назва:", "Редагування", SelectedItem.Point);
            if (!string.IsNullOrWhiteSpace(input))
            {
                SelectedItem.Point = input;

                if (SelectedItem.Type == "Лекція" && SelectedItem.OriginalItem is Lecture lec)
                    lec.Title = input;
                else if (SelectedItem.Type == "Практика" && SelectedItem.OriginalItem is Practice prac)
                    prac.Title = input;

                CourseService.UpdateCourse(_course);
                BuildContentList();
            }
        }

        private void MoveUp()
        {
            int index = ContentItems.IndexOf(SelectedItem);
            if (index > 0)
            {
                var item = SelectedItem;
                ContentItems.RemoveAt(index);
                ContentItems.Insert(index - 1, item);
                RebuildCourseLists();
                OnPropertyChanged(nameof(ContentItems));
            }
        }
        private bool CanMoveUp() =>
            SelectedItem != null && ContentItems.IndexOf(SelectedItem) > 0;

        private void MoveDown()
        {
            int index = ContentItems.IndexOf(SelectedItem);
            if (index < ContentItems.Count - 1)
            {
                var item = SelectedItem;
                ContentItems.RemoveAt(index);
                ContentItems.Insert(index + 1, item);
                RebuildCourseLists();
                OnPropertyChanged(nameof(ContentItems));
            }
        }
        private bool CanMoveDown() =>
            SelectedItem != null && ContentItems.IndexOf(SelectedItem) < ContentItems.Count - 1;

        private void RebuildCourseLists()
        {
            _course.LectureList = ContentItems
                .Where(c => c.Type == "Лекція")
                .Select(c => c.OriginalItem as Lecture)
                .ToList();

            _course.PracticeList = ContentItems
                .Where(c => c.Type == "Практика")
                .Select(c => c.OriginalItem as Practice)
                .ToList();

            CourseService.UpdateCourse(_course);
            BuildContentList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
