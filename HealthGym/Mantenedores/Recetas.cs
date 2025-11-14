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

namespace HealthGym.Mantenedores
{
    public partial class Recetas : Form
    {
        EntAlimento alimento = new EntAlimento();
        List<EntRecetaMaterial> materiales = new List<EntRecetaMaterial>();
        List<EntRecetaPaso> pasos = new List<EntRecetaPaso>();

        EntRecetaMaterial matSelect = new EntRecetaMaterial();
        EntRecetaPaso pasSelect = new EntRecetaPaso();

        bool modo = true;
        public Recetas()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Recetas_Load(object sender, EventArgs e)
        {
            alimento.Id = -1;
            Btn_MatEdit.Enabled = false;
            Btn_PasEdit.Enabled = false;
            Dgv_Alimentos.AutoGenerateColumns = true;
            CargarDatos();
        }

        private void CargarDatos()
        {
            List<EntAlimento> alimentos = LogAlimento.Instancia.CargarAlimentos();
            if (alimentos.Count <= 0)
            {
                MessageBox.Show("No hay alimentos cargados");
                this.Close();
            }
            Dgv_Alimentos.DataSource = alimentos;

            alimento = alimentos[0];
            materiales = LogRecetaMaterial.Instancia.CargarMaterialesDe(alimento);
            pasos = LogRecetaPaso.Instancia.CargarPasosDe(alimento);

            Dgv_Mats.DataSource = materiales;
            Dgv_Pasos.DataSource = pasos;
        }

        private void Limpiar()
        {
            Tbox_Cantidad.Text = "";
            Tbox_Instruccion.Text = "";
            Tbox_Material.Text = "";
            Tbox_Medida.Text = "";
            Tbox_Paso.Text = "";
        }

        private void Dgv_Alimentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = Dgv_Alimentos.Rows[e.RowIndex];

                EntAlimento a = new EntAlimento();
                modo = true;
                Btn_PasAdd.Enabled = true;
                Btn_MatAdd.Enabled = true;
                Btn_MatEdit.Enabled = false;
                Btn_PasEdit.Enabled = false;
                Limpiar();
                a.Id = Convert.ToInt32(fila.Cells["Id"].Value);
                a.Nombre = Convert.ToString(fila.Cells["Nombre"].Value);

                alimento = a;
                materiales = LogRecetaMaterial.Instancia.CargarMaterialesDe(alimento);
                pasos = LogRecetaPaso.Instancia.CargarPasosDe(alimento);

                Dgv_Mats.DataSource = materiales;
                Dgv_Pasos.DataSource = pasos;

