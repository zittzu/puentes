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
    public class TramosController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: Tramos
        public ActionResult Index()
        {
            var tramos = db.Tramos.Include(t => t.Estructuras);
            return View(tramos.ToList());
        }

        // GET: Tramos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tramos tramos = db.Tramos.Find(id);
            if (tramos == null)
            {
                return HttpNotFound();
            }
            return View(tramos);
        }

        // GET: Tramos/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: Tramos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TramoId,EstructuraId,NumPaso,TipoPasoId,PasoPrimero,Paso,Identificacion,Nombre,Lado,PMSkm,PMSm,PKMkm,PKMm,CargaDiseño,ClaseDistribCargaId,NormaDiseñoId,GaliboVerticalI,GaliboVerticalIM,GaliboVerticalDM,GaliboVerticalD,ClasePuente,Restringido,CargaEjeMaxima,ConsultorId,FechaCapacidad")] Tramos tramos)
        {
            if (ModelState.IsValid)
            {
                db.Tramos.Add(tramos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", tramos.EstructuraId);
            return View(tramos);
        }

        // GET: Tramos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tramos tramos = db.Tramos.Find(id);
            if (tramos == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", tramos.EstructuraId);
            return View(tramos);
        }

        // POST: Tramos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TramoId,EstructuraId,NumPaso,TipoPasoId,PasoPrimero,Paso,Identificacion,Nombre,Lado,PMSkm,PMSm,PKMkm,PKMm,CargaDiseño,ClaseDistribCargaId,NormaDiseñoId,GaliboVerticalI,GaliboVerticalIM,GaliboVerticalDM,GaliboVerticalD,ClasePuente,Restringido,CargaEjeMaxima,ConsultorId,FechaCapacidad")] Tramos tramos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tramos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", tramos.EstructuraId);
            return View(tramos);
        }

        // GET: Tramos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tramos tramos = db.Tramos.Find(id);
            if (tramos == null)
            {
                return HttpNotFound();
            }
            return View(tramos);
        }

        // POST: Tramos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tramos tramos = db.Tramos.Find(id);
            db.Tramos.Remove(tramos);
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
