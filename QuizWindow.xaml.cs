using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Threading;

namespace AzureExamQuestions
{
    public partial class QuizWindow : Window
    {
        private readonly List<Question> _questions;
        private readonly QuizMode _mode;
        private readonly string _examTitle;
        private readonly DateTime _startTime = DateTime.Now;

        private int _currentIndex = 0;
        private int _correctCount = 0;
        private bool _answered = false;

        private readonly List<WrongAnswer> _wrongAnswers = new();
        private readonly List<(Control Ctrl, Border Wrapper)> _answerItems = new();

        // Exam mode timer
        private DispatcherTimer? _timer;
        private int _secondsLeft;
        private int _secondsPerQuestion;
        private bool _paused = false;

        private static readonly SolidColorBrush GreenBack    = new(Color.FromRgb(223, 246, 221));
        private static readonly SolidColorBrush GreenBorder  = new(Color.FromRgb(108, 184, 108));
        private static readonly SolidColorBrush RedBack      = new(Color.FromRgb(253, 231, 233));
        private static readonly SolidColorBrush RedBorder    = new(Color.FromRgb(196, 106, 116));
        private static readonly SolidColorBrush NeutralBack  = Brushes.White;
        private static readonly SolidColorBrush NeutralBorder = new(Color.FromRgb(225, 223, 221));

        public QuizWindow(List<Question> questions, string examTitle = "",
                          QuizMode mode = QuizMode.Study, int timerSeconds = 90)
        {
            InitializeComponent();
            _questions = questions;
            _mode = mode;
            _examTitle = examTitle;
            _secondsPerQuestion = timerSeconds > 0 ? timerSeconds : 90;

            if (!string.IsNullOrEmpty(examTitle))
                Title = $"My Exam Quiz — {examTitle}";

            if (_mode == QuizMode.Exam)
            {
                TimerBorder.Visibility  = Visibility.Visible;
                PauseButton.Visibility  = Visibility.Visible;
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
            UpdateBookmarkButton();

            HintText.Text = _mode == QuizMode.Exam
                ? "A–D: выбор  •  Enter: подтвердить  •  P: пауза"
                : "A–D: выбор  •  Enter: подтвердить";

            if (_mode == QuizMode.Exam)
            {
                _paused                 = false;
                PauseOverlay.Visibility = Visibility.Collapsed;
                PauseButton.Content     = "⏸";
                PauseButton.ToolTip     = "Пауза (P)";
                PauseButton.IsEnabled   = true;
                PauseButton.Opacity     = 1.0;
                StartTimer();
            }
        }

        private void StartTimer()
        {
            _secondsLeft = _secondsPerQuestion;
            UpdateTimerDisplay();
            _timer!.Start();
        }

        private void PauseQuiz()
        {
            _paused = true;
            _timer!.Stop();
            PauseOverlay.Visibility = Visibility.Visible;
            ActionButton.IsEnabled  = false;
            PauseButton.Content     = "▶";
            PauseButton.ToolTip     = "Продолжить (P)";
        }

        private void ResumeQuiz()
        {
            _paused = false;
            PauseOverlay.Visibility = Visibility.Collapsed;
            PauseButton.Content     = "⏸";
            PauseButton.ToolTip     = "Пауза (P)";
            ActionButton.IsEnabled  = GetSelectedLetters().Count > 0;
            _timer!.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_answered) return;
            if (_paused) ResumeQuiz(); else PauseQuiz();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.P && _mode == QuizMode.Exam && !_answered)
            {
                if (_paused) ResumeQuiz(); else PauseQuiz();
                e.Handled = true;
                return;
            }

            if (_paused) return;

            if (_answered)
            {
                if (e.Key == Key.Enter)
                {
                    ActionButton_Click(sender, e);
                    e.Handled = true;
                }
                return;
            }

            string? letter = e.Key switch
            {
                Key.A => "A", Key.B => "B", Key.C => "C",
                Key.D => "D", Key.E => "E", _     => null
            };

            if (letter != null)
            {
                foreach (var (ctrl, _) in _answerItems)
                {
                    if (ctrl.Tag?.ToString() != letter) continue;
                    if (ctrl is RadioButton rb)   rb.IsChecked = true;
                    else if (ctrl is CheckBox cb) cb.IsChecked = !cb.IsChecked;
                    e.Handled = true;
                    break;
                }
            }
            else if (e.Key == Key.Enter && ActionButton.IsEnabled)
            {
                ActionButton_Click(sender, e);
                e.Handled = true;
            }
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

            bool isLast            = _currentIndex >= _questions.Count - 1;
            ActionButton.Content   = isLast ? "Завершить тест" : "Следующий вопрос  →";
            ActionButton.IsEnabled = true;
            HintText.Text          = isLast ? "Enter: завершить тест" : "Enter: следующий вопрос";

            if (_mode == QuizMode.Exam)
            {
                PauseButton.IsEnabled = false;
                PauseButton.Opacity   = 0.35;
            }

            UpdateStats();
        }

        private void UpdateStats()
        {
            int answeredCount = _currentIndex + (_answered ? 1 : 0);
            int wrongCount    = answeredCount - _correctCount;
            int remaining     = _questions.Count - answeredCount;

            int pct = answeredCount > 0
                ? (int)Math.Round((double)_correctCount / answeredCount * 100)
                : 0;
            StatsText.Text = $"✓ {_correctCount}  ✗ {wrongCount}  •  Осталось: {remaining}  •  {pct}% верно";

            UpdateProgressBar(answeredCount, wrongCount);
            ColAccFill.Width  = new GridLength(pct,       GridUnitType.Star);
            ColAccEmpty.Width = new GridLength(100 - pct, GridUnitType.Star);
        }

        private void UpdateBookmarkButton()
        {
            bool bookmarked = BookmarkService.IsBookmarked(Current.Id);
            BookmarkButton.Content   = bookmarked ? "★" : "☆";
            BookmarkButton.Foreground = bookmarked
                ? System.Windows.Media.Brushes.Gold
                : new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromRgb(190, 224, 248));
            BookmarkButton.ToolTip = bookmarked ? "Убрать из избранного" : "Добавить в избранное";
        }

        private void BookmarkButton_Click(object sender, RoutedEventArgs e)
        {
            BookmarkService.Toggle(Current.Id);
            UpdateBookmarkButton();
        }

        private void UpdateProgressBar(int answered, int wrong)
        {
            int total   = _questions.Count;
            int correct = answered - wrong;
            // Use star-ratio columns: correct* wrong* remain*
            ColCorrect.Width = new GridLength(correct, GridUnitType.Star);
            ColWrong.Width   = new GridLength(wrong,   GridUnitType.Star);
            ColRemain.Width  = new GridLength(Math.Max(0, total - answered), GridUnitType.Star);
        }

        private void ShowResults()
        {
            var result = new QuizResult
            {
                Total        = _questions.Count,
                Correct      = _correctCount,
                Mode         = _mode,
                TimeSpent    = DateTime.Now - _startTime,
                WrongAnswers = _wrongAnswers,
                ExamTitle    = _examTitle,
                TimerSeconds = _secondsPerQuestion
            };
            new ResultWindow(result).Show();
            Close();
        }
    }
}
