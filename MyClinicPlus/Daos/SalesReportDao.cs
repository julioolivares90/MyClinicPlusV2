using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using Models.Models;

namespace MyClinicPlus.Daos
{
    public class SalesReportDao
    {
       public DataTable getSalesOrder(DateTime fromDate,DateTime toDate)
        {
            using (var con = Conexion.ConexionMySql.GetConnection())
            {
                using (var cmd = new MySqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandText = @"select v.id_venta, v.fecha_venta ,v.monto, p.nombre,dv.cantidad,dv.precioVenta from ventas as v 
                                        inner join detalle_venta as dv on v.id_venta = dv.id_venta inner join producto as p on p.id_producto = dv.id_producto 
                                        where v.fecha_venta between @fromDate and @toDate";

                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                    cmd.CommandType = CommandType.Text;
                    var reader = cmd.ExecuteReader();

                    var table = new DataTable();

                    table.Load(reader);
                    //reader.Dispose();

                    return table;
                }
            }
        }
        public DataTable GetListadoVentas(DateTime fromDate, DateTime toDate)
        {
            using (var db = new Conexion.Conexion())
            {
                var query = db.Connection;
               var cmd = query.CreateCommand();
                cmd.CommandText = @"select v.id_venta, v.fecha_venta ,v.monto, p.nombre,dv.cantidad,dv.precioVenta from ventas as v 
                                        inner join detalle_venta as dv on v.id_venta = dv.id_venta inner join producto as p on p.id_producto = dv.id_producto 
                                        where v.fecha_venta between @fromDate and @toDate";
                cmd.CommandType = CommandType.Text;


                MySqlParameter parameter1 = new MySqlParameter();
                parameter1.DbType = DbType.String;
                parameter1.ParameterName = "@fromDate";
                
                parameter1.Value = fromDate;
                cmd.Parameters.Add(parameter1);

                MySqlParameter parameter2 = new MySqlParameter();
                parameter1.DbType = DbType.String;
                parameter2.ParameterName = "@toDate";
                parameter2.Value = toDate;
                cmd.Parameters.Add(parameter2);

                var reader = cmd.ExecuteReader();

                Console.WriteLine(reader.ToString());
                var dt = new DataTable();

                dt.Load(reader);
                return dt;
            }
        }
    }
}
