using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class LogCliente
    {
        #region Singleton

        static LogCliente()
        {

        }

        private LogCliente()
        {

        }

        public static LogCliente Instance { get; } = new LogCliente();

        #endregion Singleton

        public bool CrearCliente(EntCliente cliente)
        {
            try
            {
                EntCliente dniFinded = DatCliente.Instance.BuscarDni(cliente.Dni);

                if(dniFinded!=null)
                {
                    return false;
                }

                return DatCliente.Instance.CrearCliente(cliente);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool EliminarCliente(EntCliente cliente)
        {
            try
            {
                return DatCliente.Instance.EliminarCliente(cliente);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public EntCliente BuscarDni(string Dni)
        {
            try
            {
                return DatCliente.Instance.BuscarDni(Dni);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
