using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class News
    {
        public News()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [MaxLength(300)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
