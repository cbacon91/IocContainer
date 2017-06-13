using System;

namespace IocContainer.MvcExample.ExampleDependencies
{
  public class TaxCalculator : ITaxCalculator
  {
    public double CalculateTax() => new Random().NextDouble();
  }
}