using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Exceptions
{
    public class TypeAlreadyRegisteredException : Exception
    {
        public TypeAlreadyRegisteredException(Type targetType) : base($"The interface '{targetType.Name}' has already been registered and cannot be registered again.")
        {
        }
    }
}
