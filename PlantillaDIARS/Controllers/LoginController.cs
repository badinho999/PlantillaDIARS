using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogica;

namespace PlantillaDIARS.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult VerificarAcceso(string username, string key)
        {
            
            List<EntHashtable> lista = LogHashtable.Instance.BuscarPasswordSingUp();
            string hashcode = "";

            bool existe = false;

            foreach (var hash in lista)
            {
                if (LogHashing.Instance.Comparar(key, hash.HashCode))
                {
                    hashcode = hash.HashCode;
                    existe = true;
                }
            }


            if (existe)
            {
                EntAccount account = LogAccount.Instance.VerificarAcceso(username, hashcode);
                if (account != null)
                {
                    Session["cuenta"] = account;

                    var redirectUrl = new UrlHelper(Request.RequestContext).Action("MenuIntranet", "MenuIntranet");


                    return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(null,JsonRequestBehavior.AllowGet);
        }

    }
}