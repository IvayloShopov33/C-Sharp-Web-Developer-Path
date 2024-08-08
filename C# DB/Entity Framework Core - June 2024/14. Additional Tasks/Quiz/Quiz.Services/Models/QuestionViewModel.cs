namespace Quiz.Services.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}