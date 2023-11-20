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
    public class InspeccionComponenteFotosController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: InspeccionComponenteFotos
        public ActionResult Index()
        {
            var inspeccionComponenteFotos = db.InspeccionComponenteFotos.Include(i => i.InspeccionComponentes);
            return View(inspeccionComponenteFotos.ToList());
        }

        // GET: InspeccionComponenteFotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspeccionComponenteFotos inspeccionComponenteFotos = db.InspeccionComponenteFotos.Find(id);
            if (inspeccionComponenteFotos == null)
            {
                return HttpNotFound();
            }
            return View(inspeccionComponenteFotos);
        }

        // GET: InspeccionComponenteFotos/Create
        public ActionResult Create()
        {
            ViewBag.InspeccionComponenteId = new SelectList(db.InspeccionComponentes, "InspeccionComponenteId", "Calificacion");
            return View();
        }

        // POST: InspeccionComponenteFotos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InspeccionComponenteFotoId,InspeccionComponenteId,RutaFotos")] InspeccionComponenteFotos inspeccionComponenteFotos)
        {
            if (ModelState.IsValid)
            {
                db.InspeccionComponenteFotos.Add(inspeccionComponenteFotos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InspeccionComponenteId = new SelectList(db.InspeccionComponentes, "InspeccionComponenteId", "Calificacion", inspeccionComponenteFotos.InspeccionComponenteId);
            return View(inspeccionComponenteFotos);
        }

        // GET: InspeccionComponenteFotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspeccionComponenteFotos inspeccionComponenteFotos = db.InspeccionComponenteFotos.Find(id);
            if (inspeccionComponenteFotos == null)
            {
                return HttpNotFound();
            }
            ViewBag.InspeccionComponenteId = new SelectList(db.InspeccionComponentes, "InspeccionComponenteId", "Calificacion", inspeccionComponenteFotos.InspeccionComponenteId);
            return View(inspeccionComponenteFotos);
        }

        // POST: InspeccionComponenteFotos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InspeccionComponenteFotoId,InspeccionComponenteId,RutaFotos")] InspeccionComponenteFotos inspeccionComponenteFotos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspeccionComponenteFotos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InspeccionComponenteId = new SelectList(db.InspeccionComponentes, "InspeccionComponenteId", "Calificacion", inspeccionComponenteFotos.InspeccionComponenteId);
            return View(inspeccionComponenteFotos);
        }

        // GET: InspeccionComponenteFotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspeccionComponenteFotos inspeccionComponenteFotos = db.InspeccionComponenteFotos.Find(id);
            if (inspeccionComponenteFotos == null)
            {
                return HttpNotFound();
            }
            return View(inspeccionComponenteFotos);
        }

        // POST: InspeccionComponenteFotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InspeccionComponenteFotos inspeccionComponenteFotos = db.InspeccionComponenteFotos.Find(id);
            db.InspeccionComponenteFotos.Remove(inspeccionComponenteFotos);
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
