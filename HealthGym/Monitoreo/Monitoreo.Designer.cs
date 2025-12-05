namespace HealthGym.Monitoreo
{
    partial class Monitoreo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDNI = new TextBox();
            txtPeso = new TextBox();
            txtEstatura = new TextBox();
            btnBuscar = new Button();
            groupBox1 = new GroupBox();
            cboNivelActividad = new ComboBox();
            lblNivelActividad = new Label();
            txtObjetivoCalorico = new TextBox();
            txtCintura = new TextBox();
            txtPecho = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtGluteo = new TextBox();
            txtBrazo = new TextBox();
            txtPierna = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            btnGuardar = new Button();
            lblNota = new Label();
            lblRecomendacion = new Label();
            label12 = new Label();
            dgvHistorial = new DataGridView();
            lblIMC = new Label();
            btnCalcularIMC = new Button(); 
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
           
            label1.AutoSize = true;
            label1.Location = new Point(36, 26);
            label1.Text = "DNI:";
            
            label2.AutoSize = true;
            label2.Location = new Point(18, 70);
            label2.Text = "Peso(Kg):";
            
            label3.AutoSize = true;
            label3.Location = new Point(18, 111);
            label3.Text = "Estatura(m):";
            
            txtDNI.Location = new Point(112, 19);
            txtDNI.Size = new Size(178, 27);
            
            txtPeso.Location = new Point(112, 59);
            txtPeso.Size = new Size(146, 27);
            
            txtEstatura.Location = new Point(112, 104);
            txtEstatura.Size = new Size(146, 27);
            
            btnBuscar.Location = new Point(318, 18);
            btnBuscar.Size = new Size(95, 37);
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscarMiembro_Click;
            
            btnCalcularIMC.Location = new Point(292, 104);
            btnCalcularIMC.Name = "btnCalcularIMC";
            btnCalcularIMC.Size = new Size(140, 30);
            btnCalcularIMC.TabIndex = 25;
            btnCalcularIMC.Text = "Calcular IMC";
            btnCalcularIMC.UseVisualStyleBackColor = true;
            btnCalcularIMC.Click += btnCalcularIMC_Click;
            
            groupBox1.Controls.Add(cboNivelActividad);
            groupBox1.Controls.Add(lblNivelActividad);
            groupBox1.Controls.Add(txtObjetivoCalorico);
            groupBox1.Controls.Add(txtCintura);
            groupBox1.Controls.Add(txtPecho);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtGluteo);
            groupBox1.Controls.Add(txtBrazo);
            groupBox1.Controls.Add(txtPierna);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(20, 156);
            groupBox1.Size = new Size(504, 219);
            groupBox1.Text = "Medidas y Objetivos";
            
            cboNivelActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNivelActividad.FormattingEnabled = true;
            cboNivelActividad.Location = new Point(140, 171); // Ajustado posición
            cboNivelActividad.Size = new Size(135, 28);
            
            lblNivelActividad.AutoSize = true;
            lblNivelActividad.Location = new Point(24, 174);
            lblNivelActividad.Text = "Nivel Actividad:";
           
            txtObjetivoCalorico.Location = new Point(349, 127);
            txtObjetivoCalorico.Size = new Size(135, 27);
            
            txtCintura.Location = new Point(327, 42);
            txtCintura.Size = new Size(135, 27);
            
            txtPecho.Location = new Point(327, 86);
            txtPecho.Size = new Size(135, 27);
            
            label7.AutoSize = true;
            label7.Location = new Point(251, 49);
            label7.Text = "Cintura:";
           
            label8.AutoSize = true;
            label8.Location = new Point(248, 89);
            label8.Text = "Pecho:";
            
            label9.AutoSize = true;
            label9.Location = new Point(248, 134);
            label9.Text = "Obj Calorico:";
            
            txtGluteo.Location = new Point(103, 127);
            txtGluteo.Size = new Size(135, 27);
            
            txtBrazo.Location = new Point(103, 42);
            txtBrazo.Size = new Size(135, 27);
            
            txtPierna.Location = new Point(103, 86);
            txtPierna.Size = new Size(135, 27);
           
            label6.AutoSize = true;
            label6.Location = new Point(27, 49);
            label6.Text = "Brazos:";
            
            label5.AutoSize = true;
            label5.Location = new Point(24, 89);
            label5.Text = "Piernas:";
           
            label4.AutoSize = true;
            label4.Location = new Point(24, 134);
            label4.Text = "Glúteos";
           
            btnGuardar.BackColor = Color.LimeGreen;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = SystemColors.Control;
            btnGuardar.Location = new Point(18, 395);
            btnGuardar.Size = new Size(506, 37);
            btnGuardar.Text = "Registrar Monitoreo";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            
            lblNota.AutoSize = true;
            lblNota.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblNota.Location = new Point(538, 26);
            lblNota.Text = "Calificación: N/A";
            
            lblRecomendacion.AutoSize = true;
            lblRecomendacion.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblRecomendacion.Location = new Point(538, 70);
            lblRecomendacion.Text = "Recomendación: En espera";
            
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label12.Location = new Point(36, 447);
            label12.Text = "Historial y progreso ";
            
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(24, 487);
            dgvHistorial.Size = new Size(808, 174);
           
            lblIMC.AutoSize = true;
            lblIMC.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblIMC.Location = new Point(292, 70);
            lblIMC.Text = "IMC Calculado: 0.00";
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 706);
            Controls.Add(btnCalcularIMC);
            Controls.Add(lblIMC);
            Controls.Add(dgvHistorial);
            Controls.Add(label12);
            Controls.Add(lblRecomendacion);
            Controls.Add(lblNota);
            Controls.Add(btnGuardar);
            Controls.Add(groupBox1);
            Controls.Add(btnBuscar);
            Controls.Add(txtEstatura);
            Controls.Add(txtPeso);
            Controls.Add(txtDNI);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Monitoreo";
            Text = "Monitoreo";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtDNI;
        private TextBox txtPeso;
        private TextBox txtEstatura;
        private Button btnBuscar;
        private GroupBox groupBox1;
        private TextBox txtGluteo;
        private TextBox txtBrazo;
        private TextBox txtPierna;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtObjetivoCalorico;
        private TextBox txtCintura;
        private TextBox txtPecho;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnGuardar;
        private Label lblRecomendacion;
        private Label label12;
        private DataGridView dgvHistorial;
        private Label lblIMC;
        private Label lblNota;

        
        private ComboBox cboNivelActividad; 
        private Label lblNivelActividad;
        private Button btnCalcularIMC; 
    }
}