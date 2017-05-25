using IocContainer.Exceptions;
using IocContainer.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    public sealed class BaconInjector : ILifecycleIocContainer
    {
        //Private ctor to prevent instantiation..
        public BaconInjector()
        {
        }

        private Dictionary<Lifecycle, IIocContainer> _iocContainers = new Dictionary<Lifecycle, IIocContainer>();
        public List<Type> TypesRegistered { get; private set; } = new List<Type>();


        public void Register<TTarget>() => 
            Register<TTarget>(Lifecycle.Transient);

        public void Register<TTarget>(Lifecycle lifecycle)
        {
            if (!_iocContainers.ContainsKey(lifecycle))
                _iocContainers.Add(lifecycle, IocContainerFactory.Create(lifecycle));

            _iocContainers[lifecycle].Register<TTarget>();
            TypesRegistered.Add(typeof(TTarget));

        }

        public void Register<TInterface, TImplementation>() where TImplementation : class, TInterface =>
            Register<TInterface, TImplementation>(Lifecycle.Transient);

        public void Register<TInterface, TImplementation>(Lifecycle lifecycle) where TImplementation : class, TInterface
        {
            AssertTypeIsInterface(typeof(TInterface));

            if (!_iocContainers.ContainsKey(lifecycle))
                _iocContainers.Add(lifecycle, IocContainerFactory.Create(lifecycle));

            _iocContainers[lifecycle].Register<TInterface, TImplementation>();
            TypesRegistered.Add(typeof(TInterface));
        }

        public TTarget Resolve<TTarget>()
        {
            //because we don't necessarily know the lifecycle of the item being resolved, we have to check each of the iocContainers available.
            //fortunately, it's unlikely that we will ever have more than 3-5 types of IocContainers, and each subsequent Resolve is a constant-time operation.
            foreach (var container in _iocContainers)
            {
                var resolved = container.Value.Resolve<TTarget>();
                if (resolved != null)
                    return resolved;
            }

            throw new TypeNotRegisteredException(typeof(TTarget));
        }

        public bool CanResolve(Type target)
        {
            foreach (var container in _iocContainers)
            {
                if (container.Value.CanResolve(target))
                    return true;
            }
            return false;
        }

        private void AssertTypeIsInterface(Type inputType)
        {
            if (!inputType.IsInterface)
                throw new IncorrectGenericTypeException("Supplied type was not an interface.");
        }
    }
}
