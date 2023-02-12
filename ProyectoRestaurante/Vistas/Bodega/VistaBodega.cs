using ProyectoRestaurante.DAO;
using ProyectoRestaurante.Vistas.Bodega;
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
        C_Negocio.CN_Productos CN_Productos = new C_Negocio.CN_Productos();
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        
        public VistaBodega(string usuario)
        {
            InitializeComponent();
            lblNameUser.Text = usuario;
        }
        public VistaBodega()
        {
            InitializeComponent();
        }

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void insertar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void ActualizarGridAgregar(object sender, UpdateEventArgs args)
        {
            ProductosDao prd = new ProductosDao();
            dataGridView1.DataSource = prd.VerProductos();
        }
        private void ActualizarGridUpdate(object sender, UpdateEventArgs args)
        {
            ProductosDao prd = new ProductosDao();
            dataGridView1.DataSource = prd.VerProductos();
        }

        private void ActualizarGridDelete(object sender, UpdateEventArgs args)
        {
            ProductosDao prd = new ProductosDao();
            dataGridView1.DataSource = prd.VerProductos();
        }

        private void btn_cerrarSesion_Click(object sender, EventArgs e)
        {
            VistaLogin sesion = new VistaLogin();
            sesion.Show();
            this.Close();
        }

        
        private void VistaBodega_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            int i = 0;
            
            btnGuardar.Enabled = false;
            btnCancelarEdit.Enabled = true;
            dataGridView1.Rows[i].Selected = true;
        }
        private void MostrarProductos()
        {
            ProductosDao prd = new ProductosDao();
            dataGridView1.DataSource = prd.VerProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarNuevo();
            UpdateEventHandler += ActualizarGridAgregar;
            insertar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lblID.Show();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtIVA.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                
                btnGuardar.Enabled = true;
                btnCancelarEdit.Enabled = true;
                btnAgregar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                CN_Productos.EliminarProducto(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                UpdateEventHandler += ActualizarGridDelete;
                insertar();
                MessageBox.Show("Registro eliminado");

            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar");
            }
        }

        public void AgregarNuevo()
        {
            if (txtNombre.Text != "")
            {
                if (txtPrecio.Text != "")
                {
                    if (txtDescripcion.Text != "")
                    {
                        
                        CN_Productos.AgregarProducto(txtNombre.Text,txtCodigo.Text,Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(txtIVA.Text),Convert.ToInt32(txtStock.Text));
                        MessageBox.Show("Plato creado con exito!");
                    }
                    else
                    {
                        MessageBox.Show("Ingrese descripción del plato");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese precio del plato");
                }
            }
            else
            {
                MessageBox.Show("Ingrese nombre del plato");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //int estado = 0;
            //if (chkBoxEstadoDisp.Checked)
            //{
            //    estado = 1;
            //}

            CN_Productos.EditarProducto(Convert.ToInt32(lblID.Text), txtNombre.Text, txtCodigo.Text, Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(txtIVA.Text), Convert.ToInt32(txtStock.Text));
            MessageBox.Show("Registro editado con exito!");
            UpdateEventHandler += ActualizarGridUpdate;
            insertar();

            LimpiarControles();
        }

        private void LimpiarControles()
        {
            if (txtNombre.Text != "" && txtPrecio.Text != "" && txtDescripcion.Text != "")
            {
                txtNombre.Clear();
                txtPrecio.Clear();
                txtDescripcion.Clear();
                //chkBoxEstadoDisp.Checked = false;
                btnGuardar.Enabled = false;
                btnCancelarEdit.Enabled = false;
                btnAgregar.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }

        }

        private void btnCancelarEdit_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btn_recetas_Click(object sender, EventArgs e)
        {
            VistaGestiónReceta vgr = new VistaGestiónReceta(lblNameUser.Text);
            vgr.Show();
            this.Hide();
            
        }
    }
}
