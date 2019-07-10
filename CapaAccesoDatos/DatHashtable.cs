using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DatHashtable
    {
        #region Singleton

        static DatHashtable()
        {

        }

        private DatHashtable()
        {

        }

        public static DatHashtable Instance { get; } = new DatHashtable();

        #endregion Singleton

        //New password
        public bool NewHash(EntHashtable hashtable)
        {
            SqlCommand cmd = null;
            bool create;

            try
            {
                SqlConnection connection = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_NewHash", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@prmstrHashCode", hashtable.HashCode);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                create = result > 0 ? true : false;

            }
            catch (SqlException err)
            {

                throw err;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return create;
        }

        public EntHashtable BuscarPassword(string nombreUsuario,string hashCode)
        {
            SqlCommand cmd = null;
            EntHashtable hashtable = null;

            try
            {
                SqlConnection connection = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_BuscarPassword", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@prmstrNombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@prmstrHashCode", hashCode);

                connection.Open();

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    hashtable = new EntHashtable
                    {
                        HashCode = Convert.ToString(dataReader["HashCode"])
                    };
                }

            }
            catch (SqlException e)
            {

                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return hashtable;
        }

        public List<EntHashtable> BuscarPasswordSingUp()
        {
            SqlCommand cmd = null;
            List<EntHashtable> lista = new List<EntHashtable>();

            try
            {
                SqlConnection connection = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_BuscarPasswordSignUp", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                connection.Open();

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    EntHashtable hashtable = new EntHashtable
                    {
                        HashCode = Convert.ToString(dataReader["HashCode"])
                    };

                    lista.Add(hashtable);
                }

            }
            catch (SqlException e)
            {

                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        //public bool ActualizarEstado(EntAccount cuenta)
        //{
        //    SqlCommand cmd = null;
        //    bool actualiza;

        //    try
        //    {
        //        SqlConnection conexion = Conexion.Instance.Conectar();
        //        cmd = new SqlCommand("SP_ActualizarEstado", conexion)
        //        {
        //            CommandType = System.Data.CommandType.StoredProcedure
        //        };
        //        cmd.Parameters.AddWithValue("@prmstrNombreUsuario", cuenta.NombreUsuario);

        //        conexion.Open();
        //        int result = cmd.ExecuteNonQuery();
        //        actualiza = result > 0 ? true : false;

        //    }
        //    catch (SqlException err)
        //    {

        //        throw err;
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return actualiza;
        //}

        //public EntHashtable BuscarPassword(string NombreUsuario, string Passwordstring)
        //{
        //    SqlCommand cmd = null;
        //    EntHashtable password = null;
        //    EntAccount cuenta = null;

        //    try
        //    {
        //        SqlConnection conexion = Conexion.Instance.Conectar();
        //        cmd = new SqlCommand("SP_BuscarPassword", conexion)
        //        {
        //            CommandType = System.Data.CommandType.StoredProcedure
        //        };
        //        cmd.Parameters.AddWithValue("@prmstrNombreUsuario", NombreUsuario);
        //        cmd.Parameters.AddWithValue("@prmstrPasswordstring", Passwordstring);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {

        //            cuenta = new EntAccount
        //            {
        //                NombreUsuario = Convert.ToString(reader["NombreUsuario"])
        //            };

        //            password = new EntHashtable
        //            {
        //                Passwordstring = Convert.ToString(reader["Passwordstring"]),
        //                Estado = Convert.ToBoolean(reader["Estado"]),
        //                Cuenta = cuenta
        //            };

        //        }
        //    }
        //    catch (SqlException err)
        //    {

        //        throw err;
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return password;
        //}

    }
}
