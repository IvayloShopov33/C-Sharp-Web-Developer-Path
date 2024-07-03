using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(120)]
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}