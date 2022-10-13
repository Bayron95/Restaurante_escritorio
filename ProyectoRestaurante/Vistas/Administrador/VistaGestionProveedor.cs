using ProyectoRestaurante.DAO;
using ProyectoRestaurante.DTO;
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
    public partial class VistaGestionProveedor : Form
    {
        public VistaGestionProveedor()
        {
            InitializeComponent();
            //lblNameUser.Text
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VistaHomeAdministrador homeAdm = new VistaHomeAdministrador();
            homeAdm.Show();
            this.Close();
        }

        private void ActualizarGridAdd(object sender, AgregarProveedor.UpdateEventArgs args)
        {
            ProveedoresDao pvdrs = new ProveedoresDao();
            dgvProveedores.DataSource = pvdrs.VerProveedores();
        }

        private void ActualizarGridUpdate(object sender, EditarProveedor.UpdateEventArgs args)
        {
            ProveedoresDao pvdrs = new ProveedoresDao();
            dgvProveedores.DataSource = pvdrs.VerProveedores();
        }

        private void ActualizarGridDelete(object sender, EliminarProveedor.UpdateEventArgs args)
        {
            ProveedoresDao pvdrs = new ProveedoresDao();
            dgvProveedores.DataSource = pvdrs.VerProveedores();
        }
        private void MostrarProveedores()
        {
            ProveedoresDao pvdrs = new ProveedoresDao();
            dgvProveedores.DataSource = pvdrs.VerProveedores();
        }

        private void VistaGestionProveedor_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }
    }
}
