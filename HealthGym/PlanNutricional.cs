using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthGym
{
    public partial class PlanNutricional : Form
    {
        List<EntPlatillo> platillos = LogPlatillo.Instancia.ListarPlatillo();
        List<EntDetalleReceta> detalles = new List<EntDetalleReceta>();

        private int celdaFilaSeleccionada = -1;
        private int celdaColSeleccionada = -1;

        private int totalCal = 0;
        private decimal totalCarb = 0;
        private decimal totalGrasas = 0;
        private decimal totalProteinas = 0;

        public PlanNutricional()
        {
            InitializeComponent();
        }
        private string ObtenerCategoriaPorFila(int fila)
        {
            switch (fila)
            {
                case 0: return "Desayuno";
                case 1: return "Media Mañana";
                case 2: return "Almuerzo";
                case 3: return "Media Tarde";
                case 4: return "Cena";
                default: return "";
            }
        }


        private void PlanNutricional_Load(object sender, EventArgs e)
        {
            Gbox.Enabled = false;
            Cbox_Platillo.DataSource = platillos;
            Cbox_Platillo.DisplayMember = "Nombre";
            Cbox_Platillo.ValueMember = "IdPlatillo";
            PrepararGrid();
        }
        private void ActualizarLabels()
        {
            Lbl_Calorias.Text = "Calorias: " + totalCal.ToString("0.##");
            Lbl_carbos.Text = "Carbohidratos: " + totalCarb.ToString("0.##");
            Lbl_papu.Text = "Grasas: " + totalGrasas.ToString("0.##");
            Lbl_protes.Text = "Proteinas: " + totalProteinas.ToString("0.##");
        }

        private void Btn_Cargar_Click(object sender, EventArgs e)
        {
            string dni = Tbox_DNI.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(dni))
                    throw new Exception("Debe ingresar un dni");

                if (dni.Length != 8)
                    throw new Exception("El DNI debe ser de 8 digitos");

                int idreceta = LogReceta.instancia.BuscarReceta(dni);

                if (idreceta < 0)
                {
                    //throw new Exception("No se encontro una receta compatible");
                    totalCal = 0;
                    totalCarb = 0;
                    totalGrasas = 0;
                    totalProteinas = 0;
                    ActualizarLabels();
                    MessageBox.Show("No se encontró un plan apto");
                }
                else
                {
                    CargarReceta(idreceta);
                }

                Gbox.Enabled = true;
                

                Tbox_DNI.Enabled = false;

                Btn_Cargar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarReceta(int idReceta)
        {
            detalles = LogReceta.instancia.BuscarDetalles(idReceta);
            foreach (var det in detalles)
            {
                var plat = platillos.FirstOrDefault(p => p.IdPlatillo == det.IdPlatillo);
                if (plat == null)
                    continue;

                int fila = det.Momento - 1;
                int columna = det.Dia;

                Dgv_Plan.Rows[fila].Cells[columna].Value = plat.Nombre;
            }
            CalcularMacros(detalles, platillos);
        }

        private void PrepararGrid()
        {
            Dgv_Plan.Rows.Clear();
            Dgv_Plan.Columns.Clear();

            Dgv_Plan.Columns.Add("col0", "-----");
            Dgv_Plan.Columns.Add("col1", "Lunes");
            Dgv_Plan.Columns.Add("col2", "Martes");
            Dgv_Plan.Columns.Add("col3", "Miércoles");
            Dgv_Plan.Columns.Add("col4", "Jueves");
            Dgv_Plan.Columns.Add("col5", "Viernes");
            Dgv_Plan.Columns.Add("col6", "Sábado");
            Dgv_Plan.Columns.Add("col7", "Domingo");

            // 5 filas (momentos)
            Dgv_Plan.Rows.Add("Desayuno");
            Dgv_Plan.Rows.Add("Media mañana");
            Dgv_Plan.Rows.Add("Almuerzo");
            Dgv_Plan.Rows.Add("Media tarde");
            Dgv_Plan.Rows.Add("Cena");

            // bloquear edición
            Dgv_Plan.ReadOnly = true;
            Dgv_Plan.RowHeadersVisible = true;

            Dgv_Plan.Columns["col0"].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_Plan.Columns["col1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_Plan.Columns["col2"].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_Plan.Columns["col3"].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_Plan.Columns["col4"].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_Plan.Columns["col5"].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_Plan.Columns["col6"].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_Plan.Columns["col7"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
        private void CalcularMacros(List<EntDetalleReceta> detalles, List<EntPlatillo> platillos)
        {
            totalCal = 0;
            totalCarb = 0;
            totalGrasas = 0;
            totalProteinas = 0;

            foreach (var det in detalles)
            {
                var plat = platillos.FirstOrDefault(p => p.IdPlatillo == det.IdPlatillo);
                if (plat != null)
                {
                    totalCal += plat.Calorias;
                    totalCarb += plat.Carbohidratos;
                    totalGrasas += plat.Grasas;
                    totalProteinas += plat.Proteinas;
                }
            }

            ActualizarLabels();
        }

        private void Dgv_Plan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
            {
                celdaFilaSeleccionada = -1;
                celdaColSeleccionada = -1;
                Cbox_Platillo.SelectedIndex = -1;
                return;
            }

            celdaFilaSeleccionada = e.RowIndex;
            celdaColSeleccionada = e.ColumnIndex;

            // 1️⃣ Obtener categoría según la fila
            string categoria = ObtenerCategoriaPorFila(e.RowIndex);

            // 2️⃣ Filtrar lista
            var filtrados = platillos
                .Where(p => p.Categoria != null && p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // 3️⃣ Asignar DataSource filtrado
            Cbox_Platillo.DataSource = filtrados;
            Cbox_Platillo.DisplayMember = "Nombre";
            Cbox_Platillo.ValueMember = "IdPlatillo";

            string nombre = Dgv_Plan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            if (!string.IsNullOrEmpty(nombre))
            {
                Cbox_Platillo.SelectedItem = filtrados.FirstOrDefault(p => p.Nombre == nombre);
            }
            else
            {
                Cbox_Platillo.SelectedIndex = -1;
            }
        }

        private void Cbox_Platillo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (celdaFilaSeleccionada < 0 || celdaColSeleccionada < 0)
                return;

            if (Cbox_Platillo.SelectedItem is EntPlatillo platNuevo)
            {
                int momento = celdaFilaSeleccionada + 1;
                int dia = celdaColSeleccionada;

                var detalle = detalles.FirstOrDefault(d => d.Dia == dia && d.Momento == momento);

                if (detalle != null)
                {
                    var platViejo = platillos.FirstOrDefault(p => p.IdPlatillo == detalle.IdPlatillo);
                    if (platViejo != null)
                    {
                        totalCal -= platViejo.Calorias;
                        totalCarb -= platViejo.Carbohidratos;
                        totalGrasas -= platViejo.Grasas;
                        totalProteinas -= platViejo.Proteinas;
                    }

                    detalle.IdPlatillo = platNuevo.IdPlatillo;
                }
                else
                {
                    detalle = new EntDetalleReceta
                    {
                        IdPlatillo = platNuevo.IdPlatillo,
                        Dia = dia,
                        Momento = momento
                    };
                    detalles.Add(detalle);
                }

                totalCal += platNuevo.Calorias;
                totalCarb += platNuevo.Carbohidratos;
                totalGrasas += platNuevo.Grasas;
                totalProteinas += platNuevo.Proteinas;

                Dgv_Plan.Rows[celdaFilaSeleccionada].Cells[celdaColSeleccionada].Value = platNuevo.Nombre;

                ActualizarLabels();
            }

        }

        private void Dgv_Plan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (detalles == null || detalles.Count == 0)
                {
                    MessageBox.Show("No hay detalles para guardar.");
                    return;
                }

                int idPlan = LogPlanNuticional.Instancia.CrearPlan(Tbox_DNI.Text);
                if (idPlan < 0)
                {
                    throw new Exception("No se pudo crear el plan");
                }

                List<EntDetallePlan> listaDetallesPlan = new List<EntDetallePlan>();

                for (int fila = 0; fila < Dgv_Plan.Rows.Count; fila++)
                {
                    for (int col = 1; col < Dgv_Plan.Columns.Count; col++)
                    {
                        var nombrePlatillo = Dgv_Plan.Rows[fila].Cells[col].Value?.ToString();
                        if (!string.IsNullOrEmpty(nombrePlatillo))
                        {
                            var plat = platillos.FirstOrDefault(p => p.Nombre == nombrePlatillo);
                            if (plat != null)
                            {
                                EntDetallePlan detalle = new EntDetallePlan
                                {
                                    IdPlan = idPlan,
                                    IdPlatillo = plat.IdPlatillo,
                                    Dia = col,
                                    Momento = fila + 1
                                };
                                listaDetallesPlan.Add(detalle);
                            }
                        }
                    }
                }

                if (!LogPlanNuticional.Instancia.InsertarDetallesPlan(listaDetallesPlan))
                {
                    throw new Exception("Hubo un error al insertar los detalles");
                }
                else
                {
                    MessageBox.Show("Se realizo el Plan Nutricional");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void show(List<EntDetallePlan> lista)
        {
            foreach (var det in lista)
            {
                string a = "";
                string b = "";
                switch (det.Dia)
                {
                    case 1:
                        a = "Lunes";
                        break;
                    case 2:
                        a = "Martes";
                        break;
                    case 3:
                        a = "Miercoles";
                        break;
                    case 4:
                        a = "Jueves";
                        break;
                    case 5:
                        a = "Viernes";
                        break;
                    case 6:
                        a = "Sabado";
                        break;
                    case 7:
                        a = "Domingo";
                        break;
                    default:
                        break;
                }
                
                switch(det.Momento)
                {
                    case 1:
                        b = "Desayuno";
                        break;
                    case 2:
                        b = "Media mañana";
                        break;
                    case 3:
                        b = "Almuerzo";
                        break;
                    case 4:
                        b = "Media tarde";
                        break;
                    case 5:
                        b = "Cena";
                        break;
                    default:
                        break;
                }

                string n = platillos.FirstOrDefault(p => p.IdPlatillo == det.IdPlatillo).Nombre;

                MessageBox.Show($"{n}: {a} - {b}");
            }
        }
    }
}
