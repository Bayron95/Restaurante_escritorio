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
using ProyectoRestaurante.Vistas.viewCrudBodega;

namespace ProyectoRestaurante
{
    public partial class VistaGestiónProductos3 : Form
    {
        public VistaGestiónProductos3()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VistaBodega homeBodega = new VistaBodega();
            homeBodega.Show();
            this.Close();
        }
        private void ActualizarGridAgregar(object sender, AgregarProductos.UpdateEventArgs args)
        {
            ProductosDao prd = new ProductosDao();
            dataGridView1.DataSource = prd.VerProductos();
        }
        private void ActualizarGridUpdate(object sender, EditarProductos.UpdateEventArgs args)
        {
            ProductosDao prd = new ProductosDao();
            dataGridView1.DataSource = prd.VerProductos();
        }

        private void ActualizarGridDelete(object sender, EliminarProductos.UpdateEventArgs args)
        {
            ProductosDao prd = new ProductosDao();
            dataGridView1.DataSource = prd.VerProductos();
        }

        private void VistaGestionProductos_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            ProductosDao prd = new ProductosDao();
            dataGridView1.DataSource = prd.VerProductos();
        }
        private void btn_AgregarProd_Click(object sender, EventArgs e)
        {
            AgregarProductos Addprd = new AgregarProductos();
            Addprd.Show();
            Addprd.UpdateEventHandler += ActualizarGridAgregar;
        }

        private void btn_EditarClick(object sender, EventArgs e)
        {
            EditarProductos EditPrd = new EditarProductos();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                EditPrd.lblId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                EditPrd.txtNombreProd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                EditPrd.txtCodProd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                EditPrd.txtPrecio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                EditPrd.txtStock.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                EditPrd.Show();
                EditPrd.UpdateEventHandler += ActualizarGridUpdate;


            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un producto");
            }

        }

        private void btn_EliminarClick(object sender, EventArgs e)
        {
            EliminarProductos DelPrd = new EliminarProductos();

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DelPrd.lblId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                DelPrd.lblNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DelPrd.Show();
                DelPrd.UpdateEventHandler += ActualizarGridDelete;

            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar un usuario");
            }
        }
    }
}
