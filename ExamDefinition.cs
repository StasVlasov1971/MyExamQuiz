using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureExamQuestions
{
    public class ExamDefinition
    {
        /// <summary>Ключ набора для статистики: общая часть имени файлов, например "az-900".</summary>
        public string Key { get; set; } = "";

        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        /// <summary>Языковые версии набора. Для одноязычного набора — один элемент.</summary>
        public List<QuestionLanguage> Languages { get; set; } = new();

        /// <summary>Язык, выбранный при открытии окна настройки.</summary>
        public string DefaultLanguage { get; set; } = "";

        /// <summary>Вопросы во всех языковых версиях. Читаются лениво и кэшируются.</summary>
        public Func<List<QuestionBundle>> GetBundles { get; set; } = () => new();

        public bool IsMultiLanguage => Languages.Count > 1;

        public string DisplayTitle => $"{Code} — {Name}";

        /// <summary>Язык по умолчанию, если он доступен; иначе первый из списка.</summary>
        public QuestionLanguage? PreferredLanguage =>
            Languages.FirstOrDefault(l => string.Equals(l.Code, DefaultLanguage, StringComparison.OrdinalIgnoreCase))
            ?? Languages.FirstOrDefault();
    }
}
