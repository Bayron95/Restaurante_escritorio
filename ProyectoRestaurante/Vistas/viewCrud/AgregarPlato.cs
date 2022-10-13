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
    public partial class AgregarPlato : Form
    {
        CN_Platos cnplato = new CN_Platos();
        public AgregarPlato()
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AgregarNuevo();
            this.Close();
            insertar();
        }

        public void AgregarNuevo()
        {

            if (txtNombrePlato.Text != "")
            {
                if (txtPrecio.Text != "")
                {
                    cnplato.AgregarPlatos(txtNombrePlato.Text, Convert.ToInt32(txtPrecio.Text), txtDescripcion.Text);

                }
                else
                {
                    MessageBox.Show("Ingrese un precio");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de plato");
            }

            MessageBox.Show("Plato creado con exito!");

        }
    }
}
