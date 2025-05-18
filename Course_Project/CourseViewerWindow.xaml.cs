using Course_Project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace OnlineCourseApp
{
    public partial class CourseViewerWindow : Window
    {
        private readonly Course _course;
        private int _currentIndex = 0;
        private List<ContentBlock> _blocks;

        public CourseViewerWindow(Course course)
        {
            InitializeComponent();
            _course = course;
            _blocks = _course.ContentBlocks.ToList();

            CourseTitle.Text = _course.Title;
            ProgressText.Text = $"Готові пройти {_blocks.Count} пунктів?";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.Visibility = Visibility.Collapsed;
            ProgressText.Text = $"Пункт {_currentIndex + 1} з {_blocks.Count}";
            ShowCurrentBlock();
        }

        private void ShowCurrentBlock()
        {
            if (_currentIndex >= _blocks.Count)
            {
                ShowCompletionWindow();
                Close();
                return;
            }

            var window = new CourseContentPlayerWindow(_blocks[_currentIndex]);
            window.Owner = this;
            var result = window.ShowDialog();

            if (result == true)
            {
                _currentIndex++;
                ProgressText.Text = $"Пункт {_currentIndex + 1} з {_blocks.Count}";
                ShowCurrentBlock();
            }
        }

        private void ShowCompletionWindow()
        {
            var completeWindow = new CourseCompletionWindow(_course);
            completeWindow.Owner = this;
            completeWindow.ShowDialog();
        }
    }
}

