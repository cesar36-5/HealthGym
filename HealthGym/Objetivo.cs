using CapaDatos;
using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthGym
{
    public partial class Objetivo : Form
    {
        private int IdMiembroActual = 0;
        public Objetivo()
        {
            InitializeComponent();
            Limpiar();
            CargarMusculos();
            gboObjetivo.Enabled = false;
        }
        public void Limpiar()
        {
            txtDNI.Text = "";
            lblNombre.Text = "";
            cboMusculo.SelectedIndex = -1;
            txtTamano.Text = "";
        }
        public void Listar(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                dgvObjetivo.DataSource = null;
                return;
            }

            dgvObjetivo.DataSource = LogObjetivo.Instancia.Listar(dni);
        }
        public void CargarMusculos()
        {
            cboMusculo.DataSource = LogObjetivo.Instancia.ListarMusculos();
            cboMusculo.DisplayMember = "NombreMusculo";
            cboMusculo.ValueMember = "IdMusculo";
            cboMusculo.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();

            if (dni.Length != 8)
            {
                MessageBox.Show("Ingrese un DNI válido de 8 dígitos.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombre = LogObjetivo.Instancia.BuscarDNI(dni);

                if (string.IsNullOrEmpty(nombre))
                {
                    lblNombre.Text = "No encontrado";
                    MessageBox.Show("No se encontró un miembro con este DNI.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lblNombre.Text = nombre;
                Listar(dni);
                gboObjetivo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar el miembro:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("Ingrese un DNI.");
                return;
            }

            if (cboMusculo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un músculo.");
                return;
            }

            if (!decimal.TryParse(txtTamano.Text, out decimal tamano))
            {
                MessageBox.Show("Ingrese un tamaño válido.");
                return;
            }

            EntObjetivo obj = new EntObjetivo
            {
                DNI = txtDNI.Text.Trim(),
                IdMusculo = Convert.ToInt32(cboMusculo.SelectedValue),
                Tamano = tamano
            };

            try
            {
                bool insertado = LogObjetivo.Instancia.InsertarObjetivo(obj);

                if (insertado)
                {
                    MessageBox.Show("Objetivo registrado correctamente.");
                    Listar(txtDNI.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvObjetivo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvObjetivo.Rows[e.RowIndex];
                string nombreMusculo = fila.Cells["Musculo"].Value.ToString();
                string tamano = fila.Cells["Tamaño"].Value.ToString();
                cboMusculo.SelectedIndex = cboMusculo.FindStringExact(nombreMusculo);
                txtTamano.Text = tamano;

                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("No hay un DNI válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMusculo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un músculo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtTamano.Text, out decimal tamano) || tamano <= 0)
            {
                MessageBox.Show("Ingrese un tamaño válido mayor a 0.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EntObjetivo obj = new EntObjetivo
            {
                DNI = txtDNI.Text.Trim(),
                IdMusculo = Convert.ToInt32(cboMusculo.SelectedValue),
                Tamano = tamano
            };

            try
            {
                bool actualizado = LogObjetivo.Instancia.EditarObjetivo(obj);

                if (actualizado)
                {
                    MessageBox.Show("Objetivo actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Listar(txtDNI.Text.Trim());
                    cboMusculo.SelectedIndex = -1;
                    txtTamano.Text = "";
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("No hay un DNI válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMusculo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un músculo para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar este objetivo?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                string dni = txtDNI.Text.Trim();
                int idMusculo = Convert.ToInt32(cboMusculo.SelectedValue);

                bool eliminado = LogObjetivo.Instancia.EliminarObjetivo(dni, idMusculo);

                if (eliminado)
                {
                    MessageBox.Show("Objetivo eliminado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Listar(txtDNI.Text.Trim());

                    cboMusculo.SelectedIndex = -1;
                    txtTamano.Text = "";
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
