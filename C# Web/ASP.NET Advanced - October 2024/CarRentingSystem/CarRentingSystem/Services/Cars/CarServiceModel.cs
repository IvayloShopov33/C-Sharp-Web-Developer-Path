using CarRentingSystem.Services.Cars.Contracts;

namespace CarRentingSystem.Services.Cars
{
    public class CarServiceModel : ICarModel
    {
        public int Id { get; init; }

        public string Make { get; init; } = null!;

        public string Model { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;

        public int Year { get; init; }

        public string CategoryName { get; init; } = null!;

        public bool IsPublic { get; init; }
    }
}