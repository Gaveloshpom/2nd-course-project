using Course_Project.Models;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class AddLectureWindow : Window
    {
        private readonly Lecture _lecture;

        public AddLectureWindow(Lecture lecture)
        {
            InitializeComponent();
            _lecture = lecture;

            TitleBox.Text = _lecture.Title;
            ContentBox.Text = _lecture.Text;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string titleError = ValidationHelper.ValidateLectureTitle(TitleBox.Text);
            string textError = ValidationHelper.ValidateLectureText(ContentBox.Text);

            if (titleError != null)
            {
                MessageBox.Show(titleError);
                return;
            }

            if (textError != null)
            {
                MessageBox.Show(textError);
                return;
            }

            _lecture.Title = TitleBox.Text.Trim();
            _lecture.Text = ContentBox.Text.Trim();

            DialogResult = true;
            Close();
        }
    }
}


