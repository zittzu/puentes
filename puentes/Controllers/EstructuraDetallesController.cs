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
    public class EstructuraDetallesController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: EstructuraDetalles
        public ActionResult Index()
        {
            var estructuraDetalles = db.EstructuraDetalles.Include(e => e.Estructuras);
            return View(estructuraDetalles.ToList());
        }

        // GET: EstructuraDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstructuraDetalles estructuraDetalles = db.EstructuraDetalles.Find(id);
            if (estructuraDetalles == null)
            {
                return HttpNotFound();
            }
            return View(estructuraDetalles);
        }

        // GET: EstructuraDetalles/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: EstructuraDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstructuraDetalleId,EstructuraId,PasoCauce,Desviacion,LongitudRutaDir,DesviacionPavim,DesviacionEstSeca,DesviacionEstLluvia,Observaciones")] EstructuraDetalles estructuraDetalles)
        {
            if (ModelState.IsValid)
            {
                db.EstructuraDetalles.Add(estructuraDetalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", estructuraDetalles.EstructuraId);
            return View(estructuraDetalles);
        }

        // GET: EstructuraDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstructuraDetalles estructuraDetalles = db.EstructuraDetalles.Find(id);
            if (estructuraDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", estructuraDetalles.EstructuraId);
            return View(estructuraDetalles);
        }

        // POST: EstructuraDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstructuraDetalleId,EstructuraId,PasoCauce,Desviacion,LongitudRutaDir,DesviacionPavim,DesviacionEstSeca,DesviacionEstLluvia,Observaciones")] EstructuraDetalles estructuraDetalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estructuraDetalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", estructuraDetalles.EstructuraId);
            return View(estructuraDetalles);
        }

        // GET: EstructuraDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstructuraDetalles estructuraDetalles = db.EstructuraDetalles.Find(id);
            if (estructuraDetalles == null)
            {
                return HttpNotFound();
            }
            return View(estructuraDetalles);
        }

        // POST: EstructuraDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstructuraDetalles estructuraDetalles = db.EstructuraDetalles.Find(id);
            db.EstructuraDetalles.Remove(estructuraDetalles);
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
