using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace AzureExamQuestions
{
    public partial class ResultWindow : Window
    {
        private readonly QuizResult _result;

        public ResultWindow(QuizResult result)
        {
            InitializeComponent();
            _result = result;
            SaveToHistory(result);

            int total   = result.Total;
            int correct = result.Correct;
            int wrong   = total - correct;

            TotalText.Text   = total.ToString();
            CorrectText.Text = correct.ToString();
            WrongText.Text   = wrong.ToString();

            // Time
            var ts = result.TimeSpent;
            TimeText.Text = ts.TotalHours >= 1
                ? $"{(int)ts.TotalHours}ч {ts.Minutes:D2}м {ts.Seconds:D2}с"
                : $"{ts.Minutes:D2}м {ts.Seconds:D2}с";

            if (result.Mode == QuizMode.Exam)
            {
                // Exam mode: show 0-1000 score and pass/fail
                ScoreText.Text  = result.Score.ToString();
                ScoreLabel.Text = "из 1000";

                ExamScoreRow.Visibility = Visibility.Visible;
                ExamScoreText.Text      = result.Score.ToString();

                PassFailBadge.Visibility = Visibility.Visible;
                if (result.Passed)
                {
                    PassFailText.Text           = "СДАЛ ✓";
                    PassFailBadge.Background    = new SolidColorBrush(Color.FromRgb(16, 124, 16));
                    HeaderBorder.Background     = new SolidColorBrush(Color.FromRgb(16, 124, 16));
                    HeaderSubtitle.Text         = $"Оценка {result.Score} — порог пройден (≥700)";
                    ScoreCircle.Fill            = new SolidColorBrush(Color.FromRgb(223, 246, 221));
                    ScoreText.Foreground        = new SolidColorBrush(Color.FromRgb(16, 124, 16));
                    ExamScoreText.Foreground    = new SolidColorBrush(Color.FromRgb(16, 124, 16));
                }
                else
                {
                    PassFailText.Text           = "НЕ СДАЛ ✗";
                    PassFailBadge.Background    = new SolidColorBrush(Color.FromRgb(96, 0, 0));
                    HeaderBorder.Background     = new SolidColorBrush(Color.FromRgb(164, 38, 44));
                    HeaderSubtitle.Text         = $"Оценка {result.Score} — порог не пройден (<700)";
                    ScoreCircle.Fill            = new SolidColorBrush(Color.FromRgb(253, 231, 233));
                    ScoreText.Foreground        = new SolidColorBrush(Color.FromRgb(164, 38, 44));
                    ExamScoreText.Foreground    = new SolidColorBrush(Color.FromRgb(164, 38, 44));
                }
            }
            else
            {
                // Study mode: show percentage
                ScoreText.Text  = $"{result.Percent:F0}%";
                ScoreLabel.Text = "результат";
                ApplyStudyTheme(result.Percent);
            }

            if (result.WrongAnswers.Count > 0)
            {
                ReviewButton.Visibility      = Visibility.Visible;
                RetryWrongButton.Visibility  = Visibility.Visible;
            }
        }

        private void ApplyStudyTheme(double percent)
        {
            if (percent >= 80)
            {
                HeaderBorder.Background = new SolidColorBrush(Color.FromRgb(16, 124, 16));
                HeaderSubtitle.Text     = "Отличный результат!";
                ScoreCircle.Fill        = new SolidColorBrush(Color.FromRgb(223, 246, 221));
                ScoreText.Foreground    = new SolidColorBrush(Color.FromRgb(16, 124, 16));
            }
            else if (percent >= 60)
            {
                HeaderBorder.Background = new SolidColorBrush(Color.FromRgb(200, 120, 0));
                HeaderSubtitle.Text     = "Хороший результат — есть куда расти.";
                ScoreCircle.Fill        = new SolidColorBrush(Color.FromRgb(255, 244, 206));
                ScoreText.Foreground    = new SolidColorBrush(Color.FromRgb(130, 90, 0));
            }
            else
            {
                HeaderBorder.Background = new SolidColorBrush(Color.FromRgb(164, 38, 44));
                HeaderSubtitle.Text     = "Требуется дополнительная подготовка.";
                ScoreCircle.Fill        = new SolidColorBrush(Color.FromRgb(253, 231, 233));
                ScoreText.Foreground    = new SolidColorBrush(Color.FromRgb(164, 38, 44));
            }
        }

        private static void SaveToHistory(QuizResult result)
        {
            var ts = result.TimeSpent;
            string timeStr = ts.TotalHours >= 1
                ? $"{(int)ts.TotalHours}ч {ts.Minutes:D2}м {ts.Seconds:D2}с"
                : $"{ts.Minutes:D2}м {ts.Seconds:D2}с";

            HistoryService.Append(new HistoryRecord
            {
                Date      = System.DateTime.Now,
                ExamTitle = result.ExamTitle,
                Mode      = result.Mode == QuizMode.Exam ? "Экзамен" : "Обучение",
                Total     = result.Total,
                Correct   = result.Correct,
                Score     = result.Score,
                Passed    = result.Passed,
                TimeSpent = timeStr
            });
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

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            new ReviewWindow(_result).Show();
        }

        private void RetryWrongButton_Click(object sender, RoutedEventArgs e)
        {
            var wrongQuestions = _result.WrongAnswers
                .Select(w => w.Bundle ?? QuestionBundle.Single(w.Question, _result.Language))
                .ToList();
            new QuizWindow(wrongQuestions, _result.ExamTitle, _result.Mode, _result.TimerSeconds,
                           _result.Languages, _result.Language).Show();
            Close();
        }
    }
}
