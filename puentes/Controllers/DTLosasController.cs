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
    public class DTLosasController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: DTLosas
        public ActionResult Index()
        {
            var dTLosa = db.DTLosa.Include(d => d.Estructuras);
            return View(dTLosa.ToList());
        }

        // GET: DTLosas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTLosa dTLosa = db.DTLosa.Find(id);
            if (dTLosa == null)
            {
                return HttpNotFound();
            }
            return View(dTLosa);
        }

        // GET: DTLosas/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: DTLosas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DTLosaId,EstructuraId,LosaInferior,LosaSuperior,SeccionTrasversa,DiseñoDeEvaluacion,MaterialId,Espesor,MunicipioID")] DTLosa dTLosa)
        {
            if (ModelState.IsValid)
            {
                db.DTLosa.Add(dTLosa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTLosa.EstructuraId);
            return View(dTLosa);
        }

        // GET: DTLosas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTLosa dTLosa = db.DTLosa.Find(id);
            if (dTLosa == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTLosa.EstructuraId);
            return View(dTLosa);
        }

        // POST: DTLosas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DTLosaId,EstructuraId,LosaInferior,LosaSuperior,SeccionTrasversa,DiseñoDeEvaluacion,MaterialId,Espesor,MunicipioID")] DTLosa dTLosa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTLosa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTLosa.EstructuraId);
            return View(dTLosa);
        }

        // GET: DTLosas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTLosa dTLosa = db.DTLosa.Find(id);
            if (dTLosa == null)
            {
                return HttpNotFound();
            }
            return View(dTLosa);
        }

        // POST: DTLosas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DTLosa dTLosa = db.DTLosa.Find(id);
            db.DTLosa.Remove(dTLosa);
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
