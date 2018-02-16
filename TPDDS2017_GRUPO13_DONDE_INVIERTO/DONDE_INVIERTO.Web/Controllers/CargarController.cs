using DONDE_INVIERTO.Model;
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
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Hubo un error.";
                return View();
            }
        }
        
    }
}
