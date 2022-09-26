using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRestaurante
{
    public partial class VistaLogin : Form
    {
        public VistaLogin()
        {
            InitializeComponent();
        }
        
        // se instacia la conexión a la base de datos
        OracleConnection oraConn = new OracleConnection("DATA SOURCE = xe; PASSWORD = ByronCarrasco07; USER ID = ADMIN;");
        
       
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            oraConn.Open();
            //selecciono la tabla de busqueda con los datos necesarios
            OracleCommand comando = new OracleCommand("SELECT NOMBRE_USUARIO, FROM USUARIOS WHERE NOMBRE_USUARIO =:nombre AND PASSWORD =:password", oraConn);

            // solicito los datos de entrada
            comando.Parameters.AddWithValue(":nombre", textBoxUser.Text);
            comando.Parameters.AddWithValue(":password", textBoxPassword.Text);

            // nuevo lector de datos entrantes
            OracleDataReader lector = comando.ExecuteReader();

            //condicional si existe el usuario dentro de la tabala de usuarios
            if (lector.Read())
            {
                //ingresa a la vista segun perfil o rol de usuario
                Form formularioADM = new VistaHomeAdministrador();
                MessageBox.Show("Ingreso Exitoso");
                formularioADM.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o clave no existe");
                oraConn.Close();
            }
        }
    }
}
