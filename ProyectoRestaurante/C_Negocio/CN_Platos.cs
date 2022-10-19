using ProyectoRestaurante.DAO;
using ProyectoRestaurante.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.C_Negocio
{
    public class CN_Platos
    {

        private PlatosDao plato = new PlatosDao();

        public void ListarPlatos()
        {
            plato.VerPlatos();
        }

        public void AgregarPlatos(string nombre, int precio, string descripcion, int estado)
        {
            plato.CreatePlatos(nombre, precio, descripcion, estado);
        }

        public void EditarPlatos(int id, string nombre, int precio, string descripcion, int estado)
        {
            plato.UpdatePlatos(id, nombre, precio, descripcion, estado);
        }

        public void EliminarPlatos(int id)
        {
            plato.DeletePlatos(id);
        }



    }
}
