using System;
using System.Collections.Generic;

namespace AzureExamQuestions
{
    /// <summary>
    /// Язык набора вопросов. Код языка берётся из имени файла:
    /// <c>az-900.rus.json</c> → <c>rus</c>, <c>az-900.eng.json</c> → <c>eng</c>.
    /// </summary>
    public class QuestionLanguage
    {
        public string Code { get; init; } = "";
        public string DisplayName { get; init; } = "";

        /// <summary>Файл с вопросами внутри папки Data.</summary>
        public string FileName { get; init; } = "";

        public override string ToString() => DisplayName;

        private static readonly Dictionary<string, string> KnownNames = new(StringComparer.OrdinalIgnoreCase)
        {
            ["rus"] = "Русский",
            ["ru"]  = "Русский",
            ["eng"] = "English",
            ["en"]  = "English",
            ["deu"] = "Deutsch",
            ["fra"] = "Français",
            ["esp"] = "Español"
        };

        /// <summary>Человекочитаемое имя языка; для незнакомого кода — сам код заглавными.</summary>
        public static string NameFor(string code) =>
            KnownNames.TryGetValue(code, out var name) ? name : code.ToUpperInvariant();
    }
}
