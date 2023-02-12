using ProyectoRestaurante.DAO;
using ProyectoRestaurante.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoRestaurante.Vistas.viewCrud
{
    public partial class EditarUsuario : Form
    {

        UsuariosDao usrDao = new UsuariosDao();

        public EditarUsuario()
        {
            InitializeComponent();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void insertar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    usrDao.UpdateUsuario(Convert.ToInt32(lblId.Text),
                                         txtUsuario.Text,
                                         txtPassword.Text,
                                         cboTipoUser.Text);

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

            MessageBox.Show("Usuario editado con exito!");
            this.Close();
            insertar();
        }
    }
}
