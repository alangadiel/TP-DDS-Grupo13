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

        public ActionResult List()
        {
            return View(Service.List());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre, Fecha_Creacion")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                Service.Save(empresa);
                return RedirectToAction("List");
            }
            return View(empresa);
        }

        public ActionResult Edit(int id)
        {
            var model = Service.Get(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Nombre")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                Service.Save(empresa);
                return RedirectToAction("List");
            }
            return View(empresa);
        }


        public ActionResult Delete(int id)
        {
            var model = Service.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Nombre, Fecha_Creacion")] Empresa empresa)
        {
            try
            {
                Service.Delete(empresa);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
