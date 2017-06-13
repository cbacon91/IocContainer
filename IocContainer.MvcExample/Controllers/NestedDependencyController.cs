using IocContainer.MvcExample.ExampleDependencies;
using System.Web.Mvc;

namespace IocContainer.MvcExample.Controllers
{
  public class NestedDependencyController : Controller
  {
    public INestedDependency NestedDependency { get; set; }
    public NestedDependencyController(INestedDependency nested)
    {
      NestedDependency = nested;
    }

    public ActionResult Index()
    {
      return View(NestedDependency.GetUserIdFromUserRepo());
    }
  }
}