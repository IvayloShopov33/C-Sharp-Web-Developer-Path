using SUS.HTTP;
using System.Collections.Generic;

namespace SUS.MvcFramework.Contracts
{
    public interface IMvcApplication
    {
        void ConfigureServices(IServiceCollection serviceCollection);

        void Configure(List<Route> routeTable);
    }
}