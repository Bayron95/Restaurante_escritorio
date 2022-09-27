using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRestaurante
{
    public partial class VistaHomeAdministrador : Form
    {
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
            VistaGestiónProductos productos = new VistaGestiónProductos();
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
    }
}
