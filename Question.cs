using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureExamQuestions
{
    public class Question
    {
        public int Id { get; set; }

        /// <summary>
        /// Постоянный код вопроса (5 символов), одинаковый во всех языковых версиях —
        /// именно по нему русский и английский варианты считаются одним вопросом.
        /// Необязательное поле: если его нет, версии сопоставляются по <see cref="Id"/>.
        /// </summary>
        public string? Uid { get; set; }

        /// <summary>Ключ, по которому вопрос сопоставляется между языками.</summary>
        public string PairKey => string.IsNullOrWhiteSpace(Uid) ? $"#{Id}" : Uid.Trim();

        public string Text { get; set; } = "";
        public List<string> Options { get; set; } = new();
        public string CorrectAnswer { get; set; } = "";
        public string CorrectAnswerText { get; set; } = "";
        public int Difficulty { get; set; }

        /// <summary>
        /// Почему правильный ответ верен. Необязательное поле: если его нет в JSON,
        /// пояснение просто не показывается.
        /// </summary>
        public string? Explanation { get; set; }

        /// <summary>
        /// Кратко — почему неверны все остальные варианты. Вторая часть пояснения.
        /// Необязательное поле: может отсутствовать или быть пустым.
        /// </summary>
        public string? WhyOthersWrong { get; set; }

        /// <summary>
        /// Почему неверен конкретный вариант: буква варианта -> текст.
        /// Необязательное поле, может быть заполнено частично.
        /// </summary>
        public Dictionary<string, string>? WhyWrong { get; set; }

        public bool HasExplanation => !string.IsNullOrWhiteSpace(Explanation);

        public bool HasWhyOthersWrong => !string.IsNullOrWhiteSpace(WhyOthersWrong);

        /// <summary>Является ли буква (одной из) букв правильного ответа.</summary>
        public bool IsCorrectLetter(string letter) =>
            !string.IsNullOrWhiteSpace(letter) &&
            CorrectAnswer.Split(',')
                .Any(l => string.Equals(l.Trim(), letter.Trim(), StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Пояснение, почему выбранный вариант неверен. Возвращает null, если пояснения нет,
        /// оно пустое или буква относится к правильному ответу — так ошибка в данных
        /// не превращается в противоречивую подсказку.
        /// </summary>
        public string? GetWhyWrong(string letter)
        {
            if (WhyWrong is null || string.IsNullOrWhiteSpace(letter)) return null;
            if (IsCorrectLetter(letter)) return null;

            foreach (var pair in WhyWrong)
            {
                if (!string.Equals(pair.Key?.Trim(), letter.Trim(), StringComparison.OrdinalIgnoreCase))
                    continue;
                return string.IsNullOrWhiteSpace(pair.Value) ? null : pair.Value.Trim();
            }
            return null;
        }
    }
}
