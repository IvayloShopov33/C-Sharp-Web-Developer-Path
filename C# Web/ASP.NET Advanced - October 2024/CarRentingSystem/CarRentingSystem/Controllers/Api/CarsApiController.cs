using Microsoft.AspNetCore.Mvc;

using CarRentingSystem.Models.Api.Cars;
using CarRentingSystem.Services.Cars.Contracts;
using CarRentingSystem.Services.Cars;

namespace CarRentingSystem.Controllers.Api
{
    [ApiController]
    [Route("/api/cars")]
    public class CarsApiController : ControllerBase
    {
        private readonly ICarsService carsService;

        public CarsApiController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        [HttpGet]
        public ActionResult<CarQueryServiceModel> All([FromQuery] AllCarsApiRequestModel queryModel)
            => this.carsService.All(queryModel.Make, 
                queryModel.SearchTerm, 
                queryModel.Sorting, 
                queryModel.CarsPerPage, 
                queryModel.CurrentPage);
    }
}