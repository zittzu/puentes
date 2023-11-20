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
    public class AuditoriasController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();

        // GET: Auditorias
        public ActionResult Index()
        {
            return View(db.Auditoria.ToList());
        }

        // GET: Auditorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditoria auditoria = db.Auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // GET: Auditorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auditorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuditoriaId,Fecha,Entidad,ValorKeyEntidad,UsuarioId,UsuarioName,Operacion,ValoresAnterior,ValoresNuevo,MaquinaIp")] Auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                db.Auditoria.Add(auditoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auditoria);
        }

        // GET: Auditorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditoria auditoria = db.Auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // POST: Auditorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuditoriaId,Fecha,Entidad,ValorKeyEntidad,UsuarioId,UsuarioName,Operacion,ValoresAnterior,ValoresNuevo,MaquinaIp")] Auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auditoria);
        }

        // GET: Auditorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditoria auditoria = db.Auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // POST: Auditorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auditoria auditoria = db.Auditoria.Find(id);
            db.Auditoria.Remove(auditoria);
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
