using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.DTO
{
    class MesasDto
    {
        //variables
        private int _id;
        private int _capacidad;
        private int _estado;


        //accesadores y mutadores
        public int Id { get => _id; set => _id = value; }
        public int Capacidad { get => _capacidad; set => _capacidad = value; }
        public int Estado { get => _estado; set => _estado = value; }

       


    }
}
