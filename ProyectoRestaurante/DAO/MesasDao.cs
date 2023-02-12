using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoRestaurante.DTO;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.Drawing;

namespace ProyectoRestaurante.DAO
{
    class MesasDao : ConexionBD
    {
        OracleDataReader LeerFilas;
        OracleCommand cmd = new OracleCommand();

        //metodos crud
        public List<MesasDto> VerMesas()
        {
            oraConn.Open();

            cmd.Connection = oraConn;
            cmd.CommandText = "SP_VER_MESAS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_mesas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            LeerFilas = cmd.ExecuteReader();
            List<MesasDto> ListaGenerica = new List<MesasDto>();
            while (LeerFilas.Read())
            {

                ListaGenerica.Add(new MesasDto
                {
                    Id = LeerFilas.GetInt32(0),
                    Capacidad = LeerFilas.GetInt32(1),
                    Estado = LeerFilas.GetString(2)
                });

            }
            
            LeerFilas.Close();
            oraConn.Close();

            return ListaGenerica;

        }

        public void CreateMesas(int capacidad, string estado)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_CREATE_MESA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("V_capacidad", capacidad);
            cmd.Parameters.Add("V_estado", estado);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }

        public void UpdateMesas(int id, string estado)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_UPDATE_ESTADO_MESA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id);
            cmd.Parameters.Add("V_estado", estado);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }
        public void DeleteMesas(int id_mesa)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_DELETE_MESA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id_mesa);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }

        

    }
}
