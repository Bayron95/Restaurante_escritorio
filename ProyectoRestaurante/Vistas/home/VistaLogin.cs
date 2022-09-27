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
        
        // Instaciar la conexión a la base de datos ORACLE
        OracleConnection oraConn = new OracleConnection("DATA SOURCE = xe; PASSWORD = restaurant; USER ID = restaurant;");
        
       
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            login(this.textBoxUser.Text,this.textBoxPassword.Text);
        }


        public void login(string usuario, string password)
        {
            try
            {
                //abro conexión
                oraConn.Open();
                //Consulta en variable
                OracleCommand comando = new OracleCommand("SELECT NOMBRE_USUARIO, TIPO_USUARIO " +
                                                          "FROM USUARIOS " +
                                                          "WHERE NOMBRE_USUARIO =:nombre " +
                                                          "AND PASSWORD =:password", oraConn);

                // solicito los datos de entrada
                comando.Parameters.AddWithValue(":nombre", textBoxUser.Text);
                comando.Parameters.AddWithValue(":password", textBoxPassword.Text);

                OracleDataAdapter sda = new OracleDataAdapter(comando);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        MessageBox.Show("Ingreso Exitoso");
                        new VistaHomeAdministrador(dt.Rows[0][0].ToString()).Show();
                        this.Hide();
                    }
                    else if (dt.Rows[0][1].ToString() == "Cocina")
                    {
                        new VistaCocina(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "Finanzas")
                    {
                        new VistaFinanzas(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "Bodega")
                    {
                        new VistaBodega(dt.Rows[0][0].ToString()).Show();
                    }
                    //else if (dt.Rows[0][1].ToString() == "Garzon")
                    //{
                    //    new VistaCocina(dt.Rows[0][0].ToString()).Show();
                    //}
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecta");
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                oraConn.Close();
            }
        }

    }
}
