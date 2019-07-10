using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;
using System.Security.Cryptography;

namespace CapaLogica
{
    public class LogPasswordAccount
    {
        #region Singleton

        static LogPasswordAccount()
        {

        }

        private LogPasswordAccount()
        {

        }

        public static LogPasswordAccount Instance { get; } = new LogPasswordAccount();

        #endregion Singleton

        public bool NewPassword(EntPasswordAccount passwordAccount)
        {
            try
            {
                //var a = new SHA512CryptoServiceProvider();

                return DatPasswordAccount.Instance.NewPassword(passwordAccount);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
