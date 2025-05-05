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
using Course_Project.ViewModels;

namespace Course_Project.Views
{
    public partial class CourseListView : Window
    {
        public CourseListView(RegisteredUser user)
        {
            InitializeComponent();
            DataContext = new CourseListViewModel(user);
        }
    }
}

