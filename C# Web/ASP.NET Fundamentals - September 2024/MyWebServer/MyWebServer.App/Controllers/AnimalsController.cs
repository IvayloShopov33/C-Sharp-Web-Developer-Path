using MyWebServer.App.Models.Animals;
using MyWebServer.Controllers;
using MyWebServer.Results;

namespace MyWebServer.App.Controllers
{
    public class AnimalsController : Controller
    {
        public ActionResult Cats()
        {
            const string nameKey = "name";
            const string ageKey = "age";

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey)
                ? query[nameKey]
                : "the cats squad";

            var catAge = query.ContainsKey(ageKey)
                ? int.Parse(query[ageKey])
                : 0;

            var viewModel = new CatViewModel
            {
                Name = catName,
                Age = catAge,
            };

            return this.View(viewModel);
        }

        public ActionResult Turtles() => this.View();

        public ActionResult Bunnies() => this.View("Rabbits");

        public ActionResult Dogs() => this.View(new DogViewModel
        {
            Name = "Rexi",
            Age = 5,
            Breed = "Golden Retriever",
        }, "Animals/Dogs");
    }
}