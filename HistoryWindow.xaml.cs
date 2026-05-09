using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace AzureExamQuestions
{
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            var records = HistoryService.Load();
            records.Reverse(); // newest first

            if (records.Count == 0)
            {
                EmptyText.Visibility  = Visibility.Visible;
                HistoryList.Visibility = Visibility.Collapsed;
                SummaryText.Text = "Нет записей";
                return;
            }

            EmptyText.Visibility   = Visibility.Collapsed;
            HistoryList.Visibility = Visibility.Visible;

            int total   = records.Count;
            int passed  = records.Count(r => r.Mode == "Экзамен" && r.Passed);
            int exams   = records.Count(r => r.Mode == "Экзамен");
            SummaryText.Text = exams > 0
                ? $"Всего: {total}  •  Экзаменов: {exams}  •  Сдано: {passed}"
                : $"Всего тестов: {total}";

            HistoryList.ItemsSource = records.Select(r => new HistoryItemViewModel(r)).ToList();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Очистить всю историю тестов?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                HistoryService.Clear();
                Refresh();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();
    }

    internal class HistoryItemViewModel
    {
        public string ExamTitle { get; }
        public string Mode { get; }
        public string DateFormatted { get; }
        public string ScoreDisplay { get; }
        public string StatsLine { get; }
        public Brush ScoreColor { get; }
        public string PassBadgeText { get; }
        public Brush PassBadgeColor { get; }
        public Visibility PassBadgeVisibility { get; }

        public HistoryItemViewModel(HistoryRecord r)
        {
            ExamTitle = r.ExamTitle;
            Mode      = r.Mode;
            DateFormatted = $"{r.Date:dd.MM.yyyy  HH:mm}  •  {r.TimeSpent}";
            StatsLine = $"{r.Correct}/{r.Total} правильных";

            if (r.Mode == "Экзамен")
            {
                ScoreDisplay = r.Score.ToString();
                ScoreColor   = r.Passed
                    ? new SolidColorBrush(Color.FromRgb(16, 124, 16))
                    : new SolidColorBrush(Color.FromRgb(164, 38, 44));
                PassBadgeText       = r.Passed ? "СДАЛ" : "НЕ СДАЛ";
                PassBadgeColor      = r.Passed
                    ? new SolidColorBrush(Color.FromRgb(16, 124, 16))
                    : new SolidColorBrush(Color.FromRgb(164, 38, 44));
                PassBadgeVisibility = Visibility.Visible;
            }
            else
            {
                ScoreDisplay = $"{r.Percent:F0}%";
                ScoreColor   = r.Percent >= 80
                    ? new SolidColorBrush(Color.FromRgb(16, 124, 16))
                    : r.Percent >= 60
                        ? new SolidColorBrush(Color.FromRgb(200, 120, 0))
                        : new SolidColorBrush(Color.FromRgb(164, 38, 44));
                PassBadgeText       = "";
                PassBadgeColor      = Brushes.Transparent;
                PassBadgeVisibility = Visibility.Collapsed;
            }
        }
    }
}
