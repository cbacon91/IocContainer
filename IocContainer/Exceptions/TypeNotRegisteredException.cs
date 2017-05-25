using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Exceptions
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(Type targetType) : base($"The interface '{targetType.Name}' has not been registered and cannot be resolved.")
        {
        }
    }
}
