using MyClinicPlus.Daos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicPlus.Views.Ventas
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void GetReporteVentas(DateTime fromDate , DateTime toDate)
        {
            var reporte = new ReporteDeVentas(fromDate,toDate);
            
            //reporte.CrearSalesReport(fromDate,toDate);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ReporteDeVentas", reporte.ListadoVentas));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("SalesListin", reporte.ListadoVentas));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("VentasPorPeriodo", reporte.ventasPorPeriodos));
            this.reportViewer1.RefreshReport();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAhora_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today;
            var toDate = DateTime.Now;
            GetReporteVentas(fromDate,toDate);
        }

        private void btnSevenDays_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-7);
            var toDate = DateTime.Now;
            GetReporteVentas(fromDate, toDate);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            var toDate = DateTime.Now;
            GetReporteVentas(fromDate, toDate);
        }

        private void btnThisYear_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year,1, 1);
            var toDate = DateTime.Now;
            GetReporteVentas(fromDate, toDate);
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-30);
            var toDate = DateTime.Now;
            GetReporteVentas(fromDate, toDate);
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            var fromDate = dtpFromDate.Value;
            var toDate = dtpToDate.Value;

            GetReporteVentas(fromDate,new DateTime(toDate.Year,toDate.Month,toDate.Day,23,59,59));
        }
    }
}
