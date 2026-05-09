using System;
using System.Collections.Generic;

namespace AzureExamQuestions
{
    public class ExamDefinition
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Func<List<Question>> GetQuestions { get; set; } = () => new();

        public string DisplayTitle => $"{Code} — {Name}";
    }
}
