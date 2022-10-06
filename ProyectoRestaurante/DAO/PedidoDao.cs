using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoRestaurante.DTO;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ProyectoRestaurante.DAO
{
    class PedidoDao : ConexionBD
    {

        OracleDataReader LeerPedidos;
        OracleCommand cmd = new OracleCommand();

        //metodos crud
        public List<PedidoDto> VerPedidos()
        {
            cmd.Connection = oraConn;
            //cmd.CommandText = "SP_VER_PEDIDOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_pedidos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            oraConn.Open();

            //LeerPedidos = cmd.ExecuteReader();
            List<PedidoDto> ListaGenerica = new List<PedidoDto>();
            while (LeerPedidos.Read())
            {
                ListaGenerica.Add(new PedidoDto
                {
                    Id = LeerPedidos.GetInt32(0),
                    Estado_pedido = LeerPedidos.GetInt32(1),
                    Id_plato = LeerPedidos.GetInt32(2),
                    Id_detalle = LeerPedidos.GetInt32(3),
                    Id_mesa = LeerPedidos.GetInt32(4),
                    Id_empleado = LeerPedidos.GetInt32(5)
                });

            }

            LeerPedidos.Close();
            oraConn.Close();

            return ListaGenerica;

        }



        public void CrearPedido() { }
        public void ActualizarPedido() { }
        public void EliminarPedido() { }


    }
}
