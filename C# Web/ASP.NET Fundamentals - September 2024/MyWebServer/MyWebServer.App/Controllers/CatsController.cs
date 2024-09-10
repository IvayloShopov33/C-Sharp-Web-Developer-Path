using MyWebServer.App.Data;
using MyWebServer.App.Data.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Results;

namespace MyWebServer.App.Controllers
{
    public class CatsController : Controller
    {
        private readonly IData data;

        public CatsController(IData data)
            => this.data = data;

        [HttpGet]
        public ActionResult Create() => this.View();

        [HttpPost]
        public ActionResult Save(string name, string age) => this.Text($"{name} - {age} years old");

        [HttpGet]
        public ActionResult All()
        {
            var cats = this.data.Cats.ToList();

            return this.View(cats);
        }
    }
}