using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

namespace AzureExamQuestions
{
    public partial class QuizWindow : Window
    {
        private readonly List<QuestionBundle> _bundles;
        private readonly List<QuestionLanguage> _languages;
        private readonly QuizMode _mode;
        private readonly string _examTitle;
        private readonly DateTime _startTime = DateTime.Now;

        /// <summary>Код языка, на котором сейчас показываются вопросы.</summary>
        private string _language;

        private int _currentIndex = 0;
        private int _correctCount = 0;
        private bool _answered = false;

        // Состояние уже отвеченного вопроса — нужно, чтобы перерисовать его
        // на другом языке, не потеряв выбор пользователя и разбор ответа.
        private List<string> _answerSelected = new();
        private List<string> _answerCorrect  = new();
        private bool _answerIsCorrect;

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

        public QuizWindow(List<QuestionBundle> bundles, string examTitle = "",
                          QuizMode mode = QuizMode.Study, int timerSeconds = 90,
                          List<QuestionLanguage>? languages = null, string language = "")
        {
            InitializeComponent();
            _bundles   = bundles;
            _languages = languages ?? new List<QuestionLanguage>();
            _mode      = mode;
            _examTitle = examTitle;
            _language  = string.IsNullOrWhiteSpace(language)
                ? (_languages.FirstOrDefault()?.Code ?? "")
                : language;
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

            LanguageButton.Visibility = CanSwitchLanguage ? Visibility.Visible : Visibility.Collapsed;
            UpdateLanguageButton();

            LoadQuestion();
        }

        private QuestionBundle CurrentBundle => _bundles[_currentIndex];
        private Question Current => CurrentBundle.Get(_language);
        private bool IsMultiAnswer => Current.CorrectAnswer.Contains(',');

        /// <summary>Язык переключается только в режиме обучения и только если версий несколько.</summary>
        private bool CanSwitchLanguage => _mode == QuizMode.Study && _languages.Count > 1;

        // ─────────────────────────── вопрос ───────────────────────────

