using QuizGenerator.Models;

namespace QuizGenerator.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionBankService _questionBank;
        private QuizSession? _currentSession;

        public QuizService(IQuestionBankService questionBank)
        {
            _questionBank = questionBank;
        }

        public QuizSession StartNewQuiz(int questionCount = 10, int timeLimitSeconds = 600,
            string? category = null, Difficulty? difficulty = null)
        {
            var questions = _questionBank.GetRandomQuestions(questionCount, category, difficulty);

            _currentSession = new QuizSession
            {
                SessionId = Guid.NewGuid(),
                Questions = questions,
                CurrentQuestionIndex = 0,
                Score = 0,
                TimeLimitSeconds = timeLimitSeconds,
                TimeRemainingSeconds = timeLimitSeconds,
                IsCompleted = false,
                StartTime = DateTime.Now,
                EndTime = null,
                SelectedAnswers = new Dictionary<int, int>()
            };

            return _currentSession;
        }

        public Question? GetCurrentQuestion()
        {
            if (_currentSession == null || _currentSession.IsCompleted)
                return null;

            if (_currentSession.CurrentQuestionIndex >= _currentSession.Questions.Count)
                return null;

            return _currentSession.Questions[_currentSession.CurrentQuestionIndex];
        }

        public bool SubmitAnswer(int selectedIndex)
        {
            if (_currentSession == null || _currentSession.IsCompleted)
                return false;

            var currentQuestion = GetCurrentQuestion();
            if (currentQuestion == null)
                return false;

            // Store the selected answer
            _currentSession.SelectedAnswers[_currentSession.CurrentQuestionIndex] = selectedIndex;

            // Check if answer is correct
            bool isCorrect = selectedIndex == currentQuestion.CorrectAnswerIndex;
            if (isCorrect)
            {
                _currentSession.Score++;
            }

            return isCorrect;
        }

        public bool NextQuestion()
        {
            if (_currentSession == null || _currentSession.IsCompleted)
                return false;

            if (_currentSession.CurrentQuestionIndex < _currentSession.Questions.Count - 1)
            {
                _currentSession.CurrentQuestionIndex++;
                return true;
            }

            return false;
        }

        public void DecrementTimer()
        {
            if (_currentSession != null && !_currentSession.IsCompleted)
            {
                if (_currentSession.TimeRemainingSeconds > 0)
                {
                    _currentSession.TimeRemainingSeconds--;
                }

                if (_currentSession.TimeRemainingSeconds <= 0)
                {
                    EndQuiz();
                }
            }
        }

        public int GetTimeRemaining()
        {
            return _currentSession?.TimeRemainingSeconds ?? 0;
        }

        public void EndQuiz()
        {
            if (_currentSession != null && !_currentSession.IsCompleted)
            {
                _currentSession.IsCompleted = true;
                _currentSession.EndTime = DateTime.Now;
            }
        }

        public bool IsQuizComplete()
        {
            return _currentSession?.IsCompleted ?? true;
        }

        public QuizSession? GetCurrentSession()
        {
            return _currentSession;
        }

        public bool HasAnsweredCurrentQuestion()
        {
            if (_currentSession == null) return false;
            return _currentSession.SelectedAnswers.ContainsKey(_currentSession.CurrentQuestionIndex);
        }

        public int GetSelectedAnswerForCurrentQuestion()
        {
            if (_currentSession == null) return -1;
            return _currentSession.SelectedAnswers.TryGetValue(
                _currentSession.CurrentQuestionIndex, out int selected) ? selected : -1;
        }

        public QuizResult GetResults()
        {
            if (_currentSession == null)
            {
                return new QuizResult
                {
                    PerformanceMessage = "No quiz data available.",
                    Grade = "N/A"
                };
            }

            // Build question results
            var questionResults = new List<QuestionResult>();
            for (int i = 0; i < _currentSession.Questions.Count; i++)
            {
                var question = _currentSession.Questions[i];
                var selectedIndex = _currentSession.SelectedAnswers.TryGetValue(i, out int sel) ? sel : -1;

                questionResults.Add(new QuestionResult
                {
                    Question = question,
                    SelectedAnswerIndex = selectedIndex,
                    IsCorrect = selectedIndex == question.CorrectAnswerIndex
                });
            }

            // Calculate time taken
            var timeTaken = _currentSession.EndTime.HasValue
                ? _currentSession.EndTime.Value - _currentSession.StartTime
                : DateTime.Now - _currentSession.StartTime;

            // Calculate percentage
            double percentage = _currentSession.Questions.Count > 0
                ? (_currentSession.Score * 100.0) / _currentSession.Questions.Count
                : 0;

            // Determine performance message and grade
            string message;
            string grade;

            if (percentage >= 90)
            {
                message = "🏆 Outstanding! You're a Quiz Master!";
                grade = "A+";
            }
            else if (percentage >= 80)
            {
                message = "🌟 Excellent work! Almost perfect!";
                grade = "A";
            }
            else if (percentage >= 70)
            {
                message = "👏 Great job! Well done!";
                grade = "B";
            }
            else if (percentage >= 60)
            {
                message = "👍 Good effort! Keep it up!";
                grade = "C";
            }
            else if (percentage >= 50)
            {
                message = "📖 Not bad! Room for improvement.";
                grade = "D";
            }
            else
            {
                message = "📚 Keep learning! Practice makes perfect!";
                grade = "F";
            }

            return new QuizResult
            {
                TotalQuestions = _currentSession.Questions.Count,
                CorrectAnswers = _currentSession.Score,
                WrongAnswers = _currentSession.Questions.Count - _currentSession.Score,
                TimeTaken = timeTaken,
                Percentage = Math.Round(percentage, 1),
                QuestionResults = questionResults,
                PerformanceMessage = message,
                Grade = grade
            };
        }
    }
}