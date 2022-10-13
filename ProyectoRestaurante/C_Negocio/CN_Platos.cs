using ProyectoRestaurante.DAO;
using ProyectoRestaurante.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.C_Negocio
{
    class CN_Platos
    {

        private PlatosDao plato = new PlatosDao();

        public void ListarPlatos()
        {
            plato.VerPlatos();
        }

        public void AgregarPlatos(string nombre, int precio, string descripcion)
        {
            plato.CreatePlatos(nombre, precio, descripcion);
        }

        public void EditarPlatos(int id, string nombre, int precio, string descripcion)
        {
            plato.UpdatePlatos(Convert.ToInt32(id), nombre, precio, descripcion);
        }

        public void EliminarPlatos(int id)
        {
            plato.DeletePlatos(Convert.ToInt32(id));
        }

    }
}
