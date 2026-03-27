using QuizGenerator.Models;

namespace QuizGenerator.Services
{
    public interface IQuestionBankService
    {
        List<Question> GetAllQuestions();
        List<Question> GetRandomQuestions(int count, string? category = null, Difficulty? difficulty = null);
        List<Question> GetQuestionsByCategory(string category);
        List<Question> GetQuestionsByDifficulty(Difficulty difficulty);
        List<string> GetCategories();
        int GetTotalQuestionCount();
        int GetCategoryCount();
    }
}