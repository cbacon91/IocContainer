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
        public BaconInjector()
        {
        }

        private Dictionary<Lifecycle, IIocContainer> _iocContainers = new Dictionary<Lifecycle, IIocContainer>();
        public List<Type> TypesRegistered { get; private set; } = new List<Type>();


        public void Register<TTarget>() => Register<TTarget>(Lifecycle.Transient);

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
            if (!typeof(TInterface).IsInterface)
                throw new IncorrectGenericTypeException(GenericType.Interface);

            if (!_iocContainers.ContainsKey(lifecycle))
                _iocContainers.Add(lifecycle, IocContainerFactory.Create(lifecycle));

            _iocContainers[lifecycle].Register<TInterface, TImplementation>();
            TypesRegistered.Add(typeof(TInterface));
        }

        public object Resolve(Type target)
        {
            IIocContainer resolver = _iocContainers.SingleOrDefault(c => c.Value.CanResolve(target)).Value;
            if(resolver == null)
                throw new TypeNotRegisteredException(target);

            return resolver.Resolve(target);
        }

        public TTarget Resolve<TTarget>() => (TTarget)Resolve(typeof(TTarget));

        public bool CanResolve(Type target) => _iocContainers.Any(c => c.Value.CanResolve(target));
    }
}
