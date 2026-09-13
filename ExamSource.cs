namespace AzureExamQuestions
{
    /// <summary>Описание экзамена, как оно хранится в Data/exams.json.</summary>
    public class ExamSource
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        /// <summary>
        /// Общая часть имени языковых файлов: для "az-900" будут найдены
        /// az-900.rus.json, az-900.eng.json и любые другие az-900.&lt;язык&gt;.json.
        /// </summary>
        public string QuestionsBase { get; set; } = "";

        /// <summary>
        /// Имя единственного файла с вопросами внутри папки Data — для наборов,
        /// у которых нет языковых версий. Используется, если не задан QuestionsBase.
        /// </summary>
        public string QuestionsFile { get; set; } = "";

        /// <summary>Код языка, выбранный по умолчанию. Необязательное поле.</summary>
        public string DefaultLanguage { get; set; } = "";
    }
}
