using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class LogHashtable
    {
        #region Singleton

        static LogHashtable()
        {

        }

        private LogHashtable()
        {

        }

        public static LogHashtable Instance { get; } = new LogHashtable();

        #endregion Singleton

        public bool NewHash(EntHashtable hashtable)
        {
            try
            {
                return DatHashtable.Instance.NewHash(hashtable);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public EntHashtable BuscarPassword(string nombreUsuario, string hashCode)
        {
            try
            {
                return DatHashtable.Instance.BuscarPassword(nombreUsuario, hashCode);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<EntHashtable> BuscarPasswordSingUp()
        {
            try
            {
                return DatHashtable.Instance.BuscarPasswordSingUp();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
