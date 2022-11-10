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
using ProyectoRestaurante.Vistas.viewCrud;

namespace ProyectoRestaurante
{
    public partial class VistaGestionMesas : Form
    {
        public VistaGestionMesas(string usuario)
        {
            InitializeComponent();

            lblNameUser.Text = usuario;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VistaHomeAdministrador homeAdm = new VistaHomeAdministrador();
            homeAdm.Show();
            this.Close();
        }

        private void VistaGestionMesas_Load(object sender, EventArgs e)
        {

            PintarMesas();

        }

        public void PintarMesas()
        {
            MesasDao mesaDao = new MesasDao();
            List<MesasDto> lista = mesaDao.VerMesas();
            foreach (var num in lista)
            {
                Button btn = new Button();
                btn.Name = "btnMesa"+ num;
                btn.Size = new Size(120,120);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Text = Convert.ToString(num);
                btn.Font = new Font("Microsoft Sans Serif",14);
                
                flowLayoutPanel1.Controls.Add(btn);
            }
            

            
        }
    }
}
