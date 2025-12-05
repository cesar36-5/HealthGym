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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MantenedorAlergia m = new MantenedorAlergia();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Platillo p = new Platillo();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MantenedorEnfermedad m = new MantenedorEnfermedad();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EvaluaciónNutricional m = new EvaluaciónNutricional();
            m.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PlanNutricional m = new PlanNutricional();
            m.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Consultas.ConsultarPlanes m = new Consultas.ConsultarPlanes();
            m.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitacora b = new Bitacora();
            b.Show();
        }
    }
}
