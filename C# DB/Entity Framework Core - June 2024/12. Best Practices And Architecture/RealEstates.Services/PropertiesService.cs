using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;
using AutoMapper.QueryableExtensions;
using RealEstates.Services.Contracts;

namespace RealEstates.Services
{
    public class PropertiesService : BaseService, IPropertiesService
    {
        private readonly ApplicationDbContext dbContext;

        public PropertiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(string district, int floor, int maxFloor, int size, int yardSize, int year, string propertyType, string buildingType, int price)
        {
            var property = new Property
            {
                Size = size,
                Price = price <= 0 ? null : price,
                Floor = floor <= 0 || floor > 255 ? null : (byte)floor,
                TotalFloors = maxFloor <= 0 || floor > 255 ? null : (byte)maxFloor,
                YardSize = yardSize <= 0 ? null : yardSize,
                Year = year <= 1800 ? null : year,
            };

            var dbDistrict = dbContext.Districts.FirstOrDefault(x => x.Name == district);
            if (dbDistrict == null)
            {
                dbDistrict = new District
                {
                    Name = district,
                };
            }

            property.District = dbDistrict;
            var dbPropertyType = dbContext.PropertyTypes.FirstOrDefault(x => x.Name == propertyType);
            if (dbPropertyType == null)
            {
                dbPropertyType = new PropertyType
                {
                    Name = propertyType,
                };
            }

            property.PropertyType = dbPropertyType;
            var dbBuildingType = dbContext.BuildingTypes.FirstOrDefault(x => x.Name == buildingType);
            if (dbBuildingType == null)
            {
                dbBuildingType = new BuildingType
                {
                    Name = buildingType,
                };
            }

            property.BuildingType = dbBuildingType;

            dbContext.Properties.Add(property);
            dbContext.SaveChanges();
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        {
            var properties = dbContext.Properties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice && x.Size >= minSize && x.Size <= maxSize)
                .ProjectTo<PropertyInfoDto>(this.Mapper.ConfigurationProvider)
                .ToList();

            return properties;
        }

        public decimal AveragePricePerSquareMeter()
        {
            return dbContext.Properties
                .Where(x => x.Price > 0)
                .Average(x => x.Price / (decimal)x.Size) ?? 0;
        }

        public decimal AveragePricePerSquareMeter(int districtId)
        {
            return dbContext.Properties
                .Where(x => x.Price > 0 && x.DistrictId == districtId)
                .Average(x => x.Price / (decimal)x.Size) ?? 0;
        }

        public double AverageSize(int districtId)
        {
            return dbContext.Properties
                .Where(x => x.Size > 0 && x.DistrictId == districtId)
                    .Average(x => x.Size);
        }

        public IEnumerable<PropertyInfoFullDataDto> GetFullData(int count)
        {
            var properties = this.dbContext.Properties
                .Where(x => x.Floor.HasValue && x.TotalFloors.HasValue && x.Floor.Value > 1 && x.Floor.Value < x.TotalFloors.Value &&
                    x.Year.HasValue && x.Year > 2015)
                .ProjectTo<PropertyInfoFullDataDto>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Price)
                .ThenBy(x => x.Size)
                .Take(count)
                .ToArray();

            return properties;
        }
    }
}