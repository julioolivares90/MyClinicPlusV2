using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    [Table(Name="producto")]
    public class Producto
    {
        [PrimaryKey,Identity]
        public int id_producto { get; set; }
        [Column("nombre")]
        public string nombre { get; set; }
        [Column("costo_por_unidad")]
        public double costo_por_unidad { get; set; }
        [Column("costo_publico")]
        public double costo_publico { get; set; }
        [Column("ganancia")]
        public double ganancia { get; set; }
        [Column("cantidad")]
        public int  cantidad { get; set; }
        [Column("id_tipo_producto")]
        public int  id_tipo_producto { get; set; }
        [Column("id_proveedor")]
        public int  id_proveedor { get; set; }

    }
}
