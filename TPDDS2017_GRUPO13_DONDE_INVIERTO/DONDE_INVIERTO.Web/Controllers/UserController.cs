using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserName, Contrasenia")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var loggedUser = new UserService().Login(usuario);
                if (loggedUser != null)
                {
                    HttpContext.Session["LoggedSession"] = loggedUser;
                    HttpContext.Session.Timeout = 5;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(usuario);
        }
    }
}
