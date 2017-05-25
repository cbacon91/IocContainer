using IocContainer.MvcExample.ExampleDependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IocContainer.MvcExample.Controllers
{
    public class MultipleDependencyController: Controller
    {
        public ITaxCalculator Irs { get; set; }
        public IUserRepository UserRepository { get; set; }
        public MultipleDependencyController(ITaxCalculator irs, IUserRepository userRepository)
        {
            Irs = irs;
            UserRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View(new Tuple<int, double> (UserRepository.GetUserId(), Irs.CalculateTax()));
        }
    }
}