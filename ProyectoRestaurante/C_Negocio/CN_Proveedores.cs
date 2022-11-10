using ProyectoRestaurante.DAO;
using ProyectoRestaurante.DTO;
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

        public bool AgregarProveedores(ProveedoresDto pvrs)
        {
            bool flag = false;
            try
            {
                pvdrs.CreateProveedores(pvrs);
                flag = true;
            }
            catch (Exception)
            {

                flag = false;
            }
            return flag;
        }

        public bool EditarProveedores(ProveedoresDto pvrs)
        {
            bool flag = false;
            try
            {
                pvdrs.UpdateProveedores(pvrs);
                flag = true;
            }
            catch (Exception)
            {

                flag = false;
            }
            return flag;
        }

        public void EliminarProveedores(ProveedoresDto pvrs)
        {
            pvdrs.DeleteProveedores(pvrs);
        }
    }
}
