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

            UpdateEnrollButton();
        }

        private void UpdateEnrollButton()
        {
            if (App.CurrentUser is RegisteredUser user)
            {
                if (user.CompletedCourses.Contains(_course.Id))
                {
                    EnrollButton.Content = "Курс завершено";
                    EnrollButton.IsEnabled = false;
                }
                else if (user.EnrolledCourses.Contains(_course.Id))
                {
                    EnrollButton.Content = "Пройти курс";
                    EnrollButton.Click -= Enroll_Click;
                    EnrollButton.Click += ContinueCourse_Click;
                }
                else
                {
                    EnrollButton.Content = "Записатися на курс";
                    EnrollButton.Click -= ContinueCourse_Click;
                    EnrollButton.Click += Enroll_Click;
                }
            }
            else
            {
                EnrollButton.Content = "Увійдіть для доступу";
                EnrollButton.IsEnabled = false;
            }
        }

        private void Enroll_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser is RegisteredUser user)
            {
                if (user.EnrollToCourse(_course))
                {
                    MessageBox.Show("Ви успішно записалися на курс!");
                    UpdateEnrollButton();
                }
            }
        }

        private void ContinueCourse_Click(object sender, RoutedEventArgs e)
        {
            var viewer = new CourseViewerWindow(_course);
            viewer.Owner = this;
            viewer.ShowDialog();
        }
    }
}

