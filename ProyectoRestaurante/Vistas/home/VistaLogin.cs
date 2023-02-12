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
using ProyectoRestaurante.C_Negocio;



namespace ProyectoRestaurante
{
    public partial class VistaLogin : Form
    {
        public VistaLogin()
        {
            InitializeComponent();
        }

        

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Usuarios cn_usr = new CN_Usuarios();

            if (textBoxUser.Text.Trim() != "")
            {
                if (textBoxPassword.Text.Trim() != "")
                {
                    if (cn_usr.LoginUsuario(this.textBoxUser.Text, this.textBoxPassword.Text) == 1)
                    {
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un usuario");
            }
        }

    }
}
