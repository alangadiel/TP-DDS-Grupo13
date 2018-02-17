using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DONDE_INVIERTO.Service;
using Microsoft.AspNet.Identity;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;

namespace DONDE_INVIERTO.Web.Controllers
{
    [Authorize]
    public class CondicionController : Controller
    {
        private IndicadorService IndicadorService = new IndicadorService();
        private CondicionService Service = new CondicionService();
        private TipoCondicionService TipoCondicionService = new TipoCondicionService();


        // GET: Condicion
        public ActionResult Index()
        {
            return View(Service.List());
        }

        // GET: Condicion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Condicion/Create
        public ActionResult Create()
        {
            setViewbag();
            return View();
        }
        private void setViewbag()
        {
            ViewBag.ListIndicadores = IndicadorService.List(User.Identity.GetUserName())
                .Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.Id.ToString()
                }).ToList();

            ViewBag.ListTipos = TipoCondicionService.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Descripcion,
                    Value = x.Id.ToString()
                }).ToList();
        }
        // POST: Condicion/Create
        [HttpPost]
        public ActionResult Create(CondicionView condicion)
        {
            try
            {
                Service.Save(condicion);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                setViewbag();
                return View();
            }
        }
        
        // GET: Condicion/Delete/5
        public ActionResult Delete(int id)
        {
            Service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
