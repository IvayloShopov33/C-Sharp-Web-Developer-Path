using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Caching.Memory;

using CarRentingSystem.Data.Models;
using CarRentingSystem.Controllers;
using CarRentingSystem.Services.Cars;
using CarRentingSystem.Tests.Mocks;

namespace CarRentingSystem.Tests.Controllers
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public HomeControllerTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task IndexShouldBeMappedCorrectly()
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync("/");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void IndexShouldReturnViewWithCorrectModel()
        {
            var mapper = MapperMock.Instance;
            var data = DatabaseMock.Instance;

            data.Categories.Add(new Category { Name = string.Empty });
            data.Cars.AddRange(Enumerable.Range(0, 10).Select(x => new Car()
            {
                Make = string.Empty,
                Model = string.Empty,
                Description = string.Empty,
                ImageUrl = string.Empty,
                Year = 2024,
                CategoryId = 1,
                IsPublic = true,
            }));
            data.SaveChanges();

            var carService = new CarsService(mapper, data);

            var homeController = new HomeController(mapper, new MemoryCache(new MemoryCacheOptions()), carService);

            var result = homeController.Index();

            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = viewResult.Model;
            Assert.NotNull(model);

            var listOfCarServiceModel = Assert.IsType<List<CarServiceModel>>(model);
            Assert.Equal(3, listOfCarServiceModel.Count);
        }

        [Fact]
        public async Task ErrorShouldBeMappedCorrectly()
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync("/Home/Error");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public void ErrorShouldReturnCorrectViewModel()
        {
            var mapper = MapperMock.Instance;
            var data = DatabaseMock.Instance;

            var carService = new CarsService(mapper, data);

            var homeController = new HomeController(mapper, new MemoryCache(new MemoryCacheOptions()), carService);

            var result = homeController.Error();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}