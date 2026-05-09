using System;

namespace AzureExamQuestions
{
    public class HistoryRecord
    {
        public DateTime Date { get; set; }
        public string ExamTitle { get; set; } = "";
        public string Mode { get; set; } = "";   // "Обучение" / "Экзамен"
        public int Total { get; set; }
        public int Correct { get; set; }
        public int Score { get; set; }           // 0–1000
        public bool Passed { get; set; }
        public string TimeSpent { get; set; } = "";

        public double Percent => Total > 0 ? (double)Correct / Total * 100 : 0;
    }
}
