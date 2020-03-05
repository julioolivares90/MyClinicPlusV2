using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    [Table(Name="detalle_venta")]
   public class DetalleVenta
    {
        [PrimaryKey,Identity]
        public int id_detalle { get; set; }

        [Column("id_venta")]
        public int id_venta { get; set; }

        [Column("id_producto")]
        public int id_producto { get; set; }

        [Column("cantidad")]
        public int cantidad { get; set; }

        [Column("precioVenta")]
        public double precioVenta { get; set; }
    }
}
