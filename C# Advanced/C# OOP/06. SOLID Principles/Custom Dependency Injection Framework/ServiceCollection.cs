namespace Dependency_Injection_Framework
{
    public class ServiceCollection
    {
        private Dictionary<Type, Type> mappings;
        private Dictionary<Type, Func<IServiceProvider, object>> mappingsWithFactories;

        public ServiceCollection()
        {
            this.mappings = new Dictionary<Type, Type>();
            this.mappingsWithFactories = new Dictionary<Type, Func<IServiceProvider, object>>();
        }

        public void AddSingleton(Type interfaceType, Type implementationType)
        {
            this.mappings.Add(interfaceType, implementationType);
        }

        public void AddSingleton<TInterface, TImplementation>()
        {
            AddSingleton(typeof(TInterface), typeof(TImplementation));
        }

        public void AddSingleton(Type interfaceType, Func<IServiceProvider, object> factory)
        {
            this.mappingsWithFactories.Add(interfaceType, factory);
        }

        public void AddSingleton<TInterface>(Func<IServiceProvider, object> factory)
        {
            AddSingleton(typeof(TInterface), factory);
        }

        public Type GetMapping(Type interfaceType)
        {
            if (!this.mappings.ContainsKey(interfaceType))
            {
                return null;
            }

            return this.mappings[interfaceType];
        }

        public Func<IServiceProvider, object> GetFactoryMapping(Type interfaceType)
        {
            if (!this.mappingsWithFactories.ContainsKey(interfaceType))
            {
                return null;
            }

            return this.mappingsWithFactories[interfaceType];
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(this);
        }
    }
}
