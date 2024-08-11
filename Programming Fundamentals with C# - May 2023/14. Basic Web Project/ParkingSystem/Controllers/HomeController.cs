using Microsoft.AspNetCore.Mvc;

namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Data.DataAccess.Cars);
        }
    }
}
