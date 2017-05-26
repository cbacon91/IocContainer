using IocContainer.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IocContainer.DependencyResolvers
{
    public class BaconDependencyResolver : IDependencyResolver
    {
        private ILifecycleIocContainer IocContainer { get; set; }

        public BaconDependencyResolver(ILifecycleIocContainer container)
        {
            IocContainer = container;
        }

        public object GetService(Type serviceType) => IocContainer.Resolve(serviceType);

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
