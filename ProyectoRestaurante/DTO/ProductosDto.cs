using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante.DTO
{
    public class ProductosDto
    {
        //variables
        int _id_producto;
        string _nombre_producto;
        string _codigo_producto;
        int _precio_producto;
        int _stock;

        public int Id_Producto { get => _id_producto; set => _id_producto = value; }
        public string Nombre_Producto { get => _nombre_producto; set => _nombre_producto = value; }
        public string Codigo_Producto { get => _codigo_producto; set => _codigo_producto = value; }
        public int Precio_Producto { get => _precio_producto; set => _precio_producto = value; }
        public int Stock { get => _stock; set => _stock = value; }
    }
}
