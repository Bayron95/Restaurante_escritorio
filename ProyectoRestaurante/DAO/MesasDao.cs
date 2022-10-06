using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using System.Data.OracleClient;
using ProyectoRestaurante.DTO;
using Oracle.ManagedDataAccess.Client;

namespace ProyectoRestaurante.DAO
{
    class MesasDao:ConexionBD
    {
        OracleDataReader LeerFilas;
        OracleCommand cmd = new OracleCommand();

        //metodos crud
        public List<MesasDto> VerMesas(string condicion)
        {
            cmd.Connection  = oraConn;
            cmd.CommandText = "SP_verMesas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@valor", condicion);

            oraConn.Open(); 

            LeerFilas = cmd.ExecuteReader();
            List<MesasDto> ListaGenerica = new List<MesasDto>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new MesasDto
                {
                    Id = LeerFilas.GetInt32(0),
                    Capacidad = LeerFilas.GetInt32(1),
                    Estado = LeerFilas.GetInt32(2)
                });

            }

            LeerFilas.Close();
            oraConn.Close();

            return ListaGenerica;

        }

        public void insert() { }
        public void update() { }
        public void delete() { }
        

    }
}
