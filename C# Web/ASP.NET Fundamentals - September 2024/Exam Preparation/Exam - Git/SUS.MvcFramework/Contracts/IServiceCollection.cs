using System;

namespace SUS.MvcFramework.Contracts
{
    public interface IServiceCollection
    {
        void Add<TSource, TDestination>();

        object CreateInstance(Type type);
    }
}