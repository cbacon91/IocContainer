using IocContainer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    class SingletonIocContainer : IocContainerBase
    {
        private Dictionary<Type, IoCResolutionModel> _singletons = new Dictionary<Type, IoCResolutionModel>();

        public override bool CanResolve(Type t) => _singletons.ContainsKey(t);

        public override void Register<TTarget>()
        {
            if (_singletons.ContainsKey(typeof(TTarget)))
                throw new TypeAlreadyRegisteredException(typeof(TTarget));

            _singletons.Add(typeof(TTarget), new IoCResolutionModel(typeof(TTarget)));
        }

        public override void Register<TInterface, TImplementation>()
        {
            if (_singletons.ContainsKey(typeof(TInterface)))
                throw new TypeAlreadyRegisteredException(typeof(TInterface));

            _singletons.Add(typeof(TInterface), new IoCResolutionModel(typeof(TImplementation))); 
        }

        protected override object Resolve(Type targetType)
        {
            if (!_singletons.ContainsKey(targetType))
                return null;

            var resolvedValue = _singletons[targetType];
            object resolved = resolvedValue.ResolvedObject ;
            if (resolved == null)
            {
                resolved = Instantiate(resolvedValue.ResolveType);
                _singletons[targetType] = new IoCResolutionModel(targetType) { ResolvedObject = resolved, Lifecycle = Lifecycle.Singleton };
            }

            return resolved;
        }
    }
}
