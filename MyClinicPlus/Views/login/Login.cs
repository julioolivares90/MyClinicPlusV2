using MyClinicPlus.Controller;
using MyClinicPlus.Model;
using MyClinicPlus.Models;
using MyClinicPlus.utilities;
using MyClinicPlus.Views.SplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicPlus
{
    public partial class Login : Form
    {
        private readonly LoginController Controller = new LoginController();
        private readonly Mensajes mensajes = new Mensajes();

        private readonly static Login _instance = new Login();

        public int ID_USER { get; set; }

        public int ROL_USER { get; set; }

        public  TextBox GettxtUsername()
        {
            return txtUsername;
        }
        public TextBox TxtPass { get { return txtPassword; } }
        public static Login Instance => _instance;

        public Login()
        {
            /*Thread thread = new Thread(new ThreadStart(cargarSplash));
            thread.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            thread.Abort();
            */
            InitializeComponent();
            
        }

        public void cargarSplash()
        {
            Application.Run(new Splash());
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var username = txtUsername.Text;
            var pass = txtPassword.Text;
            var userViewModel = new UserViewModel();
            if (username.Equals(""))
            {
                Mensajes.EmptyFields();
                txtUsername.Focus();
            }
            else if (pass.Equals(""))
            {
                Mensajes.EmptyFields();
                txtPassword.Focus();
            }
            else
            {

                userViewModel.Username = username;
                userViewModel.Pass = Encriptar.encriptarPassword(pass);

                var user = Controller.GetUsuario(userViewModel);
                if (user != null)
                {
                    if (user.Nombre != "")
                    {
                        var userLogin = UserLogin.Instance;
                        MessageBox.Show($"Bienvenido  {user.Nombre}");
                        userLogin.ID_USER = user.ID;
                        userLogin.ROL = user.ROL_ID;

                        Views.Menu.Mennu mennu = new Views.Menu.Mennu();
                        mennu.Show();
                        Hide();
                    }
                }
                
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
