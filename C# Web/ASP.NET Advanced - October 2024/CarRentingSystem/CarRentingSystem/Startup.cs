using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using CarRentingSystem.Data;
using CarRentingSystem.Services.Statistics.Contracts;
using CarRentingSystem.Services.Statistics;
using CarRentingSystem.Services.Cars.Contracts;
using CarRentingSystem.Services.Cars;
using CarRentingSystem.Services.Dealers.Contracts;
using CarRentingSystem.Services.Dealers;
using CarRentingSystem.Data.Models;
using CarRentingSystem.Infrastructure.Extensions;

namespace CarRentingSystem
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAutoMapper(typeof(Startup));
            builder.Services.AddMemoryCache();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            builder.Services.AddTransient<IStatisticsService, StatisticsService>();
            builder.Services.AddTransient<ICarsService, CarsService>();
            builder.Services.AddTransient<IDealersService, DealersService>();

            var app = builder.Build();

            app.PrepareDatabase();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "Car Details",
                        pattern: "/Cars/Details/{id}/{information}",
                        defaults: new { controller = "Cars", action = "Details" });

                    endpoints.MapControllerRoute(
                        name: "Admins",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                });

            app.Run();
        }
    }
}