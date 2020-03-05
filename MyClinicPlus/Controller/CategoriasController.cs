
using LinqToDB;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicPlus.Conexion;

namespace MyClinicPlus.Controller
{
    class CategoriasController
    {
        public async Task<List<TipoProducto>> GetProductos()
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.TipoProductos.ToListAsync();
            }
        }

        public async Task<int> AddTipoProduco(TipoProducto tipo)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.TipoProductos
                    .Value(t => t.tipo_producto,tipo.tipo_producto)
                    .Value(t=>t.descripcion,tipo.descripcion)
                    .InsertAsync();
            }
        }

        public async Task<int> UpdateTipoProduco(TipoProducto tipo)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.TipoProductos
                    .Where(t=>t.id_tipo.Equals(tipo.id_tipo))
                    .Set(t=>t.id_tipo,tipo.id_tipo)
                    .Set(t => t.tipo_producto, tipo.tipo_producto)
                    .Set(t => t.descripcion, tipo.descripcion).UpdateAsync();
            }
        }

        public async Task<int> DeleteTipoProducto(int id)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.TipoProductos.Where(t=>t.tipo_producto.Equals(id)).DeleteAsync();
            }
        }
    }
}
