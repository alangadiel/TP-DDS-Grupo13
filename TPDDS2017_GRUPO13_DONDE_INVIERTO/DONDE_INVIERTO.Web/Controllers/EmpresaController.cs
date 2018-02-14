using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DONDE_INVIERTO.Model;

namespace DONDE_INVIERTO.Web.Controllers
{
    [Authorize]
    public class EmpresaController : Controller
    {
        private EmpresaService service = new EmpresaService();

        [HttpGet]
        public ActionResult Index()
        {
            var empresas = service.List();
            return View(empresas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empresa empresa)
        {
            service.Save(empresa);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empresa = service.Get(id);
            return View(empresa);
        }
        [HttpPost]
        public ActionResult Edit(Empresa empresa)
        {
            service.Save(empresa);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
