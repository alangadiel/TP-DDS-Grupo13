using DONDE_INVIERTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (HttpContext.Session["LoggedSession"] == null)
            {
                return View("../User/Login", new Usuario());
            }

            return View();
            
        }


    }
}