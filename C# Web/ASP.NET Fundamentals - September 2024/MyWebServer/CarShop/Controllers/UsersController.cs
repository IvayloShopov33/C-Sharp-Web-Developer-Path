using MyWebServer.Controllers;
using MyWebServer.Results;

using CarShop.Data.Models;
using CarShop.Models.Users;
using CarShop.Services.Contracts;

using static CarShop.Data.ModelsValidationConstraints;
using CarShop.Data;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly CarShopDbContext dbContext;

        public UsersController(IValidator validator, IPasswordHasher passwordHasher, CarShopDbContext dbContext)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.dbContext = dbContext;
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUserRegistration(model);

            if (this.dbContext.Users.Any(x => x.UserName == model.UserName))
            {
                modelErrors.Add($"Username {model.UserName} already exists.");
            }

            if (this.dbContext.Users.Any(x => x.Email == model.Email))
            {
                modelErrors.Add($"User with email {model.Email} already exists.");
            }

            if (modelErrors.Any())
            {
                return this.Error(modelErrors);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password),
                IsMechanic = model.UserType == UserTypeMechanic,
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

            return this.Redirect("/Users/Login");
        }

        public ActionResult Login() => this.View();

        [HttpPost]
        public ActionResult Login(LoginUserFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);
            var userId = this.dbContext.Users
                .Where(x => x.UserName == model.UserName && x.Password == hashedPassword)
                .Select(x => x.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return this.Error("Login is not valid.");
            }

            this.SignIn(userId);

            return this.Redirect("/Cars/All");
        }

        public ActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}