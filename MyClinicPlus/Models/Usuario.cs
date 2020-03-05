
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    [Table(Name ="usuarios")]
   public class Usuario
    {
        [PrimaryKey,Identity]
        public int id { get; set; }
        [Column("nombre")]
        public string nombre { get; set; }

        [Column("apellido")]
        public string apellido { get; set; }

        [Column("username")]
        public string username { get; set; }

        [Column("pass")]
        public string pass { get; set; }

        [Column("id_rol")]
        public int id_rol { get; set; }
    }
}
