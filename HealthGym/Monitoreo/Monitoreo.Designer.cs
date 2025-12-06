namespace HealthGym.Monitoreo
{
    partial class Monitoreo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
           
            label1.AutoSize = true;
            label1.Location = new Point(36, 26);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "DNI:";
            // 
           
            label2.AutoSize = true;
            label2.Location = new Point(18, 70);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Peso(Kg):";
            // 
            
            label3.AutoSize = true;
            label3.Location = new Point(18, 111);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 2;
            label3.Text = "Estatura(m):";
            // 
            
            txtDNI.Location = new Point(112, 19);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(178, 27);
            txtDNI.TabIndex = 3;
            // 
            
            txtPeso.Location = new Point(112, 59);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(146, 27);
            txtPeso.TabIndex = 4;
            // 
            
            txtEstatura.Location = new Point(112, 104);
            txtEstatura.Name = "txtEstatura";
            txtEstatura.Size = new Size(146, 27);
            txtEstatura.TabIndex = 5;
            // 
            
            btnBuscar.Location = new Point(318, 18);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(95, 37);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscarMiembro_Click;
            // 
            
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
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(504, 219);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Medidas y Objetivos";
            // 
            
            cboNivelActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNivelActividad.FormattingEnabled = true;
            cboNivelActividad.Location = new Point(103, 171);
            cboNivelActividad.Name = "cboNivelActividad";
            cboNivelActividad.Size = new Size(135, 28);
            cboNivelActividad.TabIndex = 21;
            // 
            
            lblNivelActividad.AutoSize = true;
            lblNivelActividad.Location = new Point(24, 174);
            lblNivelActividad.Name = "lblNivelActividad";
            lblNivelActividad.Size = new Size(75, 20);
            lblNivelActividad.TabIndex = 20;
            lblNivelActividad.Text = "Actividad:";
            // 
            
            txtObjetivoCalorico.Location = new Point(349, 127);
            txtObjetivoCalorico.Name = "txtObjetivoCalorico";
            txtObjetivoCalorico.Size = new Size(135, 27);
            txtObjetivoCalorico.TabIndex = 19;
            // 
          
            txtCintura.Location = new Point(327, 42);
            txtCintura.Name = "txtCintura";
            txtCintura.Size = new Size(135, 27);
            txtCintura.TabIndex = 17;
            // 
            
            txtPecho.Location = new Point(327, 86);
            txtPecho.Name = "txtPecho";
            txtPecho.Size = new Size(135, 27);
            txtPecho.TabIndex = 18;
            // 
           
            label7.AutoSize = true;
            label7.Location = new Point(251, 49);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 14;
            label7.Text = "Cintura:";
            // 
            
            label8.AutoSize = true;
            label8.Location = new Point(248, 89);
            label8.Name = "label8";
            label8.Size = new Size(51, 20);
            label8.TabIndex = 15;
            label8.Text = "Pecho:";
            // 
            
            label9.AutoSize = true;
            label9.Location = new Point(248, 134);
            label9.Name = "label9";
            label9.Size = new Size(95, 20);
            label9.TabIndex = 16;
            label9.Text = "Obj Calorico:";
            // 
           
            txtGluteo.Location = new Point(103, 127);
            txtGluteo.Name = "txtGluteo";
            txtGluteo.Size = new Size(135, 27);
            txtGluteo.TabIndex = 13;
            // 
           
            txtBrazo.Location = new Point(103, 42);
            txtBrazo.Name = "txtBrazo";
            txtBrazo.Size = new Size(135, 27);
            txtBrazo.TabIndex = 11;
            // 
            
            txtPierna.Location = new Point(103, 86);
            txtPierna.Name = "txtPierna";
            txtPierna.Size = new Size(135, 27);
            txtPierna.TabIndex = 12;
            // 
           
            label6.AutoSize = true;
            label6.Location = new Point(27, 49);
            label6.Name = "label6";
            label6.Size = new Size(56, 20);
            label6.TabIndex = 8;
            label6.Text = "Brazos:";
            // 
            
            label5.AutoSize = true;
            label5.Location = new Point(24, 89);
            label5.Name = "label5";
            label5.Size = new Size(59, 20);
            label5.TabIndex = 9;
            label5.Text = "Piernas:";
            // 
            
            label4.AutoSize = true;
            label4.Location = new Point(24, 134);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 10;
            label4.Text = "Glúteos";
            // 
            
            btnGuardar.BackColor = Color.LimeGreen;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.Control;
            btnGuardar.Location = new Point(18, 395);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(506, 37);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Registrar Monitoreo";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
           
            lblNota.AutoSize = true;
            lblNota.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNota.Location = new Point(538, 26);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(195, 31);
            lblNota.TabIndex = 20;
            lblNota.Text = "Calificación: N/A";
            // 
            
            lblRecomendacion.AutoSize = true;
            lblRecomendacion.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecomendacion.Location = new Point(538, 70);
            lblRecomendacion.Name = "lblRecomendacion";
            lblRecomendacion.Size = new Size(240, 25);
            lblRecomendacion.TabIndex = 21;
            lblRecomendacion.Text = "Recomendación: En espera";
            // 
            
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(36, 447);
            label12.Name = "label12";
            label12.Size = new Size(233, 31);
            label12.TabIndex = 22;
            label12.Text = "Historial y progreso ";
            // 
            
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(24, 487);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.Size = new Size(808, 174);
            dgvHistorial.TabIndex = 23;
            // 
            
            lblIMC.AutoSize = true;
            lblIMC.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIMC.Location = new Point(292, 70);
            lblIMC.Name = "lblIMC";
            lblIMC.Size = new Size(225, 31);
            lblIMC.TabIndex = 24;
            lblIMC.Text = "IMC Calculado: 0.00";
            // 
           
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 706);
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
    }
}
