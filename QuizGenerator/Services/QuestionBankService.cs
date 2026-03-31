using QuizGenerator.Models;

namespace QuizGenerator.Services
{
    public class QuestionBankService : IQuestionBankService
    {
        private readonly List<Question> _questions;
        private readonly Random _random = new();

        public QuestionBankService()
        {
            _questions = InitializeQuestions();
        }

        public List<Question> GetAllQuestions() => _questions;

        public List<Question> GetRandomQuestions(int count, string? category = null, Difficulty? difficulty = null)
        {
            var filtered = _questions.AsEnumerable();

            if (!string.IsNullOrEmpty(category) && category != "All")
                filtered = filtered.Where(q => q.Category == category);

            if (difficulty.HasValue)
                filtered = filtered.Where(q => q.DifficultyLevel == difficulty.Value);

            var available = filtered.ToList();

            if (available.Count <= count)
                return available.OrderBy(_ => _random.Next()).ToList();

            return available.OrderBy(_ => _random.Next()).Take(count).ToList();
        }

        public List<Question> GetQuestionsByCategory(string category)
            => _questions.Where(q => q.Category == category).ToList();

        public List<Question> GetQuestionsByDifficulty(Difficulty difficulty)
            => _questions.Where(q => q.DifficultyLevel == difficulty).ToList();

        public List<string> GetCategories()
            => _questions.Select(q => q.Category).Distinct().ToList();

        public int GetTotalQuestionCount() => _questions.Count;

        public int GetCategoryCount()
            => _questions.Select(q => q.Category).Distinct().Count();

