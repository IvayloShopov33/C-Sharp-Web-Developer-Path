using System.ComponentModel.DataAnnotations;

using static Footballers.Data.ModelsValidationConstraints;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamInputJsonModel
    {
        [Required]
        [RegularExpression(TeamNameRegEx)]
        [MinLength(TeamNameMinLength)]
        [MaxLength(TeamNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(TeamNationalityMinLength)]
        [MaxLength(TeamNameMaxLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        public int Trophies { get; set; }

        [Required]
        public int[] Footballers { get; set; }
    }
}