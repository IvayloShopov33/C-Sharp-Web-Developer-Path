using System.ComponentModel.DataAnnotations;

using static Quiz.Data.ModelsValidationConstraints;

namespace Quiz.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AnswerTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<UserAnswer> UsersAnswers { get; set; } = new HashSet<UserAnswer>();
    }
}