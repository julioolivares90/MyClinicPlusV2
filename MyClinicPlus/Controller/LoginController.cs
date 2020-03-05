using MyClinicPlus.Daos;
using MyClinicPlus.Model;
using MyClinicPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.Controller
{
    class LoginController
    {
        
        public Usuario1 GetUsuario(UserViewModel user)
        {
            var usuario = LoginDao.Login(user);
            return usuario;
        }
    }
}
