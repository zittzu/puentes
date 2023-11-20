using puentes.Controllers;
using puentes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace puentes.Filters
{
    public class VerificaSesion : ActionFilterAttribute
    {
        private tablausuario oUsuario;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);
                oUsuario = (tablausuario)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {
                    if(filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }
                    
                }
            }
            catch (Exception ) 
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }

    }
}