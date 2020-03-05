using System;
namespace MyClinicPlus.Daos
{
    public class ListadoVentas
    {
        public int id_venta { get; set; }
        public DateTime fecha_venta { get; set; }
        public double monto { get; set; }

        public string nombre { get; set; }
        public int cantidad { get; set; }

        public double precioVenta { get; set; }


    }
}