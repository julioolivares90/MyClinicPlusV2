using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace MyClinicPlus.Controller
{
    public class ReporteVentasController
    {
        public DataTable GetData(DateTime fromDate, DateTime toDate)
        {
            using (var con = Conexion.ConexionMySql.GetConnection())
            {
                var query = $@"select v.id_venta, v.fecha_venta ,v.monto, p.nombre,dv.cantidad,dv.precioVenta from ventas as v 
                                        inner join detalle_venta as dv on v.id_venta = dv.id_venta inner join producto as p on p.id_producto = dv.id_producto 
                                        where v.fecha_venta between '{fromDate}' and '{toDate}'";
                var dataTable = new DataTable();
                using (var dataAdapter = new MySqlDataAdapter(query,con))
                {
                    dataAdapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }
    }
}
