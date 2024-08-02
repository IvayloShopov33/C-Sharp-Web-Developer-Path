using System.ComponentModel.DataAnnotations;

using Artillery.Data.Models.Enums;
using static Artillery.Data.ModelsValidationConstraints;

namespace Artillery.DataProcessor.ImportDto
{
    public class GunInputJsonModel
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(GunWeightMinValue, GunWeightMaxValue)]
        public int GunWeight { get; set; }

        [Required]
        [Range(GunBarrelLengthMinValue, GunBarrelLengthMaxValue)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(GunRangeMinValue, GunRangeMaxValue)]
        public int Range { get; set; }

        [Required]
        public string GunType { get; set; } = null!;

        [Required]
        public int ShellId { get; set; }

        [Required]
        public CountryInputJsonModel[] Countries { get; set; }
    }
}