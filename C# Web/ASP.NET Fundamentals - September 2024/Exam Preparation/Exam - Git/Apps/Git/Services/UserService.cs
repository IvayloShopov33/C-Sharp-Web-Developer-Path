using System.Linq;

using Git.Data;
using Git.Data.Models;
using Git.Services.Contracts;

namespace Git.Services
{
    public class UserService : IUsersService
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext, IPasswordHasher passwordHasher)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.passwordHasher.HashPassword(password),
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

            return user?.Id;
        }

        public string GetUserId(string username, string password)
        {
            var hashedPassword = this.passwordHasher.HashPassword(password);

            var user = this.dbContext.Users
                .FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);

            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return this.dbContext.Users
                .Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return this.dbContext.Users
                .Any(x => x.Username == username);
        }
    }
}