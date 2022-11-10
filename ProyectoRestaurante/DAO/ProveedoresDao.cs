using ProyectoRestaurante.DTO;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoRestaurante.DAO
{
    class ProveedoresDao : ConexionBD
    {
        OracleDataReader LeerFilas;
        OracleCommand cmd = new OracleCommand();

        //metodos crud
        public List<ProveedoresDto> VerProveedores()
        {
            cmd.Connection = oraConn;
            cmd.CommandText = "SP_VER_PROVEEDORES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_proveedores", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            oraConn.Open();

            LeerFilas = cmd.ExecuteReader();
            List<ProveedoresDto> ListaGenerica = new List<ProveedoresDto>();
            while (LeerFilas.Read())
            {

                ListaGenerica.Add(new ProveedoresDto
                {
                    ID_PROVEEDOR = LeerFilas.GetInt32(0),
                    NOMBRE = LeerFilas.GetString(1),
                    RUT = LeerFilas.GetString(2),
                    DIRECCION = LeerFilas.GetString(3),
                    TELEFONO = LeerFilas.GetInt32(4),
                    CORREO = LeerFilas.GetString(5),

                });

            }

            LeerFilas.Close();
            oraConn.Close();

            return ListaGenerica;

        }
        //public void CreateProveedores(string nombre, string rut, string direccion, int telefono, string correo)


        public void CreateProveedores(ProveedoresDto proveedor)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_CREATE_PROVEEDOR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_nombre_prov", proveedor.NOMBRE);
            cmd.Parameters.Add("V_rut", proveedor.RUT);
            cmd.Parameters.Add("v_direccion", proveedor.DIRECCION);
            cmd.Parameters.Add("v_telefono", proveedor.TELEFONO);
            cmd.Parameters.Add("v_correo", proveedor.CORREO);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }

        public void UpdateProveedores(ProveedoresDto proveedor)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_UPDATE_PROVEEDOR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", proveedor.ID_PROVEEDOR);
            cmd.Parameters.Add("v_nombre_prov", proveedor.NOMBRE);
            cmd.Parameters.Add("V_rut", proveedor.RUT);
            cmd.Parameters.Add("v_direccion", proveedor.DIRECCION);
            cmd.Parameters.Add("v_telefono", proveedor.TELEFONO);
            cmd.Parameters.Add("v_correo", proveedor.CORREO);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }
        public void DeleteProveedores(ProveedoresDto proveedor)
        {
            cmd.Connection = oraConn;
            oraConn.Open();
            cmd.CommandText = "SP_DELETE_PROVEEDOR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_id", proveedor.ID_PROVEEDOR);
            cmd.ExecuteNonQuery();
            oraConn.Close();
        }
    }
}
