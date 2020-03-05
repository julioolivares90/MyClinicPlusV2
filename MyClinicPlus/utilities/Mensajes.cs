using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicPlus.utilities
{
    public class Mensajes
    {
        public static void EmptyFields()
        {
            MessageBox.Show("Campos Vacios");
        }

        public static void AgregadoConExito()
        {
            MessageBox.Show("agregado con exito");
        }

        public static void ActualizadoConExito()
        {
            MessageBox.Show("Actualizado con exito");
        }
        public static void EliminadoConExito()
        {
            MessageBox.Show("Eliminado con exito");
        }
        public static void OcurrioUnError()
        {
            MessageBox.Show("Ocurrio un error");
        }

        public static void CorreoNoValido()
        {
            MessageBox.Show("Correo no valido");
        }
    }
}
