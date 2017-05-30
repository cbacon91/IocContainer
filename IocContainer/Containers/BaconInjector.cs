using IocContainer.Exceptions;
using IocContainer.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    public sealed class BaconInjector : ISelectableLifecycleIocContainer
    {
        private Dictionary<Lifecycle, ISpecificLifecycleContainer> _lifecycleIocContainers = new Dictionary<Lifecycle, ISpecificLifecycleContainer>();

        public readonly List<Type> TypesRegistered = new List<Type>();

        public void Register<TTarget>() where TTarget : class => Register<TTarget>(Lifecycle.Transient);

        public void Register<TTarget>(Lifecycle lifecycle) where TTarget : class
        {
            if (!_lifecycleIocContainers.ContainsKey(lifecycle))
                _lifecycleIocContainers.Add(lifecycle, IocContainerFactory.CreateLifecycleSpecificIocContainer(lifecycle));

            _lifecycleIocContainers[lifecycle].Register<TTarget>();
            TypesRegistered.Add(typeof(TTarget));
        }

        public void Register<TInterface, TImplementation>() where TImplementation : class, TInterface =>
            Register<TInterface, TImplementation>(Lifecycle.Transient);

        public void Register<TInterface, TImplementation>(Lifecycle lifecycle) where TImplementation : class, TInterface
        {
            if (!typeof(TInterface).IsInterface)
                throw new IncorrectGenericTypeException(GenericType.Interface);

            if (!_lifecycleIocContainers.ContainsKey(lifecycle))
                _lifecycleIocContainers.Add(lifecycle, IocContainerFactory.CreateLifecycleSpecificIocContainer(lifecycle));

            _lifecycleIocContainers[lifecycle].Register<TInterface, TImplementation>();
            TypesRegistered.Add(typeof(TInterface));
        }

        public object Resolve(Type target)
        {
            ISpecificLifecycleContainer resolver = _lifecycleIocContainers.SingleOrDefault(c => c.Value.CanResolve(target)).Value;
            if(resolver == null)
                throw new TypeNotRegisteredException(target);

            return resolver.Resolve(target, CanResolve, Resolve);
        }

        public TTarget Resolve<TTarget>() => (TTarget)Resolve(typeof(TTarget));

        public bool CanResolve(Type target) => _lifecycleIocContainers.Any(c => c.Value.CanResolve(target));
    }
}
