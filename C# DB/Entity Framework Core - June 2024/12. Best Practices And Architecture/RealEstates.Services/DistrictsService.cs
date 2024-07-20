using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictsService : BaseService, IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var mostExpensiveDistricts = dbContext.Districts
                .ProjectTo<DistrictInfoDto>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(x => x.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();

            return mostExpensiveDistricts;
        }

        public IEnumerable<DistrictInfoDto> GetCheapestDistricts(int count)
        {
            var cheapestDistricts = dbContext.Districts
                .ProjectTo<DistrictInfoDto>(this.Mapper.ConfigurationProvider)
                .OrderBy(x => x.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();

            return cheapestDistricts;
        }
    }
}