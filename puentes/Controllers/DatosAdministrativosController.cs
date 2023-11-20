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
    public class DatosAdministrativosController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: DatosAdministrativos
        public ActionResult Index()
        {
            var datosAdministrativos = db.DatosAdministrativos.Include(d => d.Estructuras);
            return View(datosAdministrativos.ToList());
        }

        // GET: DatosAdministrativos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosAdministrativos datosAdministrativos = db.DatosAdministrativos.Find(id);
            if (datosAdministrativos == null)
            {
                return HttpNotFound();
            }
            return View(datosAdministrativos);
        }

        // GET: DatosAdministrativos/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion");
            return View();
        }

        // POST: DatosAdministrativos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatosAdminId,EstructuraId,AnioReconstruccion")] DatosAdministrativos datosAdministrativos)
        {
            if (ModelState.IsValid)
            {
                db.DatosAdministrativos.Add(datosAdministrativos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", datosAdministrativos.EstructuraId);
            return View(datosAdministrativos);
        }

        // GET: DatosAdministrativos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosAdministrativos datosAdministrativos = db.DatosAdministrativos.Find(id);
            if (datosAdministrativos == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", datosAdministrativos.EstructuraId);
            return View(datosAdministrativos);
        }

        // POST: DatosAdministrativos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DatosAdminId,EstructuraId,AnioReconstruccion")] DatosAdministrativos datosAdministrativos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosAdministrativos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraId = new SelectList(db.Estructuras, "EstructuraId", "Identificacion", datosAdministrativos.EstructuraId);
            return View(datosAdministrativos);
        }

        // GET: DatosAdministrativos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosAdministrativos datosAdministrativos = db.DatosAdministrativos.Find(id);
            if (datosAdministrativos == null)
            {
                return HttpNotFound();
            }
            return View(datosAdministrativos);
        }

        // POST: DatosAdministrativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosAdministrativos datosAdministrativos = db.DatosAdministrativos.Find(id);
            db.DatosAdministrativos.Remove(datosAdministrativos);
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
