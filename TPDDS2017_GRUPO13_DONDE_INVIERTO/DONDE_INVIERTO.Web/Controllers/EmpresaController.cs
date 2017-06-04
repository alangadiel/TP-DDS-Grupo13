using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DONDE_INVIERTO.Model;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class EmpresaController : Controller
    {
        private EmpresaService Service = new EmpresaService();
        // GET: Empresa
        public ActionResult List()
        {
            return View(Service.List());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                Service.Save(empresa);
                return RedirectToAction("List");
            }
            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Service.Get(id);
            return View(model);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Nombre")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                Service.Save(empresa);
                return RedirectToAction("List");
            }
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Service.Get(id);
            return View(model);
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id")] Empresa empresa)
        {
            try
            {
                Service.Delete(empresa.Id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
