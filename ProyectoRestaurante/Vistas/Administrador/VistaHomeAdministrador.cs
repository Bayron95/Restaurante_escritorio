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
    }
}
