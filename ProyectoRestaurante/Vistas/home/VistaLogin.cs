using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;



namespace ProyectoRestaurante
{
    public partial class VistaLogin : Form
    {
        public VistaLogin()
        {
            InitializeComponent();
        }

        // Instaciar la conexión a la base de datos ORACLE CLOUD
        OracleConnection oraConn = new OracleConnection("DATA SOURCE = restaurantedb_high; " +
                                                        "PASSWORD = RestauranteSiglo21; " +
                                                        "USER ID = ADMIN;");

        // Instaciar la conexión a la base de datos ORACLE LOCAL
        //OracleConnection oraConn = new OracleConnection("DATA SOURCE = localhost; " +
        //"PASSWORD = restaurant; " +
        //"USER ID = restaurant;");


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            login(this.textBoxUser.Text, this.textBoxPassword.Text);
        }


        public void login(string usuario, string password)
        {
            try
            {
                //abro conexión
                oraConn.Open();
                //Consulta en variable
                OracleCommand comando = new OracleCommand("SELECT USUARIO, TIPO_USUARIO " +
                                                          "FROM USUARIOS " +
                                                          "WHERE USUARIO =:nombre " +
                                                          "AND PASSWORD =:password", oraConn);

                // solicito los datos de entrada
                comando.Parameters.Add(":nombre", textBoxUser.Text);
                comando.Parameters.Add(":password", textBoxPassword.Text);

                OracleDataAdapter oda = new OracleDataAdapter(comando);

                DataTable dt = new DataTable();
                oda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        MessageBox.Show("Bienvenido! \n"+textBoxUser.Text);
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
