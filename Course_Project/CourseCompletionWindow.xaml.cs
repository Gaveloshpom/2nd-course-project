using Course_Project.Models;
using Maket_View_test_1;
using System;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class CourseCompletionWindow : Window
    {
        private readonly Course _course;

        public CourseCompletionWindow(Course course)
        {
            InitializeComponent();
            _course = course;
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            int rating = (int)RatingSlider.Value;
            string review = ReviewBox.Text.Trim();

            if (App.CurrentUser is RegisteredUser user)
            {
                if (!user.CompletedCourses.Contains(_course.Id))
                    user.CompletedCourses.Add(_course.Id);

                _course.Ratings.Add(rating);

                if (!string.IsNullOrWhiteSpace(review) && review.Length >= 5)
                {
                    _course.Reviews.Add(new CourseReview
                    {
                        UserEmail = user.Email,
                        ReviewText = review,
                        Date = DateTime.Now.ToString("dd.MM.yyyy")
                    });

                    MessageBox.Show("Оцінка та відгук збережені!");
                }
                else
                {
                    MessageBox.Show("Оцінку збережено. Відгук не додано.");
                }

                CourseService.UpdateCourse(_course);
            }

            Close();
        }
    }
}


