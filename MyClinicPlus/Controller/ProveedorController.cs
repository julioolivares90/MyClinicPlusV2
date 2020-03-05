using LinqToDB;
using Models.Models;
using MyClinicPlus.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.Controller
{
    class ProveedorController
    {
        public static int AddProveedor(Proveedor proveedor)
        {

            
            using (var db = new Conexion.Conexion())
            {
              return  db.Proveedores.Value(p => p.nombre_proveedor,proveedor.nombre_proveedor.Trim())
                    .Value(p=>p.correo_proveedor,proveedor.correo_proveedor.Trim())
                    .Value(p=>p.telefono_proveedor,proveedor.telefono_proveedor.Trim()).Insert();
            }
            //return ProveedorDao.InsertProveedor(proveedor);
        }

        public List<Proveedor> GetProveedores()
        {
            var lista = new List<Proveedor>();
            using (var db = new Conexion.Conexion())
            {
                
                lista = db.GetTable<Proveedor>().ToList();
            }
            return lista;
        }

        public int UpdateProveedor(Proveedor proveedor)
        {
            using (var db = new Conexion.Conexion())
            {
                return db.Proveedores.Where(p => p.id_proveedor.Equals(proveedor.id_proveedor))
                    .Set(p => p.nombre_proveedor, proveedor.nombre_proveedor)
                    .Set(p => p.correo_proveedor, proveedor.correo_proveedor)
                    .Set(p=>p.telefono_proveedor,proveedor.telefono_proveedor)
                    .Update();
            }
        }

        public int DeleteProveedor(int proveedor)
        {
            using (var db = new Conexion.Conexion())
            {
                return db.Proveedores.Where(p => p.id_proveedor.Equals(proveedor)).Delete();
            }
        }

        
    }
}
