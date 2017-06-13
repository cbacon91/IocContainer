using System;

namespace IocContainer.Exceptions
{
  [Serializable]
  public class TypeAlreadyRegisteredException : Exception
  {
    public TypeAlreadyRegisteredException(Type targetType) : base($"The type '{targetType.Name}' has already been registered and cannot be registered again.")
    {
    }
  }
}
