using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.MvcExample.ExampleDependencies
{
    public class DmvOrderNumber : IDmvOrderNumber
    {
        private int _ticketId = -1;
        public int GetTicketId()
        {
            if(_ticketId < 0 )
                _ticketId = new Random().Next(100, 999);

            return _ticketId;
        }
    }
}
