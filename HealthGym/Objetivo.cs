using CapaDatos;
using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthGym
{
    public partial class Objetivo : Form
    {
        public Objetivo()
        {
            InitializeComponent();
            Limpiar();
            gboObjetivo.Enabled = false;
            btnEliminar.Enabled = false;
        }
        public void Limpiar()
        {
            txtDNI.Text = "";
            lblNombre.Text = "";
            cboMusculo.SelectedIndex = -1;
            txtTamano.Text = "";
        }

    }
}
