using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicPlus.utilities
{
    class Validaciones
    {
        public static bool isEmailValid(string value) {

            var expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(value,expresion))
            {
                if (Regex.Replace(value,expresion,string.Empty).Length == 0)
                {
                    return true;
                }else
                {
                    return false;
                }
            }else
            {
                return false;
            }
        
        }

        public static void validarLetras(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsUpper(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLower(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras y espacions en blanco","Adventercia",MessageBoxButtons.OK);
            }
        } 
    }
}
