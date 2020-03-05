using Models.Models;
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

namespace MyClinicPlus.Views.Medicamentos
{
    public partial class AddMedicamento : Form
    {
        private readonly MedicamentosController _controller = new MedicamentosController();

       

        private Producto _producto = new Producto();

        
        public AddMedicamento()
        {
            InitializeComponent();
        }

        public AddMedicamento(Producto producto)
        {
            InitializeComponent();
            _producto = producto;
            fillFields();
        }

        private void fillFields()
        {
            btnCrear.Text = "Actualizar";
            txtNombre.Text = _producto.nombre;
            txtCantidad.Text = _producto.cantidad.ToString();
            txtCostoPorUnidad.Text = _producto.costo_por_unidad.ToString();
            txtCostoPublico.Text = _producto.costo_publico.ToString();
        }
        private void AddMedicamento_Load(object sender, EventArgs e)
        {
            initData();
        }

        private void initData()
        {
            initComboProveedores();
            initComboTipo();
        }

        private async void initComboProveedores()
        {
            cbCategoria.Items.Insert(0, "Selecciona un proveedor");
            cbProveedor.ValueMember = "id_proveedor";
            cbProveedor.DisplayMember = "nombre_proveedor";
            cbProveedor.DropDownStyle = ComboBoxStyle.DropDownList; 
            cbProveedor.DataSource = await _controller.GetProveedoresAsync();
        }

        private async void initComboTipo()
        {
            cbCategoria.Items.Insert(0,"Selecciona una categoria");
            cbCategoria.ValueMember = "id_tipo";
            cbCategoria.DisplayMember = "tipo_producto";
            cbCategoria.DataSource = await _controller.GetTipoProductoAsync();
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (btnCrear.Text == "Crear")
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
                    var rs = await _controller.AddMedicamento(_producto);
                    if (rs > 0)
                    {
                        Mensajes.AgregadoConExito();
                        limpiar();
                    }
                    else
                    {
                        Mensajes.OcurrioUnError();
                    }
                }
            }else
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
            
           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

      
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
           
          //var id = Convert.ToInt32(cbCategoria.SelectedValue.ToString());
          
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            var id = cbCategoria.SelectedIndex;
            
                
            if (id > 0 )
            {
                var idCategoria = int.Parse(cbCategoria.SelectedValue.ToString());
                _producto.id_tipo_producto = idCategoria;
            }
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = cbProveedor.SelectedIndex;
            var idProveedor = int.Parse(cbProveedor.SelectedValue.ToString());

            if (id>0)
            {
                _producto.id_proveedor = idProveedor;
            }
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtCostoPorUnidad.Text = "";
            txtCostoPublico.Text = "";
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras ","Advertencia",MessageBoxButtons.OK);
            }
        }

        private void txtCostoPorUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros ", "Advertencia", MessageBoxButtons.OK);
            }
        }

        private void txtCostoPublico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.Equals("."))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros enteros y con punto decimal ", "Advertencia", MessageBoxButtons.OK);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.Equals("."))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros enteros y con punto decimal ", "Advertencia", MessageBoxButtons.OK); ;
            }
        }
    }
}
