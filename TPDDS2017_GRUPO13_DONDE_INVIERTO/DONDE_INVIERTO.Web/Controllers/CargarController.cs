using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class CargarController : Controller
    {
        private BalanceService Service = new BalanceService();
        private CuentaService CuentaService = new CuentaService();

        public ActionResult CargarArchivo()
        {
            //GenerarJson();
            return View();
        }

        [HttpPost]
        public ActionResult CargarArchivo(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    var path = Server.MapPath("~/App_Data/Archivos");
                    string _path = Path.Combine(path, "balances.json");
                    Directory.CreateDirectory(path);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "Subido Correctamente!";
                CargarBalancesDesdeArchivo();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Hubo un error.";
                return View();
            }
        }

        public List<BalanceView> DeserializarArchivoBalances()
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
                buffer = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Archivos\\balances.json"));
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<BalanceView>>(buffer);
        }

        private void GenerarJson()
        {
            var balances = Service.List(User.Identity.GetUserName());
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(balances);
            System.IO.File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Archivos\\balances.json"), json);
        }


        public ActionResult CargarBalancesDesdeArchivo()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    //Deserializo el archivo seleccionado  
                    //List<ComponenteOperando> componentesArchivo = this.DeserializarArchivoComponente();
                    //ComponenteService.cargarCuentas(componentesArchivo)
                    var balancesArchivo = this.DeserializarArchivoBalances();
                    Service.ValidarBalancesArchivo(balancesArchivo);
                    balancesArchivo.ForEach(balance =>
                    {
                        balance.Id = 0;
                        balance.Cuentas.ForEach(c => c.Id = 0);
                        Service.Save(balance, User.Identity.GetUserName());
                    });
                    return Json(new { Success = true });
                }
                else
                {
                    throw new Exception("Ingrese un archivo de balances");
                }
            }
            catch (BalancesRepetidosException bre)
            {
                return Json(new { Success = false, Error = bre.Message, Balances = bre.Balances });

            }
            catch (Exception e)
            {
                return Json(new { Success = false, Error = e.Message });
            }
        }

    }
}
