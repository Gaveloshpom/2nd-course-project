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
using System.Windows.Shapes;
using Course_Project.Models;

namespace OnlineCourseApp
{
    /// <summary>
    /// Interaction logic for CreateCourseWindow.xaml
    /// </summary>
    public partial class CreateCourseWindow : Window
    {
        private CreateCourseViewModel _viewModel;
        private List<RegisteredUser> users;
        private RegisteredUser registeredUser;
        public CreateCourseWindow(string authorEmail)
        {
            InitializeComponent();
            
            _viewModel = new CreateCourseViewModel();
            DataContext = _viewModel;
            users = UserStorage.Users;
            registeredUser = App.CurrentUser;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string authorEmail = registeredUser.Email;

            string title = CourseTitleBox.Text;
            string description = CourseDescriptionBox.Text;

            if (_viewModel.CreateCourse(title, description, authorEmail))
            {
                MessageBox.Show("Курс створено!");
                
                Close();
            }
            else
            {
                MessageBox.Show("Введіть усі поля!");
            }
        }
    }

}
