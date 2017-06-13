using System.Web.Mvc;

namespace IocContainer.MvcExample.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}