using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.MvcExample.ExampleDependencies
{
    public interface IUnresolvedDependency
    {
        bool Unimplemented();
    }
}
