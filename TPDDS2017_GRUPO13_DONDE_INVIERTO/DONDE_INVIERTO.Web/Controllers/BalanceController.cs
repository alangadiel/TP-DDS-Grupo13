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

        // POST: Balances/Create
        [HttpPost]
        public ActionResult Create(BalanceView balanceModel)
        {
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
