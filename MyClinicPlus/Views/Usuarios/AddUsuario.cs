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
    public partial class AddUsuario : Form
    {
        private Usuario _usuario = new Usuario();
        private readonly UsuariosController _controller = new UsuariosController();
        public AddUsuario()
        {
            InitializeComponent();
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var username = txtUsername.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                Mensajes.EmptyFields();
                txtNombre.Focus();
            }
            else if (string.IsNullOrEmpty(apellido))
            {
                Mensajes.EmptyFields();
                txtApellido.Focus();
            }
            else if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                Mensajes.EmptyFields();
                txtUsername.Focus();
            }
            else
            {
                _usuario.nombre = nombre;
                _usuario.apellido = apellido;
                _usuario.username = username;
                _usuario.pass = Encriptar.encriptarPassword(nombre + apellido + "123");
                
                var rs = await _controller.AddUsuarioAsync(_usuario);
                if (rs > 0)
                {
                    Mensajes.AgregadoConExito();
                    limpiar();
                }
                else
                {
                    Mensajes.EliminadoConExito();
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = cbRol.SelectedIndex;
            if (id>0)
            {
                var idRol =int.Parse(cbRol.SelectedValue.ToString());
                if (idRol > 0)
                {
                    _usuario.id_rol = idRol;
                }
            }
        }

        private void limpiar()
        {
             txtNombre.Text = "";
            txtApellido.Text ="";
            txtUsername.Text = "";
        }
        private async void cargadDatos()
        {
            cbRol.Items.Insert(0, "Selecciona un rol");
            cbRol.ValueMember = "id_rol";
            cbRol.DisplayMember = "rol";
            cbRol.DataSource = await _controller.GetRolUserComboAsync();
        }

        private void AddUsuario_Load(object sender, EventArgs e)
        {
            cargadDatos();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarLetras(e);
        }
    }
}
