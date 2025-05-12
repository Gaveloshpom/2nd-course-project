using Course_Project.Models;
using System.Windows;

namespace Course_Project
{
    public partial class EditCourseInfoWindow : Window
    {
        private readonly Course _course;

        public EditCourseInfoWindow(Course course)
        {
            InitializeComponent();
            _course = course;

            // Показуємо поточні дані в текстових полях
            CourseTitleBox.Text = _course.Title;
            CourseDescriptionBox.Text = _course.Description;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string title = CourseTitleBox.Text.Trim();
            string description = CourseDescriptionBox.Text.Trim();

            if (string.IsNullOrEmpty(title) || title.Length < 1 || title.Length > 30)
            {
                MessageBox.Show("Назва курсу має містити від 1 до 30 символів.");
                return;
            }

            if (string.IsNullOrEmpty(description) || description.Length < 5 || description.Length > 200)
            {
                MessageBox.Show("Опис курсу має містити від 5 до 200 символів.");
                return;
            }

            _course.Title = title;
            _course.Description = description;

            CourseService.UpdateCourse(_course);

            MessageBox.Show("Інформацію збережено.");
            DialogResult = true;
            Close();
        }
    }
}
