using MyWebServer.Controllers;
using MyWebServer.Results;

using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Cars;
using CarShop.Services.Contracts;

namespace CarShop.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly CarShopDbContext dbContext;
        private readonly IUserService userService;

        public CarsController(IValidator validator, CarShopDbContext dbContext, IUserService userService)
        {
            this.validator = validator;
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public ActionResult Add()
        {
            if (this.userService.IsMechanic(this.User.Id))
            {
                return this.Unauthorized();
            }

            return this.View();
        }

        [HttpPost]
        public ActionResult Add(AddCarFormModel model)
        {
            if (this.userService.IsMechanic(this.User.Id))
            {
                return this.Unauthorized();
            }

            var modelErrors = this.validator.ValidateCarAddition(model);
            if (modelErrors.Any())
            {
                return this.Error(modelErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id,
            };

            this.dbContext.Cars.Add(car);
            this.dbContext.SaveChanges();

            return this.Redirect("/Cars/All");
        }

        public ActionResult All()
        {
            var carsQuery = this.dbContext.Cars.AsQueryable();

            if (this.userService.IsMechanic(this.User.Id))
            {
                carsQuery = carsQuery.Where(x => x.Issues.Any(y => !y.IsFixed));
            }
            else
            {
                carsQuery = carsQuery.Where(x => x.OwnerId == this.User.Id);
            }

            var cars = carsQuery
                    .Select(x => new CarListingViewModel
                    {
                        Id = x.Id,
                        Model = x.Model,
                        Year = x.Year,
                        Image = x.PictureUrl,
                        PlateNumber = x.PlateNumber,
                        FixedIssues = x.Issues.Count(y => y.IsFixed),
                        RemainingIssues = x.Issues.Count(y => !y.IsFixed),
                    })
                    .ToList();

            return this.View(cars);
        }

        public ActionResult Delete(string carId)
        {
            var car = this.dbContext.Cars.FirstOrDefault(x => x.Id == carId);
            if (car == null)
            {
                return this.Error("Car with this id does not exist.");
            }

            if (car.OwnerId != this.User.Id)
            {
                return this.Error("This car is not yours. You cannot delete it.");
            }

            this.dbContext.Cars.Remove(car);
            this.dbContext.SaveChanges();

            return this.Redirect("/Cars/All");
        }
    }
}