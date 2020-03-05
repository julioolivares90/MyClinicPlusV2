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

namespace MyClinicPlus.Views.Proveedores
{
    public partial class ProveedorV : Form
    {
        private readonly ProveedorController _controller = new ProveedorController(); 
        public ProveedorV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nombre = textBox2.Text;
            var correo = textBox3.Text;
            var telefono = textBox4.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                Mensajes.EmptyFields();
                textBox2.Focus();
            }
            else if (string.IsNullOrEmpty(correo) || string.IsNullOrWhiteSpace(correo))
            {
                Mensajes.EmptyFields();
                textBox3.Focus();
            }
            else if (!Validaciones.isEmailValid(correo))
            {
                Mensajes.CorreoNoValido();
                textBox3.Focus();
            }
            else if (string.IsNullOrEmpty(telefono) || string.IsNullOrWhiteSpace(telefono))
            {
                Mensajes.EmptyFields();
                textBox4.Focus();
            }
            else
            {
                var proveedor = new Proveedor();
                proveedor.nombre_proveedor = nombre;
                proveedor.correo_proveedor = correo;
                proveedor.telefono_proveedor = telefono;
                int re = ProveedorController.AddProveedor(proveedor);
                if (re >0)
                {
                    Mensajes.AgregadoConExito();
                    Limpiar();
                    initData();
                }
                else
                {
                    Mensajes.OcurrioUnError();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nombre = textBox2.Text;
            var correo = textBox3.Text;
            var telefono = textBox4.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                Mensajes.EmptyFields();
                textBox2.Focus();
            }
            else if (string.IsNullOrEmpty(correo) || string.IsNullOrWhiteSpace(correo))
            {
                Mensajes.EmptyFields();
                textBox3.Focus();
            }
            else if (!Validaciones.isEmailValid(correo))
            {
                Mensajes.CorreoNoValido();
                textBox3.Focus();
            }
            else if (string.IsNullOrEmpty(telefono) || string.IsNullOrWhiteSpace(telefono))
            {
                Mensajes.EmptyFields();
                textBox4.Focus();
            }
            else
            {
                var proveedor = new Proveedor();
                proveedor.id_proveedor = Convert.ToInt32(textBox1.Text);
                proveedor.nombre_proveedor = nombre;
                proveedor.correo_proveedor = correo;
                proveedor.telefono_proveedor = telefono;
                int re = _controller.UpdateProveedor(proveedor);
                if (re > 0)
                {
                    Mensajes.ActualizadoConExito();
                    Limpiar();
                    initData();
                }
                else
                {
                    Mensajes.OcurrioUnError();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Mensajes.EmptyFields();
            }
            else
            {
                var id = Convert.ToInt32(textBox1.Text);
                var res = _controller.DeleteProveedor(id);

                if (res > 0)
                {
                    Mensajes.EliminadoConExito();
                }else {
                    Mensajes.OcurrioUnError();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvDatos.CurrentRow.Selected = true;
                textBox1.Text = dgvDatos.Rows[e.RowIndex].Cells["id_proveedor"].FormattedValue.ToString();
                textBox2.Text = dgvDatos.Rows[e.RowIndex].Cells["nombre_proveedor"].FormattedValue.ToString();
                textBox3.Text = dgvDatos.Rows[e.RowIndex].Cells["correo_proveedor"].FormattedValue.ToString();
                textBox4.Text = dgvDatos.Rows[e.RowIndex].Cells["telefono_proveedor"].FormattedValue.ToString();
            }
        }

        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void initData()
        {
            dgvDatos.DataSource = _controller.GetProveedores();
        }

        private void ProveedorV_Load(object sender, EventArgs e)
        {
            initData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
