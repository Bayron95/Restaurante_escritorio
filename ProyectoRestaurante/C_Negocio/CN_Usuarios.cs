using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoRestaurante.DAO;
using System.Windows;

namespace ProyectoRestaurante.C_Negocio
{
    public class CN_Usuarios
    {

        private UsuariosDao usr = new UsuariosDao();


        //metodo que devuelve una tabla por medio del objeto usr.VerUsuarios
        public void ListarUsuarios()
        {
            usr.VerUsuarios();
        }

        public void AgregarUsuario(string usuario, string password, string tipoUsuario)
        {
            usr.CreateUsuario(usuario, password, tipoUsuario);
        }

        public void EditarUsuario(int id, string usuario, string password, string tipoUsuario)
        {
            usr.UpdateUsuario(Convert.ToInt32(id), usuario, password, tipoUsuario);
        }

        public void EliminarUsuario(int id)
        {
            usr.DeleteUsuario(Convert.ToInt32(id));
        }

        public void LoginUsuario(string usuario, string password)
        {
            usr.login(usuario, password);
        }
    }

    

}
