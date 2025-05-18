using Course_Project.Models;
using Course_Project.ViewModels;
using OnlineCourseApp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Maket_View_test_1;
using System;
using System.Linq;

public class AdminPanelViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Course> AllCourses { get; set; }

    private Course _selectedCourse;
    public Course SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            _selectedCourse = value;
            OnPropertyChanged(nameof(SelectedCourse));
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public ICommand PublishCourseCommand { get; }
    public ICommand FreezeCourseCommand { get; }
    public ICommand DeleteCourseCommand { get; }
    public ICommand ViewLogsCommand { get; }
    public ICommand ViewCourseCommand { get; }

    public AdminPanelViewModel()
    {
        AllCourses = new ObservableCollection<Course>(CourseService.LoadCourses());

        PublishCourseCommand = new RelayCommand(_ => PublishCourse(), _ => SelectedCourse != null && SelectedCourse.Status == "На розгляді");
        FreezeCourseCommand = new RelayCommand(_ => FreezeCourse(), _ => SelectedCourse != null && (SelectedCourse.Status == "Опубліковано" || SelectedCourse.Status == "На розгляді"));
        DeleteCourseCommand = new RelayCommand(_ => DeleteCourse(), _ => SelectedCourse != null);
        ViewLogsCommand = new RelayCommand(_ => ViewLogs(), _ => SelectedCourse != null);
        ViewCourseCommand = new RelayCommand(_ => ViewCourse(), _ => SelectedCourse != null);
    }

    private void ViewLogs()
    {
        if (SelectedCourse == null) return;

        var win = new AdminLogsWindow(SelectedCourse);
        win.ShowDialog();
    }

    private void PublishCourse()
    {
        if (SelectedCourse == null) return;

        string reason = GetReason();
        if (string.IsNullOrEmpty(reason)) return;

        SelectedCourse.Status = "Опубліковано";
        SelectedCourse.AdminLogs.Add($"{DateTime.Now:G} [{App.CurrentUser.Email}]: Опубліковано - {reason}");
        CourseService.UpdateCourse(SelectedCourse);

        MessageBox.Show($"Курс опубліковано. Причина: {reason}");
        RefreshCourses();
    }

    private void FreezeCourse()
    {
        if (SelectedCourse == null) return;

        string reason = GetReason();
        if (string.IsNullOrEmpty(reason)) return;

        SelectedCourse.Status = "Заморожено";
        SelectedCourse.AdminLogs.Add($"{DateTime.Now:G} [{App.CurrentUser.Email}]: Заморожено - {reason}");
        CourseService.UpdateCourse(SelectedCourse);

        MessageBox.Show($"Курс заморожено. Причина: {reason}");
        RefreshCourses();
    }

    private void DeleteCourse()
    {
        if (SelectedCourse == null) return;

        string reason = GetReason();
        if (string.IsNullOrEmpty(reason)) return;

        SelectedCourse.AdminLogs.Add($"{DateTime.Now:G} [{App.CurrentUser.Email}]: Видалено - {reason}");
        CourseService.DeleteCourse(SelectedCourse);

        MessageBox.Show($"Курс видалено. Причина: {reason}");
        RefreshCourses();
    }

    private void ViewCourse()
    {
        if (SelectedCourse == null || SelectedCourse.ContentBlocks == null || !SelectedCourse.ContentBlocks.Any())
        {
            MessageBox.Show("Курс порожній або не вибрано.");
            return;
        }

        foreach (var block in SelectedCourse.ContentBlocks)
        {
            var window = new CourseContentPlayerWindow(block, isAdmin: true);
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }

        MessageBox.Show("Перегляд завершено.");
    }

    private string GetReason()
    {
        var dialog = new ReasonDialog();
        if (dialog.ShowDialog() == true)
            return dialog.Reason;
        else
            return null;
    }

    private void RefreshCourses()
    {
        AllCourses = new ObservableCollection<Course>(CourseService.LoadCourses());
        OnPropertyChanged(nameof(AllCourses));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

