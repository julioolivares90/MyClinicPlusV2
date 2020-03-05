using MyClinicPlus.Controller;
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
    public partial class ReporteVentas : Form
    {
        private readonly ReporteVentasController _controller = new ReporteVentasController();
        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {

            //LoadReport(DateTime.Today,DateTime.Now);
        }

        private void LoadReport(DateTime fromDate,DateTime toDate)
        {
            var dt = _controller.GetData(fromDate,toDate);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1",dt));
            this.reportViewer1.RefreshReport();
        }

        private void BtnAhora_Click(object sender, EventArgs e)
        {
            LoadReport(DateTime.Today, DateTime.Now);
        }

        private void btnSevenDays_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-7);
            var toDate = DateTime.Now;
            LoadReport(fromDate,toDate);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = DateTime.Now;
            LoadReport(fromDate, toDate);
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-30);
            var toDate = DateTime.Now;
            LoadReport(fromDate, toDate);
        }

        private void btnThisYear_Click(object sender, EventArgs e)
        {
           
            var fromDate = new DateTime(DateTime.Now.Year, 1, 1);
            var toDate = DateTime.Now;
            LoadReport(fromDate, toDate);
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {

        }
    }
}
