using CapaDatos;
using CapaEntidad;
using CapaLogica;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HealthGym
{
    public partial class MantenedorEnfermedad : Form
    {
        private int idSeleccionado = -1;

        public MantenedorEnfermedad()
        {
            InitializeComponent();
            CargarEnfermedades();
            CargarComboMusculos();

            dgvEnfermedad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnfermedad.MultiSelect = false;
            dgvEnfermedad.CellClick += dgvEnfermedad_CellClick; 

            dgvEnfermedadMusculo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnfermedadMusculo.MultiSelect = false;
        }

        private void CargarEnfermedades(int seleccionarId = -1)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = "SELECT IdEnfermedad, Nombre FROM Enfermedad";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEnfermedad.DataSource = dt;
            }

            dgvEnfermedad.Columns["IdEnfermedad"].Visible = true;
            dgvEnfermedad.Columns["Nombre"].HeaderText = "Enfermedad";
            dgvEnfermedad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (seleccionarId != -1)
            {
                foreach (DataGridViewRow fila in dgvEnfermedad.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["IdEnfermedad"].Value) == seleccionarId)
                    {
                        fila.Selected = true;
                        dgvEnfermedad.FirstDisplayedScrollingRowIndex = fila.Index;
                        break;
                    }
                }
            }
        }

        private void CargarComboMusculos()
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = "SELECT IdMusculo, Nombre FROM Musculo";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMusculos.DataSource = dt;
                cbMusculos.ValueMember = "IdMusculo";
                cbMusculos.DisplayMember = "Nombre";
            }
        }

        private void CargarMusculosEnfermedad(int idEnfermedad)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = @"
                    SELECT M.IdMusculo, M.Nombre
                    FROM Musculo M
                    INNER JOIN EnfermedadMusculo EM ON M.IdMusculo = EM.IdMusculo
                    WHERE EM.IdEnfermedad = @id";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@id", idEnfermedad);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEnfermedadMusculo.DataSource = dt;
            }

            dgvEnfermedadMusculo.Columns["IdMusculo"].Visible = true;
            dgvEnfermedadMusculo.Columns["Nombre"].HeaderText = "Músculo";
            dgvEnfermedadMusculo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dgvEnfermedad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvEnfermedad.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdEnfermedad"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();

            CargarMusculosEnfermedad(idSeleccionado);
        }

        // Agregar 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese un nombre.");
                return;
            }

            if (nombre.Length > 30)
            {
                MessageBox.Show("El nombre no puede superar los 30 caracteres.");
                return;
            }

            EntEnfermedad enf = new EntEnfermedad { Nombre = nombre };

            bool agregado = LogEnfermedad.Instancia.Agregar(enf);

            if (agregado)
            {
                MessageBox.Show("Enfermedad agregada correctamente.");
                CargarEnfermedades();
                txtNombre.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo agregar la enfermedad. ¿Ya existe?");
            }
        }
        // Editar 
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEnfermedad.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila.");
                return;
            }

            var fila = dgvEnfermedad.SelectedRows[0];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdEnfermedad"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();

            btnAgregar.Visible = false;
            btnModificar.Visible = true; 
        }

        // Modificar nombre
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione una enfermedad primero.");
                return;
            }

            string nuevoNombre = txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("Ingrese un nombre.");
                return;
            }

            if (nuevoNombre.Length > 30)
            {
                MessageBox.Show("El nombre no puede superar los 30 caracteres.");
                return;
            }

            // Verificar duplicado
            if (LogEnfermedad.Instancia.ExisteNombre(nuevoNombre, idSeleccionado))
            {
                MessageBox.Show("Ya existe una enfermedad con ese nombre. Ingrese otro.");
                return;
            }

            EntEnfermedad enf = new EntEnfermedad
            {
                IdEnfermedad = idSeleccionado,
                Nombre = nuevoNombre
            };

            if (LogEnfermedad.Instancia.Editar(enf))
            {
                MessageBox.Show("Actualizado correctamente.");
                CargarEnfermedades(idSeleccionado);
                txtNombre.Clear();
                idSeleccionado = -1;

                // Restaurar botón Agregar
                btnAgregar.Visible = true;
                btnModificar.Visible = false;
            }
        }


        // Agregar músculo
        private void btnAgregarMusculo_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione una enfermedad.");
                return;
            }

            int idMusculo = Convert.ToInt32(cbMusculos.SelectedValue);

            EntEnfermedad em = new EntEnfermedad
            {
                IdEnfermedad = idSeleccionado,
                IdMusculo = idMusculo
            };

            if (!LogEnfermedad.Instancia.AgregarMusculo(em))
            {
                MessageBox.Show("Este músculo ya está asociado.");
                return;
            }

            CargarMusculosEnfermedad(idSeleccionado);
        }

        // Eliminar músculo
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEnfermedadMusculo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un músculo asociado.");
                return;
            }

            int idMusculo = Convert.ToInt32(dgvEnfermedadMusculo.SelectedRows[0].Cells["IdMusculo"].Value);

            EntEnfermedad em = new EntEnfermedad
            {
                IdEnfermedad = idSeleccionado,
                IdMusculo = idMusculo
            };

            if (LogEnfermedad.Instancia.EliminarMusculo(em))
                CargarMusculosEnfermedad(idSeleccionado);
        }
    }
}
