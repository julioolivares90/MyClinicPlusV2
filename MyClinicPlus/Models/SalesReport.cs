using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.Models
{
    public class SalesReport
    {
        public DateTime fecha_venta { get; set; }

        public double monto { get; set; }

        public string NombreProducto { get; set; }

        public int cantidad { get; set; }

        public double precioVenta { get; set; }
    }
}
