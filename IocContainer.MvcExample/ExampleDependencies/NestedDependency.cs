using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IocContainer.MvcExample.ExampleDependencies
{
    public class NestedDependency : INestedDependency
    {
        public IUserRepository UserRepository { get; set; }
        public NestedDependency(IUserRepository userRepo)
        {
            UserRepository = userRepo;
        }

        public int GetUserIdFromUserRepo() => UserRepository.GetUserId();
    }
}