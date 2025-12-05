namespace HealthGym
{
    partial class MantenedorAlergia
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
            dgvAlergia = new DataGridView();
            label1 = new Label();
            txtNombre = new TextBox();
            btnAñadir = new Button();
            btnEditar = new Button();
            btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlergia).BeginInit();
            SuspendLayout();
            // 
            // dgvAlergia
            // 
            dgvAlergia.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAlergia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlergia.Location = new Point(12, 12);
            dgvAlergia.Name = "dgvAlergia";
            dgvAlergia.RowHeadersWidth = 51;
            dgvAlergia.Size = new Size(655, 349);
            dgvAlergia.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 382);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(104, 380);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 2;
            // 
            // btnAñadir
            // 
            btnAñadir.BackColor = SystemColors.ActiveCaption;
            btnAñadir.Location = new Point(336, 378);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(94, 29);
            btnAñadir.TabIndex = 3;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = false;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = SystemColors.ActiveCaption;
            btnEditar.Location = new Point(445, 379);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.ActiveCaption;
            btnModificar.Location = new Point(557, 378);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // MantenedorAlergia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 469);
            Controls.Add(btnModificar);
            Controls.Add(btnEditar);
            Controls.Add(btnAñadir);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(dgvAlergia);
            Name = "MantenedorAlergia";
            Text = "MantenedorAlergia";
            ((System.ComponentModel.ISupportInitialize)dgvAlergia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAlergia;
        private Label label1;
        private TextBox txtNombre;
        private Button btnAñadir;
        private Button btnEditar;
        private Button btnModificar;
    }
}