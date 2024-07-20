using RealEstates.Services.Models;

namespace RealEstates.Services.Contracts
{
    public interface IPropertiesService
    {
        void Add(string district, int floor,
            int maxFloor, int size, int yardSize, int year,
            string propertyType, string buildingType, int price);

        decimal AveragePricePerSquareMeter();

        decimal AveragePricePerSquareMeter(int districtId);

        double AverageSize(int districtId);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);

        IEnumerable<PropertyInfoFullDataDto> GetFullData(int count);
    }
}