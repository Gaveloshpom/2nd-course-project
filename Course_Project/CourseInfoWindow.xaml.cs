using Course_Project.Models;
using Maket_View_test_1;
using System.Linq;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class CourseInfoWindow : Window
    {
        private readonly Course _course;

        public CourseInfoWindow(Course course)
        {
            InitializeComponent();
            _course = course;
            LoadCourseInfo();
        }

        private void LoadCourseInfo()
        {
            TitleText.Text = _course.Title;
            AuthorText.Text = $"Автор: {string.Join(", ", _course.AuthorEmailList)}";
            DescriptionText.Text = _course.Description;
            RatingText.Text = $"{_course.Rating:F1} ★";

            if (_course.Reviews != null && _course.Reviews.Any())
            {
                ReviewsList.ItemsSource = _course.Reviews;
            }
            else
            {
                ReviewsList.ItemsSource = new[] { new { UserEmail = "", Date = "", ReviewText = "Відгуків ще немає." } };
            }
        }

        private void Enroll_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser is RegisteredUser user)
            {
                if (user.EnrolledCourses.Contains(_course.Id))
                {
                    MessageBox.Show("Ви вже записані на цей курс.");
                    return;
                }

                user.EnrolledCourses.Add(_course.Id);
                MessageBox.Show("Ви успішно записалися на курс!");
            }
            else
            {
                MessageBox.Show("Будь ласка, увійдіть у свій акаунт.");
            }
        }
    }
}

