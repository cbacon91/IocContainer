using System;

namespace IocContainer.MvcExample.ExampleDependencies
{
  public class UserRepository : IUserRepository
  {
    public int GetUserId() => new Random().Next();
  }
}