using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace AzureExamQuestions
{
    public partial class QuizWindow : Window
    {
        private readonly List<Question> _questions;
        private readonly QuizMode _mode;
        private readonly DateTime _startTime = DateTime.Now;

        private int _currentIndex = 0;
        private int _correctCount = 0;
        private bool _answered = false;

        private readonly List<WrongAnswer> _wrongAnswers = new();
        private readonly List<(Control Ctrl, Border Wrapper)> _answerItems = new();

        // Exam mode timer
        private DispatcherTimer? _timer;
        private int _secondsLeft;
        private const int SecondsPerQuestion = 90;

        private static readonly SolidColorBrush GreenBack    = new(Color.FromRgb(223, 246, 221));
        private static readonly SolidColorBrush GreenBorder  = new(Color.FromRgb(108, 184, 108));
        private static readonly SolidColorBrush RedBack      = new(Color.FromRgb(253, 231, 233));
        private static readonly SolidColorBrush RedBorder    = new(Color.FromRgb(196, 106, 116));
        private static readonly SolidColorBrush NeutralBack  = Brushes.White;
        private static readonly SolidColorBrush NeutralBorder = new(Color.FromRgb(225, 223, 221));

        public QuizWindow(List<Question> questions, string examTitle = "", QuizMode mode = QuizMode.Study)
        {
            InitializeComponent();
            _questions = questions;
            _mode = mode;

            if (!string.IsNullOrEmpty(examTitle))
                Title = $"My Exam Quiz — {examTitle}";

            if (_mode == QuizMode.Exam)
            {
                TimerBorder.Visibility = Visibility.Visible;
                _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                _timer.Tick += Timer_Tick;
            }

            LoadQuestion();
        }

        private Question Current => _questions[_currentIndex];
        private bool IsMultiAnswer => Current.CorrectAnswer.Contains(',');

        private void LoadQuestion()
        {
            _answered = false;
            _answerItems.Clear();

            var q = Current;
            QuestionNumberText.Text = $"Вопрос {_currentIndex + 1} из {_questions.Count}";
            DifficultyText.Text     = new string('★', q.Difficulty) + new string('☆', 5 - q.Difficulty);
            ProgressBar.Value       = (double)_currentIndex / _questions.Count * 100;
            QuestionText.Text       = q.Text;

            MultiAnswerHint.Visibility = IsMultiAnswer ? Visibility.Visible : Visibility.Collapsed;
            FeedbackBorder.Visibility  = Visibility.Collapsed;
            AnswersPanel.Children.Clear();

            foreach (var option in q.Options)
            {
                string letter = QuizHelper.ExtractLetter(option);

                var wrapper = new Border
                {
                    Background      = NeutralBack,
                    BorderBrush     = NeutralBorder,
                    BorderThickness = new Thickness(1),
                    CornerRadius    = new CornerRadius(4),
                    Padding         = new Thickness(14, 10, 14, 10),
                    Margin          = new Thickness(0, 4, 0, 4),
                    Cursor          = System.Windows.Input.Cursors.Hand
                };

                Control ctrl;
                if (IsMultiAnswer)
                {
                    var cb = new CheckBox
                    {
                        Content = option, FontSize = 14, Tag = letter,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    cb.Checked   += OnSelectionChanged;
                    cb.Unchecked += OnSelectionChanged;
                    ctrl = cb;
                }
                else
                {
                    var rb = new RadioButton
                    {
                        Content = option, GroupName = "QuizAnswer", FontSize = 14, Tag = letter,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    rb.Checked += OnSelectionChanged;
                    ctrl = rb;
                }

                wrapper.Child = ctrl;
                wrapper.MouseLeftButtonDown += (_, _) =>
                {
                    if (_answered) return;
                    if (ctrl is RadioButton r) r.IsChecked = true;
                    else if (ctrl is CheckBox c) c.IsChecked = !c.IsChecked;
                };

                AnswersPanel.Children.Add(wrapper);
                _answerItems.Add((ctrl, wrapper));
            }

            ActionButton.Content   = "Ответить";
            ActionButton.IsEnabled = false;
            UpdateStats();

            if (_mode == QuizMode.Exam)
                StartTimer();
        }

        private void StartTimer()
        {
            _secondsLeft = SecondsPerQuestion;
            UpdateTimerDisplay();
            _timer!.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _secondsLeft--;
            UpdateTimerDisplay();

            if (_secondsLeft <= 0)
            {
                _timer!.Stop();
                // Time's up — auto-submit with current selection (may be empty)
                if (!_answered)
                    CheckAnswer();
            }
        }

        private void UpdateTimerDisplay()
        {
            int m = _secondsLeft / 60;
            int s = _secondsLeft % 60;
            TimerText.Text = $"{m:D2}:{s:D2}";
            TimerText.Foreground = _secondsLeft <= 15
                ? new SolidColorBrush(Colors.OrangeRed)
                : Brushes.White;
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!_answered)
                ActionButton.IsEnabled = GetSelectedLetters().Count > 0;
        }

        private List<string> GetSelectedLetters()
        {
            var result = new List<string>();
            foreach (var (ctrl, _) in _answerItems)
            {
                bool selected = ctrl is RadioButton rb && rb.IsChecked == true
                             || ctrl is CheckBox cb  && cb.IsChecked  == true;
                if (selected && ctrl.Tag is string letter)
                    result.Add(letter);
            }
            return result;
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_answered)
            {
                CheckAnswer();
                return;
            }

            _currentIndex++;
            if (_currentIndex >= _questions.Count)
                ShowResults();
            else
                LoadQuestion();
        }

        private void CheckAnswer()
        {
            _timer?.Stop();
            _answered = true;

            var q        = Current;
            var selected = GetSelectedLetters();
            var correct  = q.CorrectAnswer.Split(',')
                            .Select(s => s.Trim())
                            .OrderBy(s => s)
                            .ToList();
            bool isCorrect = selected.OrderBy(s => s).SequenceEqual(correct);

            if (isCorrect)
            {
                _correctCount++;
            }
            else
            {
                _wrongAnswers.Add(new WrongAnswer
                {
                    Question     = q,
                    UserSelected = new List<string>(selected)
                });
            }

            // Always highlight options
            foreach (var (ctrl, wrapper) in _answerItems)
            {
                string letter          = ctrl.Tag?.ToString() ?? "";
                bool   isCorrectOption = correct.Contains(letter);
                bool   isChosen        = selected.Contains(letter);

                if (isCorrectOption)
                {
                    wrapper.Background  = GreenBack;
                    wrapper.BorderBrush = GreenBorder;
                }
                else if (isChosen)
                {
                    wrapper.Background  = RedBack;
                    wrapper.BorderBrush = RedBorder;
                }

                ctrl.IsEnabled = false;
            }

            if (_mode == QuizMode.Study)
            {
                if (isCorrect)
                {
                    FeedbackText.Text       = "✓  Правильно!";
                    FeedbackText.Foreground = new SolidColorBrush(Color.FromRgb(16, 124, 16));
                }
                else
                {
                    FeedbackText.Text       = $"✗  Неверно.   Правильный ответ: {q.CorrectAnswerText}";
                    FeedbackText.Foreground = new SolidColorBrush(Color.FromRgb(164, 38, 44));
                }
                FeedbackBorder.Visibility = Visibility.Visible;
            }

            bool isLast          = _currentIndex >= _questions.Count - 1;
            ActionButton.Content  = isLast ? "Завершить тест" : "Следующий вопрос  →";
            ActionButton.IsEnabled = true;

            UpdateStats();
        }

        private void UpdateStats()
        {
            int answeredCount = _currentIndex + (_answered ? 1 : 0);
            int wrongCount    = answeredCount - _correctCount;
            int remaining     = _questions.Count - answeredCount;
            StatsText.Text    = $"✓ {_correctCount}  ✗ {wrongCount}  •  Осталось: {remaining}";
        }

        private void ShowResults()
        {
            var result = new QuizResult
            {
                Total        = _questions.Count,
                Correct      = _correctCount,
                Mode         = _mode,
                TimeSpent    = DateTime.Now - _startTime,
                WrongAnswers = _wrongAnswers
            };
            new ResultWindow(result).Show();
            Close();
        }
    }
}
