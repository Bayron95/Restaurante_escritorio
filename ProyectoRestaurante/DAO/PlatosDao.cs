using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoRestaurante.DTO;

namespace ProyectoRestaurante.DAO
{
    class PlatosDao : ConexionBD
    {
        OracleDataReader LeerFilas;
        OracleCommand cmd = new OracleCommand();

        //metodos crud
        public List<PlatosDto> VerPlatos()
        {
            cmd.Connection = oraConn;
            cmd.CommandText = "SP_VER_PLATOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_platos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            oraConn.Open();
            LeerFilas = cmd.ExecuteReader();
            List<PlatosDto> ListaGenerica = new List<PlatosDto>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new PlatosDto
                {
                    Id_plato = LeerFilas.GetInt32(0),
                    Nombre_plato = LeerFilas.GetString(1),
                    Precio_plato = LeerFilas.GetInt32(2),
                    Descripcion_plato = LeerFilas.GetString(3)
                    //Estado_plato = LeerFilas.GetInt32(3)
                });
            }
            LeerFilas.Close();
            oraConn.Close();

            return ListaGenerica;
        }

        public void CreatePlatos(string nombre, int precio, string descripcion, int estado)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_CREATE_PLATO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_nombre", nombre);
            cmd.Parameters.Add("V_precio", precio);
            cmd.Parameters.Add("V_descripcion", descripcion);
            cmd.Parameters.Add("v_estado_mesa", estado);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }

        public void UpdatePlatos(int id, string nombre, int precio, string descripcion, int estado)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_UPDATE_PLATO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id);
            cmd.Parameters.Add("v_nombre", nombre);
            cmd.Parameters.Add("v_precio_Plato", precio);
            cmd.Parameters.Add("v_descripcion_Plato", descripcion);
            cmd.Parameters.Add("v_estado_plato", estado);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }
        public void DeletePlatos(int id_plato)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_DELETE_PLATO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id_plato);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }
    }
}
