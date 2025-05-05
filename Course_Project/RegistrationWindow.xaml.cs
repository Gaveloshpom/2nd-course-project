using Course_Project.Models;
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

namespace OnlineCourseApp
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private readonly RegisterViewModel _viewModel;

        public RegistrationWindow()
        {
            InitializeComponent();
            _viewModel = new RegisterViewModel();
            DataContext = _viewModel;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var password = PasswordBox.Password;
            if (_viewModel.Register(password))
            {
                MessageBox.Show("Реєстрація успішна!");
                Close();
            }
            else
            {
                MessageBox.Show("Користувач вже існує.");
            }
        }
    }

}
