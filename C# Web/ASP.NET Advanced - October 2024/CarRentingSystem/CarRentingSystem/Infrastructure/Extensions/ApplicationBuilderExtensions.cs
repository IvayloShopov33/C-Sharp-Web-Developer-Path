using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using CarRentingSystem.Data;
using CarRentingSystem.Data.Models;

using static CarRentingSystem.WebConstants;

namespace CarRentingSystem.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        const string adminEmail = "admin@crs.com";

        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;
            var db = scopedServices.ServiceProvider.GetService<ApplicationDbContext>();

            db.Database.Migrate();

            if (!db.Categories.Any())
            {
                SeedCategories(db);
            }

            if (!db.Users.Any(x => x.Email == adminEmail))
            {
                SeedAdministratorRole(serviceProvider);
            }

            return app;
        }

        private static void SeedCategories(ApplicationDbContext dbContext)
        {
            dbContext.Categories.AddRange(new[]
            {
                new Category { Name = "Mini" },
                new Category { Name = "Economy" },
                new Category { Name = "Midsize" },
                new Category { Name = "SUV" },
                new Category { Name = "Vans" },
                new Category { Name = "Luxury" },
            });

            dbContext.SaveChanges();
        }

        private static void SeedAdministratorRole(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    await roleManager.CreateAsync(new IdentityRole
                    {
                        Name = AdministratorRoleName,
                    });

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin",
                    };

                    await userManager.CreateAsync(user, "admin21");
                    await userManager.AddToRoleAsync(user, AdministratorRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}