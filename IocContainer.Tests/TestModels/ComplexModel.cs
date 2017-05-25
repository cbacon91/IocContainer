using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer.Tests.TestModels
{
    class ComplexModel : IComplexModel
    {
        public IModel Model { get; set; }
        public IParamModel ParamModel { get; set; }

        public ComplexModel(IModel model, IParamModel paramModel)
        {
            ParamModel = paramModel;
            Model = model;
        }
    }
}
