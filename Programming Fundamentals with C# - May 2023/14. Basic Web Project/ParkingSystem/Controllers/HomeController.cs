﻿using Microsoft.AspNetCore.Mvc;

namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View(Data.DataAccess.Cars);
        }
    }
}
