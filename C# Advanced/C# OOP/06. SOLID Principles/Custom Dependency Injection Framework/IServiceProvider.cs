namespace Dependency_Injection_Framework
{
    public interface IServiceProvider
    {
        public T GetRequiredService<T>();

        public object GetRequiredService(Type type);
    }
}
