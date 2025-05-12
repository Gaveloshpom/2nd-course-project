using Course_Project.Models;
using System.Linq;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class CourseReviewsWindow : Window
    {
        public CourseReviewsWindow(Course course)
        {
            InitializeComponent();

            if (course.Reviews != null && course.Reviews.Any())
            {
                ReviewsList.ItemsSource = course.Reviews;
            }
            else
            {
                ReviewsList.Items.Add("Відгуків ще немає.");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

