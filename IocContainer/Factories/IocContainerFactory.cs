using IocContainer.Containers;
using System;

namespace IocContainer.Factories
{
  class IocContainerFactory
  {
    public static ISpecificLifecycleContainer CreateLifecycleSpecificIocContainer(Lifecycle lifecycle)
    {
      switch (lifecycle)
      {
        case Lifecycle.Singleton:
          return new SingletonIocContainer();
        case Lifecycle.Transient:
          return new TransientIocContainer();
        default:
          throw new NotImplementedException($"{lifecycle.ToString()} IoCContainer Lifecycle not implemented.");
      }
    }
  }
}
