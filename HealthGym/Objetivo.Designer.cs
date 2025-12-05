namespace HealthGym
{
    partial class Objetivo
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
            dgvObjetivo = new DataGridView();
            gboObjetivo = new GroupBox();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            label5 = new Label();
            cboMusculo = new ComboBox();
            txtTamano = new TextBox();
            label4 = new Label();
            lblNombre = new Label();
            label2 = new Label();
            txtDNI = new TextBox();
            label1 = new Label();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvObjetivo).BeginInit();
            gboObjetivo.SuspendLayout();
            SuspendLayout();
            // 
            // dgvObjetivo
            // 
            dgvObjetivo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvObjetivo.Location = new Point(26, 12);
            dgvObjetivo.Name = "dgvObjetivo";
            dgvObjetivo.Size = new Size(262, 426);
            dgvObjetivo.TabIndex = 0;
            // 
            // gboObjetivo
            // 
            gboObjetivo.Controls.Add(btnEliminar);
            gboObjetivo.Controls.Add(btnEditar);
            gboObjetivo.Controls.Add(btnGuardar);
            gboObjetivo.Controls.Add(label5);
            gboObjetivo.Controls.Add(cboMusculo);
            gboObjetivo.Controls.Add(txtTamano);
            gboObjetivo.Controls.Add(label4);
            gboObjetivo.Controls.Add(lblNombre);
            gboObjetivo.Controls.Add(label2);
            gboObjetivo.Location = new Point(304, 104);
            gboObjetivo.Name = "gboObjetivo";
            gboObjetivo.Size = new Size(367, 334);
            gboObjetivo.TabIndex = 1;
            gboObjetivo.TabStop = false;
            gboObjetivo.Text = "Información de Objetivo:";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.ForeColor = Color.Transparent;
            btnEliminar.Location = new Point(130, 299);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(125, 29);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(129, 265);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(125, 23);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(130, 232);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 23);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 162);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 10;
            label5.Text = "Tamaño esperado:";
            // 
            // cboMusculo
            // 
            cboMusculo.FormattingEnabled = true;
            cboMusculo.Location = new Point(69, 121);
            cboMusculo.Name = "cboMusculo";
            cboMusculo.Size = new Size(121, 23);
            cboMusculo.TabIndex = 9;
            // 
            // txtTamano
            // 
            txtTamano.Location = new Point(69, 192);
            txtTamano.Name = "txtTamano";
            txtTamano.Size = new Size(100, 23);
            txtTamano.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 92);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 7;
            label4.Text = "Músculo:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(69, 62);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "Nombre ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 31);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 5;
            label2.Text = "Nombre del miembro:";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(373, 44);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(165, 23);
            txtDNI.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(314, 20);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 3;
            label1.Text = "Ingrese DNI del miembro";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(551, 75);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(104, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // Objetivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 450);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Controls.Add(txtDNI);
            Controls.Add(gboObjetivo);
            Controls.Add(dgvObjetivo);
            Name = "Objetivo";
            Text = "Objetivo";
            ((System.ComponentModel.ISupportInitialize)dgvObjetivo).EndInit();
            gboObjetivo.ResumeLayout(false);
            gboObjetivo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvObjetivo;
        private GroupBox gboObjetivo;
        private Label label4;
        private Label lblNombre;
        private Label label2;
        private TextBox txtDNI;
        private Label label1;
        private Button btnBuscar;
        private Label label5;
        private ComboBox cboMusculo;
        private TextBox txtTamano;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
    }
}