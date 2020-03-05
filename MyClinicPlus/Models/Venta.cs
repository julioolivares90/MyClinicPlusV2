
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    [Table(Name ="ventas")]
   public class Venta
    {
        [PrimaryKey,Identity]
        public int id_venta { get; set; }

        [Column(Name ="fecha_venta")]
        public string fecha_venta { get; set; }
        [Column(Name ="monto")]
        public double monto { get; set; }
        [Column(Name ="descuento")]
        public int descuento { get; set; }
        [Column(Name ="id_usuario")]
        public int id_usuario { get; set; }
    }
}
