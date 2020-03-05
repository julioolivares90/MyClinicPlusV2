using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    [Table(Name="rol")]
   public class Rol
    {
        [PrimaryKey,Identity]
        public int id_rol { get; set; }

        [Column("rol")]
        public string rol { get; set; }
    }
}
