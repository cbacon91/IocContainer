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
        public static IIocContainer Create(LifeCycle lifeCycle)
        {
            switch(lifeCycle)
            {
                case LifeCycle.Singleton:
                    return new SingletonIocContainer();
                case LifeCycle.Transient:
                    return new TransientIocContainer();
                default:
                    throw new NotImplementedException($"{lifeCycle.ToString()} not implemented.");
            }
        }
    }
}
