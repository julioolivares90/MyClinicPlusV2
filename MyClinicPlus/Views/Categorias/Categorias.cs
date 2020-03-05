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

namespace MyClinicPlus.Views.Categorias
{
    public partial class Categorias : Form
    {
        private readonly CategoriasController _controller = new CategoriasController();
        public Categorias()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var nombre = textBox2.Text;
            var descripcion = textBox3.Text;


            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                Mensajes.EmptyFields();
                textBox2.Focus();
            }
            else if (string.IsNullOrEmpty(descripcion) || string.IsNullOrWhiteSpace(descripcion))
            {
                Mensajes.EmptyFields();
                textBox3.Focus();
            }
            else
            {
                var tipoProducto = new TipoProducto();
                tipoProducto.tipo_producto = nombre;
                tipoProducto.descripcion = descripcion;
                int re = await _controller.AddTipoProduco(tipoProducto);
                if (re > 0)
                {
                    Mensajes.AgregadoConExito();
                    Limpiar();
                    await initData();
                }
                else
                {
                    Mensajes.OcurrioUnError();
                }
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            var nombre = textBox2.Text;
            var descripcion = textBox3.Text;
            var id = textBox1.Text;
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Mensajes.EmptyFields();
                textBox1.Focus();

            }

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                Mensajes.EmptyFields();
                textBox2.Focus();
            }
            else if (string.IsNullOrEmpty(descripcion) || string.IsNullOrWhiteSpace(descripcion))
            {
                Mensajes.EmptyFields();
                textBox3.Focus();
            }
            else
            {
                var tipoProducto = new TipoProducto();
                tipoProducto.id_tipo = Convert.ToInt32(id);
                tipoProducto.tipo_producto = nombre;
                tipoProducto.descripcion = descripcion;
                int re = await _controller.UpdateTipoProduco(tipoProducto);
                if (re > 0)
                {
                    Mensajes.AgregadoConExito();
                    Limpiar();
                    await initData();
                }
                else
                {
                    Mensajes.OcurrioUnError();
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Mensajes.EmptyFields();
            }
            else
            {
                var id = int.Parse(textBox1.Text);
                var res = await _controller.DeleteTipoProducto(id);

                if (res > 0)
                {
                    Mensajes.EliminadoConExito();
                }
                else
                {
                    Mensajes.OcurrioUnError();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private async void Categorias_Load(object sender, EventArgs e)
        {
            await initData();
        }

        private async Task initData()
        {
            dgvDatos.DataSource = await _controller.GetProductos();
        }
        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvDatos.CurrentRow.Selected = true;
                textBox1.Text = dgvDatos.Rows[e.RowIndex].Cells["id_tipo"].FormattedValue.ToString();
                textBox2.Text = dgvDatos.Rows[e.RowIndex].Cells["tipo_producto"].FormattedValue.ToString();
                textBox3.Text = dgvDatos.Rows[e.RowIndex].Cells["descripcion"].FormattedValue.ToString();
               
            }
        }
    }
}
