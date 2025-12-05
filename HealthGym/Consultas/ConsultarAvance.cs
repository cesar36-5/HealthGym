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

namespace HealthGym.Consultas
{
    public partial class ConsultarAvance : Form
    {
        public ConsultarAvance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Tbox_DNI.Text))
                {
                    throw new Exception("Debe ingresar un DNI");
                }
                else if (Tbox_DNI.Text.Length != 8)
                {
                    throw new Exception("El DNI debe ser de 8 digitos");
                }

                EntEvaluacionNutricional l = LogEvaluacionNutricional.Instancia.BuscarPorDNI(Tbox_DNI.Text);

                if (l == null)
                {
                    throw new Exception("No se encontro una evaluacion");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
