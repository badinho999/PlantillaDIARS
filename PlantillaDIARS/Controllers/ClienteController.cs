using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogica;

namespace PlantillaDIARS.Controllers
{
    public class ClienteController : Controller
    {
        //[HttpGet]
        //public ActionResult NuevoCliente()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult NuevoCliente(EntCliente cliente,FormCollection form)
        //{
        //    try
        //    {
                
        //        Random rnd = new Random();

        //        bool sex;

        //        if(Convert.ToString(form["rbS"]) == "option1")
        //        {
        //            sex = true;
        //        }
        //        else
        //        {
        //            sex = false;
        //        }

        //        cliente.ClienteID = rnd.Next();
        //        cliente.Sexo = sex;

        //        if (!ModelState.IsValid)
        //        {
        //            return View("NuevoCliente",cliente);
        //        }

        //        bool nuevoCliente = LogCliente.Instance.CrearCliente(cliente);

        //        if(nuevoCliente)
        //        {
        //            return RedirectToAction("NuevaCuenta", "Account", new { cliente.ClienteID }); 
        //        }
        //        else
        //        {
        //            return View("NuevoCliente",cliente);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return HttpNotFound();
        //    }
        //}

        public JsonResult SignUp(EntCliente cliente)
        {
            return Json(LogCliente.Instance.CrearCliente(cliente), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCliente(EntCliente cliente)
        {
            return Json(LogCliente.Instance.EliminarCliente(cliente), JsonRequestBehavior.AllowGet);
        }

        //Verificar dni

        public JsonResult VerifyDni(string Dni)
        {
            return Json(LogCliente.Instance.BuscarDni(Dni),JsonRequestBehavior.AllowGet);
        }

    }
}