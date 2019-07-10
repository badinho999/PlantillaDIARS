using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class LogAccountHashTable
    {
        #region Singleton

        static LogAccountHashTable()
        {

        }

        private LogAccountHashTable()
        {

        }

        public static LogAccountHashTable Instance { get; } = new LogAccountHashTable();

        #endregion Singleton

        public bool EnlazarHashCuenta(EntAccountHashTable accountHashTable)
        {
            try
            {
                return DatAccountHashTable.Instance.EnlazarHashCuenta(accountHashTable);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool ActualizarEstado(EntAccountHashTable accountHashTable)
        {
            try
            {
                return DatAccountHashTable.Instance.ActualizarEstado(accountHashTable);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
