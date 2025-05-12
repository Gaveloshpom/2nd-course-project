using Course_Project.Models;
using System.Linq;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class AdminLogsWindow : Window
    {
        public AdminLogsWindow(Course course)
        {
            InitializeComponent();

            if (course.AdminLogs != null && course.AdminLogs.Any())
            {
                LogsList.ItemsSource = course.AdminLogs;
            }
            else
            {
                LogsList.Items.Add("Немає дій адміністратора для цього курсу.");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
