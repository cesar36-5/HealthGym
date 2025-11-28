using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HealthGym
{
    public partial class EvaluaciónNutricional : Form
    {
        int IdMiembroSeleccionado = 0;

        public EvaluaciónNutricional()
        {
            InitializeComponent();
            CargarNivelActividad();
            CargarFrecuencia();

            txtPeso.TextChanged += (s, e) => { CalcularIMC(); MostrarObjetivoCalorico(); };
            txtEstatura.TextChanged += (s, e) => { CalcularIMC(); MostrarObjetivoCalorico(); };
            cboNivel.SelectedIndexChanged += (s, e) => MostrarObjetivoCalorico();
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

        private void CalcularIMC()
        {
            if (!decimal.TryParse(txtEstatura.Text, out decimal estatura) ||
                !decimal.TryParse(txtPeso.Text, out decimal peso) ||
                estatura <= 0 || peso <= 0)
            {
                lbCalimc.Text = "-";
                labelCalNot.Text = "-";
                return;
            }

            decimal estMetros = estatura > 3 ? estatura / 100m : estatura;
            decimal imc = peso / (estMetros * estMetros);
            decimal imcFinal = Math.Round(imc, 2);

            lbCalimc.Text = imcFinal.ToString("0.00");
            CalcularNota();
        }

        private void CalcularNota()
        {
            if (!float.TryParse(lbCalimc.Text, out float imc))
            {
                labelCalNot.Text = "-";
                return;
            }

            string nota;
            if (imc < 18.5f)
                nota = "B";
            else if (imc <= 24.9f)
                nota = "A";
            else if (imc <= 29.9f)
                nota = "B";
            else
                nota = "C";

            labelCalNot.Text = nota;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDNI.Text.Trim();
                var datos = LogEvaluacionNutricional.Instancia.BuscarPorDNI(dni);

                if (datos == null)
                {
                    MessageBox.Show("No se encontró miembro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                IdMiembroSeleccionado = datos.IdMiembro;
                lbNom.Text = datos.Nombres;
                labelapellidos.Text = datos.Apellidos;
                lbSex.Text = datos.Sexo;
                dtpFechaNacimiento.Value = datos.FechaNacimiento;

                int edad = DateTime.Now.Year - datos.FechaNacimiento.Year;
                if (DateTime.Now.DayOfYear < datos.FechaNacimiento.DayOfYear)
                    edad--;

                lbEda.Text = edad.ToString();

                MostrarObjetivoCalorico();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar miembro:\n" + ex.Message);
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

        private int CalcularObjetivoCalorico()
        {
            if (!decimal.TryParse(txtPeso.Text, out decimal peso) ||
                !decimal.TryParse(txtEstatura.Text, out decimal estatura) ||
                !int.TryParse(lbEda.Text, out int edad) ||
                peso <= 0 || estatura <= 0)
            {
                return 0;
            }

            decimal tallaCm = estatura > 3 ? estatura : estatura * 100;

            string sexo = lbSex.Text;
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

        private void MostrarObjetivoCalorico()
        {
            int objetivo = CalcularObjetivoCalorico();
            labelCalObje.Text = objetivo > 0 ? objetivo.ToString() : "-";
        }
        //Registrar evaluaciónn
        private void btnRegistar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (IdMiembroSeleccionado == 0)
                {
                    MessageBox.Show("Debe seleccionar un miembro primero.");
                    return;
                }

                if (LogEvaluacionNutricional.Instancia.EvaluacionYaRegistrada(IdMiembroSeleccionado))
                {
                    MessageBox.Show("Este miembro ya tiene una evaluación registrada.");
                    return;
                }

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

                if (lbCalimc.Text == "-" || labelCalNot.Text == "-")
                {
                    MessageBox.Show("Debe calcular IMC y Nota.");
                    return;
                }

                decimal brazo = decimal.Parse(txtBrazo.Text);
                decimal pierna = decimal.Parse(txtPierna.Text);
                decimal gluteo = decimal.Parse(txtGluteo.Text);
                decimal cintura = decimal.Parse(txtCintura.Text);
                decimal pecho = decimal.Parse(txtPecho.Text);
                EntEvaluacionNutricional eva = new EntEvaluacionNutricional()
                {
                    IdMiembro = IdMiembroSeleccionado,
                    Peso = decimal.Parse(txtPeso.Text),
                    Estatura = decimal.Parse(txtEstatura.Text),
                    IMC = float.Parse(lbCalimc.Text),
                    Brazo = brazo,
                    Pierna = pierna,
                    Gluteo = gluteo,
                    Cintura = cintura,
                    Pecho = pecho,
                    Nota = labelCalNot.Text,
                    NivelActividad = NivelActividadChar(),
                    FrecuenciaActividad = cboFrecuencia.SelectedValue is int freq ? freq : 0,
                    ObjetivoCalorico = CalcularObjetivoCalorico()
                };

                bool ok = LogEvaluacionNutricional.Instancia.RegistrarEvaluacion(eva);

                if (ok)
                    MessageBox.Show("Evaluación registrada correctamente.");
                else
                    MessageBox.Show("No se pudo registrar.");

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al registrar: " + ex.Message);
            }
        }
        //Limpiar campos
        private void LimpiarCampos()
        {
            IdMiembroSeleccionado = 0;
            txtDNI.Clear();
            lbNom.Text = "-";
            labelapellidos.Text = "-";
            lbSex.Text = "-";
            dtpFechaNacimiento.Value = DateTime.Now;
            lbEda.Text = "-";
            txtPeso.Clear();
            txtEstatura.Clear();
            lbCalimc.Text = "-";
            labelCalNot.Text = "-";
            labelCalObje.Text = "-";
            txtBrazo.Clear();
            txtPierna.Clear();
            txtGluteo.Clear();
            txtCintura.Clear();
            txtPecho.Clear();
            cboNivel.SelectedIndex = 0;
            cboFrecuencia.SelectedIndex = 0;
        }
    }
}
