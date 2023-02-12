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
    public partial class VistaCalcularPedido : Form
    {
        public VistaCalcularPedido()
        {
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            VistaBodega homeAdm = new VistaBodega(lblNameUser.Text);
            homeAdm.Show();
            this.Close();
        }
    }
}
