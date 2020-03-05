using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    [Table(Name="proveedores")]
   public class Proveedor
    {
        [PrimaryKey,Identity]
        public int id_proveedor { get; set; }
        [Column("nombre_proveedor")]
        public string  nombre_proveedor { get; set; }
        [Column("correo_proveedor")]
        public string correo_proveedor { get; set; }
        [Column("telefono_proveedor")]
        public string telefono_proveedor { get; set; }
    }
}
