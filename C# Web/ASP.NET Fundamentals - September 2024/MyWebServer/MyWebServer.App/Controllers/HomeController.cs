using MyWebServer.Controllers;
using MyWebServer.Results;

namespace MyWebServer.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
            => this.Text("Hello from Ivaylo G!");

        public ActionResult LocalRedirectToCats() => this.Redirect("/Animals/Cats");

        public ActionResult ToYouTube() => this.Redirect("https://www.youtube.com/");

        public ActionResult StaticFiles() => this.View();

        public ActionResult Error() => throw new InvalidOperationException("Invalid action!");
    }
}