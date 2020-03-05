using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicPlus.Views.FormsBase
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
        }

        public virtual int Insert()
        {
            return 0;
        }

        public virtual int  UpdateTable()
        {
            return 0;
        }

        public virtual int Delete()
        {
            return 0;
        }

        public virtual int GetID()
        {
            try
            {
                return Convert.ToInt32(dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public virtual void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
    }
}
