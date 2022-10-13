using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoRestaurante.DAO;
using System.Windows.Forms;
using ProyectoRestaurante.C_Negocio;

namespace ProyectoRestaurante.Vistas.viewCrudBodega
{
    public partial class AgregarProductos : Form
    {
        CN_Productos cn_prd = new CN_Productos();

        public AgregarProductos()
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
            UpdateEventHandler.Invoke(this,args);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AgregarNuevo();
            this.Close();
            insertar();
        }


        public void AgregarNuevo()
        {
            
            if (txtProducto.Text != "")
            {
                if (txtCodProd.Text != "")
                {
                    if (textPrecio.Text != "")
                    {
                        if (textStock.Text != "")
                        {
                            cn_prd.AgregarProductos(txtProducto.Text, txtCodProd.Text,int.Parse(textPrecio.Text),int.Parse(textStock.Text));

                        }
                        else
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
                    MessageBox.Show("Ingrese el código del producto");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre del producto");
            }

            MessageBox.Show("Producto creado exitosamente!");

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
