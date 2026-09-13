using System;
using System.IO;

namespace AzureExamQuestions
{
    /// <summary>
    /// Где лежат пользовательские данные: история, закладки и статистика.
    /// Это подпапка UserData рядом с исполняемым файлом — всё приложение вместе
    /// со своими данными живёт в одном каталоге и переносится копированием.
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

        static UserDataStore()
        {
            var preferred = Path.Combine(AppContext.BaseDirectory, FolderName);
            try
            {
                System.IO.Directory.CreateDirectory(preferred);
                Directory = preferred;
            }
            catch
            {
                // Каталог приложения может быть недоступен для записи (например, Program Files).
                // Тогда остаёмся на прежнем месте, чтобы не потерять данные молча.
                Directory = LegacyDirectory;
            }

            MigrateFromLegacy();
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
