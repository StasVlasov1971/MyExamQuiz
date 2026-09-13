using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AzureExamQuestions
{
    /// <summary>
    /// Загружает описания экзаменов и наборы вопросов из JSON-файлов. Каталог
    /// задаётся в appsettings.json; если настройки нет — папка Data рядом с exe.
    ///
    /// Языковые версии одного набора лежат в файлах вида &lt;база&gt;.&lt;язык&gt;.json
    /// (az-900.rus.json и az-900.eng.json). Файлы с одинаковой базой — это один
    /// экзамен; в списке он показывается одной записью с выбором языка.
    /// </summary>
    public static class QuestionRepository
    {
        public const string ExamsFileName = "exams.json";

        /// <summary>Каталог с вопросами: из appsettings.json, иначе папка Data рядом с exe.</summary>
        public static string DataDirectory { get; } =
            AppConfig.DataDirectory ?? Path.Combine(AppContext.BaseDirectory, "Data");

        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        private static readonly Dictionary<string, List<Question>> QuestionCache = new(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, List<QuestionBundle>> BundleCache = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>Читает exams.json и возвращает описания экзаменов.</summary>
        public static List<ExamSource> LoadExamSources()
        {
            var sources = ReadJson<List<ExamSource>>(ExamsFileName);
            if (sources is null || sources.Count == 0)
                throw new InvalidDataException($"Файл \"{ExamsFileName}\" не содержит ни одного экзамена.");

            foreach (var src in sources)
            {
                if (string.IsNullOrWhiteSpace(src.Code))
                    throw new InvalidDataException($"В файле \"{ExamsFileName}\" у экзамена не указан код (code).");
                if (string.IsNullOrWhiteSpace(src.QuestionsBase) && string.IsNullOrWhiteSpace(src.QuestionsFile))
                    throw new InvalidDataException(
                        $"У экзамена \"{src.Code}\" не указан ни questionsBase, ни questionsFile.");
            }

            return sources;
        }

        /// <summary>
        /// Находит языковые версии набора. Для questionsBase = "az-900" вернёт все файлы
        /// az-900.&lt;язык&gt;.json; для одиночного questionsFile — одну запись без языка.
        /// </summary>
        public static List<QuestionLanguage> DiscoverLanguages(ExamSource src)
        {
            if (string.IsNullOrWhiteSpace(src.QuestionsBase))
                return new List<QuestionLanguage>
                {
                    new() { Code = "", DisplayName = "", FileName = src.QuestionsFile }
                };

            var baseName = src.QuestionsBase.Trim();
            var found = new List<QuestionLanguage>();

            if (Directory.Exists(DataDirectory))
            {
                foreach (var path in Directory.EnumerateFiles(DataDirectory, baseName + ".*.json"))
                {
                    var fileName = Path.GetFileName(path);

                    // Строго <база>.<язык>.json — в коде языка не должно быть точек,
                    // иначе az-900 «поглотил» бы посторонние файлы.
                    var middle = fileName[(baseName.Length + 1)..^".json".Length];
                    if (middle.Length == 0 || middle.Contains('.')) continue;

                    found.Add(new QuestionLanguage
                    {
                        Code        = middle,
                        DisplayName = QuestionLanguage.NameFor(middle),
                        FileName    = fileName
                    });
                }
            }

            if (found.Count == 0)
                throw new FileNotFoundException(
                    $"Для экзамена \"{src.Code}\" не найдено ни одного файла вида " +
                    $"\"{baseName}.<язык>.json\" в папке {DataDirectory}.");

            // Язык по умолчанию — первым, остальные по алфавиту.
            return found
                .OrderByDescending(l => string.Equals(l.Code, src.DefaultLanguage, StringComparison.OrdinalIgnoreCase))
                .ThenBy(l => l.Code, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        /// <summary>
        /// Читает все языковые версии и связывает одинаковые вопросы в <see cref="QuestionBundle"/>.
        /// Порядок вопросов задаётся первым языком из списка.
        /// </summary>
        public static List<QuestionBundle> LoadBundles(List<QuestionLanguage> languages)
        {
            if (languages.Count == 0)
                throw new InvalidDataException("Не указано ни одной языковой версии набора.");

            var cacheKey = string.Join("|", languages.Select(l => l.FileName));
            if (BundleCache.TryGetValue(cacheKey, out var cachedBundles))
                return new List<QuestionBundle>(cachedBundles);

            var bundles   = new List<QuestionBundle>();
            var byKey     = new Dictionary<string, QuestionBundle>(StringComparer.OrdinalIgnoreCase);

            foreach (var lang in languages)
            {
                foreach (var q in LoadQuestions(lang.FileName))
                {
                    var key = q.PairKey;

                    if (!byKey.TryGetValue(key, out var bundle))
                    {
                        bundle = new QuestionBundle { Key = key };
                        byKey[key] = bundle;
                        bundles.Add(bundle);
                    }
                    else
                    {
                        EnsureVersionsMatch(bundle, q, lang, key);
                    }

                    if (!bundle.ByLanguage.ContainsKey(lang.Code))
                        bundle.ByLanguage[lang.Code] = q;
                }
            }

            BundleCache[cacheKey] = bundles;
            return new List<QuestionBundle>(bundles);
        }

        /// <summary>
        /// Проверяет, что языковые версии одного вопроса не расходятся в том, что
        /// влияет на проверку ответа. Расхождение — ошибка данных: при смене языка
        /// правильный ответ не должен меняться.
        /// </summary>
        private static void EnsureVersionsMatch(QuestionBundle bundle, Question q, QuestionLanguage lang, string key)
        {
            var first = bundle.ByLanguage.Values.First();

            if (first.Options.Count != q.Options.Count)
                throw new InvalidDataException(
                    $"Вопрос {key} в файле \"{lang.FileName}\" содержит {q.Options.Count} вариантов, " +
                    $"а в другой языковой версии — {first.Options.Count}.");

            if (!string.Equals(NormalizeAnswer(first.CorrectAnswer), NormalizeAnswer(q.CorrectAnswer),
                               StringComparison.OrdinalIgnoreCase))
                throw new InvalidDataException(
                    $"Вопрос {key} в файле \"{lang.FileName}\" помечен правильным ответом " +
                    $"\"{q.CorrectAnswer}\", а в другой языковой версии — \"{first.CorrectAnswer}\".");
        }

        private static string NormalizeAnswer(string answer) =>
            string.Join(",", answer.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).OrderBy(s => s));

        /// <summary>Читает набор вопросов; результат кэшируется по имени файла.</summary>
        public static List<Question> LoadQuestions(string questionsFile)
        {
            if (!QuestionCache.TryGetValue(questionsFile, out var cached))
            {
                cached = ReadJson<List<Question>>(questionsFile)
                         ?? throw new InvalidDataException($"Файл \"{questionsFile}\" не содержит вопросов.");

                for (int i = 0; i < cached.Count; i++)
                {
                    var q = cached[i];
                    if (string.IsNullOrWhiteSpace(q.Text) || q.Options.Count == 0)
                        throw new InvalidDataException(
                            $"Вопрос #{i + 1} (Id = {q.Id}) в файле \"{questionsFile}\" заполнен некорректно: " +
                            "отсутствует текст или варианты ответа.");
                }

                QuestionCache[questionsFile] = cached;
            }

            // Копия списка, чтобы вызывающий код не мог изменить кэш.
            return new List<Question>(cached);
        }

        /// <summary>Сбрасывает кэш — вопросы будут перечитаны с диска.</summary>
        public static void ClearCache()
        {
            QuestionCache.Clear();
            BundleCache.Clear();
        }

        private static T? ReadJson<T>(string fileName)
        {
            var path = Path.Combine(DataDirectory, fileName);
            if (!File.Exists(path))
                throw new FileNotFoundException($"Не найден файл данных: {path}", path);

            try
            {
                return JsonSerializer.Deserialize<T>(File.ReadAllText(path), JsonOpts);
            }
            catch (JsonException ex)
            {
                throw new InvalidDataException($"Ошибка разбора JSON в файле \"{path}\": {ex.Message}", ex);
            }
        }
    }
}
