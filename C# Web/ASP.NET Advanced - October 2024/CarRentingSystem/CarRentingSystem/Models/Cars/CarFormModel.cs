using System.ComponentModel.DataAnnotations;

using CarRentingSystem.Services.Cars;
using CarRentingSystem.Services.Cars.Contracts;

using static CarRentingSystem.Data.ModelsValidationConstraints;

namespace CarRentingSystem.Models.Cars
{
    public class CarFormModel : ICarModel
    {
        [Required]
        [StringLength(CarMakeMaxLength, MinimumLength = CarMakeMinLength)]
        public string Make { get; init; } = null!;

        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; init; } = null!;

        [Required]
        [StringLength(int.MaxValue, MinimumLength = CarDescriptionMinLength, ErrorMessage = "The field {0} must be at least {2} characters long.")]
        public string Description { get; init; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; init; } = null!;

        [Required]
        [Range(CarYearMinValue, CarYearMaxValue)]
        public int Year { get; init; }

        [Required]
        public int CategoryId { get; init; }

        public virtual ICollection<CarCategoryServiceModel> Categories { get; set; } = new HashSet<CarCategoryServiceModel>();
    }
}