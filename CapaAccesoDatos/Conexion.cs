using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region Singleton

        static Conexion()
        {

        }

        private Conexion()
        {

        }

        public static Conexion Instance { get; } = new Conexion();

        #endregion Singleton

        public SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection
            {
                ConnectionString = "Data Source=BADINHO\\SQLEXPRESS; initial Catalog=DBDiags; Integrated Security=true"
            };
            return conexion;
        }

    }
}
