using System;

namespace IocContainer.Containers
{
  public interface IIocContainer
  {
    void Register<TTarget>() where TTarget : class;
    void Register<TInterface, TImplementation>() where TImplementation : class, TInterface;
    TTarget Resolve<TTarget>();
    object Resolve(Type target);
    bool CanResolve(Type target);
  }
}