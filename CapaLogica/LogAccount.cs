using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class LogAccount
    {
        #region Singleton

        static LogAccount()
        {

        }

        private LogAccount()
        {

        }

        public static LogAccount Instance { get; } = new LogAccount();

        #endregion Singleton

        public bool CrearCuenta(EntAccount cuenta)
        {
            try
            {

                EntAccount emailAccountFinded = DatAccount.Instance.BuscarEmail(cuenta.Email);
                EntAccount usernameFinded = DatAccount.Instance.BuscarUsername(cuenta.NombreUsuario);

                if(emailAccountFinded!=null)
                {
                    return false;
                    
                }
                if(usernameFinded!=null)
                {
                    return false;
                }
               
                return DatAccount.Instance.CrearCuenta(cuenta);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public EntAccount VerificarAcceso(string NombreUsuario, string Passwordstring)
        {
            try
            {
                return DatAccount.Instance.BuscarCuenta(NombreUsuario, Passwordstring);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public EntAccount VerifyEmail(string email)
        {
            try
            {
                return DatAccount.Instance.BuscarEmail(email);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public EntAccount BuscarUsername(string NombreUsuario)
        {
            try
            {
                return DatAccount.Instance.BuscarUsername(NombreUsuario);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
