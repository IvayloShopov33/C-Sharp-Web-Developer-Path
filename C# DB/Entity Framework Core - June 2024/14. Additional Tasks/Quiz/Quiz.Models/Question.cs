using System.ComponentModel.DataAnnotations;

using static Quiz.Data.ModelsValidationConstraints;

namespace Quiz.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(QuestionTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();

        public virtual ICollection<UserAnswer> UsersAnswers { get; set; } = new HashSet<UserAnswer>();
    }
}