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
    public partial class VistaGestionReportes : Form
    {
        public VistaGestionReportes(string usuario)
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
    }
}
