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

        C_Negocio.CN_Proveedores pvdrs = new C_Negocio.CN_Proveedores();
        ProveedoresDto _proveedor = new ProveedoresDto();
        public VistaGestionProveedor(string usuario)
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 1)
            {
                lblID.Text = dgvProveedores.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgvProveedores.CurrentRow.Cells[1].Value.ToString();
                txtRut.Text = dgvProveedores.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = dgvProveedores.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dgvProveedores.CurrentRow.Cells[4].Value.ToString();
                txtCorreo.Text = dgvProveedores.CurrentRow.Cells[5].Value.ToString();
                btnEditar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe selecionar un registro");
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                _proveedor.ID_PROVEEDOR = Convert.ToInt32(dgvProveedores.CurrentRow.Cells[0].Value.ToString());
                pvdrs.EliminarProveedores(_proveedor);
            }
            else
            {
                MessageBox.Show("Debe selecionar un registro");
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (txtNombre.Text != "")
            {
                if (txtRut.Text != "")
                {
                    if (txtDireccion.Text != "")
                    {
                        if (txtTelefono.Text != "")
                        {
                            if (txtCorreo.Text != "")
                            {

                                _proveedor.NOMBRE = txtNombre.Text;
                                _proveedor.RUT = txtRut.Text;
                                _proveedor.DIRECCION = txtDireccion.Text;
                                _proveedor.TELEFONO = Convert.ToInt32(txtTelefono.Text);
                                _proveedor.CORREO = txtCorreo.Text;

                                if (lblID.Text != "")
                                {

                                    flag = pvdrs.EditarProveedores(_proveedor);
                                }
                                else
                                {
                                    flag = pvdrs.AgregarProveedores(_proveedor);
                                }
                                if (flag)
                                {
                                    MessageBox.Show("Registro guardado");
                                    limpiar();
                                }
                            }
                            else { MessageBox.Show("Ingrese correo");}
                        }
                        else { MessageBox.Show("Ingrese telefono"); }
                    }
                    else { MessageBox.Show("Ingrese dirección"); }
                }
                else { MessageBox.Show("Ingrese rut"); }
            }
            else { MessageBox.Show("Ingrese nombre"); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar()
        {
            txtNombre.Text = "";
            txtRut.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            lblID.Text = "";
            btnEditar.Enabled = true;
        }
    }
}
