using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class LogBitacora
    {
        #region Singleton

        static LogBitacora()
        {

        }

        private LogBitacora()
        {

        }

        public static LogBitacora Instance { get; } = new LogBitacora();

        #endregion Singleton

        public EntBitacora MostrarBitacora(EntAccount cuenta)
        {
            try
            {
                return DatBitacora.Instance.MostrarBitacora(cuenta);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool GenerarBitacora(EntAccount cuenta)
        {
            try
            {
                return DatBitacora.Instance.GenerarBitacora(cuenta);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool GenerarSalida(EntAccount cuenta, EntBitacora bitacora)
        {
            try
            {
                return DatBitacora.Instance.GenerarSalida(cuenta, bitacora);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
