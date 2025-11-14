using CapaDatos;
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
    public partial class MantenedorAlergia : Form
    {
        public MantenedorAlergia()
        {
            InitializeComponent();
            ListarAlergia();
        }
        // LISTAR
        public void ListarAlergia()
        {
            dgvAlergia.DataSource = LogAlergia.Instancia.ListarAlergia();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    throw new Exception("Debe llenar el nombre.");
                }

                EntAlergia enf = new EntAlergia();
                enf.Nombre = nombre;

                LogAlergia.Instancia.InsertarAlergia(enf);
                MessageBox.Show("Alergia agregada correctamente.");

                LimpiarCampos();
                txtNombre.Enabled = false;
                ListarAlergia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Visible = true;
            btnAñadir.Visible = true;
            btnModificar.Visible = true;
        }

        int idSeleccionado = 0;
        string nombreAnte = "";
        private void dgvAlergia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAlergia.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells[0].Value);
                txtNombre.Text = fila.Cells[1].Value.ToString();
                nombreAnte = txtNombre.Text.Trim();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoNombre = txtNombre.Text.Trim();

                if (string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    throw new Exception("Debe llenar el nombre.");
                }

                if (nuevoNombre.Equals(nombreAnte, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Debe ingresar un nombre diferente al actual.");
                }

                EntAlergia enf = new EntAlergia();
                enf.Id = idSeleccionado;
                enf.Nombre = nuevoNombre;

                LogAlergia.Instancia.EditarAlergia(enf);
                MessageBox.Show("Alergia modificada correctamente.");

                LimpiarCampos();
                txtNombre.Enabled = true;
                ListarAlergia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
