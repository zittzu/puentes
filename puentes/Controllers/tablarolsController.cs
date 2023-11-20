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
    public class tablarolsController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: tablarols
        public ActionResult Index()
        {
            return View(db.tablarol.ToList());
        }

        // GET: tablarols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablarol tablarol = db.tablarol.Find(id);
            if (tablarol == null)
            {
                return HttpNotFound();
            }
            return View(tablarol);
        }

        // GET: tablarols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tablarols/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombreRol")] tablarol tablarol)
        {
            if (ModelState.IsValid)
            {
                db.tablarol.Add(tablarol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablarol);
        }

        // GET: tablarols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablarol tablarol = db.tablarol.Find(id);
            if (tablarol == null)
            {
                return HttpNotFound();
            }
            return View(tablarol);
        }

        // POST: tablarols/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombreRol")] tablarol tablarol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablarol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablarol);
        }

        // GET: tablarols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablarol tablarol = db.tablarol.Find(id);
            if (tablarol == null)
            {
                return HttpNotFound();
            }
            return View(tablarol);
        }

        // POST: tablarols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tablarol tablarol = db.tablarol.Find(id);
            db.tablarol.Remove(tablarol);
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
