﻿using IocContainer.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace IocContainer.Containers
{
  abstract class IocContainerBase : IIocContainer
  {
    private ConcurrentDictionary<Type, ConstructorInfo> _resolutionCtors = new ConcurrentDictionary<Type, ConstructorInfo>();
    public abstract void Register<TTarget>() where TTarget : class;
    public abstract void Register<TInterface, TImplementation>() where TImplementation : class, TInterface;
    public TTarget Resolve<TTarget>() => (TTarget)Resolve(typeof(TTarget));
    public abstract object Resolve(Type targetType);
    public abstract bool CanResolve(Type targetType);

    protected object Instantiate(Type objectType, Func<Type, bool> canResolveCallback, Func<Type, object> resolveCallback)
    {
      ConstructorInfo ctor = GetCtorForType(objectType, canResolveCallback);

      return ctor
          .Invoke(ctor
              .GetParameters()
              .Select(p => resolveCallback(p.ParameterType))
              .ToArray());
    }

    private ConstructorInfo GetCtorForType(Type objectType, Func<Type, bool> canResolveCallback)
    {
      return _resolutionCtors.GetOrAdd(objectType, (inputType) =>
      {

        //Business rules:
        // 1. The constructor must be public. We're using reflection, but we should respect the clients' encapsulation levels.
        // 2. Only get constructors where we can actually resolve all of the references. If a constructor has even one parameter we can't resolve, we should ignore it. Passing in 'null' to a ctor is just poor design and can be dangerous for client use.
        // 3. Take the Autofac way of creating the object - find the constructor with the most parameters we can resolve.
        // 4. If there are no valid constructors meeting the above criteria, throw an exception. If nothing else, we should be provided a default or parameterless constructor.
        var ctors = inputType
            .GetConstructors()
            .Where(c => c.IsPublic //probably only want to do this for public ctors
                && c.GetParameters()
                    .All(p => canResolveCallback(p.ParameterType)) //also only care about ctors we can actually resolve the params
            );

        if (!ctors.Any())
          throw new NoValidConstructorException(inputType);

        int maxParams = -1;
        ConstructorInfo victor = null;
        foreach (var ctor in ctors)
        {
          var count = ctor.GetParameters().Length;
          if (count > maxParams)
          {
            victor = ctor;
            maxParams = count;
          }
        }
        return victor;
      });
    }
  }
}
