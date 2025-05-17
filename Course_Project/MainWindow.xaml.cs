using Course_Project.Models;
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

            //var user = App.CurrentUser;
            //if (user != null && user.Role == "Автор курсу")
            //{
            //    AuthorPanelButton.Visibility = Visibility.Visible;
            //}

            LoadCourses();

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
                SwitchUserButton.Visibility = Visibility.Visible;

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

        private void LoadCourses()
        {
            var publishedCourses = CourseService.LoadCourses().Where(c => c.Status == "Опубліковано").ToList();

            foreach (var course in publishedCourses)
            {
                var card = CreateCourseCard(course);
                CoursesWrapPanel.Children.Add(card);
            }
        }
        private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser is RegisteredUser user)
            {
                var profileWin = new ProfileWindow(user);
                profileWin.Owner = this;
                profileWin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Будь ласка, увійдіть в акаунт.");
            }
        }

        private Border CreateCourseCard(Course course)
        {
            var border = new Border
            {
                Background = Brushes.White,
                Width = 220,
                Height = 150,
                Margin = new Thickness(10),
                Padding = new Thickness(10),
                CornerRadius = new CornerRadius(8),
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness(1),
                Cursor = System.Windows.Input.Cursors.Hand
            };

            var stack = new StackPanel();
            stack.Children.Add(new TextBlock { Text = course.Title, FontWeight = FontWeights.Bold, FontSize = 14 });
            stack.Children.Add(new TextBlock { Text = $"Автор: {string.Join(", ", course.AuthorEmailList)}", FontSize = 12, Foreground = Brushes.Gray });
            stack.Children.Add(new TextBlock { Text = $"{course.Rating:F1} ★", Foreground = Brushes.Orange, FontSize = 12 });

            border.Child = stack;
            border.MouseLeftButtonUp += (s, e) =>
            {
                var infoWin = new CourseInfoWindow(course);
                infoWin.Owner = this;
                infoWin.ShowDialog();
            };

            return border;
        }

        private void SwitchUser_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser is RegisteredUser user)
            {
                LoginButton_Click(sender, e);      // ТАК РОБИТИ НЕ МОЖНА! ПЕРЕРОБИТИ ЗА ПРИСУТНОСТІ ЧАСУ!!!
            }
            else { MessageBox.Show("Будь ласка, увійдіть в акаунт."); }
        }

    }
}
