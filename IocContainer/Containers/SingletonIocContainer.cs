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

        public override void Register<TInterface, TImplementation>()
        {
            if (_singletons.ContainsKey(typeof(TInterface)))
                throw new TypeAlreadyRegisteredException(typeof(TInterface));

            _singletons.Add(typeof(TInterface), new IoCResolutionModel(typeof(TImplementation))); 
        }

        public override TInterface Resolve<TInterface>() => 
            (TInterface)Resolve(typeof(TInterface));

        protected override object Resolve(Type interfaceType)
        {
            if (!_singletons.ContainsKey(interfaceType))
                return null;

            var resolvedValue = _singletons[interfaceType];
            object resolved = resolvedValue.ResolvedObject ;
            if (resolved == null)
            {
                resolved = Instantiate(resolvedValue.ResolveType);
                _singletons[interfaceType] = new IoCResolutionModel(interfaceType) { ResolvedObject = resolved, Lifecycle = Lifecycle.Singleton };
            }

            return resolved;
        }
    }
}
