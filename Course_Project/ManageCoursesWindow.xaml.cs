using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OnlineCourseApp
{
    public partial class ManageCoursesWindow : Window
    {
        public ManageCoursesWindow()
        {
            InitializeComponent();

            // Заповнення тестовими даними
            var testCourses = new List<Course>
            {
                new Course { Id = 1, Title = "Основи програмування на C#", Author = "Іван Петренко", Status = "Опубліковано" },
                new Course { Id = 2, Title = "Веб-розробка з HTML/CSS", Author = "Олена Ковальчук", Status = "На розгляді" },
                new Course { Id = 3, Title = "Алгоритми та структури даних", Author = "Максим Іванов", Status = "Заморожено" },
                new Course { Id = 4, Title = "Просунутий Python", Author = "Наталія Бондар", Status = "Опубліковано" },
                new Course { Id = 5, Title = "Бази даних та SQL", Author = "Андрій Мельник", Status = "На розгляді" },
            };

            CoursesDataGrid.ItemsSource = testCourses;
        }

        public class Course
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Status { get; set; }
        }

        // Обробники подій (можна залишити порожніми або з заглушками)
        private void check_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Перегляд курсу.");
        }

        private void Publish_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курс опубліковано.");
        }

        private void Freeze_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Доступ до курсу заморожено.");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курс видалено.");
        }
    }
}

