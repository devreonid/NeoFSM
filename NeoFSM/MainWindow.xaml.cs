using Microsoft.Win32;
using System.Windows;
using System.Windows.Media;

namespace NeoFSM
{
    public partial class MainWindow : Window
    {
        private readonly FsmEngine _engine = new FsmEngine();

        public MainWindow()
        {
            InitializeComponent();

            bool isWindowsDark = IsWindowsDarkMode();

            ThemeToggle.IsChecked = isWindowsDark;

            ApplyTheme(isWindowsDark);

            AppVersionRun.Text = "v1.0.0";
        }

        private void InputTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string input = InputTextBox.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                ResultPanel.Visibility = Visibility.Collapsed;
                return;
            }

            ResultPanel.Visibility = Visibility.Visible;

            bool isAccepted = _engine.Validate(input);

            UpdateResultUI(isAccepted, string.Join(" → ", _engine.History));
        }

        private void UpdateResultUI(bool isAccepted, string trace)
        {
            StatusResult.Text = isAccepted ? "ACCEPTED" : "REJECTED";
            StatusResult.Foreground = isAccepted ? Brushes.Green : Brushes.Red;

            StatusBorder.Background = isAccepted
                ? new SolidColorBrush(Color.FromArgb(35, 0, 255, 0))
                : new SolidColorBrush(Color.FromArgb(35, 255, 0, 0));

            RouteDisplay.Text = trace;
        }

        private bool IsWindowsDarkMode()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    // 0 = Dark Mode, 1 = Light Mode
                    return (int)(key?.GetValue("AppsUseLightTheme") ?? 1) == 0;
                }
            }
            catch { return false; }
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            ApplyTheme(ThemeToggle.IsChecked ?? false);
        }

        private void ApplyTheme(bool isDark)
        {
            var darkBg = new SolidColorBrush(Color.FromRgb(30, 30, 30));
            var controlBg = new SolidColorBrush(Color.FromRgb(45, 45, 45));
            var borderDark = new SolidColorBrush(Color.FromRgb(65, 65, 65));

            if (isDark)
            {
                this.Background = darkBg;
                this.Foreground = Brushes.White;
                InputTextBox.Background = controlBg;
                InputTextBox.Foreground = Brushes.White;
                InputTextBox.BorderBrush = borderDark;

                StatusTitle.Foreground = Brushes.LightGray;
                RouteDisplay.Foreground = Brushes.LightGray;
            }
            else
            {
                this.Background = new SolidColorBrush(Color.FromRgb(243, 243, 243));
                this.Foreground = Brushes.Black;
                InputTextBox.Background = Brushes.White;
                InputTextBox.Foreground = Brushes.Black;
                InputTextBox.BorderBrush = Brushes.LightGray;

                StatusTitle.Foreground = Brushes.Gray;
                RouteDisplay.Foreground = Brushes.DimGray;
            }
        }
    }
}