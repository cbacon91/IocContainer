using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Tests.TestModels
{
    class Model : IModel
    {
        public int Id { get; set; }
        public int SetId(int id)
        {
            return Id = id;
        }
    }
}
