using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DONDE_INVIERTO.Web.Controllers
{
    public class MetodologiaController : Controller
    {
        // GET: Metodologia
        public ActionResult Index()
        {
            return View();
        }

        // GET: Metodologia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Metodologia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Metodologia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Metodologia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Metodologia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Metodologia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Metodologia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
