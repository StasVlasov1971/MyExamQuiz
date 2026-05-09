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

            int minDiff  = (int)DifficultySlider.Value;
            int available = _selectedExam.GetQuestions()
                .Count(q => q.Difficulty >= minDiff);

            AvailableText.Text    = $"(доступно: {available})";
            CountSlider.Maximum   = Math.Max(1, available);
            if (CountSlider.Value > available)
                CountSlider.Value = available;
        }

        private void StudyModeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ModeDescText != null)
                ModeDescText.Text = "Обучение: сразу показывает правильный ответ и объяснение.";
        }

        private void ExamModeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ModeDescText != null)
                ModeDescText.Text = "Экзамен: без подсказок, таймер, оценка по шкале 0–1000 (порог 700).";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedExam is null) return;

            int minDiff = (int)DifficultySlider.Value;
            int count   = (int)CountSlider.Value;

            var questions = _selectedExam.GetQuestions()
                .Where(q => q.Difficulty >= minDiff)
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
            new QuizWindow(questions, _selectedExam.DisplayTitle, mode).Show();
            Close();
        }
    }
}
