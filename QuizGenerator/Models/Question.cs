namespace QuizGenerator.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public int CorrectAnswerIndex { get; set; }
        public string Category { get; set; } = string.Empty;
        public Difficulty DifficultyLevel { get; set; }
    }
}