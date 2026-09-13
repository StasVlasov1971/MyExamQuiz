using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureExamQuestions
{
    /// <summary>Отбор вопросов в тест: равновероятный и с учётом накопленной статистики.</summary>
    internal static class QuestionPicker
    {
        /// <summary>
        /// Вес вопроса при отборе «реже показывать выученные»: чем больше верных ответов,
        /// тем меньше вес. Вопрос, отвеченный верно N раз, выпадает в N+1 раз реже нового.
        /// Вес всегда больше нуля, поэтому недостижимых вопросов не появляется.
        /// </summary>
        public static double Weight(int correctAnswers) =>
            1.0 / (1 + Math.Max(0, correctAnswers));

        /// <summary>Равновероятный отбор без повторов.</summary>
        public static List<QuestionBundle> PickRandom(
            IEnumerable<QuestionBundle> pool, int count, Random rnd) =>
            pool.OrderBy(_ => rnd.Next()).Take(count).ToList();

        /// <summary>
        /// Отбор без повторов с весами по алгоритму Эфраимидиса — Спиракиса: для каждого
        /// вопроса берётся ключ u^(1/вес), и выбираются наибольшие. Это даёт в точности
        /// взвешенную выборку без возвращения, а не приближение.
        /// </summary>
        public static List<QuestionBundle> PickWeighted(
            IEnumerable<QuestionBundle> pool, int count,
            Func<QuestionBundle, int> correctAnswers, Random rnd) =>
            pool.Select(b =>
                {
                    double w = Weight(correctAnswers(b));
                    double u = rnd.NextDouble();
                    if (u <= 0) u = double.Epsilon;
                    return (bundle: b, key: Math.Pow(u, 1.0 / w));
                })
                .OrderByDescending(x => x.key)
                .Take(count)
                .Select(x => x.bundle)
                .ToList();
    }
}
