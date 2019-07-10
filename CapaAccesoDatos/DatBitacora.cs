using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DatBitacora
    {
        #region Singleton

        static DatBitacora()
        {

        }

        private DatBitacora()
        {

        }

        public static DatBitacora Instance { get; } = new DatBitacora();

        #endregion Singleton

        public EntBitacora MostrarBitacora(EntAccount cuenta)
        {
            SqlCommand cmd = null;
            EntBitacora bitacora = null;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_MostrarBitacora", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmstrAccountID", cuenta.NombreUsuario);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bitacora = new EntBitacora
                    {
                        Ingreso = Convert.ToString(reader["Ingreso"]),
                        Salida = Convert.ToString(reader["Salida"]),
                        BitacoraID = Convert.ToInt32(reader["BitacoraID"])
                    };

                }
            }
            catch (SqlException err)
            {

                throw err;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return bitacora;
        }

        public bool GenerarBitacora(EntAccount cuenta)
        {
            SqlCommand cmd = null;
            bool crea;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_GenerarBitacora", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@prmstrNombreUsuario", cuenta.NombreUsuario);

                conexion.Open();
                int result = cmd.ExecuteNonQuery();
                crea = result > 0 ? true : false;

            }
            catch (SqlException err)
            {

                throw err;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return crea;
        }

        public bool GenerarSalida(EntAccount cuenta, EntBitacora bitacora)
        {
            SqlCommand cmd = null;
            bool crea;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_GenerarSalida", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@prmstrNombreUsuario", cuenta.NombreUsuario);
                cmd.Parameters.AddWithValue("@prmintBitacoraID", bitacora.BitacoraID);

                conexion.Open();
                int result = cmd.ExecuteNonQuery();
                crea = result > 0 ? true : false;

            }
            catch (SqlException err)
            {

                throw err;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return crea;
        }

    }
}
