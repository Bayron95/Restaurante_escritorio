﻿using System;
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
    public partial class VistaCocina : Form
    {
        public VistaCocina(string usuario)
        {
            InitializeComponent();
            lblNameUser.Text = usuario;
        }

    }
}
