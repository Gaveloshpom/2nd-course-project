using Course_Project.Models;
using Course_Project.ViewModels;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class MyCoursesWindow : Window
    {
        public MyCoursesWindow(RegisteredUser author)
        {
            InitializeComponent();
            DataContext = new MyCoursesViewModel(author);
        }
    }
}

