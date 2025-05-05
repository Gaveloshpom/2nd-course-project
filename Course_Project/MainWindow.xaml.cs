using Course_Project.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineCourseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Owner = this;

            if (loginWindow.ShowDialog() == true)
            {
                // Отримуємо залогіненого користувача
                var user = loginWindow.LoggedInUser;
                // Оновлюємо UI
                LoginButton.Visibility = Visibility.Collapsed;
                UsernameLabel.Content = $"Вітаємо, {user.Username}!";
                UsernameLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
