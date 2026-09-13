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
    /// У каждого набора свой файл stats_&lt;набор&gt;.json рядом с history.json и
    /// bookmarks.json: так при чтении поднимается только нужный набор, а не всё сразу.
    /// Внутри файла — режим, затем ключ вопроса (uid), затем счётчики по языкам.
    /// </summary>
    internal static class StatsService
    {
        /// <summary>Счётчики одного набора: обучение и экзамен раздельно.</summary>
        public class ExamStats
        {
            public Dictionary<string, QuestionStat> Study { get; set; } = New();
            public Dictionary<string, QuestionStat> Exam { get; set; } = New();

            public Dictionary<string, QuestionStat> For(QuizMode mode) =>
                mode == QuizMode.Exam ? Exam : Study;

            private static Dictionary<string, QuestionStat> New() =>
                new(StringComparer.OrdinalIgnoreCase);
        }

        private static readonly string Directory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyExamQuiz");

        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        /// <summary>Уже прочитанные наборы; каждый поднимается с диска один раз за запуск.</summary>
        private static readonly Dictionary<string, ExamStats> Cache =
            new(StringComparer.OrdinalIgnoreCase);

        private static string FileFor(string examKey)
        {
            var safe = new string(examKey.Trim()
                .Select(c => Path.GetInvalidFileNameChars().Contains(c) ? '_' : c)
                .ToArray());
            return Path.Combine(Directory, $"stats_{safe}.json");
        }

        private static ExamStats Load(string examKey)
        {
            if (Cache.TryGetValue(examKey, out var cached)) return cached;

            ExamStats stats;
            try
            {
                var path = FileFor(examKey);
                stats = File.Exists(path)
                    ? JsonSerializer.Deserialize<ExamStats>(File.ReadAllText(path), JsonOpts) ?? new ExamStats()
                    : new ExamStats();
            }
            catch { stats = new ExamStats(); }

            Cache[examKey] = stats;
            return stats;
        }

        private static void Persist(string examKey)
        {
            try
            {
                System.IO.Directory.CreateDirectory(Directory);
                File.WriteAllText(FileFor(examKey), JsonSerializer.Serialize(Load(examKey), JsonOpts));
            }
            catch { /* потеря статистики не должна ломать тест */ }
        }

        /// <summary>
        /// Записывает исход по вопросу. <paramref name="correct"/>: true — верно, false — неверно,
        /// null — ответа не было (в экзамене истёк таймер при пустом выборе).
        /// </summary>
        public static void Record(string examKey, QuizMode mode, string questionKey,
                                  string? language, bool? correct)
        {
            if (string.IsNullOrWhiteSpace(examKey) || string.IsNullOrWhiteSpace(questionKey))
                return;

            var bucket = Load(examKey).For(mode);
            if (!bucket.TryGetValue(questionKey, out var stat))
                bucket[questionKey] = stat = new QuestionStat();

            var lang = stat.For(language);
            lang.Shown++;
            if (correct is true) lang.Correct++;
            else if (correct is false) lang.Wrong++;
            else lang.Unanswered++;
            lang.LastSeen = DateTime.Now;

            Persist(examKey);
        }

        public static QuestionStat? Get(string examKey, QuizMode mode, string questionKey) =>
            !string.IsNullOrWhiteSpace(examKey)
            && Load(examKey).For(mode).TryGetValue(questionKey, out var stat)
                ? stat
                : null;

        /// <summary>Отвечали ли на этот вопрос в этом режиме хотя бы раз, на любом языке.</summary>
        public static bool IsAnswered(string examKey, QuizMode mode, string questionKey) =>
            Get(examKey, mode, questionKey)?.Answered == true;

        /// <summary>Сколько вопросов набора уже отвечено в этом режиме.</summary>
        public static int AnsweredCount(string examKey, QuizMode mode, IEnumerable<string> questionKeys) =>
            questionKeys.Count(k => IsAnswered(examKey, mode, k));

        /// <summary>Сбрасывает статистику набора.</summary>
        public static void Clear(string examKey)
        {
            if (string.IsNullOrWhiteSpace(examKey)) return;
            Cache[examKey] = new ExamStats();
            try
            {
                var path = FileFor(examKey);
                if (File.Exists(path)) File.Delete(path);
            }
            catch { /* ignore */ }
        }
    }
}
