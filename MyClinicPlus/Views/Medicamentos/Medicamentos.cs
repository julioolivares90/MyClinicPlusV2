using MyClinicPlus.Controller;
using MyClinicPlus.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClinicPlus.Models;
using Models.Models;

namespace MyClinicPlus.Views.Medicamentos
{
    public partial class Medicamentos : Form
    {
        private int cantidadRegistros = 10;
        private readonly MedicamentosController _controller = new MedicamentosController();
        private Producto _producto = new Producto();
        public Medicamentos()
        {
            InitializeComponent();
        }

        private void Medicamentos_Load(object sender, EventArgs e)
        {
            mostrarDatos();
            initData();
        }

        private async void mostrarDatos(int PaginaSeleccionada = 0 )
        {
            using (var db = new Conexion.Conexion())
            {
                int TotalRegistros = db.Productos.Count();
                int TotalPaginas = (int)Math
                    .Ceiling(decimal.Parse(TotalRegistros.ToString())/decimal.Parse(cantidadRegistros.ToString()));
                ObtenerPaginas(TotalPaginas, PaginaSeleccionada);

                var saltar = PaginaSeleccionada * cantidadRegistros;

                dgvDatos.DataSource = await _controller.GetProductosAsync(saltar,cantidadRegistros);
                   // db.Productos.OrderBy(p => p.id_producto).Skip(PaginaSeleccionada * cantidadRegistros).Take(cantidadRegistros).ToList();
               

            }
        }

        private void ObtenerPaginas(int totalPaginas, int paginaSeleccionada)
        {
            panelFooter.Controls.Clear();
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
                panelFooter.Controls.Add(button);
                x += 40;
            }
        }

        private void Ir(object sender, EventArgs e)
        {
            int Pagina = int.Parse(((Button)sender).Text);
            mostrarDatos(Pagina-1);
        }

        

        private  void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var producto = new Producto();
                producto.id_producto = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["id_producto"].FormattedValue.ToString());
                producto.nombre = dgvDatos.Rows[e.RowIndex].Cells["nombre"].FormattedValue.ToString();
                producto.costo_por_unidad = double.Parse(dgvDatos.Rows[e.RowIndex].Cells["costo_por_unidad"].FormattedValue.ToString());
                producto.costo_publico = double.Parse(dgvDatos.Rows[e.RowIndex].Cells["costo_publico"].FormattedValue.ToString());
                producto.ganancia = double.Parse(dgvDatos.Rows[e.RowIndex].Cells["ganancia"].FormattedValue.ToString());
                producto.cantidad = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["cantidad"].FormattedValue.ToString());
                producto.id_tipo_producto = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["id_tipo_producto"].FormattedValue.ToString());
                producto.id_proveedor = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["id_proveedor"].FormattedValue.ToString());

                txtID.Text = producto.id_producto.ToString();
                txtNombre.Text = producto.nombre;
                txtCostoPorUnidad.Text = producto.costo_por_unidad.ToString();
                txtCostoPublico.Text = producto.costo_publico.ToString();
                txtCantidad.Text = producto.cantidad.ToString();


                _producto = producto;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var AddMedicamento = new AddMedicamento();
            AddMedicamento.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text;
            var costoPorUnidad = double.Parse(txtCostoPorUnidad.Text);
            var costoPublico = double.Parse(txtCostoPublico.Text);



            var cantidad = int.Parse(txtCantidad.Text);
            var ganacia = Math.Round(costoPorUnidad - costoPublico);
            if (string.IsNullOrEmpty(nombre))
            {
                Mensajes.EmptyFields();
                txtNombre.Focus();
            }
            else if (string.IsNullOrEmpty(costoPorUnidad.ToString()) || string.IsNullOrWhiteSpace(costoPorUnidad.ToString()))
            {
                Mensajes.EmptyFields();
                txtCostoPorUnidad.Focus();
            }
            else if (string.IsNullOrEmpty(costoPublico.ToString()) || string.IsNullOrWhiteSpace(costoPublico.ToString()))
            {
                Mensajes.EmptyFields();
                txtCostoPublico.Focus();
            }
            else if (string.IsNullOrEmpty(cantidad.ToString()) || string.IsNullOrWhiteSpace(cantidad.ToString()))
            {
                Mensajes.EmptyFields();
                txtCantidad.Focus();
            }
            else
            {
                _producto.nombre = nombre;
                _producto.costo_por_unidad = costoPorUnidad;
                _producto.costo_publico = costoPublico;
                _producto.cantidad = cantidad;
                _producto.ganancia = ganacia;
                var rs = await _controller.UpdateMedicamento(_producto);
                if (rs > 0)
                {
                    Mensajes.ActualizadoConExito();
                    limpiar();
                }
                else
                {
                    Mensajes.OcurrioUnError();
                }
            }
        }
        private void limpiar()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtCostoPorUnidad.Text = "";
            txtCostoPublico.Text = "";
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var id =int.Parse(txtID.Text);
            var rs = await _controller.DeleteProducto(id);

            if (rs > 0)
            {
                Mensajes.EliminadoConExito();
                mostrarDatos();
            }
            else
            {
                Mensajes.OcurrioUnError();
            }

        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = cbCategoria.SelectedIndex;
            var idCategoria = int.Parse(cbCategoria.SelectedValue.ToString());

            if (id > 0)
            {
                _producto.id_tipo_producto = idCategoria;
            }
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = cbProveedor.SelectedIndex;
            var idProveedor = int.Parse(cbProveedor.SelectedValue.ToString());

            if (id > 0)
            {
                _producto.id_proveedor = idProveedor;
            }
        }

        private void initData()
        {
            initDataCombo();
            initComboProveedores();
            initComboTipo();
        }
        private void initDataCombo()
        {
            cbCategoria.Items.Add("Selecciona una categoria");
            cbProveedor.Items.Add("Selecciona un proveedor");
        }
        private async void initComboProveedores()
        {
            

            cbProveedor.ValueMember = "id_proveedor";
            cbProveedor.DisplayMember = "nombre_proveedor";
            cbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProveedor.DataSource = await _controller.GetProveedoresAsync();
        }

        private async void initComboTipo()
        {
            
            cbCategoria.ValueMember = "id_tipo";
            cbCategoria.DisplayMember = "tipo_producto";
            cbCategoria.DataSource = await _controller.GetTipoProductoAsync();
        }
    }
}
