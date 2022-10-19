using ProyectoRestaurante.DAO;
using ProyectoRestaurante.Vistas.viewCrud;
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
    public partial class VistaGestionPlatos : Form
    {

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        C_Negocio.CN_Platos cN_Platos = new C_Negocio.CN_Platos();
        public VistaGestionPlatos(string usuario)
        {
            InitializeComponent();
            lblNameUser.Text = usuario;

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

        private void ActualizarGridAdd(object sender, UpdateEventArgs args)
        {
            PlatosDao plato = new PlatosDao();
            dgvPlatos.DataSource = plato.VerPlatos();
        }

        private void ActualizarGridDelete(object sender, UpdateEventArgs args)
        {
            PlatosDao plato = new PlatosDao();
            dgvPlatos.DataSource = plato.VerPlatos();
        }

        private void ActualizarGridUpdate(object sender, UpdateEventArgs args)
        {
            PlatosDao plato = new PlatosDao();
            dgvPlatos.DataSource = plato.VerPlatos();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            VistaHomeAdministrador homeAdm = new VistaHomeAdministrador(lblNameUser.Text);
            homeAdm.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            AgregarNuevo();
            UpdateEventHandler += ActualizarGridAdd;
            insertar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lblID.Show();
            if (dgvPlatos.SelectedRows.Count > 0)
            {
                lblID.Text = dgvPlatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgvPlatos.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dgvPlatos.CurrentRow.Cells[2].Value.ToString();
                rtxtDescripcion.Text = dgvPlatos.CurrentRow.Cells[3].Value.ToString();
                if (dgvPlatos.CurrentRow.Cells[4].Value.ToString() == "1")
                {
                    chkBoxEstadoDisp.Checked = true;
                }
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

            if (dgvPlatos.SelectedRows.Count > 0)
            {
                cN_Platos.EliminarPlatos(Convert.ToInt32(dgvPlatos.CurrentRow.Cells[0].Value.ToString()));
                UpdateEventHandler += ActualizarGridDelete;
                insertar();
                MessageBox.Show("Registro eliminado");

            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar");
            }
        }

        private void VistaGestionPlatos_Load(object sender, EventArgs e)
        {
            int i = 0;
            MostrarPlatos();
            btnGuardar.Enabled = false;
            btnCancelarEdit.Enabled = true;
            dgvPlatos.Rows[i].Selected = true;
            
        }

        private void MostrarPlatos()
        {
            PlatosDao platos = new PlatosDao();
            dgvPlatos.DataSource = platos.VerPlatos();
        }

        public void AgregarNuevo()
        {
            if (txtNombre.Text != "")
            {
                if (txtPrecio.Text != "")
                {
                    if (rtxtDescripcion.Text != "")
                    {
                        int estado = 0;
                        if (chkBoxEstadoDisp.Checked == true)
                        {
                            estado = 1;
                        }
                        cN_Platos.AgregarPlatos(txtNombre.Text, Convert.ToInt32(txtPrecio.Text), rtxtDescripcion.Text, estado);
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

            int estado = 0;
            if (chkBoxEstadoDisp.Checked)
            {
                estado = 1;
            }

            cN_Platos.EditarPlatos(Convert.ToInt32(lblID.Text), txtNombre.Text, Convert.ToInt32(txtPrecio.Text), rtxtDescripcion.Text, estado);
            MessageBox.Show("Registro editado con exito!");
            UpdateEventHandler += ActualizarGridUpdate;
            insertar();

            LimpiarControles();
        }

        private void LimpiarControles()
        {
            if (txtNombre.Text != "" && txtPrecio.Text != "" && rtxtDescripcion.Text != "" )
            {
                txtNombre.Clear();
                txtPrecio.Clear();
                rtxtDescripcion.Clear();
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
    }
}
