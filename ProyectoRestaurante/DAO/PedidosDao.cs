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
    class PedidosDao : ConexionBD
    {

        OracleDataReader LeerPedidos;
        OracleCommand cmd = new OracleCommand();
        OracleDataAdapter adapter = new OracleDataAdapter();


        public DataTable ListarPedidos()
        {
            DataTable ListaPedidos = new DataTable();
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_VER_PEDIDOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_pedidos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            LeerPedidos = cmd.ExecuteReader();
            ListaPedidos.Load(LeerPedidos);
            LeerPedidos.Close();
            oraConn.Close();

            return ListaPedidos;
        }

        //metodos crud
        public List<PedidoDto> VerPedidos()
        {
            cmd.Connection = oraConn;
            cmd.CommandText = "SP_VER_PEDIDOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_pedidos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            oraConn.Open();

            LeerPedidos = cmd.ExecuteReader();
            List<PedidoDto> ListaGenerica = new List<PedidoDto>();
            while (LeerPedidos.Read())
            {
                ListaGenerica.Add(new PedidoDto
                {
                    Id = LeerPedidos.GetInt32(0),
                    Id_mesa = LeerPedidos.GetInt32(1),
                    Estado_pedido = LeerPedidos.GetInt32(2)
                });

            }

            LeerPedidos.Close();
            oraConn.Close();

            return ListaGenerica;

        }
        public void UpdatePedido(int id, int capacidad, string estado)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_UPDATE_PEDIDO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id);
            cmd.Parameters.Add("V_capacidad", capacidad);
            cmd.Parameters.Add("V_estado", estado);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }
        public void DeletePedido(int id_pedido)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_DELETE_PEDIDO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id_pedido);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }
    }
}
