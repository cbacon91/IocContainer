using IocContainer.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace IocContainer.Factories
{
    public class BaconInjectorControllerFactory : DefaultControllerFactory
    {
        private IIocContainer _iocContainer;
        public BaconInjectorControllerFactory(IIocContainer iocContainer) : base()
        {
            _iocContainer = iocContainer;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return _iocContainer.CanResolve(controllerType) 
                ? (IController)_iocContainer.Resolve(controllerType) 
                : base.GetControllerInstance(requestContext, controllerType);
        }
    }
}
