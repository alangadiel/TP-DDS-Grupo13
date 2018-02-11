using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
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
        public ActionResult Login(Usuario user, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
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
