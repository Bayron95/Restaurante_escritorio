using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoRestaurante.DTO;
using Oracle.ManagedDataAccess.Client;

namespace ProyectoRestaurante.DAO
{
    class UsuariosDao:ConexionBD
    {

        OracleDataReader LeerFilas;
        OracleCommand cmd = new OracleCommand();

        //metodos crud
        public List<UsuariosDto> VerUsuarios()
        {
            cmd.Connection = oraConn;
            cmd.CommandText = "SP_VER_USUARIOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_usuarios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            oraConn.Open();

            LeerFilas = cmd.ExecuteReader();
            List<UsuariosDto> ListaGenerica = new List<UsuariosDto>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new UsuariosDto
                {
                    Id_usuario = LeerFilas.GetInt32(0),
                    Nombre_usuario = LeerFilas.GetString(1),
                    Password = LeerFilas.GetString(2),
                    Tipo_usuario = LeerFilas.GetString(3)
                });

            }

            LeerFilas.Close();
            oraConn.Close();

            return ListaGenerica;

        }

        public void InsertUser(string usuario, string password, string tipoUsurio) 
        {

            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_CREATE_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_usuario",usuario);
            cmd.Parameters.Add("V_password", password);
            cmd.Parameters.Add("V_tipo_usuario", tipoUsurio);

            oraConn.Close();

        }

        public void update(int v_id, string usuario, string password, string tipoUsurio) 
        {

            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_UPDATE_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", v_id);
            cmd.Parameters.Add("v_usuario", usuario);
            cmd.Parameters.Add("V_password", password);
            cmd.Parameters.Add("V_tipo_usuario", tipoUsurio);

            oraConn.Close();
        }
        public void delete(int id_user) 
        {


            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_DELETE_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id_user);

            oraConn.Close();
        }

    }
}
