using Course_Project.Models;
using OnlineCourseApp;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Course_Project.ViewModels
{
    public class MyCoursesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Course> Courses { get; set; }

        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                _selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourse));
                CommandManager.InvalidateRequerySuggested(); // ⬅️ дуже важливо для активації кнопок
            }
        }

        private readonly RegisteredUser _author;

        public ICommand DeleteCourseCommand { get; }
        public ICommand PublishCourseCommand { get; }
        public ICommand EditContentCommand { get; }
        public ICommand EditInfoCommand { get; }
        public ICommand AddAuthorCommand { get; }
        public ICommand CreateCourseCommand { get; }

        public MyCoursesViewModel(RegisteredUser author)
        {
            _author = author;

            var mine = CourseService.GetCoursesByAuthor(_author.Email);
            Courses = new ObservableCollection<Course>(mine);

            DeleteCourseCommand = new RelayCommand(_ => DeleteCourse(), _ => SelectedCourse != null);
            PublishCourseCommand = new RelayCommand(_ => PublishCourse(), _ => SelectedCourse != null);
            EditContentCommand = new RelayCommand(_ => EditContent(), _ => SelectedCourse != null);
            EditInfoCommand = new RelayCommand(_ => EditInfo(), _ => SelectedCourse != null);
            AddAuthorCommand = new RelayCommand(_ => AddAuthor(), _ => SelectedCourse != null);
            CreateCourseCommand = new RelayCommand(_ => CreateCourse());
        }

        private void DeleteCourse()
        {
            if (SelectedCourse == null) return;

            var confirm = MessageBox.Show($"Ви дійсно хочете видалити курс '{SelectedCourse.Title}'?", "Підтвердження", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                CourseService.DeleteCourse(SelectedCourse);
                Courses.Remove(SelectedCourse);
            }
        }

        private void PublishCourse()
        {
            if (SelectedCourse == null) return;

            if (SelectedCourse.Status == "Опубліковано")
            {
                MessageBox.Show($"Курс '{SelectedCourse.Title}' вже опубліковано.");
                return;
            }

            SelectedCourse.Status = "На розгляді";
            CourseService.UpdateCourse(SelectedCourse);
            MessageBox.Show($"Курс '{SelectedCourse.Title}' передано на розгляд адміністрації.");
        }

        private void EditContent()
        {
            if (SelectedCourse == null) return;

            var win = new EditCourseContentWindow(SelectedCourse);
            win.ShowDialog();
        }

        private void EditInfo()
        {
            if (SelectedCourse == null) return;

            var win = new EditCourseInfoWindow(SelectedCourse);
            if (win.ShowDialog() == true)
            {
                MessageBox.Show("Інформацію оновлено!");
            }
        }

        private void AddAuthor()
        {
            if (SelectedCourse == null) return;

            var win = new AddAuthorWindow(SelectedCourse);
            win.ShowDialog();
        }

        private void CreateCourse()
        {
            var createWindow = new CreateCourseWindow(_author.Email);
            createWindow.ShowDialog();

            // Після створення курсу — оновлюємо список
            var updated = CourseService.GetCoursesByAuthor(_author.Email);
            Courses.Clear();
            foreach (var course in updated)
                Courses.Add(course);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

