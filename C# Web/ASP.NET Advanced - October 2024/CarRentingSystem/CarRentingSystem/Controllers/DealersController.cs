using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CarRentingSystem.Models.Dealers;
using CarRentingSystem.Infrastructure.Extensions;
using CarRentingSystem.Services.Dealers.Contracts;

using static CarRentingSystem.WebConstants;

namespace CarRentingSystem.Controllers
{
    public class DealersController : Controller
    {
        private readonly IDealersService dealersService;

        public DealersController(IDealersService dealersService)
        {
            this.dealersService = dealersService;
        }

        [Authorize]
        public IActionResult Create() => this.View();

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateDealerFormModel dealerModel)
        {
            var userId = this.User.GetId();
            var userIsAlreadyDealer = this.dealersService.IsDealer(userId);

            if (userIsAlreadyDealer)
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.View(dealerModel);
            }           

            this.dealersService.CreateDealer(dealerModel, userId);

            this.TempData[GlobalMessageKey] = "Thank you for becoming a dealer!";

            return this.RedirectToAction("All", "Cars");
        }
    }
}