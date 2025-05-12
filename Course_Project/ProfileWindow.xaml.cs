using Course_Project.Models;
using System.Linq;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class ProfileWindow : Window
    {
        private readonly RegisteredUser _user;

        public ProfileWindow(RegisteredUser user)
        {
            InitializeComponent();
            _user = user;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            NameText.Text = $"Ім’я: {_user.Name}";
            SurnameText.Text = $"Прізвище: {_user.Surname}";
            EmailText.Text = $"Email: {_user.Email}";
            RoleText.Text = $"Роль: Зареєстрований користувач";
        }

        private void EnrolledCourses_Click(object sender, RoutedEventArgs e)
        {
            var allCourses = CourseService.LoadCourses();
            var enrolled = allCourses
                .Where(c => _user.EnrolledCourses.Contains(c.Id) && !_user.CompletedCourses.Contains(c.Id))
                .ToList();

            var window = new CoursesListWindow(enrolled, "Записані курси", true);
            window.Owner = this;
            window.ShowDialog();
        }


        private void CompletedCourses_Click(object sender, RoutedEventArgs e)
        {
            var allCourses = CourseService.LoadCourses();
            var completed = allCourses.Where(c => _user.CompletedCourses.Contains(c.Id)).ToList();

            var window = new CoursesListWindow(completed, "Завершені курси", false);
            window.Owner = this;
            window.ShowDialog();
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            var editWin = new EditProfileWindow(_user);
            editWin.Owner = this;
            if (editWin.ShowDialog() == true)
            {
                // Оновити відображення
                LoadUserInfo();
            }
        }

    }
}


