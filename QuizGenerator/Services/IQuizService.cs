using QuizGenerator.Models;

namespace QuizGenerator.Services
{
    public interface IQuizService
    {
        QuizSession StartNewQuiz(int questionCount = 10, int timeLimitSeconds = 600,
            string? category = null, Difficulty? difficulty = null);
        Question? GetCurrentQuestion();
        bool SubmitAnswer(int selectedIndex);
        bool NextQuestion();
        void DecrementTimer();
        int GetTimeRemaining();
        void EndQuiz();
        bool IsQuizComplete();
        QuizSession? GetCurrentSession();
        QuizResult GetResults();
        bool HasAnsweredCurrentQuestion();
        int GetSelectedAnswerForCurrentQuestion();
    }
}