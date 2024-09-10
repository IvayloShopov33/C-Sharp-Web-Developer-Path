using System.Linq;

using SUS.HTTP;
using SUS.MvcFramework;

using Git.Data;
using Git.Services.Contracts;
using Git.ViewModels.Users;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IValidator validator;
        private readonly ApplicationDbContext dbContext;

        public UsersController(IUsersService usersService, IValidator validator, ApplicationDbContext dbContext)
        {
            this.usersService = usersService;
            this.validator = validator;
            this.dbContext = dbContext;
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Error("You are already logged in your account. You cannot access this page.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var errors = this.validator.ValidateUser(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            if (this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error($"There is already a user with the username {model.Username}.");
            }

            if (this.usersService.IsEmailAvailable(model.Email))
            {
                return this.Error($"There is already a user with the email {model.Email}.");
            }

            this.usersService.CreateUser(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Error("You are already logged in your account. You cannot access this page.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var userId = this.usersService.GetUserId(model.Username, model.Password);

            if (userId == null)
            {
                return this.Error("Username and password combination is invalid.");
            }

            this.SignIn(userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("You are not logged in your account. You cannot access this page.");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}