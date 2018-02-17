using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
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

        public ActionResult CargarArchivo()
        {
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

        public List<Balance> DeserializarArchivoBalances()
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
            List<Balance> listBalances = serializer.Deserialize<List<Balance>>(buffer);
            return listBalances;

        }

        public ActionResult CargarBalancesDesdeArchivo()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    //Deserializo el archivo seleccionado
                    List<Balance> balancesArchivo = this.DeserializarArchivoBalances();
                    Service.CargarBalances(balancesArchivo);
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
