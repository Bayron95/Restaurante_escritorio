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

        public VistaGestionPlatos()
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

        private void ActualizarGridAdd(object sender, AgregarPlato.UpdateEventArgs args)
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
            VistaHomeAdministrador homeAdm = new VistaHomeAdministrador();
            homeAdm.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPlato AddPlato = new AgregarPlato();
            AddPlato.Show();
            AddPlato.UpdateEventHandler += ActualizarGridAdd;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPlatos.SelectedRows.Count > 0)
            {
                //EditUsr.lblId.Text = dgvPlatos.CurrentRow.Cells[0].Value.ToString();
                //EditUsr.txtUsuario.Text = dgvPlatos.CurrentRow.Cells[1].Value.ToString();
                //EditUsr.txtPassword.Text = dgvPlatos.CurrentRow.Cells[2].Value.ToString();
                //EditUsr.cboTipoUser.Text = dgvPlatos.CurrentRow.Cells[3].Value.ToString();
                //EditUsr.Show();
                UpdateEventHandler += ActualizarGridUpdate;


            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un usuario");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvPlatos.SelectedRows.Count > 0)
            {
                C_Negocio.CN_Platos cN_Platos = new C_Negocio.CN_Platos();
                cN_Platos.EliminarPlatos(Convert.ToInt32(dgvPlatos.Rows[0].Index));
                UpdateEventHandler += ActualizarGridDelete;

            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un usuario");
            }
        }

        private void VistaGestionPlatos_Load(object sender, EventArgs e)
        {
            MostrarPlatos();
        }

        private void MostrarPlatos()
        {
            PlatosDao platos = new PlatosDao();
            dgvPlatos.DataSource = platos.VerPlatos();
        }

        private void dgvPlatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
