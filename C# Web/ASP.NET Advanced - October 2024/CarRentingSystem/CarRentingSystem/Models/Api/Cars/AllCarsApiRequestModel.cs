using CarRentingSystem.Models.Cars.Enums;

namespace CarRentingSystem.Models.Api.Cars
{
    public class AllCarsApiRequestModel
    {
        public string? Make { get; set; }

        public string? SearchTerm { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int CarsPerPage { get; init; } = 8;

        public CarSorting Sorting { get; init; }

        public int TotalCars { get; set; }
    }
}