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

                List<EntMonitoreo> monitoreos = LogMonitoreo.Instancia.BuscarMonitoreos(Tbox_DNI.Text);
                EntEvaluacionNutricional evaluacion = LogEvaluacionNutricional.Instancia.BuscarEvXDNI(Tbox_DNI.Text);

                DGV.Rows.Clear();

                foreach (var m in monitoreos)
                {
                    DGV.Rows.Add(
                        m.Fecha,
                        m.Estatura,
                        m.Peso,
                        m.IMC,
                        m.Brazo,
                        m.Pierna,
                        m.Gluteo,
                        m.Cintura,
                        m.Nota,
                        m.ObjetivoCalorico,
                        m.NivelActividad,
                        m.FrecuenciaActividad
                    );
                }

                if (evaluacion != null)
                {
                    DGV.Rows.Add(
                        evaluacion.Fecha.ToString(),
                        evaluacion.Estatura,
                        evaluacion.Peso,
                        evaluacion.IMC,
                        evaluacion.Brazo,
                        evaluacion.Pierna,
                        evaluacion.Gluteo,
                        evaluacion.Cintura,
                        evaluacion.Nota,
                        evaluacion.ObjetivoCalorico,
                        ObtenerNombreNivelActividad(evaluacion.NivelActividad),
                        ObtenerNombreFrecuencia(evaluacion.FrecuenciaActividad)
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static string ObtenerNombreNivelActividad(char valor)
        {
            switch (valor)
            {
                case '0': return "Sedentario";
                case '1': return "Bajo";
                case '2': return "Medio";
                case '3': return "Intenso";
                default: return "Desconocido";
            }
        }
        public static string ObtenerNombreNivelActividad(string valor)
        {
            switch (valor)
            {
                case "0": return "Sedentario";
                case "1": return "Bajo";
                case "2": return "Medio";
                case "3": return "Intenso";
                default: return "Desconocido";
            }
        }
        public static string ObtenerNombreFrecuencia(int valor)
        {
            return $"{valor} días/semana";
        }

        private void ConsultarAvance_Load(object sender, EventArgs e)
        {
            DGV.AutoGenerateColumns = false;
            DGV.Columns.Clear();

            DGV.Columns.Add("Fecha", "Fecha");
            DGV.Columns.Add("Estatura", "Estatura");
            DGV.Columns.Add("Peso", "Peso");
            DGV.Columns.Add("IMC", "IMC");
            DGV.Columns.Add("Brazo", "Brazo");
            DGV.Columns.Add("Pierna", "Pierna");
            DGV.Columns.Add("Gluteo", "Glúteo");
            DGV.Columns.Add("Cintura", "Cintura");
            DGV.Columns.Add("Nota", "Nota");
            DGV.Columns.Add("ObjetivoCalorico", "Objetivo Calórico");
            DGV.Columns.Add("NivelActividad", "Nivel Actividad");
            DGV.Columns.Add("FrecuenciaActividad", "Frecuencia Actividad");

        }
    }
}
