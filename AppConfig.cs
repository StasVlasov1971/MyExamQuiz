using System;
using System.IO;
using System.Text.Json;

namespace AzureExamQuestions
{
    /// <summary>
    /// Настройки приложения из appsettings.json: где лежат вопросы и где —
    /// пользовательские данные. Благодаря им каталоги не нужно копировать
    /// в выходной каталог сборки.
    ///
    /// Файл ищется рядом с MyExamQuiz.exe, а если там его нет — вверх по дереву,
    /// так что во время разработки он может лежать в корне проекта. Пути можно
    /// писать абсолютными или относительно самого файла настроек. Если файла нет
    /// или путь не задан, используется прежнее поведение.
    /// </summary>
    internal static class AppConfig
    {
        public const string FileName = "appsettings.json";

        private const int SearchDepth = 4;

        private sealed class Settings
        {
            public string? DataDirectory { get; set; }
            public string? UserDataDirectory { get; set; }
        }

        /// <summary>Найденный файл настроек или null, если его нет.</summary>
        public static string? ConfigPath { get; }

        /// <summary>Каталог с вопросами из настроек; null — значит, настройка не задана.</summary>
        public static string? DataDirectory { get; }

        /// <summary>Каталог пользовательских данных из настроек; null — не задан.</summary>
        public static string? UserDataDirectory { get; }

        /// <summary>
        /// Почему файл настроек не прочитался. Если он есть, но испорчен, приложение
        /// продолжит работать на путях по умолчанию — и об этом нужно сказать вслух,
        /// иначе опечатка в пути выглядит как «настройки не работают».
        /// </summary>
        public static string? Error { get; }

        static AppConfig()
        {
            ConfigPath = Locate();
            if (ConfigPath is null) return;

            try
            {
                var settings = JsonSerializer.Deserialize<Settings>(
                    File.ReadAllText(ConfigPath),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var baseDir = Path.GetDirectoryName(ConfigPath)!;
                DataDirectory = Resolve(settings?.DataDirectory, baseDir);
                UserDataDirectory = Resolve(settings?.UserDataDirectory, baseDir);
            }
            catch (Exception ex)
            {
                // Испорченный файл настроек не должен мешать запуску, но и молчать
                // об этом нельзя: приложение работает с путями по умолчанию.
                Error = "Не удалось прочитать файл настроек:" + Environment.NewLine
                      + ConfigPath + Environment.NewLine + Environment.NewLine
                      + ex.Message + Environment.NewLine + Environment.NewLine
                      + "Используются пути по умолчанию.";
            }
        }

        private static string? Locate()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            for (int level = 0; level < SearchDepth && dir is not null; level++, dir = dir.Parent)
            {
                var candidate = Path.Combine(dir.FullName, FileName);
                if (File.Exists(candidate)) return candidate;
            }
            return null;
        }

        /// <summary>Относительные пути отсчитываются от папки с файлом настроек.</summary>
        private static string? Resolve(string? path, string baseDir) =>
            string.IsNullOrWhiteSpace(path)
                ? null
                : Path.GetFullPath(Path.Combine(baseDir, path.Trim()));
    }
}
