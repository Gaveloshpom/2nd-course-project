using Course_Project.Models;
using Course_Project.ViewModels;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class EditCourseContentWindow : Window
    {
        public EditCourseContentWindow(Course course)
        {
            InitializeComponent();
            DataContext = new EditCourseContentViewModel(course);
        }
    }
}

