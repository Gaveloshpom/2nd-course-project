using System.Windows;

namespace OnlineCourseApp
{
    public partial class ReasonDialog : Window
    {
        public string Reason { get; private set; }

        public ReasonDialog()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ReasonTextBox.Text))
            {
                MessageBox.Show("Введіть причину!");
                return;
            }

            Reason = ReasonTextBox.Text.Trim();
            DialogResult = true;
            Close();
        }
    }
}

