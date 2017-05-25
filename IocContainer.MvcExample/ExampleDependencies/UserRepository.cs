using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IocContainer.MvcExample.ExampleDependencies
{
    public class UserRepository : IUserRepository
    {
        public int GetUserId() => new Random().Next();
    }
}