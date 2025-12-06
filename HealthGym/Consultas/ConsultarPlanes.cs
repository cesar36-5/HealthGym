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
    public partial class ConsultarPlanes : Form
    {
        List<EntPlatillo> platillos = new List<EntPlatillo>();
        public ConsultarPlanes()
        {
            InitializeComponent();
            Cbox_Planes.Enabled = false;
            platillos = LogPlatillo.Instancia.ListarPlatillo();
        }

        private void Btn_Cargar_Click(object sender, EventArgs e)
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

                List<EntPlanNutricional> l = LogPlanNuticional.Instancia.ListarPlanesPorDNI(Tbox_DNI.Text);

                if (l == null || l.Count == 0)
                {
                    throw new Exception("No se encontraron planes");
                }



                Cbox_Planes.DataSource = l;
                Cbox_Planes.DisplayMember = "FechaFin";
                Cbox_Planes.ValueMember = "Id";
                Cbox_Planes.Format += (s, e) =>
                {
                    if (e.ListItem is EntPlanNutricional plan && plan.FechaFin.HasValue)
                    {
                        e.Value = plan.FechaFin.Value.ToString("yyyy-MM-dd");
                    }
                };
                Cbox_Planes.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cbox_Planes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(Cbox_Planes.SelectedValue is int idPlan))
                    return;

                List<EntDetallePlan> detalles =
                    LogPlanNuticional.Instancia.ListarPlanDetallePorIdPlan(idPlan);

                CargarPlanEnGrid(detalles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargarPlanEnGrid(List<EntDetallePlan> detalles)
        {
            PrepararGridDetalle();

            foreach (var det in detalles)
            {
                int fila = det.Momento - 1;
                int col = det.Dia;

                var plat = platillos.FirstOrDefault(p => p.IdPlatillo == det.IdPlatillo);
                if (plat != null)
                {
                    DGV.Rows[fila].Cells[col].Value = plat.Nombre;
                }
            }
        }

        private void PrepararGridDetalle()
        {
            DGV.Columns.Clear();
            DGV.Rows.Clear();

            DGV.Columns.Add("col0", "-----");
            DGV.Columns.Add("col1", "Lunes");
            DGV.Columns.Add("col2", "Martes");
            DGV.Columns.Add("col3", "Miércoles");
            DGV.Columns.Add("col4", "Jueves");
            DGV.Columns.Add("col5", "Viernes");
            DGV.Columns.Add("col6", "Sábado");
            DGV.Columns.Add("col7", "Domingo");

            DGV.Rows.Add("Desayuno");
            DGV.Rows.Add("Media mañana");
            DGV.Rows.Add("Almuerzo");
            DGV.Rows.Add("Media tarde");
            DGV.Rows.Add("Cena");

            DGV.ReadOnly = true;
            DGV.Columns["col0"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private string ObtenerDia(int d)
        {
            return d switch
            {
                1 => "Lunes",
                2 => "Martes",
                3 => "Miércoles",
                4 => "Jueves",
                5 => "Viernes",
                6 => "Sábado",
                7 => "Domingo",
                _ => "?"
            };
        }

        private string ObtenerMomento(int m)
        {
            return m switch
            {
                1 => "Desayuno",
                2 => "Media mañana",
                3 => "Almuerzo",
                4 => "Media tarde",
                5 => "Cena",
                _ => "?"
            };
        }

    }
}
