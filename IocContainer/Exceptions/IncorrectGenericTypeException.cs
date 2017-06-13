using System;

namespace IocContainer.Exceptions
{
  [Serializable]
  public class IncorrectGenericTypeException : Exception
  {
    public IncorrectGenericTypeException(GenericType genericType) : base($"Generic type provided did not match expected generic type. Expected generic type: {genericType.ToString()}.")
    {
    }
  }
}
