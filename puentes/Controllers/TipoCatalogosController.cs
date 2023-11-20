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
    public class TipoCatalogosController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: TipoCatalogos
        public ActionResult Index()
        {
            return View(db.TipoCatalogos.ToList());
        }

        // GET: TipoCatalogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCatalogos tipoCatalogos = db.TipoCatalogos.Find(id);
            if (tipoCatalogos == null)
            {
                return HttpNotFound();
            }
            return View(tipoCatalogos);
        }

        // GET: TipoCatalogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCatalogos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoCatalogoId,Nombre,EstadoId")] TipoCatalogos tipoCatalogos)
        {
            if (ModelState.IsValid)
            {
                db.TipoCatalogos.Add(tipoCatalogos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCatalogos);
        }

        // GET: TipoCatalogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCatalogos tipoCatalogos = db.TipoCatalogos.Find(id);
            if (tipoCatalogos == null)
            {
                return HttpNotFound();
            }
            return View(tipoCatalogos);
        }

        // POST: TipoCatalogos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoCatalogoId,Nombre,EstadoId")] TipoCatalogos tipoCatalogos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCatalogos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCatalogos);
        }

        // GET: TipoCatalogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCatalogos tipoCatalogos = db.TipoCatalogos.Find(id);
            if (tipoCatalogos == null)
            {
                return HttpNotFound();
            }
            return View(tipoCatalogos);
        }

        // POST: TipoCatalogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCatalogos tipoCatalogos = db.TipoCatalogos.Find(id);
            db.TipoCatalogos.Remove(tipoCatalogos);
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
