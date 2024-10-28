using CarRentingSystem.Data;
using CarRentingSystem.Services.Statistics.Contracts;

namespace CarRentingSystem.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext dbContext;

        public StatisticsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StatisticsServiceModel All()
        {
            return new StatisticsServiceModel
            {
                TotalCars = this.dbContext.Cars.Count(),
                TotalUsers = this.dbContext.Users.Count(),
                TotalRents = 0,
            };
        }
    }
}