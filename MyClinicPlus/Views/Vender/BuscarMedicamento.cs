using Models.Models;
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

namespace MyClinicPlus.Views.Vender
{
    public partial class BuscarMedicamento : Form
    {
        private Producto _producto = new Producto();
        private readonly BuscarMedicamentoController _controller = new BuscarMedicamentoController();

        private int cantidadRegistros = 10;
        public Producto GetProducto() => _producto;
        public BuscarMedicamento()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _producto.id_producto = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id_producto"].FormattedValue.ToString());
            _producto.nombre = dataGridView1.Rows[e.RowIndex].Cells["nombre"].FormattedValue.ToString();
            _producto.costo_por_unidad = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["costo_por_unidad"].FormattedValue.ToString());
            _producto.costo_publico = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["costo_publico"].FormattedValue.ToString());
            _producto.cantidad = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].FormattedValue.ToString());
            _producto.ganancia = double.Parse(dataGridView1.Rows[e.RowIndex].Cells["ganancia"].FormattedValue.ToString());
            _producto.id_tipo_producto = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id_tipo_producto"].FormattedValue.ToString());
            _producto.id_proveedor = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id_proveedor"].FormattedValue.ToString());
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarMedicamento_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private async void mostrarDatos(int PaginaSeleccionada = 0)
        {
            using (var db = new Conexion.Conexion())
            {
                int TotalRegistros = db.Productos.Count();
                int TotalPaginas = (int)Math
                    .Ceiling(decimal.Parse(TotalRegistros.ToString()) / decimal.Parse(cantidadRegistros.ToString()));
                ObtenerPaginas(TotalPaginas, PaginaSeleccionada);

                var saltar = PaginaSeleccionada * cantidadRegistros;

                dataGridView1.DataSource = await _controller.GetProductosAsync(saltar, cantidadRegistros);
            }
        }

        private void ObtenerPaginas(int totalPaginas, int paginaSeleccionada)
        {
            panelPaginacion.Controls.Clear();
            int x = 10;
            for (int i = 0; i < totalPaginas; i++)
            {
                var button = new Button();
                button.Text = (i + 1).ToString();
                button.Location = new Point(x, 5);
                button.Width = 30;
                button.Height = 30;
                button.Click += Ir;
                if (paginaSeleccionada == i)
                {
                    button.Font = new Font(button.Name, button.Font.Size, FontStyle.Bold);
                }
                panelPaginacion.Controls.Add(button);
                x += 40;
            }
        }

        private void Ir(object sender, EventArgs e)
        {
            int Pagina = int.Parse(((Button)sender).Text);
            mostrarDatos(Pagina - 1);
        }

    }
}
