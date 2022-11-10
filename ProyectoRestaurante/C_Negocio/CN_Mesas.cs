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

        public void ActualizarMesas(int id, string estado)
        {
            mesa.UpdateMesas(Convert.ToInt32(id), estado);
        }

        public void EliminarMesas(int id)
        {
            mesa.DeleteMesas(Convert.ToInt32(id));
        }
    }
}
