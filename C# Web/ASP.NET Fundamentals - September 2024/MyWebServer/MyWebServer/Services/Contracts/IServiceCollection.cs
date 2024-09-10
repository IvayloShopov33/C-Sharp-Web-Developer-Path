namespace MyWebServer.Services.Contracts
{
    public interface IServiceCollection
    {
        IServiceCollection Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService;

        IServiceCollection Add<TService>()
            where TService : class;

        TService GetService<TService>() 
            where TService : class;

        object CreateInstance(Type type);
    }
}