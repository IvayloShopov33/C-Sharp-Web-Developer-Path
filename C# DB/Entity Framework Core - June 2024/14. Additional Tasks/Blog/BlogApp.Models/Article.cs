using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static BlogApp.Common.ModelsValidationConstraints;

namespace BlogApp.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ArticleTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ArticleContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [MaxLength(ArticleCategoryMaxLength)]
        public string Category { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; } = null!;

        public virtual ApplicationUser Author { get; set; }
    }
}