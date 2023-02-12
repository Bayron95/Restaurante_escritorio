using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.DTO
{
    public class ProveedoresDto
    {
        //variables
        int     _ID_PROVEEDOR;
        string  _NOMBRE;
        string  _RUT;
        string  _DIRECCION;
        int     _TELEFONO;
        string  _CORREO;

        public ProveedoresDto()
        {
            _ID_PROVEEDOR = 0;
            _NOMBRE = null;
            _RUT = null;
            _DIRECCION = null;
            _TELEFONO = 0;
            _CORREO = null;
        }

        public int ID_PROVEEDOR { get => _ID_PROVEEDOR; set => _ID_PROVEEDOR = value; }
        public string NOMBRE { get => _NOMBRE; set => _NOMBRE = value; }
        public string RUT { get => _RUT; set => _RUT = value; }
        public string DIRECCION { get => _DIRECCION; set => _DIRECCION = value; }
        public int TELEFONO { get => _TELEFONO; set => _TELEFONO = value; }
        public string CORREO { get => _CORREO; set => _CORREO = value; }
    }
}
