using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
using DONDE_INVIERTO.Web.Models;
using System;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Login(Login login, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }
            else
            {
                var user = new Usuario()
                {
                    Username = login.UserName,
                    Contrasenia = login.Password
                };

                var service = new UserService().Login(user);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, "admin");
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(user);
                }
            }

          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
