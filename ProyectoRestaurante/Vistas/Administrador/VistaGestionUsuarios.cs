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

        public VistaGestionUsuarios(string usuario)
        {

            InitializeComponent();
            lblNameUser.Text = usuario;
        }
       
        private void btnVolver_Click(object sender, EventArgs e)
        {
            VistaHomeAdministrador homeAdm = new VistaHomeAdministrador(lblNameUser.Text);
            homeAdm.Show();
            this.Close();
        }

        private void ActualizarGridAdd(object sender, AgregarUsuario.UpdateEventArgs args)
        {
            UsuariosDao usr = new UsuariosDao();
            dataGridView1.DataSource = usr.VerUsuarios();
        }

        private void ActualizarGridUpdate(object sender, EditarUsuario.UpdateEventArgs args)
        {
            UsuariosDao usr = new UsuariosDao();
            dataGridView1.DataSource = usr.VerUsuarios();
        }

        private void ActualizarGridDelete(object sender, EliminarUsuario.UpdateEventArgs args)
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
            Addusr.UpdateEventHandler += ActualizarGridAdd;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarUsuario EditUsr = new EditarUsuario();
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EditUsr.lblId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                EditUsr.txtUsuario.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                EditUsr.txtPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                EditUsr.cboTipoUser.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                EditUsr.Show();
                EditUsr.UpdateEventHandler += ActualizarGridUpdate;
               

            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un usuario");
            }

            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario DelUsr = new EliminarUsuario();

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DelUsr.lblId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                DelUsr.lblNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DelUsr.Show();
                DelUsr.UpdateEventHandler += ActualizarGridDelete;

            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un usuario");
            }
            
        }
    }
}
