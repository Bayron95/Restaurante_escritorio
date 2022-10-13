using ProyectoRestaurante.C_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRestaurante.Vistas.viewCrud
{
    public partial class AgregarProveedor : Form
    {
        CN_Proveedores cn_pvdrs = new CN_Proveedores();
        public AgregarProveedor()
        {
            InitializeComponent();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void insertar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }


        public void AgregarNuevo()
        {

            if (txtNombre.Text.Trim() != "")
            {
                if (txtRut.Text.Trim() != "" )
                {
                    if (txtDireccion.Text.Trim() != "")
                    {
                        if (txtTelefono.Text.Trim() != "")
                        {
                            if (txtCorreo.Text.Trim() != "")
                            {
                                //cn_pvdrs.AgregarProveedores();
                                MessageBox.Show("Usuario creado con exito!");
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un correo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese N° de telefono");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una dirección");
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese rut del proveedor");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de proveedor");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AgregarNuevo();
            this.Close();
            insertar();
        }
    }
}
