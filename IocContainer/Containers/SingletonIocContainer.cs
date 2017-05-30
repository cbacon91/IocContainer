using IocContainer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    class SingletonIocContainer : IocContainerBase, ISpecificLifecycleContainer
    {
        private Dictionary<Type, IocResolutionModel> _singletons = new Dictionary<Type, IocResolutionModel>();

        public override bool CanResolve(Type t) => _singletons.ContainsKey(t);

        public override void Register<TTarget>()
        {
            if (_singletons.ContainsKey(typeof(TTarget)))
                throw new TypeAlreadyRegisteredException(typeof(TTarget));

            _singletons.Add(typeof(TTarget), new IocResolutionModel(typeof(TTarget)));
        }

        public override void Register<TInterface, TImplementation>()
        {
            if (_singletons.ContainsKey(typeof(TInterface)))
                throw new TypeAlreadyRegisteredException(typeof(TInterface));

            _singletons.Add(typeof(TInterface), new IocResolutionModel(typeof(TImplementation)));
        }

        public override object Resolve(Type targetType) => Resolve(targetType, CanResolve, Resolve);

        public object Resolve(Type targetType, Func<Type, bool> otherLifecycleCanResolveCallback, Func<Type, object> otherLifecycleResolveCallback)
        {
            if (!_singletons.ContainsKey(targetType))
                return null;

            var resolvedValue = _singletons[targetType];
            object resolved = resolvedValue.ResolvedObject;
            if (resolved == null)
            {
                resolved = Instantiate(resolvedValue.ResolveType, otherLifecycleCanResolveCallback, otherLifecycleResolveCallback);
                _singletons[targetType] = new IocResolutionModel(targetType) { ResolvedObject = resolved, Lifecycle = Lifecycle.Singleton };
            }

            return resolved;
        }
    }
}
