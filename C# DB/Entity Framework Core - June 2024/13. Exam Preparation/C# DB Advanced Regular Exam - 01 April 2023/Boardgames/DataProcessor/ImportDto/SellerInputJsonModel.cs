using System.ComponentModel.DataAnnotations;

using static Boardgames.Data.ModelsValidationConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    public class SellerInputJsonModel
    {
        [Required]
        [MinLength(SellerNameMinLength)]
        [MaxLength(SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(SellerAddressMinLength)]
        [MaxLength(SellerAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(SellerWebsiteRegEx)]
        public string Website { get; set; } = null!;

        public int[] Boardgames { get; set; } = null!;
    }
}