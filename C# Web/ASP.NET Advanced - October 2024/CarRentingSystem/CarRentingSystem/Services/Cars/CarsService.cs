using AutoMapper;
using AutoMapper.QueryableExtensions;

using CarRentingSystem.Data;
using CarRentingSystem.Data.Models;
using CarRentingSystem.Models.Cars.Enums;
using CarRentingSystem.Services.Cars.Contracts;

namespace CarRentingSystem.Services.Cars
{
    public class CarsService : ICarsService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public CarsService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public CarQueryServiceModel All(string make = null, string searchTerm = null, CarSorting sorting = CarSorting.Year, int carsPerPage = int.MaxValue, int currentPage = 1, bool isPublic = false)
        {               
            var carsQuery = this.dbContext.Cars.AsQueryable();
            if (isPublic)
            {
               carsQuery = carsQuery.Where(x => x.IsPublic);
            }

            if (!string.IsNullOrWhiteSpace(make))
            {
                carsQuery = carsQuery.Where(x => x.Make == make);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                carsQuery = carsQuery
                    .Where(x => (x.Make + " " + x.Model).ToLower().Contains(searchTerm.ToLower()) ||
                    x.Description.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Year.ToString().ToLower().Contains(searchTerm.ToLower()));
            }

            carsQuery = sorting switch
            {
                CarSorting.Year => carsQuery.OrderByDescending(x => x.Year),
                CarSorting.MakeAndModel => carsQuery.OrderBy(x => x.Make).ThenBy(x => x.Model),
                CarSorting.CreatedOn or _ => carsQuery.OrderBy(x => x.Id),
            };

            var cars = this.GetCars(carsQuery
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .OrderByDescending(x => x.Year));

            return new CarQueryServiceModel
            {
                Cars = cars,
                TotalCars = cars.Count,
                CurrentPage = currentPage,
            };
        }

        public IEnumerable<CarServiceModel> Latest()
            => this.dbContext.Cars
                .Where(x => x.IsPublic)
                .OrderByDescending(x => x.Year)
                .ProjectTo<CarServiceModel>(this.mapper.ConfigurationProvider)
                .Take(this.dbContext.Cars.Count() >= 3 ? 3 : this.dbContext.Cars.Count());

        public DetailsCarServiceModel Details(int id)
            => this.dbContext.Cars
                .Where(x => x.Id == id)
                .ProjectTo<DetailsCarServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public int Create(
            string make,
            string model,
            string description,
            string imageUrl,
            int year,
            int categoryId,
            int dealerId)
        {
            var newCar = new Car
            {
                Make = make,
                Model = model,
                Description = description,
                ImageUrl = imageUrl,
                Year = year,
                CategoryId = categoryId,
                DealerId = dealerId,
                IsPublic = false,
            };

            this.dbContext.Cars.Add(newCar);
            this.dbContext.SaveChanges();

            return newCar.Id;
        }

        public bool Edit(
            int id,
            string make,
            string model,
            string description,
            string imageUrl,
            int year,
            int categoryId,
            int dealerId, 
            bool isPublic = false)
        {
            var carToEdit = this.dbContext.Cars.Find(id);

            if (carToEdit == null)
            {
                return false;
            }

            carToEdit.Make = make;
            carToEdit.Model = model;
            carToEdit.Description = description;
            carToEdit.ImageUrl = imageUrl;
            carToEdit.Year = year;
            carToEdit.CategoryId = categoryId;
            carToEdit.IsPublic = isPublic;

            this.dbContext.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var carToDelete = this.dbContext.Cars.Find(id);

            if (carToDelete == null)
            {
                return false;
            }

            this.dbContext.Cars.Remove(carToDelete);
            this.dbContext.SaveChanges();

            return true;
        }

        public void ChangeVisibility(int carId)
        {
            var car = this.dbContext.Cars.Find(carId);
            if (car == null)
            {
                throw new ArgumentException("Invalid id.");
            }

            car.IsPublic = !car.IsPublic;
            this.dbContext.SaveChanges();
        }

        public IEnumerable<CarServiceModel> ByUser(string userId)
            => this.GetCars(this.dbContext.Cars
                .Where(x => x.Dealer.UserId == userId));

        public IEnumerable<string> GetAllMakes()
            => this.dbContext.Cars
                .Select(x => x.Make)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

        public ICollection<CarCategoryServiceModel> GetAllCategories()
            => this.dbContext.Categories
                .ProjectTo<CarCategoryServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

        public bool CategoryExists(int categoryId)
            => this.dbContext.Categories.Any(x => x.Id == categoryId);

        private ICollection<CarServiceModel> GetCars(IQueryable<Car> carsQuery)
            => carsQuery
                .ProjectTo<CarServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
    }
}