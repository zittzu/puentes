using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using puentes.Models;

namespace puentes.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            try
            {

                using(Models.DBPUENTESEntities db = new Models.DBPUENTESEntities())
                {
                    var oUser = (from d in db.tablausuario
                                where d.Usuario == User.Trim() && d.password == Pass.Trim() select d).FirstOrDefault();

                    if(oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña incorrecta";
                        string mbox = "Usuario o contraseña incorrecta";
                        return View();
                    }

                    Session["User"] = oUser;
                }

                return RedirectToAction("Index", "Home");


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
          
        }
    }
}