using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthGym
{
    public partial class PlanNutricional : Form
    {
        public PlanNutricional()
        {
            InitializeComponent();
        }

        private void PlanNutricional_Load(object sender, EventArgs e)
        {
            Gbox.Enabled = false;
        }

        private void Btn_Cargar_Click(object sender, EventArgs e)
        {
            string dni = Tbox_DNI.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(dni))
                    throw new Exception("Debe ingresar un dni");

                if (dni.Length != 8)
                    throw new Exception("El DNI debe ser de 8 digitos");

                int idreceta = LogReceta.instancia.BuscarReceta(dni);

                if (idreceta < 0)
                    throw new Exception("No se encontro una receta compatible");

                MessageBox.Show($"IdReceta: {idreceta}");
                Gbox.Enabled = true;
                CargarReceta(idreceta);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarReceta(int idReceta)
        {
            List<EntDetalleReceta> detalles = LogReceta.instancia.BuscarDetalles(idReceta);
        }
    }
}
