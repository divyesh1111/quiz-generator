namespace QuizGenerator.Models
{
    public class QuizResult
    {
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public double Percentage { get; set; }
        public List<QuestionResult> QuestionResults { get; set; } = new();
        public string PerformanceMessage { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
    }
}