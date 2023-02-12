using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoRestaurante.DAO;

namespace ProyectoRestaurante.C_Negocio
{
    public class CN_Productos
    {

        private ProductosDao producto = new ProductosDao();


        //metodo que devuelve una tabla por medio del objeto usr.VerUsuarios
        public DataTable ListarProductos()
        {
            DataTable dt = new DataTable();
            //dt = usr.VerUsuarios();
            return dt;
        }

        public void AgregarProducto(string nombre_prod, string cod_prod, int precio_prod, int iva, int stock)
        {
            producto.CreateProductos(nombre_prod, cod_prod, precio_prod, iva, stock);
        }

        public void EditarProducto(int id, string nombre_prod, string cod_prod, int precio_prod, int iva, int stock)
        {
            producto.UpdateProductos(Convert.ToInt32(id),nombre_prod, cod_prod, precio_prod, iva, stock);
        }

        public void EliminarProducto(int id)
        {
            producto.DeleteProducto(id);
        }
    }

    

}
