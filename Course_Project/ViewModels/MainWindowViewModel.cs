using Course_Project.Models;
using Maket_View_test_1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Course_Project.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Course> Courses { get; set; }
        public ICommand EnrollCommand { get; }

        public MainWindowViewModel()
        {
            // Тут можна отримати курси з CourseStorage або іншого сервісу
            Courses = new ObservableCollection<Course>(CourseStorage.Courses);

            EnrollCommand = new RelayCommand<Course>(EnrollToCourse);
        }

        private void EnrollToCourse(Course course)
        {
            if (App.CurrentUser is RegisteredUser user && course != null)
            {
                user.EnrollToCourse(course);
                MessageBox.Show($"Ви записались на курс: {course.Title}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
