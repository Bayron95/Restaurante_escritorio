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
using ProyectoRestaurante.DAO;
using ProyectoRestaurante.DTO;
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

        private void VistaGestionUsuarios_Load(object sender, EventArgs e)
        {
            VerUsuarios();
        }

        private void VerUsuarios()
        {
            UsuariosDao usr = new UsuariosDao();
            dataGridView1.DataSource = usr.VerUsuarios();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            AgregarUsuario Addusr = new AgregarUsuario();
            Addusr.Show();
        }

  
    }
}
