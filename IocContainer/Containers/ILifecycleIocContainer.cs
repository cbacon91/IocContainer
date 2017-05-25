namespace IocContainer.Containers
{
    public interface ILifecycleIocContainer : IIocContainer
    {
        void Register<TTarget>(Lifecycle lifecycle); //Registers a type to enable DI

        void Register<TInterface, TImplementation>(Lifecycle lifecycle)
            where TImplementation : class, TInterface; //Can't force TInterface to actually be an interface here; needs to be in the implementation
    }
}