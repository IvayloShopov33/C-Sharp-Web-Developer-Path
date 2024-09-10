using Microsoft.EntityFrameworkCore;

using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using MyWebServer.Results.Views.Contracts;

using CarShop.Data;
using CarShop.Services.Contracts;
using CarShop.Services;

namespace CarShop
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            var server = HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IValidator, Validator>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IUserService, UserService>()
                    .Add<CarShopDbContext>())
                .WithConfiguration<CarShopDbContext>(context => context.Database.Migrate());

            await server.Start();
        }
    }
}