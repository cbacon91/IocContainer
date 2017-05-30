using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Containers
{
    public class IocResolutionModel
    {
        public Type ResolveType { get; set; }
        public object ResolvedObject { get; set; }
        public Lifecycle Lifecycle { get; set; }

        public IocResolutionModel(Type resolveType)
        {
            ResolveType = resolveType;
        }
    }
}
