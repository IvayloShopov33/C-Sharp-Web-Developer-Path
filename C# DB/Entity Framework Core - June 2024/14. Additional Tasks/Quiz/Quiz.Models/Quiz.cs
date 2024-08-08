using System.ComponentModel.DataAnnotations;

using static Quiz.Data.ModelsValidationConstraints;

namespace Quiz.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(QuizTitleMaxLength)]
        public string Title { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}