using System.Windows;
using System.Windows.Media;

namespace AzureExamQuestions
{
    public partial class ResultWindow : Window
    {
        public ResultWindow(int total, int correct)
        {
            InitializeComponent();

            int    wrong   = total - correct;
            double percent = total > 0 ? (double)correct / total * 100 : 0;

            TotalText.Text   = total.ToString();
            CorrectText.Text = correct.ToString();
            WrongText.Text   = wrong.ToString();
            PercentText.Text = $"{percent:F0}%";

            ApplyScoreTheme(percent);
        }

        private void ApplyScoreTheme(double percent)
        {
            if (percent >= 80)
            {
                HeaderBorder.Background = new SolidColorBrush(Color.FromRgb(16, 124, 16));
                HeaderSubtitle.Text     = "Отличный результат!";
                ScoreCircle.Fill        = new SolidColorBrush(Color.FromRgb(223, 246, 221));
                PercentText.Foreground  = new SolidColorBrush(Color.FromRgb(16, 124, 16));
            }
            else if (percent >= 60)
            {
                HeaderBorder.Background = new SolidColorBrush(Color.FromRgb(200, 120, 0));
                HeaderSubtitle.Text     = "Хороший результат — есть куда расти.";
                ScoreCircle.Fill        = new SolidColorBrush(Color.FromRgb(255, 244, 206));
                PercentText.Foreground  = new SolidColorBrush(Color.FromRgb(130, 90, 0));
            }
            else
            {
                HeaderBorder.Background = new SolidColorBrush(Color.FromRgb(164, 38, 44));
                HeaderSubtitle.Text     = "Требуется дополнительная подготовка.";
                ScoreCircle.Fill        = new SolidColorBrush(Color.FromRgb(253, 231, 233));
                PercentText.Foreground  = new SolidColorBrush(Color.FromRgb(164, 38, 44));
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
