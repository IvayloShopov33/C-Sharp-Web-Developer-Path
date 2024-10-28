using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;

using CarRentingSystem.Models.Cars;
using CarRentingSystem.Services.Cars.Contracts;
using CarRentingSystem.Services.Dealers.Contracts;
using CarRentingSystem.Infrastructure.Extensions;

using static CarRentingSystem.WebConstants;

namespace CarRentingSystem.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IDealersService dealersService;
        private readonly IMapper mapper;

        public CarsController(ICarsService carsService, IDealersService dealersService, IMapper mapper)
        {
            this.carsService = carsService;
            this.dealersService = dealersService;
            this.mapper = mapper;
        }

        public IActionResult All([FromQuery]AllCarsQueryModel queryModel)
        {
            var queryResult = this.carsService.All(
                queryModel.Make,
                queryModel.SearchTerm,
                queryModel.Sorting,
                AllCarsQueryModel.CarsPerPage,
                queryModel.CurrentPage, 
                true);

            var carMakes = this.carsService.GetAllMakes();

            queryModel.Cars = queryResult.Cars;
            queryModel.TotalCars = queryResult.TotalCars;
            queryModel.Makes = carMakes;

            return this.View(queryModel);
        }

        public IActionResult Details(int id, string information)
        {
            var car = this.carsService.Details(id);

            if (car.GetInformation() != information)
            {
                return this.BadRequest();
            }

            return this.View(car);
        }

        [Authorize]
        public IActionResult Mine()
        {
            var myCars = this.carsService.ByUser(this.User.GetId());

            return this.View(myCars);
        }

        [Authorize]
        public IActionResult Create() 
        {
            if (!this.dealersService.IsDealer(this.User.GetId()) && !this.User.IsAdmin())
            {
                return this.RedirectToAction("Create", "Dealers");
            }

            return this.View(new CarFormModel
            {
                Categories = this.carsService.GetAllCategories(),
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CarFormModel car)
        {
            var dealerId = this.dealersService.GetIdByUser(this.User.GetId());

            if (!dealerId.HasValue)
            {
                return this.RedirectToAction("Create", "Dealers");
            }

            if (!this.carsService.CategoryExists(car.CategoryId))
            {
                ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = this.carsService.GetAllCategories();

                return this.View(car);
            }

            var carId = this.carsService.Create(
                car.Make,
                car.Model,
                car.Description,
                car.ImageUrl,
                car.Year,
                car.CategoryId,
                dealerId.Value);

            this.TempData[GlobalMessageKey] = "You created a car successfully!";

            return this.RedirectToAction("Details", new { id = carId, information = car.GetInformation() });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.GetId();

            if (!this.dealersService.IsDealer(userId) && !this.User.IsAdmin())
            {
                return this.RedirectToAction("Create", "Dealers");
            }

            var car = this.carsService.Details(id);
            if (car.UserId != userId && !this.User.IsAdmin())
            {
                return this.Unauthorized();
            }

            var carForm = this.mapper.Map<CarFormModel>(car);
            carForm.Categories = this.carsService.GetAllCategories();

            return this.View(carForm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, CarFormModel car)
        {
            var dealerId = this.dealersService.GetIdByUser(this.User.GetId());

            if (!dealerId.HasValue && !this.User.IsAdmin())
            {
                return this.RedirectToAction("Create", "Dealers");
            }

            if (!this.carsService.CategoryExists(car.CategoryId))
            {
                ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = this.carsService.GetAllCategories();

                return this.View(car);
            }

            if (this.dealersService.GetIdByUser(this.User.GetId()) != dealerId.Value && !this.User.IsAdmin())
            {
                return this.BadRequest();
            }

            var carIsEdited = this.carsService.Edit(
                id,
                car.Make,
                car.Model,
                car.Description,
                car.ImageUrl,
                car.Year,
                car.CategoryId,
                dealerId.Value,
                this.User.IsAdmin());

            if (!carIsEdited)
            {
                return this.BadRequest();
            }

            this.TempData[GlobalMessageKey] = "You edited a car successfully!";

            return this.RedirectToAction("Details", new { id = id, information = car.GetInformation() });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var dealerId = this.dealersService.GetIdByUser(this.User.GetId());

            if (!dealerId.HasValue && !this.User.IsAdmin())
            {
                return this.RedirectToAction("Create", "Dealers");
            }

            var carIsDeleted = this.carsService.Delete(id);

            if (!carIsDeleted)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction("All");
        }
    }
}