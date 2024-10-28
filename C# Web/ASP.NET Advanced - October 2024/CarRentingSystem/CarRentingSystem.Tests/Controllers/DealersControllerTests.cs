using System.Net;
using System.Reflection;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Authorization;

using CarRentingSystem.Controllers;
using CarRentingSystem.Tests.Mocks;
using CarRentingSystem.Services.Dealers;
using CarRentingSystem.Models.Dealers;

namespace CarRentingSystem.Tests.Controllers
{
    public class DealersControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public DealersControllerTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task CreateShouldBeMappedCorrectly()
        {
            var client = this.factory.CreateClient();

            var response = await client.GetAsync("/Dealers/Create");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void CreateShouldBeForAuthorizedAndReturnView()
        {
            Assert.NotNull(typeof(DealersController).GetMethods()[0]
                .GetCustomAttribute<AuthorizeAttribute>());

            var data = DatabaseMock.Instance;

            var dealersService = new DealersService(data);
            var dealersController = new DealersController(dealersService);

            var result = dealersController.Create();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData("Dealer", "0888888")]
        public async Task CreatePostShouldBeMappedCorrectly(string dealerName, string phoneNumber)
        {
            var client = this.factory.CreateClient();

            var response = await client.PostAsync("/Dealers/Create", new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", dealerName),
                new KeyValuePair<string, string>("PhoneNumber", phoneNumber)
            }));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("Dealer", "0888888")]
        public void CreatePostShouldBeForAuthorizedUsersAndReturnRedirectWithCorrectModel(string dealerName, string phoneNumber)
        {
            Assert.NotNull(typeof(DealersController).GetMethods()[1]
                .GetCustomAttribute<AuthorizeAttribute>());

            Assert.NotNull(typeof(DealersController).GetMethods()[1]
                .GetCustomAttribute<HttpPostAttribute>());

            var data = DatabaseMock.Instance;

            var dealersService = new DealersService(data);
            var dealersController = new DealersController(dealersService);

            var userId = "test-user-id";
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));

            dealersController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var tempData = TempDataMock.Instance;
            dealersController.TempData = tempData.Object;

            var result = dealersController.Create(new CreateDealerFormModel
            {
                Name = dealerName,
                PhoneNumber = phoneNumber,
            });

            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}