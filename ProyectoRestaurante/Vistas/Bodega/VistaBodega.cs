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
    public partial class VistaBodega : Form
    {
        public VistaBodega(string usuario)
        {
            InitializeComponent();
            lblNameUser.Text = usuario;
        }
        public VistaBodega()
        {
            InitializeComponent();
        }

        private void btn_cerrarSesion_Click(object sender, EventArgs e)
        {
            VistaLogin sesion = new VistaLogin();
            sesion.Show();
            this.Close();
        }

        private void Btn_ProductosClick(object sender, EventArgs e)
        {
            VistaGestiónProductos3 productos = new VistaGestiónProductos3();
            productos.Show();
            this.Hide();
        }
    }
}
