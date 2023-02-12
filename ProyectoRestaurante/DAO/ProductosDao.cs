using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoRestaurante.DTO;
using Oracle.ManagedDataAccess.Client;

namespace ProyectoRestaurante.DAO
{
    class ProductosDao:ConexionBD
    {

        OracleDataReader LeerFilas;
        OracleCommand cmd = new OracleCommand();

        //metodos crud
        public List<ProductosDto> VerProductos()
        {
            cmd.Connection = oraConn;
            cmd.CommandText = "SP_VER_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_productos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            oraConn.Open();

            LeerFilas = cmd.ExecuteReader();
            List<ProductosDto> ListaGenerica = new List<ProductosDto>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new ProductosDto
                {
                    ID_PRODUCTO = LeerFilas.GetInt32(0),
                    NOMBRE = LeerFilas.GetString(1),
                    CODIGO = LeerFilas.GetString(2),
                    PRECIO = LeerFilas.GetInt32(3),
                    IVA    = LeerFilas.GetInt32(4),
                    STOCK = LeerFilas.GetInt32(5)
                });

            }

            LeerFilas.Close();
            oraConn.Close();

            return ListaGenerica;

        }

        public void CreateProductos(string nombre_prod, string cod_prod, int precio_prod, int iva, int stock_prod) 
        {

            cmd.Connection = oraConn;
            oraConn.Open();

            cmd.CommandText = "SP_CREATE_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("V_nombre_prod", nombre_prod);
            cmd.Parameters.Add("V_cod_prod", cod_prod);
            cmd.Parameters.Add("V_precio_prod", precio_prod);
            cmd.Parameters.Add("V_stock", stock_prod);
            cmd.ExecuteNonQuery();
            
            oraConn.Close();
        }

        public void UpdateProductos(int id_prod, string nombre_prod, string cod_prod, int precio_prod, int iva, int stock) 
        {

            cmd.Connection = oraConn;
            oraConn.Open();

            cmd.CommandText = "SP_UPDATE_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id_prod);
            cmd.Parameters.Add("V_Nombre_prod", nombre_prod);
            cmd.Parameters.Add("V_cod_prod", cod_prod);
            cmd.Parameters.Add("V_precio", precio_prod);
            cmd.Parameters.Add("V_stock", stock);

            cmd.ExecuteNonQuery();

            oraConn.Close();
        }
        public void DeleteProducto(int id_prod) 
        {


            cmd.Connection = oraConn;
            oraConn.Open();

            cmd.CommandText = "SP_DELETE_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", id_prod);
            cmd.ExecuteNonQuery();

            oraConn.Close();
        }

    }
}
