using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using Quiz.Services.Contracts;
using Quiz.Web.Models;

namespace Quiz.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuizService quizService;

        public HomeController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userName = this.User.Identity?.Name;
            var userQuizzes = this.quizService.GetQuizzesByUserName(userName);

            return View(userQuizzes);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}