        /// <summary>Готовит новый вопрос: сбрасывает состояние и рисует его с нуля.</summary>
        private void LoadQuestion()
        {
            _answered = false;
            _answerSelected = new List<string>();
            _answerCorrect  = new List<string>();

            RenderQuestion();

            ActionButton.Content   = "Ответить";
            ActionButton.IsEnabled = false;
            UpdateStats();
            UpdateBookmarkButton();
            UpdateHint();

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

        /// <summary>
        /// Рисует текущий вопрос на текущем языке. Если ответ уже дан, восстанавливает
        /// выбор пользователя, подсветку вариантов и разбор — так смена языка
        /// не сбрасывает состояние вопроса.
        /// </summary>
        private void RenderQuestion()
        {
            _answerItems.Clear();

            var q = Current;
            QuestionNumberText.Text = $"Вопрос {_currentIndex + 1} из {_bundles.Count}";
            DifficultyText.Text     = new string('★', q.Difficulty) + new string('☆', 5 - q.Difficulty);
            QuestionText.Text       = q.Text;

            MultiAnswerHint.Visibility = IsMultiAnswer ? Visibility.Visible : Visibility.Collapsed;
            FeedbackBorder.Visibility  = Visibility.Collapsed;
            AnswersPanel.Children.Clear();

            foreach (var option in q.Options)
            {
                string letter = QuizHelper.ExtractLetter(option);
                bool   chosen = _answerSelected.Contains(letter);

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

                // Текст варианта — отдельный TextBlock с переносом: строка в Content
                // не переносится, и длинный вариант обрезался бы по ширине.
                var label = new TextBlock
                {
                    Text         = option,
                    TextWrapping = TextWrapping.Wrap,
                    LineHeight   = 20
                };

                Control ctrl;
                if (IsMultiAnswer)
                {
                    var cb = new CheckBox
                    {
                        Content = label, FontSize = 14, Tag = letter,
                        IsChecked = chosen,
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
                        Content = label, GroupName = "QuizAnswer", FontSize = 14, Tag = letter,
                        IsChecked = chosen,
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

            if (_answered)
            {
                ApplyAnsweredVisuals();
                if (_mode == QuizMode.Study)
                    ShowFeedback();
            }
        }

        /// <summary>Подсветка вариантов после ответа: зелёный — верный, красный — ошибочно выбранный.</summary>
        private void ApplyAnsweredVisuals()
        {
            foreach (var (ctrl, wrapper) in _answerItems)
            {
                string letter          = ctrl.Tag?.ToString() ?? "";
                bool   isCorrectOption = _answerCorrect.Contains(letter);
                bool   isChosen        = _answerSelected.Contains(letter);

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
        }

        /// <summary>Разбор ответа в режиме обучения — три необязательные части пояснения.</summary>
        private void ShowFeedback()
        {
            var q = Current;

            WhyWrongText.Visibility   = Visibility.Collapsed;
            WhyCorrectText.Visibility = Visibility.Collapsed;
            WhyOthersText.Visibility  = Visibility.Collapsed;

            if (_answerIsCorrect)
            {
                FeedbackText.Text       = "✓  Правильно!";
                FeedbackText.Foreground = new SolidColorBrush(Color.FromRgb(16, 124, 16));
            }
            else
            {
                FeedbackText.Text       = $"✗  Неверно.   Правильный ответ: {q.CorrectAnswerText}";
                FeedbackText.Foreground = new SolidColorBrush(Color.FromRgb(164, 38, 44));

                // 1) Почему выбранный вариант неверен
                var reasons = _answerSelected
                    .Where(letter => !_answerCorrect.Contains(letter))
                    .Select(letter => q.GetWhyWrong(letter))
                    .Where(text => !string.IsNullOrWhiteSpace(text))
                    .Select(text => text!)
                    .ToList();

                if (reasons.Count > 0)
                    SetLabeledText(WhyWrongText, "Почему ваш ответ неверен:",
                        string.Join(Environment.NewLine, reasons),
                        new SolidColorBrush(Color.FromRgb(164, 38, 44)));
            }

            // 2) Почему верен правильный ответ — один и тот же текст для обоих случаев
            if (q.HasExplanation)
                SetLabeledText(WhyCorrectText,
                    _answerIsCorrect ? "Почему это верно:" : $"Почему верен ответ {q.CorrectAnswer}:",
                    q.Explanation!,
                    new SolidColorBrush(Color.FromRgb(16, 124, 16)));

            // 3) Кратко — почему неверны остальные варианты.
            //    Показываем только при верном ответе: при неверном уже выведена
            //    точная причина по выбранному варианту, и сводка была бы повтором.
            if (_answerIsCorrect && q.HasWhyOthersWrong)
                SetLabeledText(WhyOthersText, "Почему остальные неверны:",
                    q.WhyOthersWrong!,
                    new SolidColorBrush(Color.FromRgb(72, 70, 68)));

            FeedbackBorder.Visibility = Visibility.Visible;
        }

        // ─────────────────────────── язык ───────────────────────────

        private void UpdateLanguageButton()
        {
            if (!CanSwitchLanguage) return;

            var current = _languages.FirstOrDefault(l =>
                string.Equals(l.Code, _language, StringComparison.OrdinalIgnoreCase)) ?? _languages[0];
            var next = NextLanguage();

            LanguageButton.Content = current.Code.ToUpperInvariant();
            LanguageButton.ToolTip = $"Язык: {current.DisplayName} → {next.DisplayName}  (L)";
        }

        private QuestionLanguage NextLanguage()
        {
            int idx = _languages.FindIndex(l =>
                string.Equals(l.Code, _language, StringComparison.OrdinalIgnoreCase));
            if (idx < 0) idx = 0;
            return _languages[(idx + 1) % _languages.Count];
        }

        /// <summary>Переключает язык и перерисовывает вопрос, сохраняя все ответы и счёт.</summary>
        private void SwitchLanguage()
        {
            if (!CanSwitchLanguage) return;

            _language = NextLanguage().Code;
            UpdateLanguageButton();
            RenderQuestion();
            UpdateHint();
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e) => SwitchLanguage();

        private void UpdateHint()
        {
            string hint;
            if (_answered)
            {
                bool isLast = _currentIndex >= _bundles.Count - 1;
                hint = isLast ? "Enter: завершить тест" : "Enter: следующий вопрос";
            }
            else
            {
                hint = _mode == QuizMode.Exam
                    ? "A–D: выбор  •  Enter: подтвердить  •  P: пауза"
                    : "A–D: выбор  •  Enter: подтвердить";
            }

            if (CanSwitchLanguage)
                hint += "  •  L: язык";

            HintText.Text = hint;
        }

        // ─────────────────────────── таймер ───────────────────────────

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

            if (e.Key == Key.L && CanSwitchLanguage)
            {
                SwitchLanguage();
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

        // ─────────────────────────── ответ ───────────────────────────

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
            if (_currentIndex >= _bundles.Count)
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

            _answerSelected  = new List<string>(selected);
            _answerCorrect   = correct;
            _answerIsCorrect = isCorrect;

            if (isCorrect)
            {
                _correctCount++;
            }
            else
            {
                _wrongAnswers.Add(new WrongAnswer
                {
                    Question     = q,
                    UserSelected = new List<string>(selected),
                    Bundle       = CurrentBundle
                });
            }

            ApplyAnsweredVisuals();

            if (_mode == QuizMode.Study)
                ShowFeedback();

            bool isLast            = _currentIndex >= _bundles.Count - 1;
            ActionButton.Content   = isLast ? "Завершить тест" : "Следующий вопрос  →";
            ActionButton.IsEnabled = true;
            UpdateHint();

            if (_mode == QuizMode.Exam)
            {
                PauseButton.IsEnabled = false;
                PauseButton.Opacity   = 0.35;
            }

            UpdateStats();
        }

        /// <summary>Выводит "Заголовок: текст" и делает блок видимым.</summary>
        private static void SetLabeledText(TextBlock target, string label, string body, Brush labelBrush)
        {
            target.Inlines.Clear();
            target.Inlines.Add(new Run(label) { FontWeight = FontWeights.SemiBold, Foreground = labelBrush });
            target.Inlines.Add(new Run(" " + body));
            target.Visibility = Visibility.Visible;
        }

        private void UpdateStats()
        {
            int answeredCount = _currentIndex + (_answered ? 1 : 0);
            int wrongCount    = answeredCount - _correctCount;
            int remaining     = _bundles.Count - answeredCount;

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
            int total   = _bundles.Count;
            int correct = answered - wrong;
            // Use star-ratio columns: correct* wrong* remain*
            ColCorrect.Width = new GridLength(correct, GridUnitType.Star);
            ColWrong.Width   = new GridLength(wrong,   GridUnitType.Star);
            ColRemain.Width  = new GridLength(Math.Max(0, total - answered), GridUnitType.Star);
        }

        private void ShowResults()
        {
            // Разбор ошибок показываем на том языке, на котором тест завершён.
            var wrong = _wrongAnswers
                .Select(wa => new WrongAnswer
                {
                    Question     = wa.Bundle?.Get(_language) ?? wa.Question,
                    UserSelected = wa.UserSelected,
                    Bundle       = wa.Bundle
                })
                .ToList();

            var result = new QuizResult
            {
                Total        = _bundles.Count,
                Correct      = _correctCount,
                Mode         = _mode,
                TimeSpent    = DateTime.Now - _startTime,
                WrongAnswers = wrong,
                ExamTitle    = _examTitle,
                TimerSeconds = _secondsPerQuestion,
                Languages    = _languages,
                Language     = _language
            };
            new ResultWindow(result).Show();
            Close();
        }
    }
}
