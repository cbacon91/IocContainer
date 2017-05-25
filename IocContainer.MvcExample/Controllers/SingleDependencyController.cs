using IocContainer.MvcExample.ExampleDependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IocContainer.MvcExample.Controllers
{
    public class SingleDependencyController : Controller
    {
        public ITaxCalculator Irs { get; set; }
        public SingleDependencyController(ITaxCalculator irs)
        {
            Irs = irs;
        }

        public ActionResult Index()
        {
            return View(Irs.CalculateTax());
        }
    }
}