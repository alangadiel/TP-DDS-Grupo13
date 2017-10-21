using DONDE_INVIERTO.Model;
using System.Web.Mvc;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View("~/Views/Account/Login", new Usuario());
        }
    }
}
