using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.utilities
{
    class Encriptar
    {
        /// <summary>
        /// metodo para encriptar las contraseñas en formato SHA256
        /// </summary>
        /// <param name="pass">cadena que se quiere encriptar</param>
        /// <returns>retorna la cadena encriptada</returns>
        public static string encriptarPassword(string pass)
        {
            SHA256 sHA256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();

            StringBuilder stringBuilder = new StringBuilder();
            byte[] stream = sHA256.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++)
            {
                stringBuilder.AppendFormat("{0:x2}", stream[i]);
            }
            return stringBuilder.ToString();
        }
    }
}
