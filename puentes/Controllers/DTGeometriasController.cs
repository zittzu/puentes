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
    public class DTGeometriasController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: DTGeometrias
        public ActionResult Index()
        {
            var dTGeometrias = db.DTGeometrias.Include(d => d.Estructuras);
            return View(dTGeometrias.ToList());
        }

        // GET: DTGeometrias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTGeometrias dTGeometrias = db.DTGeometrias.Find(id);
            if (dTGeometrias == null)
            {
                return HttpNotFound();
            }
            return View(dTGeometrias);
        }

        // GET: DTGeometrias/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: DTGeometrias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DTGeometriaId,EstructuraId,Numeroclaros,LongitudClaroMinimo,LongitudClaroMaximos,LongitudTotal,AnchoTotal,AnchoMediana,AnchoAceraIzq,AnchoAceraDer,AnchoCalzada,AnchoBordillos,AnchoAcceso,Area,CurvaTangente,Esviajamiento")] DTGeometrias dTGeometrias)
        {
            if (ModelState.IsValid)
            {
                db.DTGeometrias.Add(dTGeometrias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTGeometrias.EstructuraId);
            return View(dTGeometrias);
        }

        // GET: DTGeometrias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTGeometrias dTGeometrias = db.DTGeometrias.Find(id);
            if (dTGeometrias == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTGeometrias.EstructuraId);
            return View(dTGeometrias);
        }

        // POST: DTGeometrias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DTGeometriaId,EstructuraId,Numeroclaros,LongitudClaroMinimo,LongitudClaroMaximos,LongitudTotal,AnchoTotal,AnchoMediana,AnchoAceraIzq,AnchoAceraDer,AnchoCalzada,AnchoBordillos,AnchoAcceso,Area,CurvaTangente,Esviajamiento")] DTGeometrias dTGeometrias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTGeometrias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTGeometrias.EstructuraId);
            return View(dTGeometrias);
        }

        // GET: DTGeometrias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTGeometrias dTGeometrias = db.DTGeometrias.Find(id);
            if (dTGeometrias == null)
            {
                return HttpNotFound();
            }
            return View(dTGeometrias);
        }

        // POST: DTGeometrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DTGeometrias dTGeometrias = db.DTGeometrias.Find(id);
            db.DTGeometrias.Remove(dTGeometrias);
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
