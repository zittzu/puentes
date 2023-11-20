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
    public class DTSubEstructurasController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: DTSubEstructuras
        public ActionResult Index()
        {
            var dTSubEstructuras = db.DTSubEstructuras.Include(d => d.Estructuras);
            return View(dTSubEstructuras.ToList());
        }

        // GET: DTSubEstructuras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTSubEstructuras dTSubEstructuras = db.DTSubEstructuras.Find(id);
            if (dTSubEstructuras == null)
            {
                return HttpNotFound();
            }
            return View(dTSubEstructuras);
        }

        // GET: DTSubEstructuras/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: DTSubEstructuras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DTSubEstrucId,EstructuraId,SubEstrucTipoId,MaterialId,TipoCimentacionId,SubEstrucClasificacionId")] DTSubEstructuras dTSubEstructuras)
        {
            if (ModelState.IsValid)
            {
                db.DTSubEstructuras.Add(dTSubEstructuras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTSubEstructuras.EstructuraId);
            return View(dTSubEstructuras);
        }

        // GET: DTSubEstructuras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTSubEstructuras dTSubEstructuras = db.DTSubEstructuras.Find(id);
            if (dTSubEstructuras == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTSubEstructuras.EstructuraId);
            return View(dTSubEstructuras);
        }

        // POST: DTSubEstructuras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DTSubEstrucId,EstructuraId,SubEstrucTipoId,MaterialId,TipoCimentacionId,SubEstrucClasificacionId")] DTSubEstructuras dTSubEstructuras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTSubEstructuras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTSubEstructuras.EstructuraId);
            return View(dTSubEstructuras);
        }

        // GET: DTSubEstructuras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTSubEstructuras dTSubEstructuras = db.DTSubEstructuras.Find(id);
            if (dTSubEstructuras == null)
            {
                return HttpNotFound();
            }
            return View(dTSubEstructuras);
        }

        // POST: DTSubEstructuras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DTSubEstructuras dTSubEstructuras = db.DTSubEstructuras.Find(id);
            db.DTSubEstructuras.Remove(dTSubEstructuras);
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
