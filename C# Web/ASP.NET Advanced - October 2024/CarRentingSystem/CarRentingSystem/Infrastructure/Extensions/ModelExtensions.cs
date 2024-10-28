using CarRentingSystem.Services.Cars.Contracts;

namespace CarRentingSystem.Infrastructure.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICarModel car)
            => car.Make + "-" + car.Model + "-" + car.Year;
    }
}