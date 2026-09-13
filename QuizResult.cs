using System;
using System.Collections.Generic;

namespace AzureExamQuestions
{
    public class WrongAnswer
    {
        public Question Question { get; init; } = null!;
        public List<string> UserSelected { get; init; } = new();

        /// <summary>
        /// Все языковые версии вопроса — чтобы разбор ошибок показать на том языке,
        /// на котором тест был завершён. Может быть null для одноязычного набора.
        /// </summary>
        public QuestionBundle? Bundle { get; init; }
    }

    public class QuizResult
    {
        public int Total { get; init; }
        public int Correct { get; init; }
        public QuizMode Mode { get; init; }
        public TimeSpan TimeSpent { get; init; }
        public List<WrongAnswer> WrongAnswers { get; init; } = new();
        public string ExamTitle { get; init; } = "";

        /// <summary>Ключ набора для статистики.</summary>
        public string ExamKey { get; init; } = "";
        public int TimerSeconds { get; init; } = 90;

        /// <summary>Языковые версии набора и выбранный язык — для повтора ошибок.</summary>
        public List<QuestionLanguage> Languages { get; init; } = new();
        public string Language { get; init; } = "";

        public double Percent => Total > 0 ? (double)Correct / Total * 100 : 0;
        public int Score => (int)Math.Round(Percent * 10); // 0–1000
        public bool Passed => Score >= 700;
    }
}
