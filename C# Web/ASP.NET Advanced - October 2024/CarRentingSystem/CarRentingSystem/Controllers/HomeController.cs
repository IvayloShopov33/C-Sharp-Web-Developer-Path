using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using AutoMapper;

using CarRentingSystem.Services.Cars.Contracts;
using CarRentingSystem.Services.Cars;

namespace CarRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMemoryCache memoryCache;
        private readonly ICarsService carsService;

        public HomeController(IMapper mapper, IMemoryCache memoryCache, ICarsService carsService)
        {
            this.mapper = mapper;
            this.memoryCache = memoryCache;
            this.carsService = carsService;
        }

        public IActionResult Index()
        {
            const string latestCarsCacheKey = "latestCarsCacheKey";

            var latestCars = this.memoryCache.Get<List<CarServiceModel>>(latestCarsCacheKey);
            if (latestCars == null)
            {
                latestCars = this.carsService
                    .Latest()
                    .ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(20));

                this.memoryCache.Set(latestCarsCacheKey, latestCars, cacheOptions);
            }

            return this.View(latestCars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}