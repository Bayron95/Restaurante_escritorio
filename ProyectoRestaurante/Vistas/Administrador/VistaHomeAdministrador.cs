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
using Oracle.ManagedDataAccess.Client;

namespace ProyectoRestaurante
{
    public partial class VistaHomeAdministrador : Form
    {

        ConexionBD con = new ConexionBD();
        public VistaHomeAdministrador(string usuario)
        {
            
            InitializeComponent();
            lblNameUser.Text = usuario;
        }
        public VistaHomeAdministrador()
        {
            InitializeComponent();

        }

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            VistaLogin sesion = new VistaLogin();
            sesion.Show();
            this.Close();
        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            VistaGestionMesas mesas = new VistaGestionMesas();
            mesas.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            VistaGestionUsuarios usuarios = new VistaGestionUsuarios();
            usuarios.Show();
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            VistaGestionPlatos productos = new VistaGestionPlatos();
            productos.Show();
            this.Hide();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            VistaGestionProveedor proveedores = new VistaGestionProveedor();
            proveedores.Show();
            this.Hide();
        }

        private void btnResumenDatos_Click(object sender, EventArgs e)
        {
            VistaGestionReportes reportes = new VistaGestionReportes();
            reportes.Show();
            this.Hide();
        }

        private void VistaHomeAdministrador_Load(object sender, EventArgs e)
        {
            AllPedidos();
        }

        private void AllPedidos()
        {
            PedidosDao usr = new PedidosDao();
            dgvPedidos.DataSource = usr.VerPedidos();
        }
    }
}
