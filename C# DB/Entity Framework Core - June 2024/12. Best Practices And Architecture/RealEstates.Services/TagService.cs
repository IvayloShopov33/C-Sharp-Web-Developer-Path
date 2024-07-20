using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Contracts;

namespace RealEstates.Services
{
    public class TagService : BaseService, ITagService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPropertiesService propertiesService;

        public TagService(ApplicationDbContext dbContext, IPropertiesService propertiesService)
        {
            this.dbContext = dbContext;
            this.propertiesService = propertiesService;
        }

        public void Add(string name, int? importance)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance
            };

            this.dbContext.Tags.Add(tag);
            this.dbContext.SaveChanges();
        }

        public void BulkTagToProperties()
        {
            var allProperties = this.dbContext.Properties.ToList();
            foreach (var property in allProperties)
            {
                var averagePriceForDistrict = propertiesService.AveragePricePerSquareMeter(property.DistrictId);

                if (property.Price >= averagePriceForDistrict)
                {
                    var expensiveTag = GetTag("expensive_property");
                    property.Tags.Add(expensiveTag);
                }
                else
                {
                    var cheapTag = GetTag("cheap_property");
                    property.Tags.Add(cheapTag);
                }

                var currentDate = DateTime.UtcNow.AddYears(-15);

                if (property.Year.HasValue && property.Year < currentDate.Year)
                {
                    var oldTag = GetTag("old_property");
                    property.Tags.Add(oldTag);
                }
                else if (property.Year.HasValue && property.Year >= currentDate.Year)
                {
                    var newTag = GetTag("new_property");
                    property.Tags.Add(newTag);
                }

                var averagePropertySize = propertiesService.AverageSize(property.DistrictId);

                if (property.Size >= averagePropertySize)
                {
                    var hugeTag = GetTag("huge_property");
                    property.Tags.Add(hugeTag);
                }
                else
                {
                    var smallTag = GetTag("small_property");
                    property.Tags.Add(smallTag);
                }

                if (property.Floor.HasValue && property.Floor.Value == 1)
                {
                    var firstTag = GetTag("first_floor");
                    property.Tags.Add(firstTag);
                }
                else if (property.Floor.HasValue && property.TotalFloors.HasValue && property.Floor.Value == property.TotalFloors.Value)
                {
                    var lastTag = GetTag("last_floor");
                    property.Tags.Add(lastTag);
                }
            }

            this.dbContext.SaveChanges();
        }

        private Tag GetTag(string tagName)
            => this.dbContext.Tags.FirstOrDefault(x => x.Name == tagName);
    }
}