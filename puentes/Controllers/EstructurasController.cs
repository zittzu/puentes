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
    public class EstructurasController : Controller
    {
        private DBPUENTESEntities db = new DBPUENTESEntities();



        // GET: Estructuras
        public ActionResult Index()
        {
            var todasLasEstructuras = db.Estructuras.ToList();
            return View(todasLasEstructuras);
        }

        // GET: Estructuras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estructuras estructuras = db.Estructuras.Find(id);
            if (estructuras == null)
            {
                return HttpNotFound();
            }
            return View(estructuras);
        }

        // Vistas filtradas por EstructuraTipoId

        // Vista para estructuras con EstructuraTipoId = 1
        public ActionResult DetailsTipo1()
        {
            var estructuraTipoId1 = db.Estructuras.Where(e => e.EstructuraTipoId == 1).ToList();
            return View(estructuraTipoId1);
        }

        // Vista para estructuras con EstructuraTipoId = 2
        public ActionResult DetailsTipo2()
        {
            var estructuraTipoId2 = db.Estructuras.Where(e => e.EstructuraTipoId == 2).ToList();
            return View(estructuraTipoId2);
        }



        // GET: Estructuras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estructuras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstructuraId,EstructuraTipoId,NumeroRegistro,Identificacion,Nombre,CarreteraId,DepartamentoId,MunicipioId,PMS,PKM,AnioConstruccion,CatalogoCarreteraId,CatalogoRequisitoId,FechaRecoleccionDatos,EstadoId")] Estructuras estructuras)
        {
            if (ModelState.IsValid)
            {
                db.Estructuras.Add(estructuras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estructuras);
        }

        // GET: Estructuras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estructuras estructuras = db.Estructuras.Find(id);
            if (estructuras == null)
            {
                return HttpNotFound();
            }
            return View(estructuras);
        }

        // POST: Estructuras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstructuraId,EstructuraTipoId,NumeroRegistro,Identificacion,Nombre,CarreteraId,DepartamentoId,MunicipioId,PMS,PKM,AnioConstruccion,CatalogoCarreteraId,CatalogoRequisitoId,FechaRecoleccionDatos,EstadoId")] Estructuras estructuras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estructuras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estructuras);
        }

        // GET: Estructuras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estructuras estructuras = db.Estructuras.Find(id);
            if (estructuras == null)
            {
                return HttpNotFound();
            }
            return View(estructuras);
        }

        // POST: Estructuras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estructuras estructuras = db.Estructuras.Find(id);
            db.Estructuras.Remove(estructuras);
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
