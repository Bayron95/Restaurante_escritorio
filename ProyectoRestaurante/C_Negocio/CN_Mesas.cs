using ProyectoRestaurante.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.C_Negocio
{
    public class CN_Mesas
    {
        private MesasDao mesa = new MesasDao();

        public void ListarMesas()
        {
            mesa.VerMesas();
        }

        public void AgregarMesas(int capacidad, string estado)
        {
            mesa.CreateMesas(capacidad, estado);
        }

        public void EditarMesas(int id, int capacidad, string estado)
        {
            mesa.UpdateMesas(Convert.ToInt32(id), capacidad, estado);
        }

        public void EliminarMesas(int id)
        {
            mesa.DeleteMesas(Convert.ToInt32(id));
        }

    }
}
