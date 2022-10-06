using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.DTO
{
    public class UsuariosDto
    {
        //variables
        int _id_usuario;
        String _nombre_usuario;
        String _password;
        String _tipo_usuario;

        public int Id_usuario { get => _id_usuario; set => _id_usuario = value; }
        public string Nombre_usuario { get => _nombre_usuario; set => _nombre_usuario = value; }
        public string Password { get => _password; set => _password = value; }
        public string Tipo_usuario { get => _tipo_usuario; set => _tipo_usuario = value; }

        //accesadores y mutadores





    }
}
