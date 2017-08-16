using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cuenta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cuenta/Create
        public ActionResult Create()
        {
            ViewBag.Empresas = new EmpresaService().List().OrderBy(x => x.Nombre);
            Model.Periodo periodo = new Model.Periodo();
            periodo.Inicio = DateTime.Today.AddYears(-1);
            periodo.Fin = DateTime.Today;

            CuentaPeriodo model = new CuentaPeriodo();
            model.Periodo = periodo;
            model.Cuenta = new Cuenta();
            return View(model);
        }

        // POST: Cuenta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuentaPeriodo model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            return View(model);
        }

        // GET: Cuenta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cuenta/Edit/5
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

        // GET: Cuenta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuenta/Delete/5
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
