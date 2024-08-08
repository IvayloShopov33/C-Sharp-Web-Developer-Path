namespace Quiz.Services.Models
{
    public class AnswerViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int QuestionId { get; set; }

        public int Points { get; set; }       
    }
}