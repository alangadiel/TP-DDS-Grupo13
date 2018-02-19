using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Service;
using Microsoft.AspNet.Identity;
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
        BalanceService BalanceService = new BalanceService();

        [HttpGet]
        public ActionResult Index()
        {
            return View(service.GetAll());
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
            service.Save(model, idsCondiciones.Distinct().ToList());
            return RedirectToAction("Index");
        }

        public ActionResult ObtenerEmpresasDeseables(int idMetodologia)
        {
            try
            {
                var metodologia = service.GetById(idMetodologia);
                var empresas = new EmpresaService().List().Select(emp => new EmpresaView()
                {
                    Id = emp.Id,
                    FechaFundacion = emp.FechaFundacion,
                    Nombre = emp.Nombre,
                    Balances = BalanceService.List().Where(balance => balance.EmpresaId == emp.Id).ToList()
                }).ToList();
                var operandos = new ComponenteService().List(User.Identity.GetUserName());
                var tiposCondiciones = new CondicionService().GetTiposCondicionByMetodologia(metodologia);
                service.Condiciones = tiposCondiciones;
                var deseables = service.ObtenerEmpresasDeseables(empresas, operandos);
                ViewBag.Metodologia_Nombre = metodologia.Nombre;
                return View(deseables);
            }
            catch (Exception ex)
            {
                throw ex;
                //return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
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
