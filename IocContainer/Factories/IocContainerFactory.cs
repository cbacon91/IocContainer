using IocContainer.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Factories
{
    class IocContainerFactory
    {
        public static IIocContainer Create(Lifecycle lifeCycle)
        {
            switch(lifeCycle)
            {
                case Lifecycle.Singleton:
                    return new SingletonIocContainer();
                case Lifecycle.Transient:
                    return new TransientIocContainer();
                default:
                    throw new NotImplementedException($"{lifeCycle.ToString()} IoCContainer Lifecycle not implemented.");
            }
        }
    }
}
