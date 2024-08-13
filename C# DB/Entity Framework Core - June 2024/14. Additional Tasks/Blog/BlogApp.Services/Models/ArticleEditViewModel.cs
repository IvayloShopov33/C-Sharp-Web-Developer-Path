using System.ComponentModel.DataAnnotations;

using static BlogApp.Common.ModelsValidationConstraints;

namespace BlogApp.Services.Models
{
    public class ArticleEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ArticleContentMaxLength, MinimumLength = ArticleContentMinLength)]
        public string Content { get; set; } = null!;

        [Required]
        [StringLength(ArticleCategoryMaxLength, MinimumLength = ArticleCategoryMinLength)]
        public string Category { get; set; } = null!;
    }
}