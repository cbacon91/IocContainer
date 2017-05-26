using IocContainer.MvcExample.ExampleDependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IocContainer.MvcExample.Controllers
{
    public class SingletonDependencyController : Controller
    {
        public IDmvOrderNumber Dmv { get; set; }
        public SingletonDependencyController(IDmvOrderNumber dmv)
        {
            Dmv = dmv;
        }

        public ActionResult Index()
        {
            return View(Dmv.GetTicketId());
        }
    }
}