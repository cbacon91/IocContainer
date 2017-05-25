using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IocContainer.MvcExample.ExampleDependencies
{
    public class TaxCalculator : ITaxCalculator
    {
        public double CalculateTax() => new Random().NextDouble();
    }
}