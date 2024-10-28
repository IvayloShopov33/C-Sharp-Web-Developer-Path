using System.ComponentModel.DataAnnotations;
using static CarRentingSystem.Data.ModelsValidationConstraints;

namespace CarRentingSystem.Services.Cars
{
    public class CarCategoryServiceModel
    {
        public int Id { get; init; }

        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; init; } = null!;
    }
}