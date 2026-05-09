using System;
using System.Collections.Generic;

namespace AzureExamQuestions
{
    public class WrongAnswer
    {
        public Question Question { get; init; } = null!;
        public List<string> UserSelected { get; init; } = new();
    }

    public class QuizResult
    {
        public int Total { get; init; }
        public int Correct { get; init; }
        public QuizMode Mode { get; init; }
        public TimeSpan TimeSpent { get; init; }
        public List<WrongAnswer> WrongAnswers { get; init; } = new();

        public double Percent => Total > 0 ? (double)Correct / Total * 100 : 0;
        public int Score => (int)Math.Round(Percent * 10); // 0–1000
        public bool Passed => Score >= 700;
    }
}
