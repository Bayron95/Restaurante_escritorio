using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.DTO
{
    public class PedidoDto
    {

        private int _id;
        private int _estado_pedido;
        private int _id_detalle;
        private int _id_mesa;
        private int _id_empleado;

        public int Id { get => _id; set => _id = value; }
        public int Estado_pedido { get => _estado_pedido; set => _estado_pedido = value; }
        public int Id_detalle { get => _id_detalle; set => _id_detalle = value; }
        public int Id_mesa { get => _id_mesa; set => _id_mesa = value; }
        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
    }
}
