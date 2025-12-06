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

namespace HealthGym.Monitoreo
{
    public partial class Monitoreo : Form
    {
        private CapaEntidad.Miembro? miembroActual;

        public Monitoreo()
        {
            InitializeComponent();
            CargarComboActividad();
            InicializarControlesMonitoreo(false);

            // Asignar eventos de cálculo automático
            txtPeso.TextChanged += new EventHandler(txtPeso_TextChanged);
            txtEstatura.TextChanged += new EventHandler(txtEstatura_TextChanged);
        }

        private void CargarComboActividad()
        {
            cboNivelActividad.Items.Clear();
            cboNivelActividad.Items.Add("Sedentario");
            cboNivelActividad.Items.Add("Bajo");
            cboNivelActividad.Items.Add("Medio");
            cboNivelActividad.Items.Add("Intenso");
            cboNivelActividad.SelectedIndex = 0;

            cboNivelActividad.SelectedIndexChanged += new EventHandler(cboNivelActividad_SelectedIndexChanged);
        }

        private void InicializarControlesMonitoreo(bool enabled)
        {
            txtPeso.Enabled = enabled;
            txtEstatura.Enabled = enabled;
            

            // Medidas
            txtBrazo.Enabled = enabled;
            txtPierna.Enabled = enabled;
            txtGluteo.Enabled = enabled;
            txtCintura.Enabled = enabled;
            txtPecho.Enabled = enabled;

            txtObjetivoCalorico.Enabled = false; 
            cboNivelActividad.Enabled = enabled;

            if (!enabled)
            {
                txtPeso.Text = txtEstatura.Text = txtBrazo.Text = txtPierna.Text = txtGluteo.Text = txtCintura.Text = txtPecho.Text = string.Empty;
                txtObjetivoCalorico.Text = "";
                lblIMC.Text = "IMC Calculado: 0.00";
                lblNota.Text = "Calificación: N/A";
                lblNota.ForeColor = Color.Black;
                lblRecomendacion.Text = "Recomendación: En espera";
                dgvHistorial.DataSource = null;
            }
        }

        private void btnBuscarMiembro_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = "";
            miembroActual = new CN_Miembro().BuscarPorDNI(dni, out mensaje);

