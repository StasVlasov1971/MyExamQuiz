namespace AzureExamQuestions
{
    internal static class QuizHelper
    {
        public static string ExtractLetter(string option)
        {
            int idx = option.IndexOf(')');
            return idx > 0 ? option[..idx].Trim() : option[0].ToString();
        }
    }
}
