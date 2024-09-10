using MyWebServer.App.Controllers;
using MyWebServer.App.Data;
using MyWebServer.App.Data.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using MyWebServer.Results.Views.Contracts;

namespace MyWebServer.App
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            var server = HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers()
                    .MapGet<HomeController>("/YouTube", c => c.ToYouTube())
                    .MapGet<HomeController>("/ToCats", c => c.LocalRedirectToCats()))
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IData, MyDbContext>());

            await server.Start();
        }
    }
}