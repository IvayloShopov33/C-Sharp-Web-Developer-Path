using System.ComponentModel.DataAnnotations;

using static Boardgames.Data.ModelsValidationConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    public class BoardgameInputXmlModel
    {
        [Required]
        [MinLength(BoardgameNameMinLength)]
        [MaxLength(BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), BoardgameRatingMinValue, BoardgameRatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        [Range(BoardgameYearPublishedMinValue, BoardgameYearPublishedMaxValue)]
        public int YearPublished { get; set; }

        [Required]
        [Range(BoardgameCategoryTypeMinValue, BoardgameCategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; } = null!;
    }
}