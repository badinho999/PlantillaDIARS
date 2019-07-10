using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogica;

namespace PlantillaDIARS.Controllers
{
    public class AccountController : Controller
    {
        //[HttpGet]
        //public ActionResult NuevaCuenta(int ClienteID)
        //{
        //    ViewBag.ClienteID = ClienteID;
        //    return View(ClienteID);
        //}
        //[HttpPost]
        //public ActionResult NuevaCuenta(FormCollection form)
        //{
        //    try
        //    {

        //        EntCliente cliente = new EntCliente
        //        {
        //            ClienteID = Convert.ToInt32(form["clienteID"])
        //        };

        //        EntAccount cuenta = new EntAccount
        //        {
        //            Cliente = cliente,
        //            Email = Convert.ToString(form["email"]),
        //            Fechacreacion = DateTime.Now.ToString("MM/dd/yyyy"),
        //            NombreUsuario = Convert.ToString(form["username"]),
        //            Telefono = Convert.ToString(form["telf"])                    
        //        };

        //        if (!ModelState.IsValid)
        //        {
        //            return View("NuevaCuenta", cliente);
        //        }

        //        bool nuevaCuenta = LogAccount.Instance.CrearCuenta(cuenta);

        //        if (nuevaCuenta)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            return View("NuevaCuenta", cuenta);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("NuevaCuenta", new { mesjException = ex.Message });
        //    }
        //}

        public JsonResult NewAccount(EntAccountViewData accountViewData)
        {
            //Crea cuenta primero
            bool cuentaCreada = LogAccount.Instance.CrearCuenta(accountViewData.account);
            //Encrypt Password
            string hashcode = "";
            string password = accountViewData.PasswordAccount.PasswordString;

            if (cuentaCreada)
            {
                
                EntPasswordAccount passwordAccount = new EntPasswordAccount
                {
                    PasswordString = accountViewData.PasswordAccount.PasswordString
                };

                //Verificamos si existe una contraseña de la lista hash
                List<EntHashtable> lista = LogHashtable.Instance.BuscarPasswordSingUp();
                bool existe = false;

                if(lista.Count>0)
                {
                    foreach (var hash in lista)
                    {
                        if (LogHashing.Instance.Comparar(password, hash.HashCode))
                        {
                            hashcode = hash.HashCode;
                            existe = true;
                        }
                    }
                }

                if (existe)
                {

                    EntHashtable hashtable = new EntHashtable
                    {
                        HashCode = hashcode
                    };

                    EntAccountHashTable accountHashTable = new EntAccountHashTable
                    {
                        Cuenta = accountViewData.account,
                        Hashtable = hashtable
                    };

                    //Si se encontró enlaza la cuenta con la contraseña
                    if (LogAccountHashTable.Instance.EnlazarHashCuenta(accountHashTable))
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    hashcode = LogHashing.Instance.Encrypt(password);

                    EntHashtable hashtable = new EntHashtable
                    {
                        HashCode = hashcode
                    };

                    //Si la contraseña es nueva, crea un nuevo hash
                    bool hashtableCreate = LogHashtable.Instance.NewHash(hashtable);

                    if(hashtableCreate)
                    {
                        passwordAccount.Hashtable = hashtable;

                        //Crea una nueva contraseña
                        bool newPassCreated = LogPasswordAccount.Instance.NewPassword(passwordAccount);

                        if(newPassCreated)
                        {
                            EntAccountHashTable accountHashTable = new EntAccountHashTable
                            {
                                Cuenta = accountViewData.account,
                                Hashtable = hashtable
                            };

                            //Enlaza la nueva contraseña
                            if(LogAccountHashTable.Instance.EnlazarHashCuenta(accountHashTable))
                            {
                                return Json(true, JsonRequestBehavior.AllowGet);
                            }

                            return Json(false, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {

                            return Json(false, JsonRequestBehavior.AllowGet);
                        }

                    }
                    return Json(false, JsonRequestBehavior.AllowGet);

                }
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        //Verificar email
        
        public JsonResult VerifyEmail(string email)
        {
            return Json(LogAccount.Instance.VerifyEmail(email), JsonRequestBehavior.AllowGet);
        }

        //Verificar username
        public JsonResult VirifyUsername(string NombreUsuario)
        {
            return Json(LogAccount.Instance.BuscarUsername(NombreUsuario), JsonRequestBehavior.AllowGet);
        }
    }
}