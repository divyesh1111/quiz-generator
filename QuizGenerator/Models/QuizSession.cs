namespace QuizGenerator.Models
{
    public class QuizSession
    {
        public Guid SessionId { get; set; }
        public List<Question> Questions { get; set; } = new();
        public int CurrentQuestionIndex { get; set; }
        public int Score { get; set; }
        public int TimeLimitSeconds { get; set; }
        public int TimeRemainingSeconds { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Dictionary<int, int> SelectedAnswers { get; set; } = new();
    }
}