using Quiz.Services.Models.Enums;

namespace Quiz.Services.Models
{
    public class UserQuizViewModel
    {
        public int QuizId { get; set; }

        public string QuizTitle { get; set; } = null!;

        public QuizStatus QuizStatus { get; set; }
    }
}