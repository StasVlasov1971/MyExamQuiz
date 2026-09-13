using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AzureExamQuestions
{
    internal static class HistoryService
    {
        private static readonly string FilePath = UserDataStore.PathFor("history.json");

        private static readonly JsonSerializerOptions JsonOpts = new() { WriteIndented = true };

        public static List<HistoryRecord> Load()
        {
            try
            {
                if (!File.Exists(FilePath)) return new();
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<HistoryRecord>>(json, JsonOpts) ?? new();
            }
            catch
            {
                return new();
            }
        }

        public static void Append(HistoryRecord record)
        {
            var list = Load();
            list.Add(record);
            Save(list);
        }

        public static void Clear()
        {
            Save(new());
        }

        private static void Save(List<HistoryRecord> list)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
                File.WriteAllText(FilePath, JsonSerializer.Serialize(list, JsonOpts));
            }
            catch { /* ignore write failures */ }
        }
    }
}
