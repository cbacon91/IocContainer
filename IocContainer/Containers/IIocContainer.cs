using System;

namespace IocContainer.Containers
{
    public interface IIocContainer
    {
        void Register<TTarget>(); //Registers a type to enable DI

        void Register<TInterface, TImplementation>()
            where TImplementation : class, TInterface; //Can't force TInterface to actually be an interface here; needs to be in the implementation
        TTarget Resolve<TTarget>();
        object Resolve(Type target);
        bool CanResolve(Type target);
    }
}