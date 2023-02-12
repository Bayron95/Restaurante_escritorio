using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoRestaurante.DAO;

namespace ProyectoRestaurante.C_Negocio
{
    public class CN_Pedidos
    {
        private PedidosDao pedido = new PedidosDao();

        public void ListarPedidos()
        {
            pedido.ListarPedidos();

        }

        public void AgregarPedido(int capacidad, string estado)
        {
            //pedido.CreatePedido(capacidad, estado);
        }

        public void EditarPedido(int id, int capacidad, string estado)
        {
            //pedido.UpdatePedido(Convert.ToInt32(id), capacidad, estado);
        }

        public void EliminarPedido(int id)
        {
            //pedido.DeletePedido(Convert.ToInt32(id));
        }
    }
}
