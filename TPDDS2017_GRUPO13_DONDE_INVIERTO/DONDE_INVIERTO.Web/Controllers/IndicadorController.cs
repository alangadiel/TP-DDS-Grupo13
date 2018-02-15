using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var indicadores = Service.List();
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
                Service.Save(indicador);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Indicador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indicador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Indicador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indicador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
