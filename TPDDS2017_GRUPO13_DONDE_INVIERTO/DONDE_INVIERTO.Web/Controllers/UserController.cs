using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DONDE_INVIERTO.Web.DAL;
using System.Web.Security;

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
        //public ActionResult Login([Bind(Include = "UserName, Contrasenia")] Usuario usuario)
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            /*if (ModelState.IsValid)
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
            */

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User() { Email = model.UserName, Password = model.Password };

            user = Repository.GetUserDetails(user);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);

                var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }


        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
