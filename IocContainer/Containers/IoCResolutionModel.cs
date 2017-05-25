using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    public class IoCResolutionModel
    {
        public Type ResolveType { get; set; }
        public object ResolvedObject { get; set; }
        public LifeCycle Lifecycle { get; set; }

        public IoCResolutionModel(Type resolveType)
        {
            ResolveType = resolveType;
        }
    }
}