        private List<Question> InitializeQuestions()
        {
            return new List<Question>
            {
                // ============================================
                // GENERAL KNOWLEDGE (25 Questions)
                // ============================================
                new Question
                {
                    Id = 1,
                    QuestionText = "What is the capital of France?",
                    Options = new List<string> { "London", "Berlin", "Paris", "Madrid" },
                    CorrectAnswerIndex = 2,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 2,
                    QuestionText = "Which planet is known as the Red Planet?",
                    Options = new List<string> { "Venus", "Mars", "Jupiter", "Saturn" },
                    CorrectAnswerIndex = 1,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 3,
                    QuestionText = "What is the largest ocean on Earth?",
                    Options = new List<string> { "Pacific Ocean", "Atlantic Ocean", "Indian Ocean", "Arctic Ocean" },
                    CorrectAnswerIndex = 0,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 4,
                    QuestionText = "Who painted the Mona Lisa?",
                    Options = new List<string> { "Michelangelo", "Pablo Picasso", "Leonardo da Vinci", "Vincent van Gogh" },
                    CorrectAnswerIndex = 2,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 5,
                    QuestionText = "What is the chemical symbol for gold?",
                    Options = new List<string> { "Go", "Gd", "Ag", "Au" },
                    CorrectAnswerIndex = 3,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 6,
                    QuestionText = "How many continents are there on Earth?",
                    Options = new List<string> { "5", "7", "6", "8" },
                    CorrectAnswerIndex = 1,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 7,
                    QuestionText = "What is the largest mammal in the world?",
                    Options = new List<string> { "Blue Whale", "African Elephant", "Giraffe", "Hippopotamus" },
                    CorrectAnswerIndex = 0,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 8,
                    QuestionText = "What is the currency of Japan?",
                    Options = new List<string> { "Won", "Yuan", "Yen", "Ringgit" },
                    CorrectAnswerIndex = 2,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 9,
                    QuestionText = "Who wrote 'Romeo and Juliet'?",
                    Options = new List<string> { "Charles Dickens", "William Shakespeare", "Jane Austen", "Mark Twain" },
                    CorrectAnswerIndex = 1,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 10,
                    QuestionText = "What is the tallest mountain in the world?",
                    Options = new List<string> { "K2", "Kangchenjunga", "Makalu", "Mount Everest" },
                    CorrectAnswerIndex = 3,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 11,
                    QuestionText = "What is the smallest country in the world by area?",
                    Options = new List<string> { "Vatican City", "Monaco", "San Marino", "Liechtenstein" },
                    CorrectAnswerIndex = 0,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 12,
                    QuestionText = "Which gas do plants absorb from the atmosphere?",
                    Options = new List<string> { "Oxygen", "Nitrogen", "Carbon Dioxide", "Hydrogen" },
                    CorrectAnswerIndex = 2,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 13,
                    QuestionText = "In what year did World War II end?",
                    Options = new List<string> { "1943", "1945", "1944", "1946" },
                    CorrectAnswerIndex = 1,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 14,
                    QuestionText = "What is the hardest natural substance on Earth?",
                    Options = new List<string> { "Gold", "Iron", "Quartz", "Diamond" },
                    CorrectAnswerIndex = 3,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 15,
                    QuestionText = "How many players are on a standard soccer team on the field?",
                    Options = new List<string> { "11", "9", "10", "12" },
                    CorrectAnswerIndex = 0,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 16,
                    QuestionText = "Who is credited with inventing the telephone?",
                    Options = new List<string> { "Thomas Edison", "Nikola Tesla", "Alexander Graham Bell", "Guglielmo Marconi" },
                    CorrectAnswerIndex = 2,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 17,
                    QuestionText = "What is the boiling point of water in Celsius?",
                    Options = new List<string> { "90°C", "100°C", "110°C", "120°C" },
                    CorrectAnswerIndex = 1,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 18,
                    QuestionText = "Which country is known as the Land of the Rising Sun?",
                    Options = new List<string> { "China", "South Korea", "Thailand", "Japan" },
                    CorrectAnswerIndex = 3,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 19,
                    QuestionText = "What is the main component of the Sun?",
                    Options = new List<string> { "Hydrogen", "Helium", "Oxygen", "Carbon" },
                    CorrectAnswerIndex = 0,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 20,
                    QuestionText = "Who is known as the Father of Computers?",
                    Options = new List<string> { "Alan Turing", "Bill Gates", "Charles Babbage", "Steve Jobs" },
                    CorrectAnswerIndex = 2,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 21,
                    QuestionText = "How many bones are in the adult human body?",
                    Options = new List<string> { "195", "206", "215", "226" },
                    CorrectAnswerIndex = 1,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 22,
                    QuestionText = "What is the largest organ of the human body?",
                    Options = new List<string> { "Skin", "Liver", "Heart", "Lungs" },
                    CorrectAnswerIndex = 0,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 23,
                    QuestionText = "What is the approximate speed of light?",
                    Options = new List<string> { "150,000 km/s", "200,000 km/s", "250,000 km/s", "300,000 km/s" },
                    CorrectAnswerIndex = 3,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Hard
                },
                new Question
                {
                    Id = 24,
                    QuestionText = "Which language has the most native speakers worldwide?",
                    Options = new List<string> { "English", "Mandarin Chinese", "Spanish", "Hindi" },
                    CorrectAnswerIndex = 1,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 25,
                    QuestionText = "What is the largest hot desert in the world?",
                    Options = new List<string> { "Gobi", "Arabian", "Sahara", "Kalahari" },
                    CorrectAnswerIndex = 2,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },

                // ============================================
                // SCIENCE (25 Questions)
                // ============================================
                new Question
                {
                    Id = 26,
                    QuestionText = "What is the chemical formula for water?",
                    Options = new List<string> { "H₂O", "CO₂", "NaCl", "O₂" },
                    CorrectAnswerIndex = 0,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 27,
                    QuestionText = "Which planet is closest to the Sun?",
                    Options = new List<string> { "Venus", "Mercury", "Earth", "Mars" },
                    CorrectAnswerIndex = 1,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 28,
                    QuestionText = "What is often called the 'powerhouse of the cell'?",
                    Options = new List<string> { "Nucleus", "Ribosome", "Mitochondria", "Golgi Body" },
                    CorrectAnswerIndex = 2,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 29,
                    QuestionText = "What gas do humans need to breathe to survive?",
                    Options = new List<string> { "Oxygen", "Nitrogen", "Carbon Dioxide", "Helium" },
                    CorrectAnswerIndex = 0,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 30,
                    QuestionText = "What is the pH value of pure water?",
                    Options = new List<string> { "5", "6", "8", "7" },
                    CorrectAnswerIndex = 3,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 31,
                    QuestionText = "What type of chemical bond involves the sharing of electrons?",
                    Options = new List<string> { "Ionic Bond", "Covalent Bond", "Metallic Bond", "Hydrogen Bond" },
                    CorrectAnswerIndex = 1,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 32,
                    QuestionText = "What is the SI unit of electric current?",
                    Options = new List<string> { "Volt", "Watt", "Ampere", "Ohm" },
                    CorrectAnswerIndex = 2,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 33,
                    QuestionText = "Which element has the atomic number 1?",
                    Options = new List<string> { "Hydrogen", "Helium", "Lithium", "Carbon" },
                    CorrectAnswerIndex = 0,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 34,
                    QuestionText = "What is the process by which plants make their own food?",
                    Options = new List<string> { "Respiration", "Osmosis", "Fermentation", "Photosynthesis" },
                    CorrectAnswerIndex = 3,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 35,
                    QuestionText = "What is the most abundant gas in Earth's atmosphere?",
                    Options = new List<string> { "Oxygen", "Nitrogen", "Carbon Dioxide", "Argon" },
                    CorrectAnswerIndex = 1,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 36,
                    QuestionText = "Which organ pumps blood throughout the human body?",
                    Options = new List<string> { "Heart", "Lungs", "Brain", "Liver" },
                    CorrectAnswerIndex = 0,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 37,
                    QuestionText = "What is the chemical symbol for sodium?",
                    Options = new List<string> { "So", "Sd", "Na", "No" },
                    CorrectAnswerIndex = 2,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 38,
                    QuestionText = "What force keeps planets in orbit around the Sun?",
                    Options = new List<string> { "Magnetism", "Friction", "Inertia", "Gravity" },
                    CorrectAnswerIndex = 3,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 39,
                    QuestionText = "How many chromosomes do humans have in each cell?",
                    Options = new List<string> { "44", "46", "48", "23" },
                    CorrectAnswerIndex = 1,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 40,
                    QuestionText = "What is the study of fungi called?",
                    Options = new List<string> { "Mycology", "Botany", "Zoology", "Virology" },
                    CorrectAnswerIndex = 0,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Hard
                },
                new Question
                {
                    Id = 41,
                    QuestionText = "What vitamin does the human body produce when exposed to sunlight?",
                    Options = new List<string> { "Vitamin A", "Vitamin C", "Vitamin D", "Vitamin E" },
                    CorrectAnswerIndex = 2,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 42,
                    QuestionText = "What is the basic unit of a chemical element?",
                    Options = new List<string> { "Molecule", "Cell", "Electron", "Atom" },
                    CorrectAnswerIndex = 3,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 43,
                    QuestionText = "What is the freezing point of water in Fahrenheit?",
                    Options = new List<string> { "32°F", "0°F", "28°F", "40°F" },
                    CorrectAnswerIndex = 0,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 44,
                    QuestionText = "Which planet in our solar system has the most known moons?",
                    Options = new List<string> { "Jupiter", "Saturn", "Uranus", "Neptune" },
                    CorrectAnswerIndex = 1,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Hard
                },
                new Question
                {
                    Id = 45,
                    QuestionText = "What is the chemical formula for table salt?",
                    Options = new List<string> { "KCl", "NaOH", "NaCl", "CaCl₂" },
                    CorrectAnswerIndex = 2,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 46,
                    QuestionText = "What type of animal is a dolphin?",
                    Options = new List<string> { "Mammal", "Fish", "Reptile", "Amphibian" },
                    CorrectAnswerIndex = 0,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 47,
                    QuestionText = "What is the largest planet in our solar system?",
                    Options = new List<string> { "Saturn", "Neptune", "Uranus", "Jupiter" },
                    CorrectAnswerIndex = 3,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 48,
                    QuestionText = "What is the approximate speed of sound in air at room temperature?",
                    Options = new List<string> { "299 m/s", "343 m/s", "400 m/s", "512 m/s" },
                    CorrectAnswerIndex = 1,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Hard
                },
                new Question
                {
                    Id = 49,
                    QuestionText = "What type of rock is formed when magma or lava cools and solidifies?",
                    Options = new List<string> { "Igneous", "Sedimentary", "Metamorphic", "Mineral" },
                    CorrectAnswerIndex = 0,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 50,
                    QuestionText = "Newton's first law of motion is about which concept?",
                    Options = new List<string> { "Acceleration", "Reaction", "Inertia", "Momentum" },
                    CorrectAnswerIndex = 2,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },

                // ============================================
                // MATHEMATICS (25 Questions)
                // ============================================
                new Question
                {
                    Id = 51,
                    QuestionText = "What is the value of Pi (π) rounded to two decimal places?",
                    Options = new List<string> { "3.12", "3.14", "3.16", "3.18" },
                    CorrectAnswerIndex = 1,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 52,
                    QuestionText = "What is the square root of 144?",
                    Options = new List<string> { "12", "14", "11", "13" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 53,
                    QuestionText = "What is 15% of 200?",
                    Options = new List<string> { "20", "25", "30", "35" },
                    CorrectAnswerIndex = 2,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 54,
                    QuestionText = "How many degrees are in a right angle?",
                    Options = new List<string> { "45", "60", "180", "90" },
                    CorrectAnswerIndex = 3,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 55,
                    QuestionText = "What is the next prime number after 7?",
                    Options = new List<string> { "9", "11", "13", "8" },
                    CorrectAnswerIndex = 1,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 56,
                    QuestionText = "What is the formula for the area of a circle?",
                    Options = new List<string> { "πr²", "2πr", "πd", "2πr²" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 57,
                    QuestionText = "What is 2 raised to the power of 10?",
                    Options = new List<string> { "512", "2048", "1024", "1000" },
                    CorrectAnswerIndex = 2,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 58,
                    QuestionText = "How many sides does a hexagon have?",
                    Options = new List<string> { "5", "7", "8", "6" },
                    CorrectAnswerIndex = 3,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 59,
                    QuestionText = "What is the sum of all interior angles of a triangle?",
                    Options = new List<string> { "180 degrees", "360 degrees", "90 degrees", "270 degrees" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 60,
                    QuestionText = "What is 7 multiplied by 8?",
                    Options = new List<string> { "54", "56", "58", "48" },
                    CorrectAnswerIndex = 1,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 61,
                    QuestionText = "What is the 7th number in the Fibonacci sequence (starting 1, 1, 2, ...)?",
                    Options = new List<string> { "8", "11", "13", "21" },
                    CorrectAnswerIndex = 2,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 62,
                    QuestionText = "What is the Least Common Multiple (LCM) of 4 and 6?",
                    Options = new List<string> { "12", "24", "6", "18" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 63,
                    QuestionText = "How many edges does a cube have?",
                    Options = new List<string> { "6", "8", "10", "12" },
                    CorrectAnswerIndex = 3,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 64,
                    QuestionText = "What is the derivative of x² with respect to x?",
                    Options = new List<string> { "x", "2x", "x²", "2x²" },
                    CorrectAnswerIndex = 1,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Hard
                },
                new Question
                {
                    Id = 65,
                    QuestionText = "What is 25% expressed as a simple fraction?",
                    Options = new List<string> { "1/4", "1/3", "1/5", "1/2" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 66,
                    QuestionText = "What is the formula for the perimeter of a rectangle?",
                    Options = new List<string> { "l × w", "l + w", "2(l + w)", "4l" },
                    CorrectAnswerIndex = 2,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 67,
                    QuestionText = "What is the square root of 169?",
                    Options = new List<string> { "11", "12", "14", "13" },
                    CorrectAnswerIndex = 3,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 68,
                    QuestionText = "How many faces does a tetrahedron have?",
                    Options = new List<string> { "4", "5", "6", "3" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 69,
                    QuestionText = "What is the value of log base 10 of 1000?",
                    Options = new List<string> { "2", "3", "4", "10" },
                    CorrectAnswerIndex = 1,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Hard
                },
                new Question
                {
                    Id = 70,
                    QuestionText = "What is the Greatest Common Divisor (GCD) of 24 and 36?",
                    Options = new List<string> { "6", "8", "12", "4" },
                    CorrectAnswerIndex = 2,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 71,
                    QuestionText = "What is the indefinite integral of 2x with respect to x?",
                    Options = new List<string> { "x² + C", "2x² + C", "x + C", "2 + C" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Hard
                },
                new Question
                {
                    Id = 72,
                    QuestionText = "How many degrees are in a straight angle (straight line)?",
                    Options = new List<string> { "90", "270", "360", "180" },
                    CorrectAnswerIndex = 3,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 73,
                    QuestionText = "What is 3! (3 factorial)?",
                    Options = new List<string> { "3", "6", "9", "27" },
                    CorrectAnswerIndex = 1,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 74,
                    QuestionText = "What is the slope of a horizontal line?",
                    Options = new List<string> { "0", "1", "Undefined", "Infinity" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 75,
                    QuestionText = "What is the formula for the volume of a sphere?",
                    Options = new List<string> { "πr³", "(2/3)πr³", "(4/3)πr³", "4πr²" },
                    CorrectAnswerIndex = 2,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Hard
                },

                // ============================================
                // HISTORY (15 Questions)
                // ============================================
                new Question
                {
                    Id = 76,
                    QuestionText = "Who was the first President of the United States?",
                    Options = new List<string> { "Thomas Jefferson", "George Washington", "Abraham Lincoln", "John Adams" },
                    CorrectAnswerIndex = 1,
                    Category = "History",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 77,
                    QuestionText = "In which year did the Titanic sink?",
                    Options = new List<string> { "1912", "1905", "1920", "1915" },
                    CorrectAnswerIndex = 0,
                    Category = "History",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 78,
                    QuestionText = "Who is credited with discovering the Americas in 1492?",
                    Options = new List<string> { "Vasco da Gama", "Ferdinand Magellan", "Christopher Columbus", "Amerigo Vespucci" },
                    CorrectAnswerIndex = 2,
                    Category = "History",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 79,
                    QuestionText = "Which ancient civilization is famous for building the Great Pyramids?",
                    Options = new List<string> { "Romans", "Greeks", "Mayans", "Egyptians" },
                    CorrectAnswerIndex = 3,
                    Category = "History",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 80,
                    QuestionText = "In which year did World War I begin?",
                    Options = new List<string> { "1914", "1916", "1912", "1918" },
                    CorrectAnswerIndex = 0,
                    Category = "History",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 81,
                    QuestionText = "Who was the first person to walk on the Moon?",
                    Options = new List<string> { "Buzz Aldrin", "Neil Armstrong", "Yuri Gagarin", "John Glenn" },
                    CorrectAnswerIndex = 1,
                    Category = "History",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 82,
                    QuestionText = "In which year did the Berlin Wall fall?",
                    Options = new List<string> { "1987", "1991", "1989", "1985" },
                    CorrectAnswerIndex = 2,
                    Category = "History",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 83,
                    QuestionText = "Who was the key leader of the Indian independence movement?",
                    Options = new List<string> { "Mahatma Gandhi", "Jawaharlal Nehru", "Subhas Chandra Bose", "B.R. Ambedkar" },
                    CorrectAnswerIndex = 0,
                    Category = "History",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 84,
                    QuestionText = "Who was the principal author of the Declaration of Independence?",
                    Options = new List<string> { "Benjamin Franklin", "John Adams", "George Washington", "Thomas Jefferson" },
                    CorrectAnswerIndex = 3,
                    Category = "History",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 85,
                    QuestionText = "Which empire was Julius Caesar a leader of?",
                    Options = new List<string> { "Greek Empire", "Roman Empire", "Ottoman Empire", "Persian Empire" },
                    CorrectAnswerIndex = 1,
                    Category = "History",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 86,
                    QuestionText = "In which year was the United Nations (UN) established?",
                    Options = new List<string> { "1945", "1948", "1950", "1942" },
                    CorrectAnswerIndex = 0,
                    Category = "History",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 87,
                    QuestionText = "Who invented the mechanical printing press?",
                    Options = new List<string> { "Benjamin Franklin", "Thomas Edison", "Johannes Gutenberg", "Galileo Galilei" },
                    CorrectAnswerIndex = 2,
                    Category = "History",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 88,
                    QuestionText = "The Cold War was primarily between which two superpowers?",
                    Options = new List<string> { "USA and China", "USA and Germany", "UK and Russia", "USA and Soviet Union" },
                    CorrectAnswerIndex = 3,
                    Category = "History",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 89,
                    QuestionText = "In which year did India gain independence from British rule?",
                    Options = new List<string> { "1945", "1947", "1950", "1942" },
                    CorrectAnswerIndex = 1,
                    Category = "History",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 90,
                    QuestionText = "What was the Renaissance primarily known as?",
                    Options = new List<string> { "A cultural and artistic rebirth in Europe", "A religious reformation movement", "A scientific revolution only", "An industrial movement" },
                    CorrectAnswerIndex = 0,
                    Category = "History",
                    DifficultyLevel = Difficulty.Medium
                },

                // ============================================
                // GEOGRAPHY (10 Questions)
                // ============================================
                new Question
                {
                    Id = 91,
                    QuestionText = "What is traditionally considered the longest river in the world?",
                    Options = new List<string> { "Amazon", "Mississippi", "Nile", "Yangtze" },
                    CorrectAnswerIndex = 2,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 92,
                    QuestionText = "Which is the largest continent by area?",
                    Options = new List<string> { "Asia", "Africa", "Europe", "North America" },
                    CorrectAnswerIndex = 0,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 93,
                    QuestionText = "What is the capital city of Australia?",
                    Options = new List<string> { "Sydney", "Melbourne", "Brisbane", "Canberra" },
                    CorrectAnswerIndex = 3,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 94,
                    QuestionText = "Which country currently has the largest population in the world?",
                    Options = new List<string> { "China", "India", "United States", "Indonesia" },
                    CorrectAnswerIndex = 1,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 95,
                    QuestionText = "Which ocean lies between Africa and Australia?",
                    Options = new List<string> { "Indian Ocean", "Pacific Ocean", "Atlantic Ocean", "Southern Ocean" },
                    CorrectAnswerIndex = 0,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 96,
                    QuestionText = "What is the smallest continent by land area?",
                    Options = new List<string> { "Europe", "Antarctica", "Australia", "South America" },
                    CorrectAnswerIndex = 2,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Easy
                },
                new Question
                {
                    Id = 97,
                    QuestionText = "Which country is known as the 'Land of Fire and Ice'?",
                    Options = new List<string> { "Greenland", "Norway", "Finland", "Iceland" },
                    CorrectAnswerIndex = 3,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 98,
                    QuestionText = "What is the capital city of Brazil?",
                    Options = new List<string> { "Rio de Janeiro", "Brasília", "São Paulo", "Salvador" },
                    CorrectAnswerIndex = 1,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 99,
                    QuestionText = "Which mountain range forms a natural border between Europe and Asia?",
                    Options = new List<string> { "Ural Mountains", "Alps", "Himalayas", "Caucasus Mountains" },
                    CorrectAnswerIndex = 0,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 100,
                    QuestionText = "What is the deepest known point in the Earth's oceans?",
                    Options = new List<string> { "Puerto Rico Trench", "Java Trench", "Mariana Trench", "Tonga Trench" },
                    CorrectAnswerIndex = 2,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Easy
                },
                // ============================================
                // BONUS QUESTIONS (5 Extra — Total 105)
                // ============================================
                new Question
                {
                    Id = 101,
                    QuestionText = "What programming language was developed by James Gosling at Sun Microsystems?",
                    Options = new List<string> { "Python", "Java", "C++", "Ruby" },
                    CorrectAnswerIndex = 1,
                    Category = "General Knowledge",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 102,
                    QuestionText = "What is the term for the rate at which velocity changes over time?",
                    Options = new List<string> { "Speed", "Force", "Acceleration", "Momentum" },
                    CorrectAnswerIndex = 2,
                    Category = "Science",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 103,
                    QuestionText = "What is the binary representation of the decimal number 10?",
                    Options = new List<string> { "1010", "1001", "1100", "1110" },
                    CorrectAnswerIndex = 0,
                    Category = "Mathematics",
                    DifficultyLevel = Difficulty.Medium
                },
                new Question
                {
                    Id = 104,
                    QuestionText = "Which ancient wonder of the world was located in Alexandria, Egypt?",
                    Options = new List<string> { "Colossus of Rhodes", "Hanging Gardens", "Great Lighthouse (Pharos)", "Temple of Artemis" },
                    CorrectAnswerIndex = 2,
                    Category = "History",
                    DifficultyLevel = Difficulty.Hard
                },
                new Question
                {
                    Id = 105,
                    QuestionText = "What is the capital city of Canada?",
                    Options = new List<string> { "Toronto", "Vancouver", "Montreal", "Ottawa" },
                    CorrectAnswerIndex = 3,
                    Category = "Geography",
                    DifficultyLevel = Difficulty.Easy
                }
            };
        }
    }
}