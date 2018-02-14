using DONDE_INVIERTO.Web.Models;
using System.Web.Mvc;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View("../User/Login", new Login());
            }

            return View();
            
        }


    }
}