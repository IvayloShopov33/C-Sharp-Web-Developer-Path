using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace Quiz.Models
{
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }

        public string IdentityUserId { get; set; } = null!;

        public virtual IdentityUser IdentityUser { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public int? AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
    }
}