using Course_Project.ViewModels;
using Maket_View_test_1;
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

            var user = App.CurrentUser;
            if (user != null && user.Role == "Автор курсу")
            {
                AuthorPanelButton.Visibility = Visibility.Visible;
            }

            //if (App.CurrentUser != null)
            //{
            //    if (App.CurrentUser.Role == "Автор курсу")
            //    {
            //        AuthorButton.IsEnabled = true;
            //        AuthorButton.Visibility = Visibility.Visible;
            //    }
            //    else
            //    {
            //        AuthorButton.IsEnabled = false;
            //        AuthorButton.Visibility = Visibility.Collapsed;
            //    }
            //}
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Owner = this;

            if (loginWindow.ShowDialog() == true)
            {
                // Отримуємо залогіненого користувача
                var user = App.CurrentUser;
                // Оновлюємо UI
                LoginButton.Visibility = Visibility.Collapsed;
                UsernameLabel.Content = $"Вітаємо, {user.Name} {user.Surname}!";
                UsernameLabel.Visibility = Visibility.Visible;

                if (App.CurrentUser != null)
                {
                    if (App.CurrentUser.Role == "Автор курсу")
                    {
                        AuthorPanelButton.IsEnabled = true;
                        AuthorPanelButton.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        AuthorPanelButton.IsEnabled = false;
                        AuthorPanelButton.Visibility = Visibility.Collapsed;
                    }

                    if (App.CurrentUser?.Role == "Admin")
                    {
                        AdminPanelButton.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        AdminPanelButton.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void AuthorPanelButton_Click(object sender, RoutedEventArgs e)
        {
            var panel = new MyCoursesWindow(App.CurrentUser);
            panel.Owner = this;
            panel.ShowDialog();
        }

        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminPanelWindow();
            adminWindow.Owner = this;
            adminWindow.ShowDialog();
        }
    }
}
