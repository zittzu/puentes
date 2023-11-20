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
    public class CatalogosController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: Catalogos
        public ActionResult Index()
        {
            return View(db.Catalogos.ToList());
        }

        // GET: Catalogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogos catalogos = db.Catalogos.Find(id);
            if (catalogos == null)
            {
                return HttpNotFound();
            }
            return View(catalogos);
        }

        // GET: Catalogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatalogoId,TipoCatalogoId,Codigo,Nombre,EstadoId")] Catalogos catalogos)
        {
            if (ModelState.IsValid)
            {
                db.Catalogos.Add(catalogos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalogos);
        }

        // GET: Catalogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogos catalogos = db.Catalogos.Find(id);
            if (catalogos == null)
            {
                return HttpNotFound();
            }
            return View(catalogos);
        }

        // POST: Catalogos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatalogoId,TipoCatalogoId,Codigo,Nombre,EstadoId")] Catalogos catalogos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalogos);
        }

        // GET: Catalogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogos catalogos = db.Catalogos.Find(id);
            if (catalogos == null)
            {
                return HttpNotFound();
            }
            return View(catalogos);
        }

        // POST: Catalogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalogos catalogos = db.Catalogos.Find(id);
            db.Catalogos.Remove(catalogos);
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
