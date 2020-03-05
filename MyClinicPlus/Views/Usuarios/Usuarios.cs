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

namespace MyClinicPlus.Views.Usuarios
{
    public partial class Usuarios : Form
    {

        private readonly UsuariosController _controller = new UsuariosController();
        private Usuario _usuario = new Usuario();
        public Usuarios()
        {
            InitializeComponent();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtID.Text);
            if (id > 0)
            {
                _usuario.id = id;
                _usuario.nombre = txtNombre.Text;
                _usuario.apellido = txtApellido.Text;
                _usuario.username = txtUsername.Text;

                var rs = await _controller.UpdateUsuarioAsync(_usuario);
                if (rs > 0)
                {
                    Mensajes.ActualizadoConExito();
                    cargarDatos();
                    
                }else
                {
                    Mensajes.OcurrioUnError();
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtID.Text);
            if (id > 0)
            {

                var rs = await _controller.DeleteUsuarioAsync(id);
                if (rs > 0)
                {
                    Mensajes.EliminadoConExito();

                }
            }
        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = cbRol.SelectedIndex;
            if (id>0)
            {
                var idRol = int.Parse(cbRol.SelectedValue.ToString());
                if (idRol > 0)
                {
                    _usuario.id_rol = idRol;
                }
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvDatos.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
            txtNombre.Text = dgvDatos.Rows[e.RowIndex].Cells["nombre"].FormattedValue.ToString();
            txtApellido.Text = dgvDatos.Rows[e.RowIndex].Cells["apellido"].FormattedValue.ToString();
            txtUsername.Text = dgvDatos.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var addUser = new AddUsuario();
            addUser.ShowDialog();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            cargarDatos();
            LoadRoles();
        }

        private async void cargarDatos()
        {
            dgvDatos.DataSource = await _controller.GetUsuariosAsync();
        }

        private async void LoadRoles()
        {
            cbRol.Items.Insert(0,"selecciona un rol");
            cbRol.ValueMember = "id_rol";
            cbRol.DisplayMember = "rol";
            cbRol.DataSource = await _controller.GetRolUserComboAsync();
        }
    }
    
    
}
