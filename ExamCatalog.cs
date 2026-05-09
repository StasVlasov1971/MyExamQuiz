using System.Collections.Generic;

namespace AzureExamQuestions
{
    public static class ExamCatalog
    {
        public static List<ExamDefinition> GetAll() => new()
        {
            new ExamDefinition
            {
                Code        = "AZ-900",
                Name        = "Azure Fundamentals",
                Description = "Основы облачных вычислений и Microsoft Azure",
                GetQuestions = QuestionBank.GetAllQuestions
            },
            new ExamDefinition
            {
                Code        = "AZ-104",
                Name        = "Azure Administrator",
                Description = "Администрирование и управление ресурсами Azure",
                GetQuestions = AZ104QuestionBank.GetAllQuestions
            }
        };
    }
}
