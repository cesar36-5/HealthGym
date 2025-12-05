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
    public partial class Bitacora : Form
    {
        EntMiembro miembro = new EntMiembro();
        decimal brazo = 0;
        decimal pierna = 0;
        decimal gluteo = 0;
        decimal cintura = 0;
        decimal pecho = 0;
        public Bitacora()
        {
            InitializeComponent();
            CargarFrecuencia();
            CargarNivelActividad();
            miembro.Id = -1;
            lbCalimc.Text = "-";
            groupBox2.Enabled = false;
        }
        private int CalcularObjetivoCalorico()
        {
            if (!decimal.TryParse(txtPeso.Text, out decimal peso) ||
                !decimal.TryParse(txtEstatura.Text, out decimal estatura) ||
                peso <= 0 || estatura <= 0)
            {
                return 0;
            }

            int edad = miembro.Edad; // <-- aquí usamos directamente el miembro

            decimal tallaCm = estatura > 3 ? estatura : estatura * 100;

            string sexo = Lbl_Sexo.Text.Replace("Sexo: ", "").Trim();
            double tmb;

            if (sexo == "M")
            {
                tmb = (10 * (double)peso) + (6.25 * (double)tallaCm) - (5 * edad) + 5;
            }
            else
            {
                tmb = (10 * (double)peso) + (6.25 * (double)tallaCm) - (5 * edad) - 161;
            }

            double naf = 1.2;
            switch (cboNivel.SelectedIndex)
            {
                case 1: naf = 1.375; break;
                case 2: naf = 1.55; break;
                case 3: naf = 1.725; break;
            }

            return (int)Math.Round(tmb * naf);
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

                miembro = LogMiembro.instancia.BuscarMiembro(Tbox_DNI.Text);

                if (miembro == null || miembro.Id == -1)
                {
                    throw new Exception("No se encontro un miembro");
                }

                Lbl_Edad.Text = "Edad: " + miembro.Edad;
                Lbl_Nombre.Text = "Nombre: " + miembro.Nombre;
                Lbl_Sexo.Text = "Sexo: " + miembro.Sexo;

                EntMonitoreo mon = LogMonitoreo.Instancia.BuscarMonitoreoReciente(miembro.Id);

                if (mon != null)
                { }
                else
                {
                    EntEvaluacionNutricional ev = LogEvaluacionNutricional.Instancia.BuscarEvaluacion(Tbox_DNI.Text);
                    if (ev != null)
                    {

                    }
                    else
                    {
                        throw new Exception("No se encontro una evaluacion asociada al miembro");
                    }
                }

                groupBox2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalcularIMC()
        {
            if (!decimal.TryParse(txtEstatura.Text, out decimal estatura) ||
                !decimal.TryParse(txtPeso.Text, out decimal peso) ||
                estatura <= 0 || peso <= 0)
            {
                lbCalimc.Text = "-";
                //lblImc.Text = "-";
                return;
            }

            decimal estMetros = estatura > 3 ? estatura / 100m : estatura;
            decimal imc = peso / (estMetros * estMetros);
            decimal imcFinal = Math.Round(imc, 2);

            lbCalimc.Text = imcFinal.ToString("0.00");
        }

        private void CargarNivelActividad()
        {
            var niveles = new List<object>()
            {
                new { Valor = "0", Nombre = "Sedentario" },
                new { Valor = "1", Nombre = "Bajo" },
                new { Valor = "2", Nombre = "Medio" },
                new { Valor = "3", Nombre = "Intenso" }
            };

            cboNivel.DataSource = niveles;
            cboNivel.DisplayMember = "Nombre";
            cboNivel.ValueMember = "Valor";
        }

        private void CargarFrecuencia()
        {
            var frecuencias = new List<object>();

            for (int i = 0; i <= 7; i++)
            {
                frecuencias.Add(new { Valor = i, Nombre = i + " días/semana" });
            }

            cboFrecuencia.DataSource = frecuencias;
            cboFrecuencia.DisplayMember = "Nombre";
            cboFrecuencia.ValueMember = "Valor";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CalcularIMC();
                labelCalObje.Text = CalcularObjetivoCalorico().ToString();

                List<string> notas = new List<string>();

                decimal br = decimal.Parse(txtBrazo.Text);
                string notaBr = LogMonitoreo.Instancia.CalcularCalificacion(miembro.Id, 1, br);
                notas.Add(notaBr);

                decimal pi = decimal.Parse(txtPierna.Text);
                string notaPi = LogMonitoreo.Instancia.CalcularCalificacion(miembro.Id, 2, pi);
                notas.Add(notaPi);

                decimal g = decimal.Parse(txtGluteo.Text);
                string notaG = LogMonitoreo.Instancia.CalcularCalificacion(miembro.Id, 3, g);
                notas.Add(notaG);

                decimal c = decimal.Parse(txtCintura.Text);
                string notaC = LogMonitoreo.Instancia.CalcularCalificacion(miembro.Id, 4, c);
                notas.Add(notaC);

                decimal pe = decimal.Parse(txtPecho.Text);
                string notaPe = LogMonitoreo.Instancia.CalcularCalificacion(miembro.Id, 5, pe);
                notas.Add(notaPe);

                if (notas.All(n => n == "X"))
                {
                    MessageBox.Show("Sin objetivos");
                    return;
                }

                var notasValidas = notas.Where(n => n == "A" || n == "B" || n == "C").ToList();

                int total = notasValidas.Count;
                int countA = notasValidas.Count(n => n == "A");

                decimal porcentajeA = (decimal)countA / total * 100;

                string notaFinal;
                if (porcentajeA == 100)
                    notaFinal = "A";
                else if (porcentajeA >= 75)
                    notaFinal = "B";
                else
                    notaFinal = "C";

                label1.Text = notaFinal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtPeso.Text) ||
                    string.IsNullOrWhiteSpace(txtEstatura.Text) ||
                    string.IsNullOrWhiteSpace(txtBrazo.Text) ||
                    string.IsNullOrWhiteSpace(txtPierna.Text) ||
                    string.IsNullOrWhiteSpace(txtGluteo.Text) ||
                    string.IsNullOrWhiteSpace(txtCintura.Text) ||
                    string.IsNullOrWhiteSpace(txtPecho.Text))
                {
                    MessageBox.Show("Debe completar todos los campos.");
                    return;
                }

                if (lbCalimc.Text == "-" || label1.Text == "-")
                {
                    MessageBox.Show("Debe calcular IMC y Nota.");
                    return;
                }

                decimal brazo = decimal.Parse(txtBrazo.Text);
                decimal pierna = decimal.Parse(txtPierna.Text);
                decimal gluteo = decimal.Parse(txtGluteo.Text);
                decimal cintura = decimal.Parse(txtCintura.Text);
                decimal pecho = decimal.Parse(txtPecho.Text);
                EntMonitoreo eva = new EntMonitoreo()
                {
                    Peso = decimal.Parse(txtPeso.Text),
                    Estatura = decimal.Parse(txtEstatura.Text),
                    IMC = float.Parse(lbCalimc.Text),
                    Brazo = brazo,
                    Pierna = pierna,
                    Gluteo = gluteo,
                    Cintura = cintura,
                    Pecho = pecho,
                    Nota = label1.Text,
                    NivelActividad = NivelActividadChar().ToString(),
                    FrecuenciaActividad = cboFrecuencia.SelectedValue is int freq ? freq : 0,
                    ObjetivoCalorico = CalcularObjetivoCalorico()
                };

                bool ok = LogMonitoreo.Instancia.InsertarMonitoreo(miembro.Id, eva);

                if (!ok)
                    MessageBox.Show("Bitacora registrada correctamente.");
                else
                    MessageBox.Show("No se pudo registrar.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al registrar: " + ex.Message);
            }
        }
        private char NivelActividadChar()
        {
            switch (cboNivel.SelectedIndex)
            {
                case 0: return '0';
                case 1: return '1';
                case 2: return '2';
                case 3: return '3';
                default: return '0';
            }
        }
    }
}
