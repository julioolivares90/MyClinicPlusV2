using LinqToDB;
using LinqToDB.Data;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.Conexion
{
    public class Conexion : DataConnection
    {
       public Conexion() : base("conexionMysql") { }

        public ITable<Rol> Rols => GetTable<Rol>();
        public ITable<Usuario> Usuarios => GetTable<Usuario>();
        public ITable<TipoProducto> TipoProductos => GetTable<TipoProducto>();
        public ITable<Proveedor> Proveedores => GetTable<Proveedor>();
        public ITable<Producto> Productos => GetTable<Producto>();
        public ITable<Venta> Ventas => GetTable<Venta>();
        public ITable<DetalleVenta> DetalleVentas => GetTable<DetalleVenta>();
    }
}
