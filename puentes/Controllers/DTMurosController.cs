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
    public class DTMurosController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: DTMuros
        public ActionResult Index()
        {
            var dTMuros = db.DTMuros.Include(d => d.Estructuras);
            return View(dTMuros.ToList());
        }

        // GET: DTMuros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTMuros dTMuros = db.DTMuros.Find(id);
            if (dTMuros == null)
            {
                return HttpNotFound();
            }
            return View(dTMuros);
        }

        // GET: DTMuros/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: DTMuros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DTMuroId,EstructuraId,MuroTipoId,MaterialTipoId,Espesor,CimentacionTipoId")] DTMuros dTMuros)
        {
            if (ModelState.IsValid)
            {
                db.DTMuros.Add(dTMuros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTMuros.EstructuraId);
            return View(dTMuros);
        }

        // GET: DTMuros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTMuros dTMuros = db.DTMuros.Find(id);
            if (dTMuros == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTMuros.EstructuraId);
            return View(dTMuros);
        }

        // POST: DTMuros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DTMuroId,EstructuraId,MuroTipoId,MaterialTipoId,Espesor,CimentacionTipoId")] DTMuros dTMuros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTMuros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTMuros.EstructuraId);
            return View(dTMuros);
        }

        // GET: DTMuros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTMuros dTMuros = db.DTMuros.Find(id);
            if (dTMuros == null)
            {
                return HttpNotFound();
            }
            return View(dTMuros);
        }

        // POST: DTMuros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DTMuros dTMuros = db.DTMuros.Find(id);
            db.DTMuros.Remove(dTMuros);
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
