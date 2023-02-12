using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRestaurante.Vistas.Bodega
{
    public partial class VistaGestiónReceta : Form
    {
        public VistaGestiónReceta(string usuario)
        {
            InitializeComponent();
            lblNameUser.Text = usuario;
        }

        private void VistaGestiónReceta_Load(object sender, EventArgs e)
        {
            panelData.Hide();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            VistaBodega homeAdm = new VistaBodega(lblNameUser.Text);
            homeAdm.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panelData.Show();
        }

        private void btnCancelarEdit_Click(object sender, EventArgs e)
        {
            panelData.Hide();
        }
    }
}
