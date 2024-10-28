using CarRentingSystem.Services.Cars.Contracts;

namespace CarRentingSystem.Services.Cars
{
    public class DetailsCarServiceModel : ICarModel
    {
        public string Make { get; init; } = null!;

        public string Model { get; init; } = null!;

        public string Description { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;

        public int Year { get; init; }

        public int CategoryId { get; init; }

        public string Category { get; init; } = null!;

        public int DealerId { get; init; }

        public string DealerName { get; init; } = null!;

        public string UserId { get; init; } = null!;
    }
}