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
            label1 = new Label();
            txtNombre = new TextBox();
            btnAñadir = new Button();
            btnEditar = new Button();
            btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEnfermedad).BeginInit();
            SuspendLayout();
            // 
            // dgvEnfermedad
            // 
            dgvEnfermedad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnfermedad.Location = new Point(12, 12);
            dgvEnfermedad.Name = "dgvEnfermedad";
            dgvEnfermedad.RowHeadersWidth = 51;
            dgvEnfermedad.Size = new Size(653, 269);
            dgvEnfermedad.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 303);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(149, 304);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 2;
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(415, 304);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(94, 29);
            btnAñadir.TabIndex = 3;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(415, 354);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(415, 402);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // MantenedorEnfermedad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 487);
            Controls.Add(btnModificar);
            Controls.Add(btnEditar);
            Controls.Add(btnAñadir);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(dgvEnfermedad);
            Name = "MantenedorEnfermedad";
            Text = "MantenedorEnfermedad";
            ((System.ComponentModel.ISupportInitialize)dgvEnfermedad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEnfermedad;
        private Label label1;
        private TextBox txtNombre;
        private Button btnAñadir;
        private Button btnEditar;
        private Button btnModificar;
    }
}