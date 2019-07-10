using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DatPasswordAccount
    {
        #region Singleton

        static DatPasswordAccount()
        {

        }

        private DatPasswordAccount()
        {

        }

        public static DatPasswordAccount Instance { get; } = new DatPasswordAccount();

        #endregion Singleton

        public bool NewPassword(EntPasswordAccount passwordAccount)
        {
            SqlCommand cmd = null;
            bool register;

            try
            {
                SqlConnection connection = Conexion.Instance.Conectar();
                cmd = new SqlCommand("SP_NewPassword", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@prmstrPasswordstring", passwordAccount.PasswordString);
                cmd.Parameters.AddWithValue("@prmstrHashCode", passwordAccount.Hashtable.HashCode);

                connection.Open();

                int result = cmd.ExecuteNonQuery();

                register = result > 0 ? true : false;

            }
            catch (SqlException e)
            {

                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return register;
        }

    }
}
