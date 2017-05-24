using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Exceptions
{
    public class IncorrectGenericTypeException : Exception
    {
        public IncorrectGenericTypeException(string msg) : base(msg)
        {
        }
    }
}
