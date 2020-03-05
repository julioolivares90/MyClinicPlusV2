using LinqToDB;
using Models.Models;
using MyClinicPlus.Views.Vender;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicPlus.Controller
{
    class BuscarMedicamentoController
    {

        public async Task<List<Producto>> GetProductosAsync(int saltar, int tomar)
        {
            using (var db = new Conexion.Conexion())
            {
                return await db.Productos.OrderBy(p => p.id_producto).Skip(saltar).Take(tomar).ToListAsync();
            }
        }
    }

}
