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
        readonly static Dictionary<Lifecycle, Func<ISpecificLifecycleContainer>> LifeCycleIocContainers =
            new Dictionary<Lifecycle, Func<ISpecificLifecycleContainer>>
            {
                [Lifecycle.Singleton] = () => new SingletonIocContainer(),
                [Lifecycle.Transient] = () => new TransientIocContainer()
            };

        public static ISpecificLifecycleContainer CreateLifecycleSpecificIocContainer(Lifecycle lifecycle)
        {
            if (!LifeCycleIocContainers.ContainsKey(lifecycle))
                throw new NotImplementedException($"{lifecycle.ToString()} IoCContainer Lifecycle not implemented.");

            return LifeCycleIocContainers[lifecycle]();
        }
    }
}
