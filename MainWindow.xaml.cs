using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AzureExamQuestions
{
    public partial class MainWindow : Window
    {
        private ExamDefinition? _selectedExam;

        public MainWindow()
        {
            InitializeComponent();
            LoadExams();
            UpdateBookmarkCountText();
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            new HistoryWindow().Show();
        }

        private void BookmarksOnlyCheck_Changed(object sender, RoutedEventArgs e)
        {
            UpdateAvailableCount();
        }

        private void UpdateBookmarkCountText()
        {
            if (BookmarkCountText == null) return;
            int cnt = BookmarkService.Count;
            BookmarkCountText.Text = cnt > 0 ? $"({cnt} вопросов в избранном)" : "(нет избранных)";
        }

        private void LoadExams()
        {
            var exams = ExamCatalog.GetAll();
            foreach (var exam in exams)
                ExamComboBox.Items.Add(exam);

            ExamComboBox.DisplayMemberPath = "DisplayTitle";
            ExamComboBox.SelectedIndex = 0;   // AZ-900 по умолчанию
        }

        private void ExamComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedExam = ExamComboBox.SelectedItem as ExamDefinition;
            if (_selectedExam is null) return;

            if (ExamDescText != null)
                ExamDescText.Text = _selectedExam.Description;

            UpdateAvailableCount();
        }

        private void DifficultySlider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            if (DifficultyValueText == null) return;
            DifficultyValueText.Text = ((int)DifficultySlider.Value).ToString();
            UpdateAvailableCount();
        }

        private void CountSlider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            if (CountValueText == null) return;
            CountValueText.Text = ((int)CountSlider.Value).ToString();
        }

        private void UpdateAvailableCount()
        {
            if (AvailableText == null || CountSlider == null || _selectedExam is null) return;

            int minDiff = (int)DifficultySlider.Value;
            bool bookmarksOnly = BookmarksOnlyCheck?.IsChecked == true;

            var pool = _selectedExam.GetQuestions()
                .Where(q => q.Difficulty >= minDiff);
            if (bookmarksOnly)
                pool = pool.Where(q => BookmarkService.IsBookmarked(q.Id));

            int available = pool.Count();

            AvailableText.Text  = $"(доступно: {available})";
            CountSlider.Maximum = Math.Max(1, available);
            if (CountSlider.Value > available)
                CountSlider.Value = available;

            UpdateBookmarkCountText();
        }

        private void StudyModeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ModeDescText != null)
                ModeDescText.Text = "Обучение: сразу показывает правильный ответ и объяснение.";
            if (TimerPanel != null)
                TimerPanel.Visibility = Visibility.Collapsed;
        }

        private void ExamModeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ModeDescText != null)
                ModeDescText.Text = "Экзамен: без подсказок, таймер, оценка по шкале 0–1000 (порог 700).";
            if (TimerPanel != null)
                TimerPanel.Visibility = Visibility.Visible;
        }

        private void TimerSlider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            if (TimerBadgeText == null) return;
            int val = (int)TimerSlider.Value;
            TimerBadgeText.Text  = val.ToString();
            TimerValueText.Text  = $"({val} сек)";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedExam is null) return;

            int minDiff = (int)DifficultySlider.Value;
            int count   = (int)CountSlider.Value;

            bool bookmarksOnly = BookmarksOnlyCheck?.IsChecked == true;

            var pool = _selectedExam.GetQuestions()
                .Where(q => q.Difficulty >= minDiff);
            if (bookmarksOnly)
                pool = pool.Where(q => BookmarkService.IsBookmarked(q.Id));

            var questions = pool
                .OrderBy(_ => Guid.NewGuid())
                .Take(count)
                .ToList();

            if (questions.Count == 0)
            {
                MessageBox.Show("Нет вопросов для выбранного уровня сложности.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var mode = ExamModeRadio.IsChecked == true ? QuizMode.Exam : QuizMode.Study;
            int timerSec = mode == QuizMode.Exam ? (int)TimerSlider.Value : 0;

            new QuizWindow(questions, _selectedExam.DisplayTitle, mode, timerSec).Show();
            Close();
        }
    }
}
