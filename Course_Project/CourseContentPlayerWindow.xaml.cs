using Course_Project.Models;
using Maket_View_test_1;
using System.Runtime.Remoting.Contexts;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class CourseContentPlayerWindow : Window
    {
        private readonly ContentBlock _block;
        private readonly bool _isAdmin;

        private bool _hasVoted = false;
        private bool _answeredCorrectly = false;

        public CourseContentPlayerWindow(ContentBlock block, bool isAdmin = false)
        {
            InitializeComponent();
            _block = block;
            _isAdmin = isAdmin;

            if (_block.Type == "Лекція" && _block.LectureData != null)
            {
                TitleText.Text = _block.LectureData.Title;
                ContentText.Text = _block.LectureData.Text;
                PracticeBlock.Visibility = Visibility.Collapsed;
            }
            else if (_block.Type == "Практика" && _block.PracticeData != null)
            {
                TitleText.Text = _block.PracticeData.Title;
                ContentText.Text = _block.PracticeData.Question;
                PracticeBlock.Visibility = Visibility.Visible;
            }
        }

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            if (_hasVoted)
            {
                MessageBox.Show("Ви вже поставили оцінку.");
                return;
            }

            if (_block.Type == "Лекція" && _block.LectureData != null)
                _block.LectureData.Likes++;
            else if (_block.Type == "Практика" && _block.PracticeData != null)
                _block.PracticeData.Likes++;

            _hasVoted = true;
            LikeButton.IsEnabled = false;
            DislikeButton.IsEnabled = false;

            _block.Refresh();
            MessageBox.Show("Дякуємо за оцінку!");
        }

        private void Dislike_Click(object sender, RoutedEventArgs e)
        {
            if (_hasVoted)
            {
                MessageBox.Show("Ви вже поставили оцінку.");
                return;
            }

            if (_block.Type == "Лекція" && _block.LectureData != null)
                _block.LectureData.Dislikes++;
            else if (_block.Type == "Практика" && _block.PracticeData != null)
                _block.PracticeData.Dislikes++;

            _hasVoted = true;
            LikeButton.IsEnabled = false;
            DislikeButton.IsEnabled = false;

            _block.Refresh();
            MessageBox.Show("Дякуємо за оцінку!");
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (_block.Type == "Практика" && _block.PracticeData != null)
            {
                if (AnswerBox.Text.Trim().Equals(_block.PracticeData.Answer, System.StringComparison.OrdinalIgnoreCase))
                {
                    _answeredCorrectly = true;
                    MessageBox.Show("Правильна відповідь! Ви можете натиснути Далі.");
                }
                else
                    MessageBox.Show("Неправильно!");
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (_block.Type == "Практика")
            {
                if (!(App.CurrentUser is RegisteredUser user) || user.Role != "Admin")
                {
                    if (!_answeredCorrectly)
                    {
                        MessageBox.Show("Будь ласка, введіть правильну відповідь перед переходом далі.");
                        return;
                    }
                }
            }

            DialogResult = true;
            Close();
        }


    }
}

