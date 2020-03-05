using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.Daos
{
   public class ReporteDeVentas
    {
        public ReporteDeVentas(DateTime fromDate, DateTime toDate)
        {
            CrearSalesReport(fromDate,toDate);
        }
        public DateTime fechaReporte { get; private set; }
        public DateTime fromDate { get; private set; }
        public DateTime toDate { get; private set; }

        public List<ListadoVentas> ListadoVentas { get; private set; }
        public List<VentasPorPeriodo> ventasPorPeriodos { get; private set; }

        public double VentasNetasTotales { get; set; }

        public void CrearSalesReport(DateTime fromDate , DateTime toDate)
        {
            this.fechaReporte = DateTime.Now;
            this.fromDate = fromDate;
            this.toDate = toDate;
            var salesReportDao = new SalesReportDao();

            var result = salesReportDao.GetListadoVentas(fromDate,toDate);

            ListadoVentas = new List<ListadoVentas>();

            foreach (System.Data.DataRow row in result.Rows)
            {
                var salerMdel = new ListadoVentas() {
                    id_venta = Convert.ToInt32(row[0]),
                    fecha_venta = Convert.ToDateTime(row[1]),
                    monto = Convert.ToDouble(row[2]),
                    nombre = Convert.ToString(row[3]),
                    cantidad = Convert.ToInt32(row[4]),
                    precioVenta = Convert.ToDouble(row[5]) 
                };
                ListadoVentas.Add(salerMdel);

                VentasNetasTotales += Convert.ToDouble(row[5]);
            }

            //crear ventas netas por periodo
            var listSalesbyDate = (from ventas in ListadoVentas group ventas by ventas.fecha_venta into listaVentas select new { date = listaVentas.Key,amount = listaVentas.Sum(item=>item.monto) }).AsEnumerable();
            int totalDays = Convert.ToInt32((toDate-fromDate).Days);

            if (totalDays <= 7)
            {
                ventasPorPeriodos = (from sales in listSalesbyDate
                                     group sales by sales.date.ToString("yyyy-MM-dd") into listaSales
                                     select new VentasPorPeriodo
                                     {
                                         periodo = listaSales.Key,
                                         ventasNetas = listaSales.Sum(item=>item.amount)
                                     }).ToList();
            }
            else if (totalDays <= 30)
            {
                ventasPorPeriodos = (from sales in listSalesbyDate
                                     group sales by 
                                     
                                     System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(sales.date,System.Globalization.CalendarWeekRule.FirstDay,DayOfWeek.Monday)
                                     into listaSales
                                     select new VentasPorPeriodo
                                     {
                                         periodo ="semana"+listaSales.Key.ToString(),
                                         ventasNetas = listaSales.Sum(item => item.amount)
                                     }).ToList();
            }
            else if (totalDays <= 365)
            {
                ventasPorPeriodos = (from sales in listSalesbyDate
                                     group sales by sales.date.ToString("MMM-yyyy") into listaSales
                                     select new VentasPorPeriodo
                                     {
                                         periodo = listaSales.Key,
                                         ventasNetas = listaSales.Sum(item => item.amount)
                                     }).ToList();
            }
            else
            {
                ventasPorPeriodos = (from sales in listSalesbyDate
                                     group sales by sales.date.ToString("yyyy") into listaSales
                                     select new VentasPorPeriodo
                                     {
                                         periodo = listaSales.Key,
                                         ventasNetas = listaSales.Sum(item => item.amount)
                                     }).ToList();
            }
        }      
    }
}
