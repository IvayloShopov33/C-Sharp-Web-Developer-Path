using CarRentingSystem.Data;
using CarRentingSystem.Data.Models;
using CarRentingSystem.Models.Dealers;
using CarRentingSystem.Services.Dealers.Contracts;

namespace CarRentingSystem.Services.Dealers
{
    public class DealersService : IDealersService
    {
        private readonly ApplicationDbContext dbContext;

        public DealersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateDealer(CreateDealerFormModel dealerModel, string userId)
        {
            var dealer = new Dealer
            {
                Name = dealerModel.Name,
                PhoneNumber = dealerModel.PhoneNumber,
                UserId = userId,
            };

            this.dbContext.Dealers.Add(dealer);
            this.dbContext.SaveChanges();
        }

        public bool IsDealer(string userId)
            => this.dbContext.Dealers
                .Any(x => x.UserId == userId);

        public int? GetIdByUser(string userId)
            => this.dbContext.Dealers
                .Where(x => x.UserId == userId)
                .Select(x => x.Id)
                .FirstOrDefault();
    }
}