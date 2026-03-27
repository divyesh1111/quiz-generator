namespace QuizGenerator.Models
{
    public class QuestionResult
    {
        public Question Question { get; set; } = new();
        public int SelectedAnswerIndex { get; set; }
        public bool IsCorrect { get; set; }
    }
}