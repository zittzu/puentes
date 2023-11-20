using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using puentes.Models;

namespace puentes.Controllers
{
    public class DTSuperEstructurasController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: DTSuperEstructuras
        public ActionResult Index()
        {
            var dTSuperEstructuras = db.DTSuperEstructuras.Include(d => d.Estructuras);
            return View(dTSuperEstructuras.ToList());
        }

        // GET: DTSuperEstructuras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTSuperEstructuras dTSuperEstructuras = db.DTSuperEstructuras.Find(id);
            if (dTSuperEstructuras == null)
            {
                return HttpNotFound();
            }
            return View(dTSuperEstructuras);
        }

        // GET: DTSuperEstructuras/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: DTSuperEstructuras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DTSuperEstrucId,EstructuraId,DiseñoTipo,DiseñoSeccTransvId,DiseñoElevacionId,MaterialId,SuperEstrucClasificacionId")] DTSuperEstructuras dTSuperEstructuras)
        {
            if (ModelState.IsValid)
            {
                db.DTSuperEstructuras.Add(dTSuperEstructuras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTSuperEstructuras.EstructuraId);
            return View(dTSuperEstructuras);
        }

        // GET: DTSuperEstructuras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTSuperEstructuras dTSuperEstructuras = db.DTSuperEstructuras.Find(id);
            if (dTSuperEstructuras == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTSuperEstructuras.EstructuraId);
            return View(dTSuperEstructuras);
        }

        // POST: DTSuperEstructuras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DTSuperEstrucId,EstructuraId,DiseñoTipo,DiseñoSeccTransvId,DiseñoElevacionId,MaterialId,SuperEstrucClasificacionId")] DTSuperEstructuras dTSuperEstructuras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTSuperEstructuras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTSuperEstructuras.EstructuraId);
            return View(dTSuperEstructuras);
        }

        // GET: DTSuperEstructuras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTSuperEstructuras dTSuperEstructuras = db.DTSuperEstructuras.Find(id);
            if (dTSuperEstructuras == null)
            {
                return HttpNotFound();
            }
            return View(dTSuperEstructuras);
        }

        // POST: DTSuperEstructuras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DTSuperEstructuras dTSuperEstructuras = db.DTSuperEstructuras.Find(id);
            db.DTSuperEstructuras.Remove(dTSuperEstructuras);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
