using ProyectoRestaurante.DAO;
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
    public partial class VistaCocina : Form
    {
        public VistaCocina(string usuario)
        {
            InitializeComponent();
            lblNameUser.Text = usuario;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            VistaLogin sesion = new VistaLogin();
            sesion.Show();
            this.Close();
        }

        private void VistaCocina_Load(object sender, EventArgs e)
        {
            MostrarPedidos();
            this.btnCancelar.Hide();
            this.btnEnviarPedido.Hide();

            
           
        }

        private void MostrarPedidos()
        {
            PedidosDao pedido = new PedidosDao();
            dataGridView1.DataSource = pedido.VerPedidos();
            
        }

        private void btnEnviarPedido_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblNroMesa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblHora.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblDetalle.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            btnCancelar.Show();
            btnEnviarPedido.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEnviarPedido.Hide();
            btnCancelar.Hide();
        }
    }
}
