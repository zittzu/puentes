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
    public class TrabajosEstandarsController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: TrabajosEstandars
        public ActionResult Index()
        {
            var trabajosEstandar = db.TrabajosEstandar.Include(t => t.InspeccionComponentes);
            return View(trabajosEstandar.ToList());
        }

        // GET: TrabajosEstandars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajosEstandar trabajosEstandar = db.TrabajosEstandar.Find(id);
            if (trabajosEstandar == null)
            {
                return HttpNotFound();
            }
            return View(trabajosEstandar);
        }

        // GET: TrabajosEstandars/Create
        public ActionResult Create()
        {
            ViewBag.InspeccionComponenteId = new SelectList(db.InspeccionComponentes, "InspeccionComponenteId", "Calificacion");
            return View();
        }

        // POST: TrabajosEstandars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabajoEstandarId,InspeccionComponenteId,Unidad,Precio,Descripcion")] TrabajosEstandar trabajosEstandar)
        {
            if (ModelState.IsValid)
            {
                db.TrabajosEstandar.Add(trabajosEstandar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InspeccionComponenteId = new SelectList(db.InspeccionComponentes, "InspeccionComponenteId", "Calificacion", trabajosEstandar.InspeccionComponenteId);
            return View(trabajosEstandar);
        }

        // GET: TrabajosEstandars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajosEstandar trabajosEstandar = db.TrabajosEstandar.Find(id);
            if (trabajosEstandar == null)
            {
                return HttpNotFound();
            }
            ViewBag.InspeccionComponenteId = new SelectList(db.InspeccionComponentes, "InspeccionComponenteId", "Calificacion", trabajosEstandar.InspeccionComponenteId);
            return View(trabajosEstandar);
        }

        // POST: TrabajosEstandars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrabajoEstandarId,InspeccionComponenteId,Unidad,Precio,Descripcion")] TrabajosEstandar trabajosEstandar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajosEstandar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InspeccionComponenteId = new SelectList(db.InspeccionComponentes, "InspeccionComponenteId", "Calificacion", trabajosEstandar.InspeccionComponenteId);
            return View(trabajosEstandar);
        }

        // GET: TrabajosEstandars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrabajosEstandar trabajosEstandar = db.TrabajosEstandar.Find(id);
            if (trabajosEstandar == null)
            {
                return HttpNotFound();
            }
            return View(trabajosEstandar);
        }

        // POST: TrabajosEstandars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrabajosEstandar trabajosEstandar = db.TrabajosEstandar.Find(id);
            db.TrabajosEstandar.Remove(trabajosEstandar);
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
