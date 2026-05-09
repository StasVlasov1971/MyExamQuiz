using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AzureExamQuestions
{
    internal static class BookmarkService
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MyExamQuiz", "bookmarks.json");

        private static HashSet<int>? _cache;

        private static HashSet<int> Cache => _cache ??= LoadFromDisk();

        private static HashSet<int> LoadFromDisk()
        {
            try
            {
                if (!File.Exists(FilePath)) return new();
                var ids = JsonSerializer.Deserialize<List<int>>(File.ReadAllText(FilePath));
                return ids is null ? new() : new HashSet<int>(ids);
            }
            catch { return new(); }
        }

        private static void Persist()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
                File.WriteAllText(FilePath, JsonSerializer.Serialize(new List<int>(Cache)));
            }
            catch { }
        }

        public static bool IsBookmarked(int questionId) => Cache.Contains(questionId);

        public static void Toggle(int questionId)
        {
            if (!Cache.Remove(questionId))
                Cache.Add(questionId);
            Persist();
        }

        public static int Count => Cache.Count;
    }
}
