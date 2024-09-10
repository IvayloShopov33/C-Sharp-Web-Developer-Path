using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Issues;
using CarShop.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Results;

namespace CarShop.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly IUserService userService;
        private readonly CarShopDbContext dbContext;
        private readonly IValidator validator;

        public IssuesController(IUserService userService, CarShopDbContext dbContext, IValidator validator)
        {
            this.userService = userService;
            this.dbContext = dbContext;
            this.validator = validator;
        }


        public ActionResult CarIssues(string carId)
        {
            if (!this.userService.IsMechanic(this.User.Id))
            {
                var userHasCar = this.dbContext.Cars
                    .Any(x => x.Id == carId);

                if (!userHasCar)
                {
                    return this.Error("You do not have access to this car.");
                }
            }

            var carWithIssues = this.dbContext.Cars
                .Where(x => x.Id == carId)
                .Select(x => new CarIssuesViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    UserIsMechanic = this.userService.IsMechanic(this.User.Id),
                    Issues = x.Issues
                        .Select(y => new IssueListingViewModel
                        {
                            Id = y.Id,
                            Description = y.Description,
                            IsFixedInfo = y.IsFixed
                                ? "Yes"
                                : "Not Yet",
                        }),
                })
                .FirstOrDefault();

            if (carWithIssues == null)
            {
                return this.Error($"Car with Id {carWithIssues.Id} does not exist.");
            }

            return this.View(carWithIssues);
        }

        public ActionResult Add(string carId)
        {
            return this.View(new AddIssueFormModel { CarId = carId });
        }

        [HttpPost]
        public ActionResult Add(AddIssueFormModel model)
        {
            var modelErrors = this.validator.ValidateIssueAddition(model);
            if (modelErrors.Any())
            {
                return this.Error(modelErrors);
            }

            var issue = new Issue
            {
                Description = model.Description,
                CarId = model.CarId,
                IsFixed = false,
            };

            this.dbContext.Issues.Add(issue);
            this.dbContext.SaveChanges();

            return this.Redirect($"/Issues/CarIssues?carId={issue.CarId}");
        }

        public ActionResult Fix(string issueId, string CarId)
        {
            if (!this.userService.IsMechanic(this.User.Id))
            {
                return this.Error("You are not a mechanic. You do not have access to this feature.");
            }

            var carIssue = this.dbContext.Cars
                .Where(x => x.Id == CarId)
                .Select(x => x.Issues.FirstOrDefault(y => y.Id == issueId))
                .FirstOrDefault();

            if (carIssue == null)
            {
                return this.Error("The issue is not found.");
            }

            carIssue.IsFixed = true;
            this.dbContext.SaveChanges();

            return this.Redirect($"/Issues/CarIssues?carId={CarId}");
        }

        public ActionResult Delete(string issueId, string CarId)
        {
            var carIssue = this.dbContext.Cars
                .Where(x => x.Id == CarId)
                .Select(x => x.Issues.FirstOrDefault(y => y.Id == issueId))
                .FirstOrDefault();

            if (carIssue == null)
            {
                return this.Error("The issue is not found.");
            }

            this.dbContext.Issues.Remove(carIssue);
            this.dbContext.SaveChanges();

            return this.Redirect($"/Issues/CarIssues?carId={CarId}");
        }
    }
}