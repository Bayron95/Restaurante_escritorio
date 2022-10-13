using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.DTO
{
    public class ProductosDto
    {

        int ID_PRODUCTO;
        int ID_PROVEEDOR;
        int ID_CATEGORIA;
        string NOMBRE;
        string CODIGO;
        int PRECIO;
        int IVA;
        int STOCK;

        public int ID_PRODUCTO1 { get => ID_PRODUCTO; set => ID_PRODUCTO = value; }
        public int ID_PROVEEDOR1 { get => ID_PROVEEDOR; set => ID_PROVEEDOR = value; }
        public int ID_CATEGORIA1 { get => ID_CATEGORIA; set => ID_CATEGORIA = value; }
        public string NOMBRE1 { get => NOMBRE; set => NOMBRE = value; }
        public string CODIGO1 { get => CODIGO; set => CODIGO = value; }
        public int PRECIO1 { get => PRECIO; set => PRECIO = value; }
        public int IVA1 { get => IVA; set => IVA = value; }
        public int STOCK1 { get => STOCK; set => STOCK = value; }
    }
}
