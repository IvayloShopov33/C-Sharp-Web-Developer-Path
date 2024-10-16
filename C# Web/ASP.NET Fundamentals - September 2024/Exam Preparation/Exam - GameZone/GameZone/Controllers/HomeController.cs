using System.Diagnostics;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using GameZone.Models;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(this.User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return this.RedirectToAction("All", "Game");
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
