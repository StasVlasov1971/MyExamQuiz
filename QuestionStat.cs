using System;
using System.Text.Json.Serialization;

namespace AzureExamQuestions
{
    /// <summary>
    /// Статистика по одному вопросу в одном режиме. Ключ записи — <see cref="Question.PairKey"/>,
    /// поэтому русская и английская версии вопроса считаются одним вопросом.
    /// </summary>
    public class QuestionStat
    {
        /// <summary>Сколько раз вопрос попадал в статистику (по разу за прогон).</summary>
        public int Shown { get; set; }

        public int Correct { get; set; }
        public int Wrong { get; set; }

        /// <summary>Ответа не было: в режиме экзамена истёк таймер, а вариант не выбран.</summary>
        public int Unanswered { get; set; }

        public DateTime? LastSeen { get; set; }

        /// <summary>Вопрос считается отвеченным, если хотя бы раз был дан ответ — верный или нет.</summary>
        [JsonIgnore]
        public bool Answered => Correct + Wrong > 0;

        [JsonIgnore]
        public int Accuracy => Correct + Wrong > 0
            ? (int)Math.Round((double)Correct / (Correct + Wrong) * 100)
            : 0;
    }
}
