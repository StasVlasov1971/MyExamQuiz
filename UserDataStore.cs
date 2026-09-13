using System;
using System.IO;

namespace AzureExamQuestions
{
    /// <summary>
    /// Где лежат пользовательские данные: история, закладки и статистика.
    ///
    /// Ищем папку UserData, поднимаясь от каталога с исполняемым файлом вверх.
    /// Во время разработки exe лежит в bin\Debug\&lt;платформа&gt;, и папка находится
    /// в корне проекта — пересборка её не затрагивает. Если существующей папки
    /// нигде нет, она создаётся рядом с exe: так у собранного приложения данные
    /// лежат вместе с ним и переносятся копированием каталога.
    ///
    /// Данные из прежнего расположения (%APPDATA%\MyExamQuiz) переносятся сюда
    /// один раз при первом обращении, чтобы накопленная статистика не потерялась.
    /// </summary>
    internal static class UserDataStore
    {
        private const string FolderName = "UserData";

        /// <summary>Прежнее расположение: до переноса данные лежали здесь.</summary>
        private static readonly string LegacyDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyExamQuiz");

        public static string Directory { get; }

        /// <summary>На сколько уровней вверх подниматься в поисках существующей папки.
        /// Четырёх хватает, чтобы из bin\Debug\&lt;платформа&gt; дойти до корня проекта,
        /// и мало, чтобы случайно наткнуться на чужую папку выше по дереву.</summary>
        private const int SearchDepth = 4;

        static UserDataStore()
        {
            Directory = Locate();
            MigrateFromLegacy();
        }

        private static string Locate()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            for (int level = 0; level < SearchDepth && dir is not null; level++, dir = dir.Parent)
            {
                var candidate = Path.Combine(dir.FullName, FolderName);
                if (System.IO.Directory.Exists(candidate)) return candidate;
            }

            var preferred = Path.Combine(AppContext.BaseDirectory, FolderName);
            try
            {
                System.IO.Directory.CreateDirectory(preferred);
                return preferred;
            }
            catch
            {
                // Каталог приложения может быть недоступен для записи (например, Program Files).
                // Тогда остаёмся на прежнем месте, чтобы не потерять данные молча.
                return LegacyDirectory;
            }
        }

        public static string PathFor(string fileName) => Path.Combine(Directory, fileName);

        /// <summary>Переносит файлы из прежнего расположения; уже существующие не трогает.</summary>
        private static void MigrateFromLegacy()
        {
            if (string.Equals(Directory, LegacyDirectory, StringComparison.OrdinalIgnoreCase)) return;

            try
            {
                if (!System.IO.Directory.Exists(LegacyDirectory)) return;

                foreach (var source in System.IO.Directory.GetFiles(LegacyDirectory, "*.json"))
                {
                    var target = Path.Combine(Directory, Path.GetFileName(source));
                    if (File.Exists(target)) continue;

                    File.Copy(source, target);
                    try { File.Delete(source); } catch { /* копия уже на месте */ }
                }
            }
            catch { /* перенос не должен мешать запуску */ }
        }
    }
}
