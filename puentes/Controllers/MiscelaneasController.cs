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
    public class MiscelaneasController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: Miscelaneas
        public ActionResult Index()
        {
            var miscelaneas = db.Miscelaneas.Include(m => m.Estructuras);
            return View(miscelaneas.ToList());
        }

        // GET: Miscelaneas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miscelaneas miscelaneas = db.Miscelaneas.Find(id);
            if (miscelaneas == null)
            {
                return HttpNotFound();
            }
            return View(miscelaneas);
        }

        // GET: Miscelaneas/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: Miscelaneas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MiscelaneaId,EstructuraId,RespInspeccionId,ProyectistaId,LatitudG,LatitudM,LatitudS,LongitudG,LongitudM,LongitudS,Altitud,TipoInstalacionesId")] Miscelaneas miscelaneas)
        {
            if (ModelState.IsValid)
            {
                db.Miscelaneas.Add(miscelaneas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", miscelaneas.EstructuraId);
            return View(miscelaneas);
        }

        // GET: Miscelaneas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miscelaneas miscelaneas = db.Miscelaneas.Find(id);
            if (miscelaneas == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", miscelaneas.EstructuraId);
            return View(miscelaneas);
        }

        // POST: Miscelaneas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MiscelaneaId,EstructuraId,RespInspeccionId,ProyectistaId,LatitudG,LatitudM,LatitudS,LongitudG,LongitudM,LongitudS,Altitud,TipoInstalacionesId")] Miscelaneas miscelaneas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miscelaneas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", miscelaneas.EstructuraId);
            return View(miscelaneas);
        }

        // GET: Miscelaneas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miscelaneas miscelaneas = db.Miscelaneas.Find(id);
            if (miscelaneas == null)
            {
                return HttpNotFound();
            }
            return View(miscelaneas);
        }

        // POST: Miscelaneas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miscelaneas miscelaneas = db.Miscelaneas.Find(id);
            db.Miscelaneas.Remove(miscelaneas);
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
