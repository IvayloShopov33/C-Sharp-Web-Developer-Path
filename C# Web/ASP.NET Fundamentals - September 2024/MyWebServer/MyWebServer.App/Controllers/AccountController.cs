using MyWebServer.Controllers;
using MyWebServer.Results;

namespace MyWebServer.App.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            var someUserId = "MyUserId";

            this.SignIn(someUserId);

            return this.Text("User is authenticated successfully.");
        }

        public ActionResult Logout()
        {
            this.SignOut();

            return this.Text("User signed out successfully.");
        }       

        public ActionResult AuthenticatedAction()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Text("User is not authenticated.");
            }

            return this.Text($"Authenticated user: {this.User.Id}.");
        }

        [Authorize]
        public ActionResult AuthorizationCheck()
        {
            return this.Text($"Current user: {this.User.Id}");
        }

        public ActionResult ActionWithCookies()
        {
            const string cookieName = "My-First-Cookie";

            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return this.Text($"Cookies already exist - {cookie}");
            }

            this.Response.Cookies.Add(cookieName, "My-First-Value");
            this.Response.Cookies.Add("My-Second-Cookie", "My-Second-Value");

            return this.Text("Cookies set!");
        }

        public ActionResult ActionWithSession()
        {
            const string currentDateKey = "CurrentDate";

            if (this.Request.Session.ContainsKey(currentDateKey))
            {
                return this.Text($"Stored date: {this.Request.Session[currentDateKey]}");
            }

            this.Request.Session[currentDateKey] = DateTime.UtcNow.ToString();

            return this.Text("Date stored.");
        }
    }
}