using System.ComponentModel.DataAnnotations;

using static Footballers.Data.ModelsValidationConstraints;

namespace Footballers.DataProcessor.ImportDto
{
    public class FootballerInputXmlModel
    {
        [Required]
        [MinLength(FootballerNameMinLength)]
        [MaxLength(FootballerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string ContractStartDate { get; set; } = null!;

        [Required]
        public string ContractEndDate { get; set; } = null!;

        [Required]
        [Range(FootballerPositionTypeMinValue, FootballerPositionTypeMaxValue)]
        public int PositionType { get; set; }

        [Required]
        [Range(FootballerBestSkillTypeMinValue, FootballerBestSkillTypeMaxValue)]
        public int BestSkillType { get; set; }
    }
}