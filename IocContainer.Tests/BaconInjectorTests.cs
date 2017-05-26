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
        [InlineData(Lifecycle.Transient)]
        [InlineData(Lifecycle.Singleton)]
        public void Register_ThrowsIncorrectGenericTypeException_ForConcreteGeneric(Lifecycle lifecycle)
        {
            Assert.Throws(typeof(IncorrectGenericTypeException), () => new BaconInjector().Register<object, object>(lifecycle));
        }

        [Theory]
        [InlineData(Lifecycle.Transient)]
        [InlineData(Lifecycle.Singleton)]
        public void Register_ThrowsTypeAlreadyRegisteredException_WhenTypeAlreadyRegistered(Lifecycle lifecycle)
        {
            Assert.Throws(typeof(TypeAlreadyRegisteredException), () =>
            {
                var injector = new BaconInjector();
                injector.Register<IModel, Model>(lifecycle);
                injector.Register<IModel, Model>(lifecycle);
            });
        }

        [Theory]
        [InlineData(Lifecycle.Transient)]
        [InlineData(Lifecycle.Singleton)]
        public void Register_RegistersInterfaces(Lifecycle lifecycle)
        {
            var injector = new BaconInjector();
            injector.Register<IModel, Model>(lifecycle);
            Assert.Equal(new Type[] { typeof(IModel) }, injector.TypesRegistered);
        }

        [Theory]
        [InlineData(Lifecycle.Transient)]
        [InlineData(Lifecycle.Singleton)]
        public void CanResolve(Lifecycle lifecycle)
        {
            var injector = new BaconInjector();
            injector.Register<IModel, Model>(lifecycle);
            Assert.True(injector.CanResolve(typeof(IModel)));
        }

        [Fact]
        public void Resolve_Throws_WithNoSetup()
        {
            Assert.Throws(typeof(TypeNotRegisteredException), () => new BaconInjector().Resolve<IModel>());
        }

        [Theory]
        [InlineData(Lifecycle.Transient)]
        [InlineData(Lifecycle.Singleton)]
        public void Resolve_ResolvesInterfacesSupplied(Lifecycle lifecycle)
        {
            var injector = new BaconInjector();
            injector.Register<IModel, Model>(lifecycle); //we have to just assume this works already; if Register breaks down this test will fail. The issue is that Registering something is a prerequisite to Resolving it.
            var model = injector.Resolve<IModel>();
            Assert.IsType(typeof(Model), model); //Because this is the generic resolve, all we can verify is the type. Singleton and Transient specific tests will follow as Facts
        }


        [Theory]
        [InlineData(Lifecycle.Transient)]
        [InlineData(Lifecycle.Singleton)]
        public void Resolve_ResolveConcrete(Lifecycle lifecycle)
        {
            var injector = new BaconInjector();
            injector.Register<Model>(lifecycle);
            var model = injector.Resolve<Model>();
            Assert.IsType(typeof(Model), model);
        }

        [Theory]
        [InlineData(Lifecycle.Transient)]
        [InlineData(Lifecycle.Singleton)]
        public void Resolve_UsesComplexConstructor_Concrete(Lifecycle lifecycle)
        {
            var injector = new BaconInjector();
            injector.Register<IModel, Model>(lifecycle);
            injector.Register<IParamModel, ParamModel>(lifecycle);
            injector.Register<ComplexModel>(lifecycle);

            var complexModel = injector.Resolve<ComplexModel>();
            Assert.NotNull(complexModel.Model); //if it's not null, it was assigned
            Assert.NotNull(complexModel.ParamModel); //if it's not null, it was assigned - used the correct ctor
        }


        [Theory]
        [InlineData(Lifecycle.Transient)]
        [InlineData(Lifecycle.Singleton)]
        public void Resolve_ThrowsWhenNoValidCtor(Lifecycle lifecycle)
        {
            Assert.Throws(typeof(NoValidConstructorException), () =>
            {
                var injector = new BaconInjector();
                injector.Register<ComplexModel>(lifecycle);
                var complexModel = injector.Resolve<ComplexModel>();
            });
        }

        [Fact]
        public void Singleton_Resolve_ResolvesSameEachTime()
        {
            var injector = new BaconInjector();
            injector.Register<IModel, Model>(Lifecycle.Singleton);
            var expected = 256;
            var model = injector.Resolve<IModel>();
            model.SetId(expected);
            var modelAgain = injector.Resolve<IModel>();
            Assert.Equal(expected, ((Model)modelAgain).Id);
        }

        [Fact]
        public void Transient_Resolve_ResolvesDifferentEachTime()
        {
            var injector = new BaconInjector();
            injector.Register<IModel, Model>(Lifecycle.Transient);
            var expected = 256;
            var model = injector.Resolve<IModel>();
            model.SetId(expected);
            var modelAgain = injector.Resolve<IModel>();
            Assert.NotEqual(expected, ((Model)modelAgain).Id);
        }

        [Theory]
        [InlineData(Lifecycle.Transient, Lifecycle.Singleton)]
        [InlineData(Lifecycle.Singleton, Lifecycle.Transient)]
        public void Resolve_CanResolveDifferentLifecycles(Lifecycle thisObject, Lifecycle referencesObject)
        {
            var injector = new BaconInjector();
            injector.Register<IModel, Model>(referencesObject);
            injector.Register<IParamModel, ParamModel>(referencesObject);
            injector.Register<IComplexModel, ComplexModel>(thisObject);

            var model = injector.Resolve<IComplexModel>();
            Assert.NotNull(model);
            Assert.NotNull(model.GetParamModel());
        }

    }
}
