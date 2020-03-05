using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    [Table(Name="tipo_producto")]
   public class TipoProducto
    {
        [PrimaryKey, Identity]
        public int id_tipo { get; set; }

        [Column("tipo_producto")]
        public string tipo_producto { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }
    }
}