            if (miembroActual != null)
            {
                CN_Monitoreo logica = new CN_Monitoreo();
                var historial = logica.Listar(miembroActual.IdMiembro);

                if (historial.Count > 0)
                {
                    InicializarControlesMonitoreo(true);
                    CargarHistorial(historial);
                    MessageBox.Show($"Miembro encontrado: {miembroActual.Nombres}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    
                    bool existeEvaluacion = false; 
                    if (existeEvaluacion)
                    {
                        InicializarControlesMonitoreo(true);
                    }
                    else
                    {
                        InicializarControlesMonitoreo(false);
                        MessageBox.Show("No hay evaluación nutricional previa. Se requiere una evaluación inicial.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Miembro no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // EVENTOS PARA CÁLCULO AUTOMÁTICO
        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            CalcularMetricas();
        }

        private void txtEstatura_TextChanged(object sender, EventArgs e)
        {
            CalcularMetricas();
        }

        private void cboNivelActividad_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CalcularMetricas();
        }

        
        private void CalcularMetricas()
        {
            
            if (decimal.TryParse(txtPeso.Text, out decimal peso) && peso > 0 &&
                decimal.TryParse(txtEstatura.Text, out decimal estatura) && estatura > 0)
            {
               
                //  CÁLCULO DEL IMC
             
                double p = (double)peso;
                double es = (double)estatura;
                double imc = Math.Round(p / (es * es), 2);

                lblIMC.Text = "IMC Calculado: " + imc.ToString();

               
                // CALIFICACIÓN 
                string nota = "";
                Color colorNota = Color.Black;
                string recomendacion = "";

                if (imc >= 18.5 && imc <= 24.9)
                {
                    nota = "A"; colorNota = Color.Green;
                    recomendacion = "Excelente. Mantener rutina actual.";
                }
                else if (imc >= 25 && imc <= 29.9)
                {
                    nota = "B"; colorNota = Color.Orange;
                    recomendacion = "Aumentar cardio y revisar ingesta.";
                }
                else
                {
                    nota = "C"; colorNota = Color.Red;
                    recomendacion = "Requiere plan de déficit calórico.";
                }

                lblNota.Text = $"Calificación: {nota}";
                lblNota.ForeColor = colorNota;
                lblRecomendacion.Text = "Recomendación: " + recomendacion;

              
                if (miembroActual != null)
                {
                    // Calcular Edad
                    int edad = DateTime.Now.Year - miembroActual.FechaNacimiento.Year;
                    if (DateTime.Now.DayOfYear < miembroActual.FechaNacimiento.DayOfYear) edad--;

                    double alturaCm = es * 100;
                    double tmb = (10 * p) + (6.25 * alturaCm) - (5 * edad);

                    // Ajuste por Sexo
                    if (miembroActual.Sexo == "M" || miembroActual.Sexo == "H") tmb += 5;
                    else tmb -= 161;

                    // Ajuste por Actividad
                    double factorActividad = 1.2;
                    string seleccion = cboNivelActividad.Text;
                    if (seleccion == "Bajo") factorActividad = 1.375;
                    else if (seleccion == "Medio") factorActividad = 1.55;
                    else if (seleccion == "Intenso") factorActividad = 1.725;

                    int caloriasDiarias = (int)(tmb * factorActividad);
                    txtObjetivoCalorico.Text = caloriasDiarias.ToString();
                }
            }
            else
            {
                // Si borran los números, reseteamos labels
                lblIMC.Text = "IMC Calculado: 0.00";
                lblNota.Text = "Calificación: N/A";
                lblNota.ForeColor = Color.Black;
                lblRecomendacion.Text = "Recomendación: En espera";
                txtObjetivoCalorico.Text = "";
            }
        }

        private void CargarHistorial(List<CapaEntidad.Monitoreo> historial)
        {
            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = historial;
            if (dgvHistorial.Columns.Contains("oMiembro")) dgvHistorial.Columns["oMiembro"].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (miembroActual == null) { MessageBox.Show("Busque un miembro primero.", "Advertencia"); return; }

            if (string.IsNullOrEmpty(txtPeso.Text) || string.IsNullOrEmpty(txtEstatura.Text))
            {
                MessageBox.Show("Faltan datos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Convertir Nivel Actividad a código BD
                string seleccion = cboNivelActividad.Text;
                string charNivel = "M";
                if (seleccion == "Sedentario" || seleccion == "Bajo") charNivel = "B";
                else if (seleccion == "Intenso") charNivel = "A";

                CapaEntidad.Monitoreo obj = new CapaEntidad.Monitoreo()
                {
                    oMiembro = miembroActual,
                    Peso = decimal.Parse(txtPeso.Text),
                    Estatura = decimal.Parse(txtEstatura.Text),
                    Brazo = decimal.TryParse(txtBrazo.Text, out decimal b) ? b : 0,
                    Pierna = decimal.TryParse(txtPierna.Text, out decimal p) ? p : 0,
                    Gluteo = decimal.TryParse(txtGluteo.Text, out decimal g) ? g : 0,
                    Cintura = decimal.TryParse(txtCintura.Text, out decimal c) ? c : 0,
                    Pecho = decimal.TryParse(txtPecho.Text, out decimal pe) ? pe : 0,
                    ObjetivoCalorico = int.TryParse(txtObjetivoCalorico.Text, out int cal) ? cal : 0,

                    
                    Nota = lblNota.Text.Replace("Calificación: ", ""),
                    NivelActividad = charNivel,
                    FrecuenciaActividad = 3
                };

                string mensaje = "";
                CN_Monitoreo logica = new CN_Monitoreo();
                int id = logica.Registrar(obj, out mensaje);

                if (id > 0)
                {
                    MessageBox.Show("Monitoreo guardado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarHistorial(logica.Listar(miembroActual.IdMiembro));
                }
                else
                {
                    MessageBox.Show("Error al guardar: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
