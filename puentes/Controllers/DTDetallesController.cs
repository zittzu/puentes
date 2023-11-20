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
    public class DTDetallesController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: DTDetalles
        public ActionResult Index()
        {
            var dTDetalles = db.DTDetalles.Include(d => d.Estructuras);
            return View(dTDetalles.ToList());
        }

        // GET: DTDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTDetalles dTDetalles = db.DTDetalles.Find(id);
            if (dTDetalles == null)
            {
                return HttpNotFound();
            }
            return View(dTDetalles);
        }

        // GET: DTDetalles/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: DTDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DTDetalleId,EstructuraId,TipoBarandaId,TipoDefensaId,TipoSuperRodId,TipoJuntaExpId,TipoApoyoFSoporteId,TipoApoyoMSoporteId,TipoApoyoFVigasId,TipoApoyoMVigasId")] DTDetalles dTDetalles)
        {
            if (ModelState.IsValid)
            {
                db.DTDetalles.Add(dTDetalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTDetalles.EstructuraId);
            return View(dTDetalles);
        }

        // GET: DTDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTDetalles dTDetalles = db.DTDetalles.Find(id);
            if (dTDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTDetalles.EstructuraId);
            return View(dTDetalles);
        }

        // POST: DTDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DTDetalleId,EstructuraId,TipoBarandaId,TipoDefensaId,TipoSuperRodId,TipoJuntaExpId,TipoApoyoFSoporteId,TipoApoyoMSoporteId,TipoApoyoFVigasId,TipoApoyoMVigasId")] DTDetalles dTDetalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTDetalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dTDetalles.EstructuraId);
            return View(dTDetalles);
        }

        // GET: DTDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTDetalles dTDetalles = db.DTDetalles.Find(id);
            if (dTDetalles == null)
            {
                return HttpNotFound();
            }
            return View(dTDetalles);
        }

        // POST: DTDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DTDetalles dTDetalles = db.DTDetalles.Find(id);
            db.DTDetalles.Remove(dTDetalles);
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
