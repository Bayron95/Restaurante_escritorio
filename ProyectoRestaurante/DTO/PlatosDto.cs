using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.DTO
{
    public class PlatosDto
    {

        //variables
        int    _id_plato;
        string _nombre_plato;
        int    _precio_plato;
        string _Descripcion_plato;
        int _estado_plato;

        
        public int Id_plato { get => _id_plato; set => _id_plato = value; }
        public string Nombre_plato { get => _nombre_plato; set => _nombre_plato = value; }
        public int Precio_plato { get => _precio_plato; set => _precio_plato = value; }
        public string Descripcion_plato { get => _Descripcion_plato; set => _Descripcion_plato = value; }
        public int Estado_plato { get => _estado_plato; set => _estado_plato = value; }
    }
}
