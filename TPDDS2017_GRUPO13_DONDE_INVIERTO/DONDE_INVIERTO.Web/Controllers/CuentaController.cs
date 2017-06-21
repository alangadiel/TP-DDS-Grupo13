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
            periodo.Cuentas = new List<Model.Cuenta>();
            periodo.Inicio = DateTime.Today.AddYears(-1);
            periodo.Fin = DateTime.Today;
            return View(periodo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAccount(Periodo Periodo)
        {
            if (ModelState.IsValid)
            {
                new PeriodoService().Save(Periodo);
            }
            return View("Create", Periodo);
        }

        // POST: Cuenta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
