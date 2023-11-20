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
    public class InspeccionesController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: Inspecciones
        public ActionResult Index()
        {
            var inspecciones = db.Inspecciones.Include(i => i.Estructuras);
            return View(inspecciones.ToList());
        }

        // GET: Inspecciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspecciones inspecciones = db.Inspecciones.Find(id);
            if (inspecciones == null)
            {
                return HttpNotFound();
            }
            return View(inspecciones);
        }

        // GET: Inspecciones/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: Inspecciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InspeccionId,EstructuraId,Fecha,Numero,TipoInspeccionId,AnioProxInsp,TransitoTPDA,EstacionConteo,VehLivianos,VehPesados,Observaciones")] Inspecciones inspecciones)
        {
            if (ModelState.IsValid)
            {
                db.Inspecciones.Add(inspecciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", inspecciones.EstructuraId);
            return View(inspecciones);
        }

        // GET: Inspecciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspecciones inspecciones = db.Inspecciones.Find(id);
            if (inspecciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", inspecciones.EstructuraId);
            return View(inspecciones);
        }

        // POST: Inspecciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InspeccionId,EstructuraId,Fecha,Numero,TipoInspeccionId,AnioProxInsp,TransitoTPDA,EstacionConteo,VehLivianos,VehPesados,Observaciones")] Inspecciones inspecciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspecciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", inspecciones.EstructuraId);
            return View(inspecciones);
        }

        // GET: Inspecciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspecciones inspecciones = db.Inspecciones.Find(id);
            if (inspecciones == null)
            {
                return HttpNotFound();
            }
            return View(inspecciones);
        }

        // POST: Inspecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inspecciones inspecciones = db.Inspecciones.Find(id);
            db.Inspecciones.Remove(inspecciones);
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
