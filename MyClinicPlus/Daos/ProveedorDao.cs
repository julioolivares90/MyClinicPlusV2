using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicPlus.Models;
using MyClinicPlus.Conexion;
using MySql.Data.MySqlClient;
namespace MyClinicPlus.Daos
{
   public class ProveedorDao : Conexion.Conexion
    {
        public static int InsertProveedor(Proveedor proveedor)
        {
            int res = 0;
            using (var cmd = new MySqlCommand("insert into proveedores (nombre_proveedor,correo_proveedor,telefono_proveedor) value(@nombre,@correo,@telefono)",ConexionMySql.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@nombre",proveedor.nombre_proveedor);
                cmd.Parameters.AddWithValue("@correo",proveedor.correo_proveedor);
                cmd.Parameters.AddWithValue("@telefono",proveedor.telefono_proveedor);

                res = cmd.ExecuteNonQuery();
            }

            return res;
        }

        public static List<Proveedor> GetProveedores()
        {
            using (var db = new  Conexion.Conexion())
            {
                return db.Proveedores.ToList();
            }
        }
    }
}
