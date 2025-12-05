using CapaLogica;
using CapaDatos;
using CapaEntidad;
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
    public partial class Platillo : Form
    {
        public Platillo()
        {
            InitializeComponent();
            listarPlat();
            Limpiar();
            gboPlatillo.Enabled = false;
            btnEditar.Enabled = false;
        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtCalorias.Text = "";
            txtCarbohidratos.Text = "";
            txtGrasas.Text = "";
            txtProteinas.Text = "";
        }

        private void listarPlat()
        {
            dgvPlatillo.DataSource = LogPlatillo.Instancia.ListarPlatillo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            gboPlatillo.Enabled = true;
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EntPlatillo a = new EntPlatillo();
                a.Nombre = txtNombre.Text;
                a.Calorias = double.Parse(txtCalorias.Text);
                a.Carbohidratos = double.Parse(txtCarbohidratos.Text);
                a.Grasas = double.Parse(txtGrasas.Text);
                a.Proteinas = double.Parse(txtProteinas.Text);

                bool resultado = LogPlatillo.Instancia.InserPlatillo(a);
                if (resultado)
                {
                    MessageBox.Show("Se registró correctamente el Platillo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al agregar valores" + ex);
            }
            Limpiar();
            gboPlatillo.Enabled = false;
            listarPlat();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            gboPlatillo.Enabled = true;
            btnGuardar.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
        }

        private void dgvPlatillo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = dgvPlatillo.Rows[e.RowIndex];
            txtNombre.Text = filaActual.Cells[1].Value.ToString();
            txtCalorias.Text = filaActual.Cells[2].Value.ToString();
            txtCarbohidratos.Text = filaActual.Cells[3].Value.ToString();
            txtGrasas.Text = filaActual.Cells[4].Value.ToString();
            txtGrasas.Text = filaActual.Cells[5].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                EntPlatillo a = new EntPlatillo();
                a.IdPlatillo = Convert.ToInt32(dgvPlatillo.CurrentRow.Cells["IdPlatillo"].Value);
                a.Nombre = txtNombre.Text;
                a.Calorias = double.Parse(txtCalorias.Text);
                a.Carbohidratos = double.Parse(txtCarbohidratos.Text);
                a.Grasas = double.Parse(txtGrasas.Text);
                a.Proteinas = double.Parse(txtProteinas.Text);

                bool resultado = LogPlatillo.Instancia.EditarPlatillo(a);
                if (resultado)
                {
                    MessageBox.Show("Se editó correctamente el Platillo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al agregar valores" + ex);
            }
            Limpiar();
            gboPlatillo.Enabled = false;
            listarPlat();
        }
    }
}
