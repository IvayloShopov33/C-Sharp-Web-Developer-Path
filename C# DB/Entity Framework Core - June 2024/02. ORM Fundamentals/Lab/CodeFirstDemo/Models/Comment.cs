using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int? NewsId { get; set; }

        public News News { get; set; }

        [MaxLength(60)]
        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }
    }
}