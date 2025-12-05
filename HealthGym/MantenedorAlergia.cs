using CapaDatos;
using CapaEntidad;
using CapaLogica;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HealthGym
{
    public partial class MantenedorAlergia : Form
    {
        int idSeleccionado = 0;
        string nombreAnte = "";

        public MantenedorAlergia()
        {
            InitializeComponent();
            ListarAlergia();
            dgvAlergia.CellClick += dgvAlergia_CellClick; 
        }


        public void ListarAlergia()
        {
            var lista = LogAlergia.Instancia.ListarAlergia();
            lista = lista.OrderBy(a => a.IdAlergia).ToList();
            dgvAlergia.DataSource = lista;

            dgvAlergia.Columns["IdAlergia"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvAlergia.Columns["Nombre"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtNombre.Enabled = false;
            btnModificar.Enabled = false;
        }


        private void dgvAlergia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAlergia.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdAlergia"].Value);
                nombreAnte = fila.Cells["Nombre"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione una alergia primero.");
                return;
            }

            txtNombre.Text = nombreAnte;
            txtNombre.Enabled = true;
            btnModificar.Enabled = true;
            btnAñadir.Enabled = false; 
        }


        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new Exception("Debe llenar el nombre.");

                if (nombre.Length > 30)
                    throw new Exception("El nombre no puede superar los 30 caracteres.");

                // Verificar si ya existe
                if (LogAlergia.Instancia.ExisteNombre(nombre, 0))
                    throw new Exception("Ya existe una alergia con ese nombre.");

                EntAlergia enf = new EntAlergia { Nombre = nombre };
                LogAlergia.Instancia.AgregarAlergia(enf);

                MessageBox.Show("Alergia agregada correctamente.");
                LimpiarCampos();
                ListarAlergia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoNombre = txtNombre.Text.Trim();
                if (string.IsNullOrWhiteSpace(nuevoNombre))
                    throw new Exception("Debe llenar el nombre.");

                if (nuevoNombre.Length > 30)
                    throw new Exception("El nombre no puede superar los 30 caracteres.");

                if (nuevoNombre.Equals(nombreAnte, StringComparison.OrdinalIgnoreCase))
                    throw new Exception("Debe ingresar un nombre diferente al actual.");

                if (LogAlergia.Instancia.ExisteNombre(nuevoNombre, idSeleccionado))
                    throw new Exception("Ya existe una alergia con ese nombre.");

                EntAlergia enf = new EntAlergia
                {
                    IdAlergia = idSeleccionado,
                    Nombre = nuevoNombre
                };

                LogAlergia.Instancia.EditarAlergia(enf);
                MessageBox.Show("Alergia modificada correctamente.");

                LimpiarCampos();
                ListarAlergia();

                // Restaurar botones
                btnAñadir.Enabled = true;
                btnModificar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
