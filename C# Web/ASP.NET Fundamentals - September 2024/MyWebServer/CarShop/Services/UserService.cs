using CarShop.Data;
using CarShop.Services.Contracts;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly CarShopDbContext dbContext;

        public UserService(CarShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsMechanic(string userId)
            => this.dbContext.Users
                .Any(x => x.Id == userId && x.IsMechanic);
    }
}