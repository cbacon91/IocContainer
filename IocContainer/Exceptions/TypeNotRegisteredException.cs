using System;

namespace IocContainer.Exceptions
{
  [Serializable]
  public class TypeNotRegisteredException : Exception
  {
    public TypeNotRegisteredException(Type targetType) : base($"The type '{targetType.Name}' has not been registered and cannot be resolved.")
    {
    }
  }
}
