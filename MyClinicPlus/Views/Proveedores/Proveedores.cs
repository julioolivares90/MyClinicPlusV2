using Models.Models;
using MyClinicPlus.Controller;
using MyClinicPlus.utilities;
using MyClinicPlus.Views.FormsBase;
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
    public partial class Proveedores : CRUD
    {
        private readonly ProveedorController _Controller = new ProveedorController();
        public Proveedores()
        {
            InitializeComponent();
            initData();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            var res = Insert();
            if (res > 0)
            {
                MessageBox.Show("Agregado con exito");
                Limpiar();
                initData();
            }else
            {
                MessageBox.Show("ocurrio un error");
            }
        }

        public override int Insert()
        {
            var proveedor = new Proveedor();
            proveedor.nombre_proveedor = textBox2.Text;
            proveedor.correo_proveedor = textBox3.Text;
            proveedor.telefono_proveedor = textBox4.Text;

            return ProveedorController.AddProveedor(proveedor);
        }

        public override int Delete()
        {
            var id = GetID();
            return _Controller.DeleteProveedor(id);
        }

        public override int UpdateTable()
        {
            var proveedor = new Proveedor();
            return _Controller.UpdateProveedor(proveedor);
        }
        private void initData()
        {
           
            dgvDatos.DataSource = _Controller.GetProveedores();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(textBox1.Text);
            var nombre = textBox2.Text;
            var email = textBox3.Text;
            var telefono = textBox4.Text;

            var proveedor = new Proveedor();
            proveedor.id_proveedor = id;
            proveedor.nombre_proveedor = nombre;
            proveedor.correo_proveedor = email;
            proveedor.telefono_proveedor = telefono;

            var r = _Controller.UpdateProveedor(proveedor);

            if (r >0)
            {
                Mensajes.ActualizadoConExito();
                Limpiar();
            }else
            {
                Mensajes.OcurrioUnError();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

          var rs =   Delete();
            if (rs > 0)
            {
                Mensajes.EliminadoConExito();
            }
            else
            {
                Mensajes.OcurrioUnError();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        

    }
}
