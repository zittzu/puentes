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
    public class InspeccionComponentesController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: InspeccionComponentes
        public ActionResult Index()
        {
            var inspeccionComponentes = db.InspeccionComponentes.Include(i => i.Inspecciones);
            return View(inspeccionComponentes.ToList());
        }

        // GET: InspeccionComponentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspeccionComponentes inspeccionComponentes = db.InspeccionComponentes.Find(id);
            if (inspeccionComponentes == null)
            {
                return HttpNotFound();
            }
            return View(inspeccionComponentes);
        }

        // GET: InspeccionComponentes/Create
        public ActionResult Create()
        {
            ViewBag.InspeccionId = new SelectList(db.Inspecciones, "InspeccionId", "Observaciones");
            return View();
        }

        // POST: InspeccionComponentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InspeccionComponenteId,InspeccionId,ComponenteId,Calificacion,Mantenimiento,InspeccionEspecial,NumFotos,Descripcion,TipoDañoId,Cantidad,Anio,Costo")] InspeccionComponentes inspeccionComponentes)
        {
            if (ModelState.IsValid)
            {
                db.InspeccionComponentes.Add(inspeccionComponentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InspeccionId = new SelectList(db.Inspecciones, "InspeccionId", "Observaciones", inspeccionComponentes.InspeccionId);
            return View(inspeccionComponentes);
        }

        // GET: InspeccionComponentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspeccionComponentes inspeccionComponentes = db.InspeccionComponentes.Find(id);
            if (inspeccionComponentes == null)
            {
                return HttpNotFound();
            }
            ViewBag.InspeccionId = new SelectList(db.Inspecciones, "InspeccionId", "Observaciones", inspeccionComponentes.InspeccionId);
            return View(inspeccionComponentes);
        }

        // POST: InspeccionComponentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InspeccionComponenteId,InspeccionId,ComponenteId,Calificacion,Mantenimiento,InspeccionEspecial,NumFotos,Descripcion,TipoDañoId,Cantidad,Anio,Costo")] InspeccionComponentes inspeccionComponentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspeccionComponentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InspeccionId = new SelectList(db.Inspecciones, "InspeccionId", "Observaciones", inspeccionComponentes.InspeccionId);
            return View(inspeccionComponentes);
        }

        // GET: InspeccionComponentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspeccionComponentes inspeccionComponentes = db.InspeccionComponentes.Find(id);
            if (inspeccionComponentes == null)
            {
                return HttpNotFound();
            }
            return View(inspeccionComponentes);
        }

        // POST: InspeccionComponentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InspeccionComponentes inspeccionComponentes = db.InspeccionComponentes.Find(id);
            db.InspeccionComponentes.Remove(inspeccionComponentes);
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
