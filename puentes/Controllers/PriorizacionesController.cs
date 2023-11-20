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
    public class PriorizacionesController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: Priorizaciones
        public ActionResult Index()
        {
            var priorizaciones = db.Priorizaciones.Include(p => p.Estructuras);
            return View(priorizaciones.ToList());
        }

        // GET: Priorizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorizaciones priorizaciones = db.Priorizaciones.Find(id);
            if (priorizaciones == null)
            {
                return HttpNotFound();
            }
            return View(priorizaciones);
        }

        // GET: Priorizaciones/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: Priorizaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriorizacionId,EstructuraId,Calificacion,Pririzacion,PriorizacionFinal,Costo,Transito,Descripcion")] Priorizaciones priorizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Priorizaciones.Add(priorizaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", priorizaciones.EstructuraId);
            return View(priorizaciones);
        }

        // GET: Priorizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorizaciones priorizaciones = db.Priorizaciones.Find(id);
            if (priorizaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", priorizaciones.EstructuraId);
            return View(priorizaciones);
        }

        // POST: Priorizaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriorizacionId,EstructuraId,Calificacion,Pririzacion,PriorizacionFinal,Costo,Transito,Descripcion")] Priorizaciones priorizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priorizaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", priorizaciones.EstructuraId);
            return View(priorizaciones);
        }

        // GET: Priorizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorizaciones priorizaciones = db.Priorizaciones.Find(id);
            if (priorizaciones == null)
            {
                return HttpNotFound();
            }
            return View(priorizaciones);
        }

        // POST: Priorizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Priorizaciones priorizaciones = db.Priorizaciones.Find(id);
            db.Priorizaciones.Remove(priorizaciones);
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
