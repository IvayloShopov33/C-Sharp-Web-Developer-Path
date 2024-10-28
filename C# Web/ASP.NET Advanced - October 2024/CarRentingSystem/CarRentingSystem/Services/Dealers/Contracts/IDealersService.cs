using CarRentingSystem.Models.Dealers;

namespace CarRentingSystem.Services.Dealers.Contracts
{
    public interface IDealersService
    {
        void CreateDealer(CreateDealerFormModel dealerModel, string userId);

        bool IsDealer(string userId);

        int? GetIdByUser(string userId);
    }
}