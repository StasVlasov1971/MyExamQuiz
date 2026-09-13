using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AzureExamQuestions
{
    /// <summary>
    /// Статистика ответов по каждому вопросу, отдельно по наборам и по режимам.
    ///
    /// Файл stats.json лежит рядом с history.json и bookmarks.json и устроен так:
    /// набор -> режим -> ключ вопроса -> счётчики. Ключ вопроса — uid, поэтому
    /// языковые версии одного вопроса делят одну запись, а наборы не смешиваются.
    /// </summary>
    internal static class StatsService
    {
        /// <summary>Счётчики одного набора: режим обучения и режим экзамена раздельно.</summary>
        public class ExamStats
        {
            public Dictionary<string, QuestionStat> Study { get; set; } = New();
            public Dictionary<string, QuestionStat> Exam { get; set; } = New();

            public Dictionary<string, QuestionStat> For(QuizMode mode) =>
                mode == QuizMode.Exam ? Exam : Study;

            private static Dictionary<string, QuestionStat> New() =>
                new(StringComparer.OrdinalIgnoreCase);
        }

        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MyExamQuiz", "stats.json");

        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        private static Dictionary<string, ExamStats>? _cache;

        private static Dictionary<string, ExamStats> Cache => _cache ??= LoadFromDisk();

        private static Dictionary<string, ExamStats> LoadFromDisk()
        {
            try
            {
                if (!File.Exists(FilePath)) return Empty();
                var data = JsonSerializer.Deserialize<Dictionary<string, ExamStats>>(
                    File.ReadAllText(FilePath), JsonOpts);
                return data is null
                    ? Empty()
                    : new Dictionary<string, ExamStats>(data, StringComparer.OrdinalIgnoreCase);
            }
            catch { return Empty(); }
        }

        private static Dictionary<string, ExamStats> Empty() =>
            new(StringComparer.OrdinalIgnoreCase);

        private static void Persist()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
                File.WriteAllText(FilePath, JsonSerializer.Serialize(Cache, JsonOpts));
            }
            catch { /* потеря статистики не должна ломать тест */ }
        }

        private static Dictionary<string, QuestionStat> Bucket(string examKey, QuizMode mode)
        {
            if (!Cache.TryGetValue(examKey, out var stats))
                Cache[examKey] = stats = new ExamStats();
            return stats.For(mode);
        }

        /// <summary>
        /// Записывает исход по вопросу. <paramref name="correct"/>: true — верно, false — неверно,
        /// null — ответа не было (в экзамене истёк таймер при пустом выборе).
        /// </summary>
        public static void Record(string examKey, QuizMode mode, string questionKey, bool? correct)
        {
            if (string.IsNullOrWhiteSpace(examKey) || string.IsNullOrWhiteSpace(questionKey))
                return;

            var bucket = Bucket(examKey, mode);
            if (!bucket.TryGetValue(questionKey, out var stat))
                bucket[questionKey] = stat = new QuestionStat();

            stat.Shown++;
            if (correct is true) stat.Correct++;
            else if (correct is false) stat.Wrong++;
            else stat.Unanswered++;
            stat.LastSeen = DateTime.Now;

            Persist();
        }

        public static QuestionStat? Get(string examKey, QuizMode mode, string questionKey) =>
            !string.IsNullOrWhiteSpace(examKey)
            && Cache.TryGetValue(examKey, out var stats)
            && stats.For(mode).TryGetValue(questionKey, out var stat)
                ? stat
                : null;

        /// <summary>Отвечали ли на этот вопрос в этом режиме хотя бы раз.</summary>
        public static bool IsAnswered(string examKey, QuizMode mode, string questionKey) =>
            Get(examKey, mode, questionKey)?.Answered == true;

        /// <summary>Сколько вопросов набора уже отвечено в этом режиме.</summary>
        public static int AnsweredCount(string examKey, QuizMode mode, IEnumerable<string> questionKeys) =>
            questionKeys.Count(k => IsAnswered(examKey, mode, k));

        /// <summary>Сбрасывает статистику: всего набора или всех наборов сразу.</summary>
        public static void Clear(string? examKey = null)
        {
            if (examKey is null) Cache.Clear();
            else Cache.Remove(examKey);
            Persist();
        }
    }
}
