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

        // Instaciar la conexión a la base de datos ORACLE
        //protected OracleConnection oraConn = new OracleConnection("DATA SOURCE = r3nyifjq4ic3fa96_high; PASSWORD = RestauranteSiglo21; USER ID = ADMIN;");

        //Local
        protected OracleConnection oraConn = new OracleConnection("DATA SOURCE = localhost; PASSWORD = restaurant; USER ID = restaurant;");


    }
}