                Lbl_Alimento.Text = alimento.Nombre;
            }
        }

        private void Btn_MatAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modo)
                {
                    Limpiar();
                    Btn_MatEdit.Enabled = false;
                    Btn_PasEdit.Enabled = false;
                    Btn_PasAdd.Enabled = true;
                    modo = true;
                    return;
                }
                //validaciones
                {
                    if (string.IsNullOrWhiteSpace(Tbox_Cantidad.Text))
                    {
                        throw new Exception("Debe ingresar una cantidad");
                    }
                    if (string.IsNullOrWhiteSpace(Tbox_Material.Text))
                    {
                        throw new Exception("Debe ingresar un material");
                    }
                    if (string.IsNullOrWhiteSpace(Tbox_Medida.Text))
                    {
                        throw new Exception("Debe ingresar una medida");
                    }
                    if (!decimal.TryParse(Tbox_Cantidad.Text, out _))
                    {
                        throw new Exception("Debe ingresar una cantidad valida");
                    }
                    if (!Tbox_Medida.Text.All(char.IsLetter))
                    {
                        throw new Exception("Debe ingresar una medida valida");
                    }
                    if (Tbox_Medida.Text.Length > 2)
                    {
                        throw new Exception("La medida debe tener maximo 2 caracteres");
                    }
                    if (Tbox_Material.Text.Length > 20)
                    {
                        throw new Exception("El material debe tener maximo 20 caracteres");
                    }
                    if (materiales.Any(p => p.Material == Tbox_Material.Text))
                    {
                        throw new Exception("Ya hay un material con ese nombre");
                    }

                    EntRecetaMaterial m = new EntRecetaMaterial();
                    m.Alimento = alimento.Id;
                    m.Material = Tbox_Material.Text;
                    m.Medida = Tbox_Medida.Text;
                    m.Cantidad = decimal.Parse(Tbox_Cantidad.Text);

                    if (LogRecetaMaterial.Instancia.AgregarMaterial(m))
                    {
                        materiales = LogRecetaMaterial.Instancia.CargarMaterialesDe(alimento);

                        Dgv_Mats.DataSource = materiales;
                        Dgv_Pasos.DataSource = pasos;

                        Limpiar();

                        Form msg = new Form();
                        msg.Size = new Size(300, 150);
                        msg.BackColor = Color.LightGreen;

                        Label lbl = new Label();
                        lbl.Text = "Se agregó el material";
                        lbl.AutoSize = false;
                        lbl.Dock = DockStyle.Fill;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;

                        msg.Controls.Add(lbl);
                        msg.ShowDialog();
                    }
                    else
                    {
                        Form msg = new Form();
                        msg.Size = new Size(300, 150);
                        msg.BackColor = Color.Red;

                        Label lbl = new Label();
                        lbl.Text = "No se pudo agregar el material";
                        lbl.AutoSize = false;
                        lbl.Dock = DockStyle.Fill;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;

                        msg.Controls.Add(lbl);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Form msg = new Form();
                msg.Size = new Size(300, 150);
                msg.BackColor = Color.Red;

                Label lbl = new Label();
                lbl.Text = ex.Message;
                lbl.AutoSize = false;
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;

                msg.Controls.Add(lbl);
                msg.ShowDialog();
            }
        }

        private void Btn_PasAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modo)
                {
                    Limpiar();
                    Btn_MatEdit.Enabled = false;
                    Btn_MatAdd.Enabled = true;
                    Btn_PasEdit.Enabled = false;
                    modo = true;
                    return;
                }
                //validaciones
                {
                    if (string.IsNullOrWhiteSpace(Tbox_Paso.Text))
                    {
                        throw new Exception("Debe ingresar un numero de paso");
                    }
                    if (string.IsNullOrWhiteSpace(Tbox_Instruccion.Text))
                    {
                        throw new Exception("Debe ingresar un numero de paso");
                    }
                    if (!int.TryParse(Tbox_Paso.Text, out int value))
                    {
                        throw new Exception("Debe ingresar un numero de paso valido");
                    }
                    if (pasos.All(we => we.Paso == int.Parse(Tbox_Paso.Text)))
                    {
                        throw new Exception("Ya hay un paso con ese numero");
                    }
                    if (Tbox_Instruccion.Text.Length > 512)
                    {
                        throw new Exception("La instruccion debe ser de maximo 512 caracteres");
                    }

                    EntRecetaPaso m = new EntRecetaPaso();
                    m.Alimento = alimento.Id;
                    m.Paso = int.Parse(Tbox_Paso.Text);
                    m.Instruccion = Tbox_Instruccion.Text;

                    if (LogRecetaPaso.Instancia.AgregarPaso(m))
                    {
                        pasos = LogRecetaPaso.Instancia.CargarPasosDe(alimento);
                        Dgv_Mats.DataSource = materiales;
                        Dgv_Pasos.DataSource = pasos;

                        Limpiar();

                        Form msg = new Form();
                        msg.Size = new Size(300, 150);
                        msg.BackColor = Color.LightGreen;

                        Label lbl = new Label();
                        lbl.Text = "Se agregó el paso";
                        lbl.AutoSize = false;
                        lbl.Dock = DockStyle.Fill;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;

                        msg.Controls.Add(lbl);
                        msg.ShowDialog();
                    }
                    else
                    {
                        Form msg = new Form();
                        msg.Size = new Size(300, 150);
                        msg.BackColor = Color.Red;

                        Label lbl = new Label();
                        lbl.Text = "No se pudo agregar el paso";
                        lbl.AutoSize = false;
                        lbl.Dock = DockStyle.Fill;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;

                        msg.Controls.Add(lbl);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Form msg = new Form();
                msg.Size = new Size(300, 150);
                msg.BackColor = Color.Red;

                Label lbl = new Label();
                lbl.Text = ex.Message;
                lbl.AutoSize = false;
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;

                msg.Controls.Add(lbl);
                msg.ShowDialog();
            }
        }

        private void Btn_PasEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Tbox_Paso.Text))
                {
                    throw new Exception("Debe ingresar un numero de paso");
                }
                if (string.IsNullOrWhiteSpace(Tbox_Instruccion.Text))
                {
                    throw new Exception("Debe ingresar un numero de paso");
                }
                if (!int.TryParse(Tbox_Paso.Text, out int value))
                {
                    throw new Exception("Debe ingresar un numero de paso valido");
                }
                if(pasos.All(we => we.Id != pasSelect.Id && we.Paso == int.Parse(Tbox_Paso.Text)))
                {
                    throw new Exception("Ya hay un paso con ese numero");
                }
                if(Tbox_Instruccion.Text.Length > 512)
                {
                    throw new Exception("La instruccion debe ser de maximo 512 caracteres");
                }

                EntRecetaPaso p = new EntRecetaPaso();
                p.Id = pasSelect.Id;
                p.Alimento = pasSelect.Alimento;
                p.Paso = int.Parse(Tbox_Paso.Text);
                p.Instruccion = Tbox_Instruccion.Text;

                if(LogRecetaPaso.Instancia.EditarPaso(p))
                {
                    pasos = LogRecetaPaso.Instancia.CargarPasosDe(alimento);

                    Dgv_Pasos.DataSource = pasos;

                    Form msg = new Form();
                    msg.Size = new Size(300, 150);
                    msg.BackColor = Color.LightGreen;

                    Label lbl = new Label();
                    lbl.Text = "Se editó el paso";
                    lbl.AutoSize = false;
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;

                    msg.Controls.Add(lbl);
                    msg.ShowDialog();
                }
                else
                {
                    Form msg = new Form();
                    msg.Size = new Size(300, 150);
                    msg.BackColor = Color.Red;

                    Label lbl = new Label();
                    lbl.Text = "No se pudo editar el paso";
                    lbl.AutoSize = false;
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;

                    msg.Controls.Add(lbl);
                    msg.ShowDialog();
                }

                Limpiar();
                Btn_PasEdit.Enabled = false;
                Btn_MatAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                Form msg = new Form();
                msg.Size = new Size(300, 150);
                msg.BackColor = Color.Red;

                Label lbl = new Label();
                lbl.Text = ex.Message;
                lbl.AutoSize = false;
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;

                msg.Controls.Add(lbl);
                msg.ShowDialog();
            }
        }

        private void Btn_MatEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Tbox_Cantidad.Text))
                {
                    throw new Exception("Debe ingresar una cantidad");
                }
                if (string.IsNullOrWhiteSpace(Tbox_Material.Text))
                {
                    throw new Exception("Debe ingresar un material");
                }
                if (string.IsNullOrWhiteSpace(Tbox_Medida.Text))
                {
                    throw new Exception("Debe ingresar una medida");
                }
                if (!decimal.TryParse(Tbox_Cantidad.Text, out _))
                {
                    throw new Exception("Debe ingresar una cantidad valida");
                }
                if (!Tbox_Medida.Text.All(char.IsLetter))
                {
                    throw new Exception("Debe ingresar una medida valida");
                }
                if (Tbox_Medida.Text.Length > 2)
                {
                    throw new Exception("La medida debe tener maximo 2 caracteres");
                }
                if (Tbox_Material.Text.Length > 20)
                {
                    throw new Exception("El material debe tener maximo 20 caracteres");
                }
                if (materiales.Any(p => p.Material == Tbox_Material.Text && p.Id != matSelect.Id))
                {
                    throw new Exception("Ya hay un material con ese nombre");
                }

                EntRecetaMaterial m = new EntRecetaMaterial();
                m.Id = matSelect.Id;
                m.Alimento = matSelect.Alimento;
                m.Material = Tbox_Material.Text;
                m.Medida = Tbox_Medida.Text;
                m.Cantidad = decimal.Parse(Tbox_Cantidad.Text);

                if (LogRecetaMaterial.Instancia.EditarMaterial(m))
                {
                    materiales = LogRecetaMaterial.Instancia.CargarMaterialesDe(alimento);

                    Dgv_Mats.DataSource = materiales;
                    Dgv_Pasos.DataSource = pasos;

                    Form msg = new Form();
                    msg.Size = new Size(300, 150);
                    msg.BackColor = Color.LightGreen;

                    Label lbl = new Label();
                    lbl.Text = "Se editó el material";
                    lbl.AutoSize = false;
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;

                    msg.Controls.Add(lbl);
                    msg.ShowDialog();
                }
                else
                {
                    Form msg = new Form();
                    msg.Size = new Size(300, 150);
                    msg.BackColor = Color.Red;

                    Label lbl = new Label();
                    lbl.Text = "No se pudo editar el material";
                    lbl.AutoSize = false;
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;

                    msg.Controls.Add(lbl);
                    msg.ShowDialog();
                }

                Limpiar();
                Btn_MatEdit.Enabled = false;
                Btn_PasAdd.Enabled = true; ;
                modo = false;
            }
            catch (Exception ex)
            {
                Form msg = new Form();
                msg.Size = new Size(300, 150);
                msg.BackColor = Color.Red;

                Label lbl = new Label();
                lbl.Text = ex.Message;
                lbl.AutoSize = false;
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;

                msg.Controls.Add(lbl);
                msg.ShowDialog();
            }
        }

        private void Dgv_Mats_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modo = false;
                Btn_MatEdit.Enabled = true;
                Btn_MatAdd.Enabled = true;
                Btn_PasAdd.Enabled = false;
                Btn_PasEdit.Enabled = false;
                DataGridViewRow fila = Dgv_Mats.Rows[e.RowIndex];

                EntRecetaMaterial a = new EntRecetaMaterial();
                a.Id = Convert.ToInt32(fila.Cells["Id"].Value);
                a.Alimento = Convert.ToInt32(fila.Cells["Alimento"].Value);
                a.Material = Convert.ToString(fila.Cells["Material"].Value);
                a.Medida = Convert.ToString(fila.Cells["Medida"].Value);
                a.Cantidad = Convert.ToDecimal(fila.Cells["Cantidad"].Value);

                matSelect = a;

                Tbox_Cantidad.Text = matSelect.Cantidad.ToString();
                Tbox_Material.Text = matSelect.Material.ToString();
                Tbox_Medida.Text = matSelect.Medida.ToString();
            }
        }

        private void Dgv_Pasos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modo = false;
                Btn_MatAdd.Enabled = false;
                Btn_PasEdit.Enabled = true;
                Btn_PasAdd.Enabled = true;
                Btn_MatEdit.Enabled = false;
                DataGridViewRow fila = Dgv_Pasos.Rows[e.RowIndex];

                EntRecetaPaso a = new EntRecetaPaso();
                a.Id = Convert.ToInt32(fila.Cells["Id"].Value);
                a.Alimento = Convert.ToInt32(fila.Cells["Alimento"].Value);
                a.Paso = Convert.ToInt32(fila.Cells["Paso"].Value);
                a.Instruccion = Convert.ToString(fila.Cells["Instruccion"].Value);

                pasSelect = a;

                Tbox_Paso.Text = pasSelect.Paso.ToString();
                Tbox_Instruccion.Text = pasSelect.Instruccion.ToString();
            }
        }
    }
}
