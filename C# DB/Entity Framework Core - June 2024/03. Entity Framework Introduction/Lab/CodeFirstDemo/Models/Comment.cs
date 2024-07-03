using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    [Index(nameof(QuestionId), Name = "QuestionIdIndex")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}