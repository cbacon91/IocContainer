using IocContainer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    abstract class IocContainerBase : IIocContainer
    {
        public abstract void Register<TTarget>();
        public abstract void Register<TInterface, TImplementation>() where TImplementation : class, TInterface;
        public abstract TInterface Resolve<TInterface>();
        protected abstract object Resolve(Type targetType);
        public abstract bool CanResolve(Type targetType);

        protected object Instantiate(Type objectType)
        {
            //Business rules:
            // 1. The constructor must be public. We're using reflection, but we should respect the clients' encapsulation levels.
            // 2. Only get constructors where we can actually resolve all of the references. If a constructor has even one parameter we can't resolve, we should ignore it. Passing in 'null' to a ctor is just poor design and can be dangerous for client use.
            // 3. Take the Autofac way of creating the object - find the constructor with the most parameters we can resolve.
            // 4. If there are no valid constructors meeting the above criteria, throw an exception. If nothing else, we should be provided a default or parameterless constructor.
            var ctors = objectType
                .GetConstructors()
                .Where(c => c.IsPublic //probably only want to do this for public ctors
                    && c.GetParameters()
                        .All(p => CanResolve(p.ParameterType)) //also only care about ctors we can actually resolve the params
                );

            if (!ctors.Any())
                throw new NoValidConstructorException(objectType);

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

            return victor
                .Invoke(victor
                    .GetParameters()
                    .Select(p => Resolve(p.ParameterType))
                    .ToArray());
        }
    }
}
