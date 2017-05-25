using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Exceptions
{
    public class NoValidConstructorException : Exception
    {
        public NoValidConstructorException(Type objectType) : base($"The type '{objectType.Name}' does not contain any constructors able to be resolved. Please add either a parameterless public constructor, or resolve parameters the constructor requires.")
        {
        }
    }
}
