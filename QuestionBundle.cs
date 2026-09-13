using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureExamQuestions
{
    /// <summary>
    /// Один вопрос во всех доступных языковых версиях. Версии связаны кодом
    /// <see cref="Question.Uid"/>; сам вопрос — его номер, сложность, буквы вариантов
    /// и правильный ответ — во всех версиях одинаков, различается только текст.
    /// </summary>
    public class QuestionBundle
    {
        public string Key { get; init; } = "";

        /// <summary>Код языка -> вопрос. Гарантированно содержит хотя бы одну запись.</summary>
        public Dictionary<string, Question> ByLanguage { get; init; } = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>Вопрос на нужном языке; если версии нет — любая доступная.</summary>
        public Question Get(string? language)
        {
            if (!string.IsNullOrWhiteSpace(language) &&
                ByLanguage.TryGetValue(language, out var q))
                return q;

            return ByLanguage.Values.First();
        }

        /// <summary>Есть ли версия на этом языке.</summary>
        public bool Has(string language) => ByLanguage.ContainsKey(language);

        /// <summary>Обёртка вокруг одного вопроса — когда языковых версий нет.</summary>
        public static QuestionBundle Single(Question question, string language = "")
        {
            var bundle = new QuestionBundle { Key = question.PairKey };
            bundle.ByLanguage[language] = question;
            return bundle;
        }

        /// <summary>Номер вопроса и сложность одинаковы во всех версиях.</summary>
        public int Id => ByLanguage.Values.First().Id;

        public int Difficulty => ByLanguage.Values.First().Difficulty;
    }
}
