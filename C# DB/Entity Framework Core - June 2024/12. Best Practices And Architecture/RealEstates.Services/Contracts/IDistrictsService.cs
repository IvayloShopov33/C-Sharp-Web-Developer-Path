using RealEstates.Services.Models;

namespace RealEstates.Services.Contracts
{
    public interface IDistrictsService
    {
        IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count);

        IEnumerable<DistrictInfoDto> GetCheapestDistricts(int count);
    }
}