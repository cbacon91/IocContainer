using IocContainer.Containers;
using IocContainer.DependencyResolvers;
using IocContainer.Factories;
using IocContainer.MvcExample.Controllers;
using IocContainer.MvcExample.ExampleDependencies;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(IocContainer.MvcExample.Startup))]
namespace IocContainer.MvcExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ILifecycleIocContainer iocContainer = new BaconInjector();

            iocContainer.Register<ITaxCalculator, TaxCalculator>(); //If lifecycle is not supplied, 'Transient' is used.
            iocContainer.Register<IUserRepository, UserRepository>();
            iocContainer.Register<INestedDependency, NestedDependency>();
            iocContainer.Register<IDmvOrderNumber, DmvOrderNumber>(Lifecycle.Singleton);

            iocContainer.Register<SingleDependencyController>();
            iocContainer.Register<MultipleDependencyController>();
            iocContainer.Register<NestedDependencyController>();
            iocContainer.Register<SingletonDependencyController>(Lifecycle.Singleton);
            iocContainer.Register<UnresolvedErrorController>(); //did not resolve the dependency used for UnresolvedDependency

            IControllerFactory factory = new BaconInjectorControllerFactory(iocContainer);
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}
