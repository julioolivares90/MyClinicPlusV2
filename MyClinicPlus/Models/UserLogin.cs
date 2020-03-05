using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.Models
{
    public class UserLogin
    {
        private static readonly UserLogin _instance = new UserLogin();

        public static UserLogin Instance { get => _instance; }


        public int ID_USER { get; set; }

        public int ROL { get; set; }
    }
}
