using IocContainer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    public class BaconInjector : IIocContainer
    {
        //This is obviously going to break down the instant we add a new LifeCycle type; having a separate Dictionary for each LifeCycleType is a bad idea.
        //Going to keep this in place at least intially so I can think this through a bit better.   
        private Dictionary<Type, Type> _transientMapping;
        private static Dictionary<Type, Type> _singletonMapping;

        //It might be worth investigating having a parent container which contains instances of the different LifeCycle types as containers, ie
        /*
         * BaconIocContainer
         * {
         *   private Dictionary<LifeCycle, IocContainer>
         *   {
         *     [LifeCycle.Transient] = new TransientIoc
         *     [LifeCycle.Singleton] = new SingletonIoc
         *     [LifeCycle.NewType] = new NewTypeIoc
         *   }
         * }
         */
         //In that fashion, when we add a new LifeCycle type, it's necessary to create a new IocContainer and simple get the value from that. 
         //TODO: investigate this concept

        public void Register<TInterface, TImplementation>(LifeCycle lifecycle = LifeCycle.Transient) where TImplementation : TInterface
        {
            //Check that TInterface is of type interface
            //If not interface, throw exception
            AssertTypeIsInterface(typeof(TInterface));



            throw new NotImplementedException();
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
