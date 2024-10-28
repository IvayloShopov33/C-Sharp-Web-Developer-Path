using Microsoft.AspNetCore.Mvc;

using CarRentingSystem.Services.Statistics.Contracts;
using CarRentingSystem.Services.Statistics;

namespace CarRentingSystem.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;
        public StatisticsApiController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public StatisticsServiceModel GetStatistics() => this.statisticsService.All();
    }
}