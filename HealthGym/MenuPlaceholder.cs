using HealthGym.CORE;
using HealthGym.Mantenedores;

namespace HealthGym
{
    public partial class MenuPlaceholder : Form
    {
        public MenuPlaceholder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mantenedores.MantenedorAlimento m = new Mantenedores.MantenedorAlimento();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MantenedorEnfermedad m = new MantenedorEnfermedad();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Objetivos m = new Objetivos();
            m.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Alergias m = new Alergias();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EvaluacionNutri m = new EvaluacionNutri();
            m.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Monitoreo m = new Monitoreo();
            m.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PlanNutricional m = new PlanNutricional();
            m.Show();
        }
    }
}
