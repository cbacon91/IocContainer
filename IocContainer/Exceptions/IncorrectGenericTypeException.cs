using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Exceptions
{
    public class IncorrectGenericTypeException : Exception
    {
        public IncorrectGenericTypeException(GenericType genericType) : base($"Generic type provided did not match expected generic type. Expected generic type: {genericType.ToString()}.")
        {
        }
    }
}
