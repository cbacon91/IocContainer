using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    class TransientIocContainer : IIocContainer
    {
        public bool CanResolve(Type target)
        {
            throw new NotImplementedException();
        }

        public void Register<TInterface, TImplementation>() where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public TInterface Resolve<TInterface>()
        {
            throw new NotImplementedException();
        }
    }
}
