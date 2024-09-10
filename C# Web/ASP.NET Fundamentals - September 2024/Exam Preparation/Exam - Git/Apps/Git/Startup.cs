namespace Git
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using SUS.HTTP;
    using Git.Services;
    using Git.Services.Contracts;
    using SUS.MvcFramework.Contracts;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UserService>();
            serviceCollection.Add<IPasswordHasher, PasswordHasher>();
            serviceCollection.Add<IValidator,  Validator>();
            serviceCollection.Add<ApplicationDbContext, ApplicationDbContext>();
        }
    }
}
