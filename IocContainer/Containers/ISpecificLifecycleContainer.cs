using System;

namespace IocContainer.Containers
{
    /// <summary>
    /// IoC container representing a specific lifecycle type.
    /// </summary>
    public interface ISpecificLifecycleContainer : IIocContainer
    {
        object Resolve(Type target, Func<Type, bool> otherLifecycleCanResolveCallback, Func<Type, object> otherLifecycleResolveCallback); 
    }
}