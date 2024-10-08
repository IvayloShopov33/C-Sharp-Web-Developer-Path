﻿using MyWebServer.Services.Contracts;

namespace MyWebServer.Services
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly Dictionary<Type, Type> services;

        public ServiceCollection()
        {
            this.services = new();
        }

        public IServiceCollection Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService
        {
            this.services[typeof(TService)] = typeof(TImplementation);

            return this;
        }

        public IServiceCollection Add<TService>()
            where TService : class
            => this.Add<TService, TService>();

        public TService GetService<TService>()
            where TService : class
        {
            var typeOfService = typeof(TService);

            if (!this.services.ContainsKey(typeOfService))
            {
                return null;
            }

            var implementationType = this.services[typeOfService];

            return (TService)this.CreateInstance(implementationType);
        }

        public object CreateInstance(Type type)
        {
            if (this.services.ContainsKey(type))
            {
                type = this.services[type];
            }
            else if (type.IsInterface)
            {
                throw new InvalidOperationException($"Service {type.FullName} is not registered.");
            }

            var constructors = type.GetConstructors();

            if (constructors.Length > 1) 
            {
                throw new InvalidOperationException("Multiple constructors are not supported.");
            }

            var constructor = constructors.First();

            var parameters = constructor.GetParameters();
            var parameterValues = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++) 
            {
                var parameterValue = this.CreateInstance(parameters[i].ParameterType);
                parameterValues[i] = parameterValue;
            }

            return Activator.CreateInstance(type, parameterValues);
        }
    }
}