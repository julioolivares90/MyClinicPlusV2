using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicPlus.Views.Menu
{
    public partial class Mennu : Form
    {
        public Mennu()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Close();
            Login.Instance.Visible = true;
        }

      
        
        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
           

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Vender.Vender>();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Ventas.ReporteVentas>();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
           AbrirFormulario<Categorias.Categorias>();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Proveedores.ProveedorV>();
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Medicamentos.Medicamentos>();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario < Usuarios.Usuarios>();
        }

        private void Mennu_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Close();
            var login = Login.Instance;
            login.Visible = true;
            login.GettxtUsername().Text = "";
            login.GettxtUsername().Focus();
            login.TxtPass.Text = "";
            
        }

        private void AbrirFormulario<Miform>() where Miform : Form, new()
        {
            Form formulario;
            formulario = panelCentral.Controls.OfType<Miform>().FirstOrDefault(); //Busca en la coleccion  el formulario

            //fi el formulario / instancia no existe
            if (formulario == null)
            {
                formulario = new Miform();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.FixedSingle;
                //formulario.Dock = DockStyle.Fill;
                panelCentral.Controls.Add(formulario);
                panelCentral.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else //si el formulario/instancia existe
            {
                formulario.BringToFront();
            }
        }
    }
}
