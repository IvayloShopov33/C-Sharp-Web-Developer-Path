using MyWebServer.App.Models.Animals;
using MyWebServer.Controllers;
using MyWebServer.Results;

namespace MyWebServer.App.Controllers
{
    public class DogsController : Controller
    {
        [HttpGet]
        public ActionResult Create() => this.View();

        [HttpPost]
        public ActionResult Save(DogFormModel dog) => this.Text($"My name is {dog.Name}! I am {dog.Age} years old and my breed is {dog.Breed}!");
    }
}