using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.DTO
{
    public class ProductosDto
    {

        int _ID_PRODUCTO;
        int _ID_PROVEEDOR;
        int _ID_CATEGORIA;
        string _NOMBRE;
        string _CODIGO;
        int _PRECIO;
        int _IVA;
        int _STOCK;

        public int ID_PRODUCTO { get => _ID_PRODUCTO; set => _ID_PRODUCTO = value; }
        public int ID_PROVEEDOR { get => _ID_PROVEEDOR; set => _ID_PROVEEDOR = value; }
        public int ID_CATEGORIA { get => _ID_CATEGORIA; set => _ID_CATEGORIA = value; }
        public string NOMBRE { get => _NOMBRE; set => _NOMBRE = value; }
        public string CODIGO { get => _CODIGO; set => _CODIGO = value; }
        public int PRECIO { get => _PRECIO; set => _PRECIO = value; }
        public int IVA { get => _IVA; set => _IVA = value; }
        public int STOCK { get => _STOCK; set => _STOCK = value; }
    }
}
