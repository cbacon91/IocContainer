using System;

namespace IocContainer.Exceptions
{
  [Serializable]
  public class NoValidConstructorException : Exception
  {
    public NoValidConstructorException(Type objectType) : base($"The type '{objectType.Name}' does not contain any constructors able to be resolved. Please add either a parameterless public constructor, or register parameters the constructor requires.")
    {
    }
  }
}
