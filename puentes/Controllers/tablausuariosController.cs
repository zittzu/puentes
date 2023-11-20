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
    public class tablausuariosController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: tablausuarios
        public ActionResult Index()
        {
            return View(db.tablausuario.ToList());
        }

        // GET: tablausuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablausuario tablausuario = db.tablausuario.Find(id);
            if (tablausuario == null)
            {
                return HttpNotFound();
            }
            return View(tablausuario);
        }

        // GET: tablausuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tablausuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Idrol,nombres,apellido,Usuario,password")] tablausuario tablausuario)
        {
            if (ModelState.IsValid)
            {
                db.tablausuario.Add(tablausuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablausuario);
        }

        // GET: tablausuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablausuario tablausuario = db.tablausuario.Find(id);
            if (tablausuario == null)
            {
                return HttpNotFound();
            }
            return View(tablausuario);
        }

        // POST: tablausuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Idrol,nombres,apellido,Usuario,password")] tablausuario tablausuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablausuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablausuario);
        }

        // GET: tablausuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablausuario tablausuario = db.tablausuario.Find(id);
            if (tablausuario == null)
            {
                return HttpNotFound();
            }
            return View(tablausuario);
        }

        // POST: tablausuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tablausuario tablausuario = db.tablausuario.Find(id);
            db.tablausuario.Remove(tablausuario);
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
