using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CarRentingSystem.Services.Cars.Contracts;

namespace CarRentingSystem.Areas.Admins.Controllers
{
    [Authorize(Roles = WebConstants.AdministratorRoleName)]
    [Area("Admins")]
    public class AdminsController : Controller
    {
        private readonly ICarsService carsService;

        public AdminsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        public IActionResult AllCars()
        {
            var allCars = carsService.All(isPublic: false).Cars;

            return this.View(allCars);
        }

        public IActionResult ChangeCarVisibility(int id)
        {
            this.carsService.ChangeVisibility(id);

            return this.RedirectToAction("AllCars");
        }
    }
}