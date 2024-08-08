namespace Quiz.Services.Models
{
    public class QuizViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}