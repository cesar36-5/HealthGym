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
            InicializarControlesMonitoreo(false);

        }
        private void InicializarControlesMonitoreo(bool enabled)
        {
            txtPeso.Enabled = enabled;
            txtEstatura.Enabled = enabled;
            txtBrazo.Enabled = enabled;
            txtPierna.Enabled = enabled;
            txtGluteo.Enabled = enabled;
            txtCintura.Enabled = enabled;
            txtPecho.Enabled = enabled;
            txtObjetivoCalorico.Enabled = enabled;
            btnBuscar.Enabled = enabled;

            txtPeso.Text = txtEstatura.Text = txtBrazo.Text = txtPierna.Text = txtGluteo.Text = txtCintura.Text = txtPecho.Text = string.Empty;
            txtObjetivoCalorico.Text = "0";
            lblIMC.Text = "IMC Calculado: 0.00";
            lblNota.Text = "Calificación: N/A";
            lblRecomendacion.Text = "Recomendación: En espera";
            dgvHistorial.DataSource = null;
        }
        private void btnBuscarMiembro_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string mensajeMiembro = string.Empty;
            miembroActual = new CN_Miembro().BuscarPorDNI(dni, out mensajeMiembro);

            if (miembroActual != null)
            {
                InicializarControlesMonitoreo(true);

                CargarHistorial(miembroActual.IdMiembro);

                MessageBox.Show("Miembro encontrado. Ahora puede ingresar los datos de monitoreo.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InicializarControlesMonitoreo(false);
                MessageBox.Show("Miembro no encontrado. Por favor, verifique el DNI ingresado.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
           

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            CalcularIMC();

        }

        private void txtEstatura_TextChanged(object sender, EventArgs e)
        {
            CalcularIMC();
        }
        private void CalcularIMC()
        {
            if (decimal.TryParse(txtPeso.Text, out decimal peso) &&
                decimal.TryParse(txtEstatura.Text, out decimal estatura) && estatura > 0)
            {
                double imc = Math.Round((double)peso / ((double)estatura * (double)estatura), 2);
                lblIMC.Text = "IMC Calculado: " + imc.ToString();
            }
            else
            {
                lblIMC.Text = "IMC Calculado: 0.00";
            }
        }
        private void CargarHistorial(int idMiembro)
        {
            List<CapaEntidad.Monitoreo> historial = new CN_Monitoreo().Listar(idMiembro);
            dgvHistorial.DataSource = historial;

            if (dgvHistorial.Columns.Contains("oMiembro")) dgvHistorial.Columns["oMiembro"].Visible = false;
            if (dgvHistorial.Columns.Contains("IdMonitoreo")) dgvHistorial.Columns["IdMonitoreo"].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (miembroActual == null)
            {
                MessageBox.Show("Debe buscar y seleccionar un Miembro primero.", "Error de Guardado");
                return;
            }

            if (!decimal.TryParse(txtPeso.Text, out decimal peso) || peso <= 0 ||
                !decimal.TryParse(txtEstatura.Text, out decimal estatura) || estatura <= 0 ||
                !int.TryParse(txtObjetivoCalorico.Text, out int objCalorico))
            {
                MessageBox.Show("Ingrese Peso, Estatura y Objetivo Calórico válidos.", "Error de Validación");
                return;
            }

            CapaEntidad.Monitoreo obj = new CapaEntidad.Monitoreo()
            {
                oMiembro = miembroActual,
                Estatura = estatura,
                Peso = peso,
                Brazo = decimal.TryParse(txtBrazo.Text, out decimal brazo) ? brazo : 0,
                Pierna = decimal.TryParse(txtPierna.Text, out decimal pierna) ? pierna : 0,
                Cintura = decimal.TryParse(txtCintura.Text, out decimal cintura) ? cintura : 0,
                Gluteo = decimal.TryParse(txtGluteo.Text, out decimal gluteo) ? gluteo : 0,
                Pecho = decimal.TryParse(txtPecho.Text, out decimal pecho) ? pecho : 0,
                ObjetivoCalorico = objCalorico,
            };

            string mensaje = string.Empty;
            CN_Monitoreo cnMonitoreo = new CN_Monitoreo();

            int idGenerado = cnMonitoreo.Registrar(obj, out mensaje);

            if (idGenerado > 0)
            {
                ResultadoProgreso resultado = cnMonitoreo.EvaluarProgreso(obj);

                lblNota.Text = $"Calificación: {resultado.Nota}";
                lblRecomendacion.Text = $"Recomendación: {resultado.Mensaje}";

                MessageBox.Show($"Monitoreo registrado con éxito.", "Guardado");
                CargarHistorial(miembroActual.IdMiembro);
                InicializarControlesMonitoreo(true);
            }
            else
            {
                MessageBox.Show("Error al registrar: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
