namespace CarRentingSystem.Services.Cars.Contracts
{
    public interface ICarModel
    {
        string Make { get; }

        string Model { get; }

        int Year { get; }
    }
}