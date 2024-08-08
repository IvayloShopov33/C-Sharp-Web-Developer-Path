namespace Quiz.Services.Models
{
    public class QuizInputModel
    {
        public string UserId { get; set; } = null!;

        public int QuizId { get; set; }

        public ICollection<QuestionInputModel> QuestionsWithAnswers { get; set; }
    }
}