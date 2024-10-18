using Microsoft.AspNetCore.Mvc;
using SeminarHub.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(this.User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return this.RedirectToAction("All", "Seminar");
            }

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}