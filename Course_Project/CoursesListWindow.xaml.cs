using Course_Project.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OnlineCourseApp
{
    public partial class CoursesListWindow : Window
    {
        private readonly List<Course> _courses;
        private readonly bool _canStartCourse;

        public CoursesListWindow(List<Course> courses, string title, bool canStartCourse)
        {
            InitializeComponent();
            Title = title;
            _courses = courses;
            _canStartCourse = canStartCourse;

            LoadCourses();
        }

        private void LoadCourses()
        {
            foreach (var course in _courses)
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
                    if (_canStartCourse)
                    {
                        var viewer = new CourseViewerWindow(course);
                        viewer.Owner = this;
                        viewer.ShowDialog();
                    }
                    else
                    {
                        var infoWin = new CourseInfoWindow(course);
                        infoWin.Owner = this;
                        infoWin.ShowDialog();
                    }
                };

                CoursesWrapPanel.Children.Add(border);
            }
        }
    }
}

