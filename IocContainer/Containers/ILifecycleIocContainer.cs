namespace IocContainer.Containers
{
    public interface ILifecycleIocContainer : IIocContainer
    {
        void Register<TInterface, TImplementation>(LifeCycle lifecycle)
            where TImplementation : TInterface; //Can't force TInterface to actually be an interface here; needs to be in the implementation
    }
}