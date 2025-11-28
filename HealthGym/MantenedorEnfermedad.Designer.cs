namespace HealthGym
{
    partial class MantenedorEnfermedad
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
            dgvEnfermedad = new DataGridView();
            dgvEnfermedadMusculo = new DataGridView();
            label1 = new Label();
            btnAgregar = new Button();
            txtNombre = new TextBox();
            btnAgregarMusculo = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            cbMusculos = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvEnfermedad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEnfermedadMusculo).BeginInit();
            SuspendLayout();
            // 
            // dgvEnfermedad
            // 
            dgvEnfermedad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnfermedad.Location = new Point(12, 12);
            dgvEnfermedad.Name = "dgvEnfermedad";
            dgvEnfermedad.RowHeadersWidth = 51;
            dgvEnfermedad.Size = new Size(524, 389);
            dgvEnfermedad.TabIndex = 0;
            // 
            // dgvEnfermedadMusculo
            // 
            dgvEnfermedadMusculo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnfermedadMusculo.Location = new Point(562, 12);
            dgvEnfermedadMusculo.Name = "dgvEnfermedadMusculo";
            dgvEnfermedadMusculo.RowHeadersWidth = 51;
            dgvEnfermedadMusculo.Size = new Size(516, 389);
            dgvEnfermedadMusculo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 441);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 2;
            label1.Text = "Nombre:";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(400, 436);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(97, 438);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(229, 27);
            txtNombre.TabIndex = 5;
            // 
            // btnAgregarMusculo
            // 
            btnAgregarMusculo.Location = new Point(939, 422);
            btnAgregarMusculo.Name = "btnAgregarMusculo";
            btnAgregarMusculo.Size = new Size(94, 29);
            btnAgregarMusculo.TabIndex = 7;
            btnAgregarMusculo.Text = "Agregar";
            btnAgregarMusculo.UseVisualStyleBackColor = true;
            btnAgregarMusculo.Click += btnAgregarMusculo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(400, 493);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(939, 473);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(400, 547);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // cbMusculos
            // 
            cbMusculos.FormattingEnabled = true;
            cbMusculos.Location = new Point(592, 423);
            cbMusculos.Name = "cbMusculos";
            cbMusculos.Size = new Size(271, 28);
            cbMusculos.TabIndex = 11;
            // 
            // MantenedorEnfermedad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 629);
            Controls.Add(cbMusculos);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregarMusculo);
            Controls.Add(txtNombre);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(dgvEnfermedadMusculo);
            Controls.Add(dgvEnfermedad);
            Name = "MantenedorEnfermedad";
            Text = "MantenedorEnfermeda";
            ((System.ComponentModel.ISupportInitialize)dgvEnfermedad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEnfermedadMusculo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEnfermedad;
        private DataGridView dgvEnfermedadMusculo;
        private Label label1;
        private Button btnAgregar;
        private TextBox txtNombre;
        private Button btnAgregarMusculo;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnModificar;
        private ComboBox cbMusculos;
    }
}