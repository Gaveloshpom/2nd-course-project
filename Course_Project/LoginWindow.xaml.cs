using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;
using Course_Project.Models;
using Course_Project.ViewModels;


namespace OnlineCourseApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        private List<RegisteredUser> users;

        public LoginWindow()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
            users = UserStorage.Users;
        }

        //private void Login_Click(object sender, RoutedEventArgs e)
        //{
        //    var password = PasswordBox.Password;
        //    if (_viewModel.Login(password))
        //    {
        //        var mainWindow = new MainWindow();
        //        mainWindow.Show();
        //        Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Невірний логін або пароль.");
        //    }
        //}

        //public RegisteredUser LoggedInUser { get; private set; }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegistrationWindow();
            registerWindow.ShowDialog();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = UserEmailTextBox.Text;
            string password = PasswordBox.Password;

            if (_viewModel.Login(email, password))
            {
                MessageBox.Show("Авторизація успішна!");
                //LoggedInUser = user;
                DialogResult = true;
                Close();
            }
            else 
            {
                MessageBox.Show(
                   "Неправильний логін або пароль!",
                   "Помилка авторизації",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error
               );
            }

            //var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            //if (user != null)
            //{
            //    LoggedInUser = user;
            //    DialogResult = true; // це закриє вікно та поверне true
            //    Close();
            //}
            //else
            //{
            //    MessageBox.Show("Невірний логін або пароль");
            //}
        }
    }

}
