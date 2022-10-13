using ProyectoRestaurante.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.C_Negocio
{
    class CN_Proveedores
    {
        private ProveedoresDao pvdrs = new ProveedoresDao();

        public void ListarProveedores()
        {
            pvdrs.VerProveedores();
        }

        public void AgregarProveedores(int capacidad, string estado)
        {
            pvdrs.CreateProveedores(capacidad, estado);
        }

        public void EditarProveedores(int id, int capacidad, string estado)
        {
            pvdrs.UpdateProveedores(Convert.ToInt32(id), capacidad, estado);
        }

        public void EliminarProveedores(int id)
        {
            pvdrs.DeleteProveedores(Convert.ToInt32(id));
        }
    }
}
