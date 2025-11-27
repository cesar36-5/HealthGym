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
    public partial class Platillo : Form
    {
        public Platillo()
        {
            InitializeComponent();
            gboPlatillo.Enabled = false;
        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtCalorias.Text = "";
            txtCarbohidratos.Text = "";
            txtGrasas.Text = "";
            txtProteinas.Text = "";
        }
    }
}
