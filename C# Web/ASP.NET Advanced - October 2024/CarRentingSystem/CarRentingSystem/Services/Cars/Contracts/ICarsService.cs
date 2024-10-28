using CarRentingSystem.Models.Cars.Enums;

namespace CarRentingSystem.Services.Cars.Contracts
{
    public interface ICarsService
    {
        CarQueryServiceModel All(string make = null, string searchTerm = null, CarSorting sorting = CarSorting.Year, int carsPerPage = int.MaxValue, int currentPage = 1, bool isPublic = false);

        IEnumerable<CarServiceModel> Latest();

        DetailsCarServiceModel Details(int id);

        int Create(
            string make,
            string model,
            string description,
            string imageUrl,
            int year,
            int categoryId,
            int dealerId);

        bool Edit(
            int id,
            string make,
            string model,
            string description,
            string imageUrl,
            int year,
            int categoryId,
            int dealerId,
            bool isPublic = false);

        bool Delete(int id);

        void ChangeVisibility(int carId);

        IEnumerable<CarServiceModel> ByUser(string userId);

        IEnumerable<string> GetAllMakes();

        ICollection<CarCategoryServiceModel> GetAllCategories();

        bool CategoryExists(int categoryId);
    }
}