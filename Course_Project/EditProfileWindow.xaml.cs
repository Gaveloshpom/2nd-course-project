using Course_Project.Models;
using Maket_View_test_1;
using System.Linq;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class EditProfileWindow : Window
    {
        private readonly RegisteredUser _user;

        public EditProfileWindow(RegisteredUser user)
        {
            InitializeComponent();
            _user = user;

            // Заповнюємо поля поточними даними
            NameBox.Text = _user.Name;
            SurnameBox.Text = _user.Surname;
            EmailBox.Text = _user.Email;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var name = NameBox.Text.Trim();
            var surname = SurnameBox.Text.Trim();
            var email = EmailBox.Text.Trim();

            var nameError = ValidationHelper.ValidateName(name);
            var surnameError = ValidationHelper.ValidateSurname(surname);
            var emailError = ValidationHelper.ValidateEmail(email);

            if (nameError != null || surnameError != null || emailError != null)
            {
                MessageBox.Show(nameError ?? surnameError ?? emailError, "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var allUsers = UserService.LoadUsers();
            var existingUser = allUsers.FirstOrDefault(u => u.Email == _user.Email);

            if (existingUser != null)
            {
                existingUser.Name = name;
                existingUser.Surname = surname;
                existingUser.Email = email;

                // Оновити App.CurrentUser якщо це він
                if (App.CurrentUser is RegisteredUser current && current.Email == _user.Email)
                {
                    current.Name = name;
                    current.Surname = surname;
                    current.Email = email;
                }
            }

            UserService.SaveUsers(allUsers);

            MessageBox.Show("Профіль оновлено успішно!", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }

    }
}

