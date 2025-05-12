using Course_Project.Models;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class AddPracticalTaskWindow : Window
    {
        private readonly Practice _practice;

        public AddPracticalTaskWindow(Practice practice)
        {
            InitializeComponent();
            _practice = practice;

            TitleBox.Text = _practice.Title;
            TaskTextBox.Text = _practice.Question;
            AnswerBox.Text = _practice.Answer;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string titleError = ValidationHelper.ValidatePracticeTitle(TitleBox.Text);
            string textError = ValidationHelper.ValidatePracticeText(TaskTextBox.Text);
            string answerError = ValidationHelper.ValidatePracticeAnswer(AnswerBox.Text);

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

            if (answerError != null)
            {
                MessageBox.Show(answerError);
                return;
            }

            _practice.Title = TitleBox.Text.Trim();
            _practice.Question = TaskTextBox.Text.Trim();
            _practice.Answer = AnswerBox.Text.Trim();

            DialogResult = true;
            Close();
        }
    }
}


