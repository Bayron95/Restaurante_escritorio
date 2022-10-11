using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoRestaurante.DAO;
using ProyectoRestaurante.Vistas.viewCrud;

namespace ProyectoRestaurante
{
    public partial class VistaGestionUsuarios : Form
    {

        public VistaGestionUsuarios()
        {
            InitializeComponent();
            //lblNameUser.Text
        }
       
        private void btnVolver_Click(object sender, EventArgs e)
        {
            VistaHomeAdministrador homeAdm = new VistaHomeAdministrador();
            homeAdm.Show();
            this.Close();
        }

        private void ActualizarGrid(object sender, AgregarUsuario.UpdateEventArgs args)
        {
            UsuariosDao usr = new UsuariosDao();
            dataGridView1.DataSource = usr.VerUsuarios();
        }

        private void VistaGestionUsuarios_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            UsuariosDao usr = new UsuariosDao();
            dataGridView1.DataSource = usr.VerUsuarios();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            AgregarUsuario Addusr = new AgregarUsuario();
            Addusr.Show();
            Addusr.UpdateEventHandler += ActualizarGrid;
            //Addusr.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarUsuario EditUsr = new EditarUsuario();
            EditUsr.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario DelUsr = new EliminarUsuario();
            DelUsr.Show();
        }
    }
}
