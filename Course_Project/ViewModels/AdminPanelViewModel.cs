using Course_Project.Models;
using OnlineCourseApp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Course_Project.ViewModels
{
    public class AdminPanelViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Course> AllCourses { get; set; }

        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                _selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourse));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand ChangeStatusCommand { get; }
        public ICommand DeleteCourseCommand { get; }

        public AdminPanelViewModel()
        {
            AllCourses = new ObservableCollection<Course>(CourseService.LoadCourses());

            ChangeStatusCommand = new RelayCommand(_ => ChangeStatus(), _ => SelectedCourse != null);
            DeleteCourseCommand = new RelayCommand(_ => DeleteCourse(), _ => SelectedCourse != null);
        }

        private void ChangeStatus()
        {
            if (SelectedCourse == null) return;

            var result = MessageBox.Show("Змінити статус курсу на 'Опубліковано'?", "Підтвердження", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SelectedCourse.Status = "Опубліковано";
                CourseService.UpdateCourse(SelectedCourse);
                MessageBox.Show("Статус змінено на 'Опубліковано'");
                RefreshCourses();
            }
        }

        private void DeleteCourse()
        {
            if (SelectedCourse == null) return;

            var result = MessageBox.Show($"Видалити курс '{SelectedCourse.Title}'?", "Підтвердження", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                CourseService.DeleteCourse(SelectedCourse);
                RefreshCourses();
            }
        }

        private void RefreshCourses()
        {
            AllCourses = new ObservableCollection<Course>(CourseService.LoadCourses());
            OnPropertyChanged(nameof(AllCourses));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
