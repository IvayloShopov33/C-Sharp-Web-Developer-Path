using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ParkingSystem.Controllers
{
    public class CarController : Controller
    {
        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            Match match = Regex.Match(car.PlateNumber, @"^(?<region>[A-Z]{1,2})(?:[A-Z0-9]{6})$");
            if (car.CarMake.Length>0 && car.PlateNumber.Length>0 && match.Success)
            {
                DataAccess.Cars.Add(car);
            }
                return Redirect("/");
            
        }
        [HttpPost]
        public IActionResult DeleteCar(string plateNumber)
        {
            Car car = DataAccess.Cars.FirstOrDefault(x => x.PlateNumber == plateNumber);
            DataAccess.Cars.Remove(car);
            return Redirect("/");
        }
    }
}
