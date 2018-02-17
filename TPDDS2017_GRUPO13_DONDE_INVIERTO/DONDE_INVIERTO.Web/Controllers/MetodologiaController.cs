using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DONDE_INVIERTO.Web.Controllers
{
    [Authorize]
    public class MetodologiaController : Controller
    {
        MetodologiaService service = new MetodologiaService();
        
        [HttpGet]
        public ActionResult Index()
        {
            var metodologias = service.GetAll();
            return View(metodologias);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListCondiciones = new CondicionService().List().Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = x.Id.ToString()
            }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Metodologia model, List<int> idsCondiciones)
        {
            service.Save(model, idsCondiciones);
            return RedirectToAction("Index");
        }

        public ActionResult ObtenerEmpresasDeseables(int idMetodologia)
        {
            var metodologia = service.GetById(idMetodologia);
            var empresas = new EmpresaService().List().Select(emp => new EmpresaView() { Id = emp.Id, FechaFundacion = emp.FechaFundacion, Nombre = emp.Nombre }).ToList();
            var operandos = new IndicadorService().GetListByMetodologia(metodologia);
            var deseables = service.ObtenerEmpresasDeseables(empresas, operandos);
            ViewBag.Metodologia_Nombre = metodologia.Nombre;
            return View(deseables);
        }


        public List<Metodologia> DeserializarArchivoMetodologias()
        {
            //TODO: Falta crear el archivo json de las metodologias
            string buf = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Archivos/") + "metodologias.json");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Metodologia> listMetodologias = serializer.Deserialize<List<Metodologia>>(buf);
            return listMetodologias;

        }
    }
}
