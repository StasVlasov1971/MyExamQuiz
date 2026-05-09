using System.Collections.Generic;

namespace AzureExamQuestions
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public List<string> Options { get; set; } = new();
        public string CorrectAnswer { get; set; } = "";
        public string CorrectAnswerText { get; set; } = "";
        public int Difficulty { get; set; }
    }
}
