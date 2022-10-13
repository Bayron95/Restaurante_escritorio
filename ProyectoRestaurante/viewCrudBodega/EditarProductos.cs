using ProyectoRestaurante.DAO;
using ProyectoRestaurante.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoRestaurante.Vistas.viewCrudBodega
{
    public partial class EditarProductos : Form
    {

        ProductosDao prdDao = new ProductosDao();

        public EditarProductos()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreProd.Text != "")
            {
                if (txtCodProd.Text != "")
                {
                    if (txtPrecio.Text != "")
                    {
                        if (txtStock.Text != "")
                        {
                            prdDao.UpdateProductos(Convert.ToInt32(lblId.Text),
                                                     txtNombreProd.Text,
                                                     txtCodProd.Text,
                                                     int.Parse(txtPrecio.Text),
                                                     int.Parse(txtStock.Text));
                        }else
                        {
                            MessageBox.Show("Ingrese el stock del producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el precio del producto");
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese un código de producto");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de producto");
            }

            MessageBox.Show("Producto editado con exito!");
            this.Close();
            insertar();
        }
    }
}
