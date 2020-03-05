using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicPlus.Models;
using MyClinicPlus.Conexion;
using Models.Models;
using LinqToDB;

namespace MyClinicPlus.Controller
{
    class VenderControlller
    {
       public async Task<Producto> GetProductoByNameAsync(string name)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Productos
                    .Where(p => p.nombre.Contains(name))
                    .FirstOrDefaultAsync();
            }
        }
        public async Task<int> AddVenta(Venta venta)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Ventas
                    .Value(v => v.fecha_venta, venta.fecha_venta)
                    .Value(v => v.monto, venta.monto)
                    .Value(v=>v.descuento,venta.descuento)
                    .Value(v=>v.id_usuario,venta.id_usuario)
                    .InsertAsync();
            }
        }
        public int GetLastIDinsertedAsync()
        {
            using (var db = new Conexion.Conexion())
            {
                return  db.Ventas.Max(v=>v.id_venta);
            }
        }
        public async Task<int> AddDetalleVenta(DetalleVenta detalle)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.DetalleVentas
                    .Value(d => d.id_venta, detalle.id_venta)
                    .Value(d=>d.id_producto,detalle.id_producto)
                    .Value(d=>d.cantidad,detalle.cantidad)
                    .Value(d=>d.precioVenta,detalle.precioVenta)
                    .InsertAsync();
            }
        }

        public async Task<int> UpdateStock(int nuevaCantidad,int idProducto)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Productos
                    .Where(p=>p.id_producto.Equals(idProducto))
                    .Set(p => p.cantidad, nuevaCantidad)
                    .UpdateAsync();
            }
        }
    }
}
