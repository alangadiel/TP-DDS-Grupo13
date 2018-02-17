using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DONDE_INVIERTO.Model;
using System.IO;
using System.Web.Script.Serialization;

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

        public ActionResult TraerEmpresas() => Json(new { Empresas = service.List() }, JsonRequestBehavior.AllowGet);

        public List<Empresa> DeserializarArchivoEmpresas()
        {
            //Metodo para desserializar el archivo json de empresas
            string buffer;
            if (Request != null)
            {
                var file = Request.Files[0];
                buffer = new StreamReader(file.InputStream).ReadToEnd();
            }
            else
            {
                buffer = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Archivos\\empresas.json"));
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Empresa> listaEmpresas = serializer.Deserialize<List<Empresa>>(buffer);
            return listaEmpresas;

        }

    }
}
