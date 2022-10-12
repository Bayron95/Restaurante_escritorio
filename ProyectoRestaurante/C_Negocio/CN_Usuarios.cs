using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoRestaurante.DAO;

namespace ProyectoRestaurante.C_Negocio
{
    public class CN_Usuarios
    {

        private UsuariosDao usr = new UsuariosDao();


        //metodo que devuelve una tabla por medio del objeto usr.VerUsuarios
        public DataTable ListarUsuarios()
        {
            DataTable dt = new DataTable();
            //dt = usr.VerUsuarios();
            return dt;
        } 

        public void AgregarUsuario(string usuario, string password, string tipoUsuario)
        {
            usr.CreateUsuario(usuario, password, tipoUsuario);
        }

        public void EditarUsuario(int id, string usuario, string password, string tipoUsuario)
        {
            usr.UpdateUsuario(Convert.ToInt32(id), usuario, password, tipoUsuario);
        }


    }

    

}
