using System.ComponentModel.DataAnnotations;

using static CarRentingSystem.Data.ModelsValidationConstraints;

namespace CarRentingSystem.Models.Dealers
{
    public class CreateDealerFormModel
    {
        [Required]
        [StringLength(DealerNameMaxLength, MinimumLength = DealerNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DealerPhoneNumberMaxLength, MinimumLength = DealerPhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;
    }
}