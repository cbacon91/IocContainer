namespace IocContainer.Containers
{
    /// <summary>
    /// IoC container where the client can call the specific lifecycle with which to register elements 
    /// </summary>
    public interface ISelectableLifecycleIocContainer : IIocContainer
    {
        void Register<TTarget>(Lifecycle lifecycle) where TTarget : class;

        void Register<TInterface, TImplementation>(Lifecycle lifecycle) where TImplementation : class, TInterface; 
    }
}