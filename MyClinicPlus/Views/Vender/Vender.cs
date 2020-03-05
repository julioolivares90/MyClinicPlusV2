using Models.Models;
using MyClinicPlus.Controller;
using MyClinicPlus.Models;
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

namespace MyClinicPlus.Views.Vender
{
    public partial class Vender : Form
    {
        private readonly VenderControlller _controller = new VenderControlller();
        private double totalApagar;
        private int cantidad;
        private double precio;
        private Producto prod = new Producto();
        public Vender()
        {
            InitializeComponent();
            actualizarHoraYfecha();
            dgvVentas.Columns.Add("id", "ID");
            dgvVentas.Columns.Add("nombre", "Nombre");
            dgvVentas.Columns.Add("cantidad", "Cantidad");
            dgvVentas.Columns.Add("precio", "Precio");
        }

        private async void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                var findMedicamento = txtBuscar.Text;
                if (!string.IsNullOrEmpty(findMedicamento))
                {
                    prod = await  _controller.GetProductoByNameAsync(findMedicamento);
                    txtMedicamento.Text = prod.nombre;
                    txtPrecio.Text = prod.costo_publico.ToString();
                    txtStock.Text = prod.cantidad.ToString();

                }
            }
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {

            createFila();

        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            guardarVenta();
        }
        private async void guardarVenta()
        {
            var venta = new Venta();
            if (string.IsNullOrEmpty(txtDescuento.Text))
            {
                venta.monto = double.Parse(txtTotalAPagar.Text);
                venta.fecha_venta = txtFecha.Text;
                venta.id_usuario = UserLogin.Instance.ID_USER;
                venta.descuento = 0;

                var res = await _controller.AddVenta(venta);
                if (res > 0)
                {
                    guadarDetalleVenta();
                }
                else
                {
                    Mensajes.OcurrioUnError();
                }

            }
            else
            {
                venta.monto = double.Parse(txtTotalAPagar.Text);
                venta.fecha_venta = txtFecha.Text;
                venta.id_usuario = Login.Instance.ID_USER;
                venta.descuento = int.Parse(txtDescuento.Text);

                var res = await _controller.AddVenta(venta);
                if (res > 0)
                {
                    guadarDetalleVenta();
                }
                else
                {
                    Mensajes.OcurrioUnError();
                }
            }
        }

        private async void guadarDetalleVenta()
        {
            var lastID = _controller.GetLastIDinsertedAsync();

            for (int i = 0; i < dgvVentas.Rows.Count - 1; i++)
            {
                DetalleVenta detalle = new DetalleVenta();
                detalle.id_venta = lastID;
                detalle.cantidad = int.Parse(dgvVentas.Rows[i].Cells["cantidad"].FormattedValue.ToString());
                detalle.precioVenta = int.Parse(dgvVentas.Rows[i].Cells["precio"].FormattedValue.ToString());
                detalle.id_producto = prod.id_producto;
                int rs =  await _controller.AddDetalleVenta(detalle);
                if (rs > 0)
                {
                    int NuevaCantidad = prod.cantidad - detalle.cantidad;
                    updateStock(NuevaCantidad,prod.id_producto);
                }

            }
            limpiar();
            
            System.Console.WriteLine(lastID);
        }

        private async void updateStock(int nuevaCantidad, int idProducto)
        {
            var rs =  await _controller.UpdateStock(nuevaCantidad,idProducto);
            if (rs > 0)
            {
                MessageBox.Show("Venta Realizada con exito","Venta",MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Ocurrio un error");
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {

            limpiar();
        }

        private void limpiar()
        {
            txtBuscar.Text = "";
            txtCantidad.Text = "";
            txtStock.Text = "";
            txtMedicamento.Text = "";
            txtTotalAPagar.Text = "";
            txtDescuento.Text = "";
            txtPrecio.Text = "";
            actualizarHoraYfecha();
            dgvVentas.Rows.Clear();
        }
        private void actualizarHoraYfecha()
        {
            //txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        private void createFila()
        {
            
            var cantidad = txtCantidad.Text;
            var precio = txtPrecio.Text;
            var stock = txtStock.Text;
            
            if (string.IsNullOrEmpty(cantidad) || string.IsNullOrWhiteSpace(cantidad))
            {
                Mensajes.EmptyFields();
            }
            else
            {

                var cant = int.Parse(cantidad);
                var sto = int.Parse(stock);
                if (cant > sto)
                {
                    MessageBox.Show("No hay suficientes medicamentos debes solicitar mas a tu proveedor","Advertencia",MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    dgvVentas.Rows.Add(prod.id_producto, txtMedicamento.Text, cantidad, precio);
                    calcularTotal();
                }
                

            }
           
        }
        private void calcularTotal()
        {
            for (int i = 0; i < dgvVentas.Rows.Count-1; i++)
            {
                cantidad = int.Parse(dgvVentas.Rows[i].Cells["cantidad"].FormattedValue.ToString());
                precio = double.Parse(dgvVentas.Rows[i].Cells["precio"].FormattedValue.ToString());
                if (string.IsNullOrEmpty(txtDescuento.Text))
                {
                    totalApagar = totalApagar + (cantidad * precio);
                }
                else
                {
                    double desc;
                    double.TryParse(txtDescuento.Text, out desc);
                    var totalDescuento = (desc * precio) / 100;
                    totalApagar = Convert.ToDouble(txtTotalAPagar.Text) - totalDescuento;
                }
               

                
            }
            txtTotalAPagar.Text = totalApagar.ToString();
            totalApagar = 0.0;
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            var buscarMedicamento = new BuscarMedicamento();
            buscarMedicamento.ShowDialog();
            if (buscarMedicamento.DialogResult == DialogResult.OK)
            {
                prod = buscarMedicamento.GetProducto();
                txtMedicamento.Text = prod.nombre;
                txtPrecio.Text = prod.costo_publico.ToString();
                txtStock.Text = prod.cantidad.ToString();
            }
        }
    }
}
