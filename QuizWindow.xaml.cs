using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AzureExamQuestions
{
    public partial class QuizWindow : Window
    {
        private readonly List<Question> _questions;
        private int _currentIndex = 0;
        private int _correctCount = 0;
        private bool _answered = false;

        // Each entry: the toggle control (RadioButton or CheckBox) + its wrapper Border
        private readonly List<(Control Ctrl, Border Wrapper)> _answerItems = new();

        private static readonly SolidColorBrush GreenBack   = new(Color.FromRgb(223, 246, 221));
        private static readonly SolidColorBrush GreenBorder = new(Color.FromRgb(108, 184, 108));
        private static readonly SolidColorBrush RedBack     = new(Color.FromRgb(253, 231, 233));
        private static readonly SolidColorBrush RedBorder   = new(Color.FromRgb(196, 106, 116));
        private static readonly SolidColorBrush NeutralBack = Brushes.White;
        private static readonly SolidColorBrush NeutralBorder = new(Color.FromRgb(225, 223, 221));

        public QuizWindow(List<Question> questions, string examTitle = "")
        {
            InitializeComponent();
            _questions = questions;
            if (!string.IsNullOrEmpty(examTitle))
                Title = $"My Exam Quiz — {examTitle}";
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
                string letter = ExtractLetter(option);

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
                        Content         = option,
                        FontSize        = 14,
                        Tag             = letter,
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
                        Content         = option,
                        GroupName       = "QuizAnswer",
                        FontSize        = 14,
                        Tag             = letter,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    rb.Checked += OnSelectionChanged;
                    ctrl = rb;
                }

                wrapper.Child = ctrl;

                // Clicking the border also toggles the control
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
        }

        private static string ExtractLetter(string option)
        {
            int idx = option.IndexOf(')');
            return idx > 0 ? option[..idx].Trim() : option[0].ToString();
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
            _answered = true;

            var q        = Current;
            var selected = GetSelectedLetters();
            var correct  = q.CorrectAnswer.Split(',')
                            .Select(s => s.Trim())
                            .OrderBy(s => s)
                            .ToList();
            bool isCorrect = selected.OrderBy(s => s).SequenceEqual(correct);

            if (isCorrect) _correctCount++;

            // Highlight each option
            foreach (var (ctrl, wrapper) in _answerItems)
            {
                string letter          = ctrl.Tag?.ToString() ?? "";
                bool   isCorrectOption = correct.Contains(letter);
                bool   isChosen        = selected.Contains(letter);

                if (isCorrectOption)
                {
                    wrapper.Background   = GreenBack;
                    wrapper.BorderBrush  = GreenBorder;
                }
                else if (isChosen)
                {
                    wrapper.Background   = RedBack;
                    wrapper.BorderBrush  = RedBorder;
                }

                ctrl.IsEnabled = false;
            }

            // Feedback message
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

            bool isLast            = _currentIndex >= _questions.Count - 1;
            ActionButton.Content   = isLast ? "Завершить тест" : "Следующий вопрос  →";
            ActionButton.IsEnabled = true;

            UpdateStats();
        }

        private void UpdateStats()
        {
            int answeredCount = _currentIndex + (_answered ? 1 : 0);
            int wrongCount    = answeredCount - _correctCount;
            int remaining     = _questions.Count - answeredCount;
            StatsText.Text    =
                $"✓ {_correctCount}  ✗ {wrongCount}  •  Осталось: {remaining}";
        }

        private void ShowResults()
        {
            new ResultWindow(_questions.Count, _correctCount).Show();
            Close();
        }
    }
}
