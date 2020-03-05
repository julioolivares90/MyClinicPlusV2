using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicPlus.Conexion;
using MyClinicPlus.Model;
using MyClinicPlus.Models;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MyClinicPlus.Daos
{
    class LoginDao
    {
      private static readonly MySqlConnection _conexion = ConexionMySql.GetConnection();

        public static Usuario1 Login(UserViewModel usu)
        {

            using(var cmd = new MySqlCommand("select * from usuarios  where username=@username and pass=@pass",_conexion))
            {
                Usuario1 usuario = new Usuario1();
                
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Add("@username",MySqlDbType.VarChar).Value = usu.Username;
                cmd.Parameters.Add("@pass",MySqlDbType.VarChar).Value= usu.Pass;
                var res = cmd.ExecuteReader();
                if (res.HasRows)
                {
                    while (res.Read())
                    {
                        usuario.ID = Convert.ToInt32(res["id"].ToString());
                        usuario.Nombre = res["nombre"].ToString();
                        usuario.Apellido = res["apellido"].ToString();
                        usuario.Username = res["username"].ToString();
                        usuario.ROL_ID = Convert.ToInt32(res["id_rol"].ToString());

                    }
                    return usuario;
                }
                return null;
                
            }

        }
    }
}
