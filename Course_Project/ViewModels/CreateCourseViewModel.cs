using Course_Project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Course_Project.ViewModels
{
    public class CreateCourseViewModel : INotifyPropertyChanged
    {
        //private string _title;
        //private string _description;

        //public string Title
        //{
        //    get => _title;
        //    set { _title = value; OnPropertyChanged(nameof(Title)); }
        //}

        //public string Description
        //{
        //    get => _description;
        //    set { _description = value; OnPropertyChanged(nameof(Description)); }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public bool CreateCourse(string title, string description, string authorEmail)
        {
            var titleError = ValidationHelper.ValidateCourseTitle(title);
            var descriptionError = ValidationHelper.ValidateCourseDescription(description);

            if (titleError != null || descriptionError != null)
            {
                MessageBox.Show(
                    $"{titleError ?? ""}\n{descriptionError ?? ""}",
                    "Помилка створення",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }

            var course = new Course
            {
                Title = title,
                Description = description,
                AuthorEmailList = new List<string> { authorEmail }
            };

            CourseService.AddCourse(course);
            return true;
        }
    }

}
