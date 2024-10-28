namespace CarRentingSystem.Services.Cars
{
    public class CarQueryServiceModel
    {
        public int CurrentPage { get; set; } = 1;

        public int TotalCars { get; set; }

        public IEnumerable<CarServiceModel> Cars { get; init; }
    }
}