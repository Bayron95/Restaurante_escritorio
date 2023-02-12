using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace ProyectoRestaurante.DAO
{
    class ConexionBD
    {

        //string cadena = "DATA SOURCE = restaurantedb_high; PASSWORD = RestauranteSiglo21; USER ID = ADMIN;";
        // Instaciar la conexión a la base de datos ORACLE
        protected OracleConnection oraConn = new OracleConnection("DATA SOURCE = restaurantedb_high; PASSWORD = RestauranteSiglo21; USER ID = ADMIN;");

        //Local
        //protected OracleConnection oraConn = new OracleConnection("DATA SOURCE = localhost; PASSWORD = restaurant; USER ID = restaurant;");
        public OracleConnection abrir()
        {
            if (oraConn.State == System.Data.ConnectionState.Closed)
            {
                oraConn.Open();
            }
            return oraConn;
        }

        public OracleConnection cerrar()
        {
            if (oraConn.State == System.Data.ConnectionState.Open)
            {
                oraConn.Close();
            }
            return oraConn;
        }
    }
}
