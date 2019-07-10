using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DatAccount
    {
        #region Singleton

        static DatAccount()
        {

        }

        private DatAccount()
        {

        }

        public static DatAccount Instance { get; } = new DatAccount();

        #endregion Singleton

        //Crear cuenta
        public bool CrearCuenta(EntAccount cuenta)
        {
            SqlCommand cmd = null;
            bool crea;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_CrearCuenta", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmstrEmail", cuenta.Email);
                cmd.Parameters.AddWithValue("@prmstrTelefono", cuenta.Telefono);
                cmd.Parameters.AddWithValue("@prmstrNombreUsuario", cuenta.NombreUsuario);
                cmd.Parameters.AddWithValue("@prmstrDni", cuenta.Cliente.Dni);
                    
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

        public EntAccount BuscarCuenta(string NombreUsuario,string Passwordstring)
        {
            SqlCommand cmd = null;
            EntAccount cuenta = null;
            EntCliente cliente = null;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_BuscarCuenta", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmstrNombreUsuario", NombreUsuario);
                cmd.Parameters.AddWithValue("@prmstrHashCode", Passwordstring);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    bool sex;

                    if (Convert.ToString(reader["Sexo"]).Equals("M"))
                    {
                        sex = true;
                    }
                    else
                    {
                        sex = false;
                    }

                    cliente = new EntCliente
                    {
                        ApellidosCliente = Convert.ToString(reader["ApellidosCliente"]),
                        NombreCliente = Convert.ToString(reader["NombreCliente"]),
                        Sexo = sex,
                        FechaNacimiento = Convert.ToString(reader["FechaNacimiento"]),
                        Dni = Convert.ToString(reader["Dni"])
                    };

                    cuenta = new EntAccount
                    {
                        NombreUsuario = Convert.ToString(reader["NombreUsuario"]),
                        Email = Convert.ToString(reader["Email"]),
                        Telefono = Convert.ToString(reader["Telefono"]),
                        Fechacreacion = Convert.ToString(reader["Fechacreacion"]),
                        Cliente = cliente
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
            return cuenta;  
        }

        public EntAccount BuscarEmail(string Email)
        {
            SqlCommand cmd = null;
            EntAccount cuenta = null;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_BuscarEmail", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmstrEmail", Email);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cuenta = new EntAccount
                    {
                        Email = Convert.ToString(reader["Email"])
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
            return cuenta;
        }

        public EntAccount BuscarUsername(string NombreUsuario)
        {
            SqlCommand cmd = null;
            EntAccount cuenta = null;

            try
            {
                SqlConnection conexion = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_BuscarUsername", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmstrNombreUsuario", NombreUsuario);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cuenta = new EntAccount
                    {
                        NombreUsuario = Convert.ToString(reader["NombreUsuario"])
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
            return cuenta;
        }

    }
}
