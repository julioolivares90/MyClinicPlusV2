using LinqToDB;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.Controller
{
    class UsuariosController
    {
        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Usuarios.ToListAsync();
            }
        }
        public async Task<int> AddUsuarioAsync(Usuario usuario)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Usuarios
                    .Value(u => u.nombre, usuario.nombre)
                    .Value(u=>u.apellido,usuario.apellido)
                    .Value(u=>u.username,usuario.username)
                    .Value(u=>u.pass,usuario.pass)
                    .Value(u=>u.id_rol,usuario.id_rol)
                    .InsertAsync();
            }
        }

        public async Task<int> UpdateUsuarioAsync(Usuario usuario)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Usuarios
                    .Where(u=>u.id.Equals(usuario.id))
                    .Set(u => u.nombre, usuario.nombre)
                    .Set(u => u.apellido, usuario.apellido)
                    .Set(u=>u.username,usuario.username)
                    .Set(u=>u.id_rol,usuario.id_rol)
                    .UpdateAsync();
            }
        }

        public async Task<int> DeleteUsuarioAsync(int id)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Usuarios.Where(u => u.id.Equals(id))
                    .DeleteAsync();
            }
        }

        public async Task<List<Rol>> GetRolUserComboAsync()
        {
            using (var db = new Conexion.Conexion())
            {
                var query = from r in db.Rols select new Rol { id_rol = r.id_rol, rol = r.rol };
                return  await query.ToListAsync();
            }
        }
    }
}
