using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Service;
using Microsoft.AspNet.Identity;

namespace DONDE_INVIERTO.Web.Controllers
{
    [Authorize]
    public class BalanceController : Controller
    {
        private BalanceService Service = new BalanceService();
        private EmpresaService EmpresaService = new EmpresaService();

        // GET: Balances
        public ActionResult Index()
        {
            return View(Service.List(User.Identity.GetUserName()));
        }

        // GET: Balances/Details/5
        public ActionResult Details(int id)
        {
            return View(Service.GetView(id));
        }

        private void setViewBagEmpresa()
        {
            ViewBag.Empresas = EmpresaService.List().Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Cuit
            }).ToList();

        }

        // GET: Balances/Create
        public ActionResult Create()
        {
            setViewBagEmpresa();
            return View();
        }

        [HttpPost]
        public ActionResult CargarArchivo(HttpPostedFileBase file)
        {
            setViewBagEmpresa();
            try
            {
                if (file == null) throw new Exception("Ingrese un archivo de cuentas");
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    var path = Server.MapPath("~/App_Data/Archivos");
                    string _path = Path.Combine(path, "cuentas.json");
                    Directory.CreateDirectory(path);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "Subido Correctamente!";
                return CargarCuentasDesdeArchivo();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Hubo un error: " + ex.Message;
                return View("Create");
            }
        }


        public List<ComponenteOperando> DeserializarArchivoCuentas()
        {
            //Metodo para desserializar el archivo json
            string buffer;
            if (Request != null)
            {
                var file = Request.Files[0];
                buffer = new StreamReader(file.InputStream).ReadToEnd();
            }
            else
            {
                buffer = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Archivos\\cuentas.json"));
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<ComponenteOperando>>(buffer);
        }
        
        public ActionResult CargarCuentasDesdeArchivo()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    var cuentas = DeserializarArchivoCuentas();
                    var balance = new BalanceView
                    {
                        Cuentas=cuentas,
                    };
                    return View("Create", balance);
                }
                else
                {
                    throw new Exception("Ingrese un archivo de cuentas");
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Error = e.Message });
            }
        }


        // POST: Balances/Create
        [HttpPost]
        public ActionResult Create(BalanceView balanceModel)
        {
            ViewBag.Errores = true;
            if (balanceModel.Empresa == null) return View(); //para la carga de cuentas

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hay errores en el formulario, los valores erroneos se predeterminaran como 0");
                setViewBagEmpresa();
                return View(balanceModel);
            }

            try
            {
                if (balanceModel.Cuentas.Count == 0)
                    throw new Exception("Debe ingresar por lo menos una cuenta para este balance");
                //Busco en la base de datos si hay algun balance con ese periodo para esa empresa
                bool hayBalancesIguales = Service.Exist(balanceModel.Periodo, balanceModel.Empresa.Cuit);
                if (hayBalancesIguales)
                {
                    ModelState.AddModelError("", "Ya existe un balance para esa empresa en ese período.");
                    setViewBagEmpresa();
                    return View(balanceModel);
                }
                Service.Save(balanceModel, User.Identity.GetUserName());
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                setViewBagEmpresa();
                return View(balanceModel);
            }

        }

        // GET: Balances/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Service.GetView(id));
        }

        // POST: Balances/Edit/5
        [HttpPost]
        public ActionResult Edit(BalanceView balanceView)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hay errores en el formulario, los valores erroneos se predeterminaran como 0");
                setViewBagEmpresa();
                return View(balanceView);
            }
            try
            {
                if (balanceView.Cuentas.Count == 0)
                    throw new Exception("Debe ingresar por lo menos una cuenta para este balance");
                Service.Save(balanceView, User.Identity.GetUserName());
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                setViewBagEmpresa();
                return View(balanceView);
            }
        }

        // GET: Balances/Delete/5
        public ActionResult Delete(int id)
        {
            Service.Delete(id);
            return RedirectToAction("Index");
        }

        

        /* // POST: Balances/Delete/5
         [HttpPost]
         public ActionResult Delete(int id)
         {
             try
             {

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }*/
    }
}
