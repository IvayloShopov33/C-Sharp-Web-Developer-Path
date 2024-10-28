using CarRentingSystem.Models.Cars.Enums;
using CarRentingSystem.Services.Cars;

namespace CarRentingSystem.Models.Cars
{
    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 2;

        public string Make { get; init; }

        public IEnumerable<string> Makes { get; set; }

        public string SearchTerm { get; init; }

        public int CurrentPage { get; set; } = 1;

        public CarSorting Sorting { get; init; }

        public IEnumerable<CarServiceModel> Cars { get; set; }

        public int TotalCars { get; set; }
    }
}