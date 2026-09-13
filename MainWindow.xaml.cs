using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AzureExamQuestions
{
    public partial class MainWindow : Window
    {
        private ExamDefinition? _selectedExam;

        /// <summary>Пока идёт заполнение списка языков, его SelectionChanged игнорируется.</summary>
        private bool _fillingLanguages;

        /// <summary>Об ошибке чтения вопросов сообщаем один раз, а не на каждое движение ползунка.</summary>
        private bool _dataErrorShown;

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
            try
            {
                var exams = ExamCatalog.GetAll();
                foreach (var exam in exams)
                    ExamComboBox.Items.Add(exam);

                ExamComboBox.DisplayMemberPath = "DisplayTitle";
                ExamComboBox.SelectedIndex = 0;   // AZ-900 по умолчанию
            }
            catch (Exception ex)
            {
                ShowDataError(ex);
            }
        }

        /// <summary>
        /// Показывает ошибку данных и блокирует старт. Вопросы читаются лениво, поэтому
        /// такая ошибка может всплыть уже после открытия окна — без этого приложение
        /// просто падало бы.
        /// </summary>
        private void ShowDataError(Exception ex)
        {
            if (StartButton != null)
                StartButton.IsEnabled = false;

            if (_dataErrorShown) return;
            _dataErrorShown = true;

            MessageBox.Show(
                $@"Не удалось загрузить вопросы из папки:
{QuestionRepository.DataDirectory}

{ex.Message}",
                "Ошибка загрузки данных", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ExamComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedExam = ExamComboBox.SelectedItem as ExamDefinition;
            if (_selectedExam is null) return;

            if (ExamDescText != null)
                ExamDescText.Text = _selectedExam.Description;

            FillLanguages(_selectedExam);
            UpdateAvailableCount();
        }

        /// <summary>Заполняет список языков; для одноязычного набора прячет весь блок.</summary>
        private void FillLanguages(ExamDefinition exam)
        {
            if (LanguageComboBox == null || LanguagePanel == null) return;

            _fillingLanguages = true;
            try
            {
                LanguageComboBox.Items.Clear();
                foreach (var lang in exam.Languages)
                    LanguageComboBox.Items.Add(lang);

                var preferred = exam.PreferredLanguage;
                LanguageComboBox.SelectedItem = preferred ?? (exam.Languages.Count > 0 ? exam.Languages[0] : null);
                if (LanguageComboBox.SelectedItem is null && LanguageComboBox.Items.Count > 0)
                    LanguageComboBox.SelectedIndex = 0;
            }
            finally
            {
                _fillingLanguages = false;
            }

            LanguagePanel.Visibility = exam.IsMultiLanguage ? Visibility.Visible : Visibility.Collapsed;
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_fillingLanguages) return;
            UpdateAvailableCount();
        }

        private string SelectedLanguageCode =>
            (LanguageComboBox?.SelectedItem as QuestionLanguage)?.Code
            ?? _selectedExam?.PreferredLanguage?.Code
            ?? "";

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

        /// <summary>Вопросы выбранного экзамена после фильтров сложности и избранного.</summary>
        private List<QuestionBundle> BuildPool()
        {
            if (_selectedExam is null) return new List<QuestionBundle>();

            int minDiff = (int)DifficultySlider.Value;
            bool bookmarksOnly = BookmarksOnlyCheck?.IsChecked == true;

            try
            {
                var pool = _selectedExam.GetBundles()
                    .Where(b => b.Difficulty >= minDiff);
                if (bookmarksOnly)
                    pool = pool.Where(b => BookmarkService.IsBookmarked(b.Id));

                return pool.ToList();
            }
            catch (Exception ex)
            {
                ShowDataError(ex);
                return new List<QuestionBundle>();
            }
        }

        private void UpdateAvailableCount()
        {
            if (AvailableText == null || CountSlider == null || _selectedExam is null) return;

            int available = BuildPool().Count;

            AvailableText.Text  = $"(доступно: {available})";
            CountSlider.Maximum = Math.Max(1, available);
            if (CountSlider.Value > available)
                CountSlider.Value = available;

            UpdateBookmarkCountText();
            UpdateCoverageText();
        }

        /// <summary>Показывает, на сколько вопросов набора уже отвечали в каждом из режимов.</summary>
        private void UpdateCoverageText()
        {
            if (CoverageText == null || _selectedExam is null) return;

            try
            {
                var keys  = _selectedExam.GetBundles().Select(b => b.Key).ToList();
                int study = StatsService.AnsweredCount(_selectedExam.Key, QuizMode.Study, keys);
                int exam  = StatsService.AnsweredCount(_selectedExam.Key, QuizMode.Exam, keys);
                CoverageText.Text =
                    $"Отвечено: обучение {study} из {keys.Count}  •  экзамен {exam} из {keys.Count}";
            }
            catch (Exception ex)
            {
                ShowDataError(ex);
            }
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

            int count = (int)CountSlider.Value;

            var questions = BuildPool()
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

            new QuizWindow(questions, _selectedExam.DisplayTitle, mode, timerSec,
                           _selectedExam.Languages, SelectedLanguageCode,
                           _selectedExam.Key).Show();
            Close();
        }
    }
}
