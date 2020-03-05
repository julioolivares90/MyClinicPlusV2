using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;

namespace MyClinicPlus.Conexion
{
    class ConexionMySql
    {
        private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionMysql"].ConnectionString;
        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(cadenaConexion);
            }
            if (connection.State == System.Data.ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                connection.Open();
                return connection;
            }
            
        }
    }
}
