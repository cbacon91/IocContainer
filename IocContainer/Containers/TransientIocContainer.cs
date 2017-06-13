using IocContainer.Exceptions;
using System;
using System.Collections.Generic;

namespace IocContainer.Containers
{
  class TransientIocContainer : IocContainerBase, ISpecificLifecycleContainer
  {
    private Dictionary<Type, Type> _resolutionTypes = new Dictionary<Type, Type>();

    public override bool CanResolve(Type targetType) => _resolutionTypes.ContainsKey(targetType);

    public override void Register<TTarget>()
    {
      if (_resolutionTypes.ContainsKey(typeof(TTarget)))
        throw new TypeAlreadyRegisteredException(typeof(TTarget));

      _resolutionTypes.Add(typeof(TTarget), typeof(TTarget));
    }

    public override void Register<TInterface, TImplementation>()
    {
      if (_resolutionTypes.ContainsKey(typeof(TInterface)))
        throw new TypeAlreadyRegisteredException(typeof(TInterface));

      _resolutionTypes.Add(typeof(TInterface), typeof(TImplementation));
    }

    public override object Resolve(Type targetType) => Resolve(targetType, CanResolve, Resolve);

    public object Resolve(Type targetType, Func<Type, bool> otherLifecycleCanResolveCallback, Func<Type, object> otherLifecycleResolveCallback)
    {
      if (!_resolutionTypes.ContainsKey(targetType))
        return null;

      var resolvedValue = _resolutionTypes[targetType];
      return Instantiate(resolvedValue, otherLifecycleCanResolveCallback, otherLifecycleResolveCallback);
    }
  }
}
