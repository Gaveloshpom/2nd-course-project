using Course_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using static OnlineCourseApp.ManageCoursesWindow;

namespace OnlineCourseApp
{
    public partial class AddAuthorWindow : Window
    {
        private readonly Course _course;

        public AddAuthorWindow(Course course)
        {
            InitializeComponent();
            _course = course;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Введіть email.");
                return;
            }

            if (_course.AuthorEmailList == null)
            {
                _course.AuthorEmailList = new List<string>();
            }

            if (!_course.AuthorEmailList.Contains(email))
            {
                _course.AuthorEmailList.Add(email);
                CourseService.UpdateCourse(_course);
                MessageBox.Show("Автор доданий.");
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Автор вже доданий.");
            }
        }
    }
}
