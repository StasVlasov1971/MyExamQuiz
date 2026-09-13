using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AzureExamQuestions
{
    /// <summary>Счётчики по одной языковой версии вопроса.</summary>
    public class LanguageStat
    {
        /// <summary>Сколько раз вопрос попал в статистику (по разу за прогон).</summary>
        public int Shown { get; set; }

        public int Correct { get; set; }
        public int Wrong { get; set; }

        /// <summary>Ответа не было: в экзамене истёк таймер, а вариант не выбран.</summary>
        public int Unanswered { get; set; }

        public DateTime? LastSeen { get; set; }
    }

    /// <summary>
    /// Статистика по одному вопросу в одном режиме. Ключ записи — <see cref="Question.PairKey"/>,
    /// то есть uid: русская и английская версии — это один и тот же вопрос. При этом счётчики
    /// хранятся по языкам, поэтому видно и общий итог, и вклад каждой версии.
    /// </summary>
    public class QuestionStat
    {
        /// <summary>Код языка -> счётчики. Для одноязычного набора ключ — <see cref="NoLanguage"/>.</summary>
        public Dictionary<string, LanguageStat> ByLanguage { get; set; } =
            new(StringComparer.OrdinalIgnoreCase);

        /// <summary>Метка для набора без языковых версий.</summary>
        public const string NoLanguage = "-";

        public static string LanguageKey(string? language) =>
            string.IsNullOrWhiteSpace(language) ? NoLanguage : language.Trim();

        public LanguageStat For(string? language)
        {
            var key = LanguageKey(language);
            if (!ByLanguage.TryGetValue(key, out var stat))
                ByLanguage[key] = stat = new LanguageStat();
            return stat;
        }

        // ── Итоги по всем языкам: вопрос считается одним ──────────────────────

        [JsonIgnore] public int Shown => ByLanguage.Values.Sum(l => l.Shown);
        [JsonIgnore] public int Correct => ByLanguage.Values.Sum(l => l.Correct);
        [JsonIgnore] public int Wrong => ByLanguage.Values.Sum(l => l.Wrong);
        [JsonIgnore] public int Unanswered => ByLanguage.Values.Sum(l => l.Unanswered);

        [JsonIgnore]
        public DateTime? LastSeen => ByLanguage.Values
            .Where(l => l.LastSeen.HasValue)
            .Select(l => l.LastSeen!.Value)
            .DefaultIfEmpty()
            .Max() is var max && max == default ? null : max;

        /// <summary>Отвечен, если хотя бы раз был дан ответ — верный или нет, на любом языке.</summary>
        [JsonIgnore] public bool Answered => Correct + Wrong > 0;

        [JsonIgnore]
        public int Accuracy => Correct + Wrong > 0
            ? (int)Math.Round((double)Correct / (Correct + Wrong) * 100)
            : 0;
    }
}
