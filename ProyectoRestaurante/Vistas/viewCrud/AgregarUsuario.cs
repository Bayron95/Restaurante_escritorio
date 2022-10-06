using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoRestaurante.DAO;
using System.Windows.Forms;

namespace ProyectoRestaurante.Vistas.viewCrud
{
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }


        public void AgregarNuevo()
        {
            UsuariosDao usr = new UsuariosDao();
            if (txtUsuario.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    usr.InsertUser(txtUsuario.Text, txtPassword.Text, cboBoxTipoUser.Text);
                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de usuario");
            }
            
        }
    }
}
