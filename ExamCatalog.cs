using System.Collections.Generic;
using System.Linq;

namespace AzureExamQuestions
{
    public static class ExamCatalog
    {
        /// <summary>
        /// Строит список экзаменов по данным из Data/exams.json. Языковые версии одного
        /// набора объединяются в одну запись. Вопросы читаются лениво и кэшируются
        /// в <see cref="QuestionRepository"/>.
        /// </summary>
        public static List<ExamDefinition> GetAll() =>
            QuestionRepository.LoadExamSources()
                .Select(src =>
                {
                    var languages = QuestionRepository.DiscoverLanguages(src);
                    return new ExamDefinition
                    {
                        Code            = src.Code,
                        Name            = src.Name,
                        Description     = src.Description,
                        Languages       = languages,
                        DefaultLanguage = languages.First().Code,
                        GetBundles      = () => QuestionRepository.LoadBundles(languages)
                    };
                })
                .ToList();
    }
}
