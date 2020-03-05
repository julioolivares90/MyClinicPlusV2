using LinqToDB;
using Models.Models;
using MyClinicPlus.Views.Medicamentos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicPlus.Controller
{
    class MedicamentosController
    {
       


        public async Task<List<Producto>> GetProductosAsync(int saltar, int tomar)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Productos.OrderBy(p => p.id_producto).Skip(saltar).Take(tomar).ToListAsync();
            }
        }
        public async Task<int> AddMedicamento(Producto model)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Productos
                    .Value(p => p.nombre, model.nombre)
                    .Value(p => p.costo_por_unidad, model.costo_por_unidad)
                    .Value(p => p.costo_publico, model.costo_publico)
                    .Value(p => p.ganancia, model.ganancia)
                    .Value(p => p.cantidad, model.cantidad)
                    .Value(p => p.id_tipo_producto, model.id_tipo_producto)
                    .Value(p => p.id_proveedor, model.id_proveedor)
                    .InsertAsync();
            }
        }
        public async Task<int> UpdateMedicamento(Producto model)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Productos
                    .Set(p => p.id_producto, model.id_producto)
                    .Set(p => p.nombre, model.nombre)
                    .Set(p => p.costo_por_unidad, model.costo_por_unidad)
                    .Set(p => p.costo_publico, model.costo_publico)
                    .Set(p => p.ganancia, model.ganancia)
                    .Set(p => p.cantidad, model.cantidad)
                    .Set(p => p.id_tipo_producto, model.id_tipo_producto)
                    .Set(p => p.id_proveedor, model.id_proveedor)
                    .UpdateAsync();
            }
        }

        public async Task<int> DeleteProducto(int id)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Productos.Where(p => p.id_producto.Equals(id)).DeleteAsync();
            }
        }

        public async Task<List<Proveedor>> GetProveedoresAsync()
        {
            using (var db = new Conexion.Conexion())
            {
                var query = from p in db.Proveedores select new Proveedor { id_proveedor = p.id_proveedor, nombre_proveedor = p.nombre_proveedor };
                return await query.ToListAsync();
            }
        }

        public async Task<List<TipoProducto>> GetTipoProductoAsync()
        {
            using (var db = new Conexion.Conexion())
            {
                var query = from t in db.TipoProductos select new TipoProducto { id_tipo = t.id_tipo, tipo_producto = t.tipo_producto };
                return await query.ToListAsync();
            }
        }

    }
}
