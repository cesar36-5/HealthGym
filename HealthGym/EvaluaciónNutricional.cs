using CapaEntidad;
using CapaLogica;
using System;
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
            txtPeso.TextChanged += (s, e) => CalcularIMC();
            txtEstatura.TextChanged += (s, e) => CalcularIMC();
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
                nota = "B";  // Bajo peso
            else if (imc <= 24.9f)
                nota = "A";  // Normal
            else if (imc <= 29.9f)
                nota = "B";  // Sobrepeso
            else
                nota = "C";  // Obesidad

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
                case 0: return '0'; // Sedentario
                case 1: return '1'; // Bajo
                case 2: return '2'; // Medio
                case 3: return '3'; // Intenso
                default: return '0';
            }
        }


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
                    MessageBox.Show("Este miembro ya tiene una evaluación registrada. No se puede registrar otra.");
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
                    MessageBox.Show("Debe completar todos los campos antes de registrar.",
                                    "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lbCalimc.Text == "-" || labelCalNot.Text == "-")
                {
                    MessageBox.Show("Debe ingresar peso y estatura para calcular IMC y Nota.");
                    return;
                }
                if (!checkObjetivo.Checked)
                {
                    MessageBox.Show("Debe marcar el objetivo antes de registrar la evaluación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal brazo = string.IsNullOrWhiteSpace(txtBrazo.Text) ? 0 : decimal.Parse(txtBrazo.Text);
                decimal pierna = string.IsNullOrWhiteSpace(txtPierna.Text) ? 0 : decimal.Parse(txtPierna.Text);
                decimal gluteo = string.IsNullOrWhiteSpace(txtGluteo.Text) ? 0 : decimal.Parse(txtGluteo.Text);
                decimal cintura = string.IsNullOrWhiteSpace(txtCintura.Text) ? 0 : decimal.Parse(txtCintura.Text);
                decimal pecho = string.IsNullOrWhiteSpace(txtPecho.Text) ? 0 : decimal.Parse(txtPecho.Text);

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
                    FrecuenciaActividad = cboFrecuencia.SelectedValue is int frecuencia ? frecuencia : 0,
                    ObjetivoCalorico = checkObjetivo.Checked ? 1 : 0
                };

                bool ok = LogEvaluacionNutricional.Instancia.RegistrarEvaluacion(eva);

                if (ok)
                    MessageBox.Show("Evaluación registrada correctamente.");
                else
                    MessageBox.Show("Evaluación no registrada.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al registrar: " + ex.Message);
            }

        }
        private void LimpiarCampos()
        {
            IdMiembroSeleccionado = 0;
            txtDNI.Clear();
            lbNom.Text = "-";
            lbSex.Text = "-";
            dtpFechaNacimiento.Value = DateTime.Now;
            lbEda.Text = "-";
            txtPeso.Clear();
            txtEstatura.Clear();
            lbCalimc.Text = "-";
            labelCalNot.Text = "-";
            txtBrazo.Clear();
            txtPierna.Clear();
            txtGluteo.Clear();
            txtCintura.Clear();
            txtPecho.Clear();
            cboNivel.SelectedIndex = 0;
            cboFrecuencia.SelectedIndex = 0;
            checkObjetivo.Checked = false;
        }
    }
}

