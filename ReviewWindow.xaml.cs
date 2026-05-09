using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AzureExamQuestions
{
    public partial class ReviewWindow : Window
    {
        private readonly QuizResult _result;

        public ReviewWindow(QuizResult result)
        {
            InitializeComponent();
            _result = result;

            int count = result.WrongAnswers.Count;
            SubtitleText.Text = $"Допущено ошибок: {count} из {result.Total}";

            ErrorsList.ItemsSource = result.WrongAnswers
                .Select((wa, i) => BuildViewModel(wa, i + 1))
                .ToList();
        }

        private static ReviewItemViewModel BuildViewModel(WrongAnswer wa, int index)
        {
            var q = wa.Question;
            string stars = new string('★', q.Difficulty) + new string('☆', 5 - q.Difficulty);

            string userText = wa.UserSelected.Count == 0
                ? "(нет ответа)"
                : string.Join(", ", wa.UserSelected.Select(letter =>
                    q.Options.FirstOrDefault(o => QuizHelper.ExtractLetter(o) == letter) ?? letter));

            string correctText = q.CorrectAnswer
                .Split(',')
                .Select(l => l.Trim())
                .Select(letter => q.Options.FirstOrDefault(o => QuizHelper.ExtractLetter(o) == letter) ?? letter)
                .Aggregate((a, b) => $"{a}\n{b}");

            return new ReviewItemViewModel
            {
                Label = $"Вопрос {index}  ·  ID {q.Id}",
                Stars = stars,
                QuestionText = q.Text,
                UserAnswerText = userText,
                CorrectAnswerText = correctText
            };
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }

    internal class ReviewItemViewModel
    {
        public string Label { get; set; } = "";
        public string Stars { get; set; } = "";
        public string QuestionText { get; set; } = "";
        public string UserAnswerText { get; set; } = "";
        public string CorrectAnswerText { get; set; } = "";
    }
}
