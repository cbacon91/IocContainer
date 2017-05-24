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
        private BaconInjector() { }

        private static BaconInjector _instance;
        public static BaconInjector Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BaconInjector();

                return _instance;
            }
        }

        private Dictionary<LifeCycle, IIocContainer> _iocContainers = new Dictionary<LifeCycle, IIocContainer>();

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface => Register<TInterface, TImplementation>(LifeCycle.Transient);

        public void Register<TInterface, TImplementation>(LifeCycle lifecycle) where TImplementation : TInterface
        {
            AssertTypeIsInterface(typeof(TInterface));

            if (!_iocContainers.ContainsKey(lifecycle))
                _iocContainers.Add(lifecycle, IocContainerFactory.Create(lifecycle));

            _iocContainers[lifecycle].Register<TInterface, TImplementation>();
        }

        public TInterface Resolve<TInterface>()
        {
            //Check that TInterface is of type interface
            //If not interface, throw exception
            AssertTypeIsInterface(typeof(TInterface));

            //Determine if TInterface is Registered
            //If not registered, throw new TypeNotRegisteredException

            //Find TInterface in cache / mapping / memory 
            //return it

            throw new NotImplementedException();
        }

        private void AssertTypeIsInterface(Type inputType)
        {
            if (!inputType.IsInterface)
                throw new IncorrectGenericTypeException("Supplied type was not an interface.");
        }
    }
}
