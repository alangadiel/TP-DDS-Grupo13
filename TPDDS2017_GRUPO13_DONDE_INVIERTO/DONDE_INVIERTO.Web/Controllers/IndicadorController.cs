using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class IndicadorController : Controller
    {

        private IndicadorService Service = new IndicadorService();

        public ActionResult List()
        {
            return View();
        }


        // GET: Indicador
        public ActionResult Index()
        {
            var indicadores = Service.List(User.Identity.GetUserName());
            return View(indicadores);
        }

        // GET: Indicador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indicador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indicador/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ComponenteOperando indicador)
        {
            if (ModelState.IsValid)
            {
                indicador.Discriminador = "Indicador";
                Service.Save(indicador, User.Identity.GetUserName());
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Indicador/Edit/5
        public ActionResult Edit(int id)
        {
            var indicador = Service.Get(id);
            return View(indicador);
        }

        // POST: Indicador/Edit/5
        [HttpPost]
        public ActionResult Edit(ComponenteOperando indicador)
        {
            Service.Save(indicador);
            return RedirectToAction("Index");
        }

        // GET: Indicador/Delete/5
        public ActionResult Delete(int id)
        {
            Service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
