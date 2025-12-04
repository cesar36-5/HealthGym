namespace HealthGym
{
    partial class Platillo
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            gboPlatillo = new GroupBox();
            txtProteinas = new TextBox();
            txtGrasas = new TextBox();
            txtCarbohidratos = new TextBox();
            txtCalorias = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnEditar = new Button();
            btnGuardar = new Button();
            dgvPlatillo = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            gboPlatillo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlatillo).BeginInit();
            SuspendLayout();
            // 
            // gboPlatillo
            // 
            gboPlatillo.Controls.Add(label9);
            gboPlatillo.Controls.Add(label8);
            gboPlatillo.Controls.Add(label7);
            gboPlatillo.Controls.Add(label6);
            gboPlatillo.Controls.Add(txtProteinas);
            gboPlatillo.Controls.Add(txtGrasas);
            gboPlatillo.Controls.Add(txtCarbohidratos);
            gboPlatillo.Controls.Add(txtCalorias);
            gboPlatillo.Controls.Add(txtNombre);
            gboPlatillo.Controls.Add(label5);
            gboPlatillo.Controls.Add(label4);
            gboPlatillo.Controls.Add(label3);
            gboPlatillo.Controls.Add(label2);
            gboPlatillo.Controls.Add(label1);
            gboPlatillo.Controls.Add(btnEditar);
            gboPlatillo.Controls.Add(btnGuardar);
            gboPlatillo.Location = new Point(390, 12);
            gboPlatillo.Name = "gboPlatillo";
            gboPlatillo.Size = new Size(398, 397);
            gboPlatillo.TabIndex = 0;
            gboPlatillo.TabStop = false;
            gboPlatillo.Text = "Datos del platillo";
            // 
            // txtProteinas
            // 
            txtProteinas.Location = new Point(56, 326);
            txtProteinas.Name = "txtProteinas";
            txtProteinas.Size = new Size(213, 23);
            txtProteinas.TabIndex = 15;
            // 
            // txtGrasas
            // 
            txtGrasas.Location = new Point(56, 266);
            txtGrasas.Name = "txtGrasas";
            txtGrasas.Size = new Size(213, 23);
            txtGrasas.TabIndex = 14;
            // 
            // txtCarbohidratos
            // 
            txtCarbohidratos.Location = new Point(56, 198);
            txtCarbohidratos.Name = "txtCarbohidratos";
            txtCarbohidratos.Size = new Size(213, 23);
            txtCarbohidratos.TabIndex = 13;
            // 
            // txtCalorias
            // 
            txtCalorias.Location = new Point(56, 127);
            txtCalorias.Name = "txtCalorias";
            txtCalorias.Size = new Size(213, 23);
            txtCalorias.TabIndex = 12;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(56, 60);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(297, 23);
            txtNombre.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 303);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 10;
            label5.Text = "Proteinas:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 239);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "Grasas:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 169);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 8;
            label3.Text = "Carbohidratos:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 99);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 7;
            label2.Text = "Calorías:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 31);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 6;
            label1.Text = "Nombre:";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(200, 364);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(185, 23);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(6, 364);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(185, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dgvPlatillo
            // 
            dgvPlatillo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatillo.Location = new Point(12, 12);
            dgvPlatillo.Name = "dgvPlatillo";
            dgvPlatillo.Size = new Size(372, 426);
            dgvPlatillo.TabIndex = 1;
            dgvPlatillo.CellDoubleClick += dgvPlatillo_CellDoubleClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(399, 415);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(185, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(590, 415);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(185, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(274, 131);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 16;
            label6.Text = "kcal.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(274, 202);
            label7.Name = "label7";
            label7.Size = new Size(17, 15);
            label7.TabIndex = 17;
            label7.Text = "g.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(274, 270);
            label8.Name = "label8";
            label8.Size = new Size(17, 15);
            label8.TabIndex = 18;
            label8.Text = "g.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(274, 331);
            label9.Name = "label9";
            label9.Size = new Size(17, 15);
            label9.TabIndex = 19;
            label9.Text = "g.";
            // 
            // Platillo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPlatillo);
            Controls.Add(gboPlatillo);
            Name = "Platillo";
            Text = "Platillo";
            gboPlatillo.ResumeLayout(false);
            gboPlatillo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlatillo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox gboPlatillo;
        private DataGridView dgvPlatillo;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnAgregar;
        private Button btnModificar;
        private TextBox txtProteinas;
        private TextBox txtGrasas;
        private TextBox txtCarbohidratos;
        private TextBox txtCalorias;
        private TextBox txtNombre;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label9;
        private Label label8;
        private Label label7;
    }
}