using IocContainer.Containers;
using IocContainer.Exceptions;
using IocContainer.Tests.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace IocContainer.Tests
{
    public class BaconInjectorTests
    {
        [Theory]
        [InlineData(LifeCycle.Transient)]
        [InlineData(LifeCycle.Singleton)]
        public void Register_ThrowsIncorrectGenericTypeException_ForConcreteGeneric(LifeCycle lifecycle)
        {
            Assert.Throws(typeof(IncorrectGenericTypeException), () => new BaconInjector().Register<object, object>(lifecycle));
        }

        //public void Register_RegistersType


        [Fact]
        public void Resolve_Throws_WithNoSetup()
        {
            Assert.Throws(typeof(TypeNotRegisteredException), () => new BaconInjector().Resolve<IModel>());
        }




    }
}
