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
    public partial class VistaFinanzas : Form
    {
        public VistaFinanzas(string usuario)
        {
            InitializeComponent();
            lblNameUser.Text = usuario;
        }

        private void btn_cerrarSesion_Click(object sender, EventArgs e)
        {
            VistaLogin sesion = new VistaLogin();
            sesion.Show();
            this.Close();
        }

        private void btnReporteUtilidad_Click(object sender, EventArgs e)
        {

        }
    }
}
