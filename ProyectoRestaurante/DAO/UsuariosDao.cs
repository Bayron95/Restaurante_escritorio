using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoRestaurante.DTO;
using Oracle.ManagedDataAccess.Client;
using ProyectoRestaurante.Vistas;
using System.Windows.Forms;

namespace ProyectoRestaurante.DAO
{
    class UsuariosDao : ConexionBD
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

        public void CreateUsuario(string usuario, string password, string tipoUsurio)
        {

            cmd.Connection = oraConn;
            oraConn.Open();

            cmd.CommandText = "SP_CREATE_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_usuario", usuario);
            cmd.Parameters.Add("V_password", password);
            cmd.Parameters.Add("V_tipo_usuario", tipoUsurio);
            cmd.ExecuteNonQuery();

            oraConn.Close();
        }

        public void UpdateUsuario(int id, string usuario, string password, string tipoUsurio)
        {

            cmd.Connection = oraConn;
            oraConn.Open();

            cmd.CommandText = "SP_UPDATE_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id);
            cmd.Parameters.Add("v_usuario", usuario);
            cmd.Parameters.Add("V_password", password);
            cmd.Parameters.Add("V_tipo_usuario", tipoUsurio);

            cmd.ExecuteNonQuery();

            oraConn.Close();
        }
        public void DeleteUsuario(int id_user)
        {


            cmd.Connection = oraConn;
            oraConn.Open();

            cmd.CommandText = "SP_DELETE_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id_user);
            cmd.ExecuteNonQuery();

            oraConn.Close();
        }

        public void login(string usuario, string password)
        {
            VistaLogin vlogin = new VistaLogin();
            try
            {
                //abro conexión
                oraConn.Open();
                //Consulta en variable
                OracleCommand comando = new OracleCommand("SELECT USUARIO, TIPO_USUARIO " +
                                                          "FROM USUARIOS " +
                                                          "WHERE USUARIO =:nombre " +
                                                          "AND PASSWORD =:password", oraConn);

                // solicito los datos de entrada
                comando.Parameters.Add(":nombre", usuario);
                comando.Parameters.Add(":password", password);

                OracleDataAdapter oda = new OracleDataAdapter(comando);

                DataTable dt = new DataTable();
                oda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    //vlogin.Hide();
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        MessageBox.Show("Bienvenido! \n" + vlogin.textBoxUser.Text);
                        new VistaHomeAdministrador(dt.Rows[0][0].ToString()).Show();
                        
                    }
                    else if (dt.Rows[0][1].ToString() == "Cocina")
                    {
                        new VistaCocina(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "Finanzas")
                    {
                        new VistaFinanzas(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "Bodega")
                    {
                        new VistaBodega(dt.Rows[0][0].ToString()).Show();
                    }
                    vlogin.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecta");
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                oraConn.Close();
            }
        }
    }
}
