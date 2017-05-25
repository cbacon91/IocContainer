using IocContainer.MvcExample.ExampleDependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IocContainer.MvcExample.Controllers
{
    public class UnresolvedErrorController : Controller
    {
        public IUnresolvedDependency Unresolved { get; set; }
        public UnresolvedErrorController(IUnresolvedDependency dep)
        {
            Unresolved = dep;
        }

        public ActionResult Index()
        {
            return View(Unresolved.Unimplemented());
        }
    }
}