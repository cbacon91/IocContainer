using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Exceptions
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(Type interfaceType) : base($"The interface '{interfaceType.Name}' has not been registered and cannot be resolved.")
        {
        }
    }
}
