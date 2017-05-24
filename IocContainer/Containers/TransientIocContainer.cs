using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    class TransientIocContainer : IIocContainer
    {
        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            throw new NotImplementedException();
        }

        public TInterface Resolve<TInterface>()
        {
            throw new NotImplementedException();
        }
    }
}
