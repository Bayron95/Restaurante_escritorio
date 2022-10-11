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
        UsuariosDao usr = new UsuariosDao();

        public AgregarUsuario()
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
            UpdateEventHandler.Invoke(this,args);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AgregarNuevo();
            this.Close();
            insertar();
        }


        public void AgregarNuevo()
        {
            
            if (txtUsuario.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    usr.CreateUsuario(txtUsuario.Text, txtPassword.Text, cboTipoUser.Text);
                                        
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

            MessageBox.Show("Usuario creado con exito!");

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
