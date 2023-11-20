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
    public class DibujoCroquisController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: DibujoCroquis
        public ActionResult Index()
        {
            var dibujoCroquis = db.DibujoCroquis.Include(d => d.Estructuras);
            return View(dibujoCroquis.ToList());
        }

        // GET: DibujoCroquis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DibujoCroquis dibujoCroquis = db.DibujoCroquis.Find(id);
            if (dibujoCroquis == null)
            {
                return HttpNotFound();
            }
            return View(dibujoCroquis);
        }

        // GET: DibujoCroquis/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: DibujoCroquis/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DibujoCroquisId,EstructuraId,Nombre,Fecha,RutaDibujo")] DibujoCroquis dibujoCroquis)
        {
            if (ModelState.IsValid)
            {
                db.DibujoCroquis.Add(dibujoCroquis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dibujoCroquis.EstructuraId);
            return View(dibujoCroquis);
        }

        // GET: DibujoCroquis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DibujoCroquis dibujoCroquis = db.DibujoCroquis.Find(id);
            if (dibujoCroquis == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dibujoCroquis.EstructuraId);
            return View(dibujoCroquis);
        }

        // POST: DibujoCroquis/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DibujoCroquisId,EstructuraId,Nombre,Fecha,RutaDibujo")] DibujoCroquis dibujoCroquis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dibujoCroquis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", dibujoCroquis.EstructuraId);
            return View(dibujoCroquis);
        }

        // GET: DibujoCroquis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DibujoCroquis dibujoCroquis = db.DibujoCroquis.Find(id);
            if (dibujoCroquis == null)
            {
                return HttpNotFound();
            }
            return View(dibujoCroquis);
        }

        // POST: DibujoCroquis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DibujoCroquis dibujoCroquis = db.DibujoCroquis.Find(id);
            db.DibujoCroquis.Remove(dibujoCroquis);
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
