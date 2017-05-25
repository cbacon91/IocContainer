using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IocContainer.MvcExample.ExampleDependencies
{
    public interface INestedDependency
    {
        int GetUserIdFromUserRepo();
    }
}