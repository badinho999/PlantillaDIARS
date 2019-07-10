using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DatCliente
    {
        #region Singleton

        static DatCliente()
        {

        }

        private DatCliente()
        {

        }

        public static DatCliente Instance { get; } = new DatCliente();

        #endregion Singleton

        //public List<EntCliente> ListaClientes()
        //{
        //    SqlCommand cmd = null;
        //    List<EntCliente> lista = null;

        //    try
        //    {
        //        SqlConnection conexion = Conexion.Instance.Conectar();
        //        cmd = new SqlCommand("SP_MostrarClientes", conexion)
        //        {
        //            CommandType = System.Data.CommandType.StoredProcedure
        //        };
        //        conexion.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while(reader.Read())
        //        {
        //            EntCliente cliente = new EntCliente
        //            //{
        //            //    ApellidosCliente = Convert.ToString(reader["ApellidosCliente"]),
        //            //    ApellidosCliente = Convert.ToString(reader["NombreCliente"]),
        //            //    ApellidosCliente = Convert.ToString(reader["FechaNacimiento"]),
        //            //    ApellidosCliente = Convert.ToString(reader["Sexo"]),
        //            };
        //        }
        //    }
        //    catch (SqlException e)
        //    {

        //        throw e;
        //    }
        //}

        //Crear cliente
        public bool CrearCliente(EntCliente cliente)
        {
            SqlCommand cmd = null;
            bool crea;
            

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_CrearCliente", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                string sexo = cliente.Sexo ? "M" : "F";

                cmd.Parameters.AddWithValue("@prmstrDni", cliente.Dni);
                cmd.Parameters.AddWithValue("@prmstrApellidosCliente", cliente.ApellidosCliente);
                cmd.Parameters.AddWithValue("@prmstrFechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@prmstrNombreCliente", cliente.NombreCliente);
                cmd.Parameters.AddWithValue("@prmcharSexo", sexo);
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

        public bool EliminarCliente(EntCliente cliente)
        {
            SqlCommand cmd = null;
            bool delete;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_EliminarCliente", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@prmstrDni", cliente.Dni);

                conexion.Open();
                int result = cmd.ExecuteNonQuery();
                delete = result > 0 ? true : false;

            }
            catch (SqlException err)
            {

                throw err;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return delete;
        }

        public EntCliente BuscarDni(string Dni)
        {
            SqlCommand cmd = null;
            EntCliente cliente = null;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_BuscarDni", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmstrDni", Dni);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new EntCliente
                    {
                        Dni = Convert.ToString(reader["Dni"])
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
            return cliente;
        }
    }
}
