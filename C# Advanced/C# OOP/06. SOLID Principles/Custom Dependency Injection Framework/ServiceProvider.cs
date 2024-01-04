using System.Reflection;

namespace Dependency_Injection_Framework
{
    public class ServiceProvider : IServiceProvider
    {
        private ServiceCollection collection;

        public ServiceProvider(ServiceCollection collection)
        {
            this.collection = collection;
        }

        public T GetRequiredService<T>()
        {
            return (T)GetRequiredService(typeof(T));
        }

        public object GetRequiredService(Type interfaceType)
        {
            Func<IServiceProvider, object> factory = this.collection.GetFactoryMapping(interfaceType);

            if (factory != null)
            {
                return factory(this);
            }

            Type implementationType = this.collection.GetMapping(interfaceType);
            ConstructorInfo constructorInfo = implementationType.GetConstructors().OrderBy(x => x.GetParameters().Length).First();
            object[] parameters = new object[constructorInfo.GetParameters().Length];
            int index = 0;

            foreach (ParameterInfo parameter in constructorInfo.GetParameters())
            {
                parameters[index++] = GetRequiredService(parameter.ParameterType);
            }

            object implementation = Activator.CreateInstance(implementationType, parameters);

            return implementation;
        }
    }
}
