namespace HealthGym.Mantenedores
{
    partial class Recetas
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
            groupBox1 = new GroupBox();
            Lbl_Alimento = new Label();
            label6 = new Label();
            Btn_MatEdit = new Button();
            Btn_MatAdd = new Button();
            Tbox_Medida = new TextBox();
            Tbox_Cantidad = new TextBox();
            Tbox_Material = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Tbox_Paso = new TextBox();
            label5 = new Label();
            label4 = new Label();
            Dgv_Mats = new DataGridView();
            Dgv_Pasos = new DataGridView();
            Dgv_Alimentos = new DataGridView();
            groupBox2 = new GroupBox();
            Tbox_Instruccion = new TextBox();
            Btn_PasEdit = new Button();
            Btn_PasAdd = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_Mats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Dgv_Pasos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Dgv_Alimentos).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Lbl_Alimento);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(Btn_MatEdit);
            groupBox1.Controls.Add(Btn_MatAdd);
            groupBox1.Controls.Add(Tbox_Medida);
            groupBox1.Controls.Add(Tbox_Cantidad);
            groupBox1.Controls.Add(Tbox_Material);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(336, 155);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(452, 199);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalle de Materiales";
            // 
            // Lbl_Alimento
            // 
            Lbl_Alimento.AutoSize = true;
            Lbl_Alimento.Location = new Point(94, 24);
            Lbl_Alimento.Name = "Lbl_Alimento";
            Lbl_Alimento.Size = new Size(117, 15);
            Lbl_Alimento.TabIndex = 11;
            Lbl_Alimento.Text = "NOMBRE ALIMENTO";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 24);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 10;
            label6.Text = "Alimento:";
            // 
            // Btn_MatEdit
            // 
            Btn_MatEdit.Location = new Point(241, 160);
            Btn_MatEdit.Name = "Btn_MatEdit";
            Btn_MatEdit.Size = new Size(175, 23);
            Btn_MatEdit.TabIndex = 5;
            Btn_MatEdit.Text = "Modificar";
            Btn_MatEdit.UseVisualStyleBackColor = true;
            Btn_MatEdit.Click += Btn_MatEdit_Click;
            // 
            // Btn_MatAdd
            // 
            Btn_MatAdd.Location = new Point(43, 160);
            Btn_MatAdd.Name = "Btn_MatAdd";
            Btn_MatAdd.Size = new Size(175, 23);
            Btn_MatAdd.TabIndex = 4;
            Btn_MatAdd.Text = "Agregar";
            Btn_MatAdd.UseVisualStyleBackColor = true;
            Btn_MatAdd.Click += Btn_MatAdd_Click;
            // 
            // Tbox_Medida
            // 
            Tbox_Medida.Location = new Point(93, 122);
            Tbox_Medida.Name = "Tbox_Medida";
            Tbox_Medida.Size = new Size(189, 23);
            Tbox_Medida.TabIndex = 7;
            Tbox_Medida.TextChanged += textBox3_TextChanged;
            // 
            // Tbox_Cantidad
            // 
            Tbox_Cantidad.Location = new Point(93, 88);
            Tbox_Cantidad.Name = "Tbox_Cantidad";
            Tbox_Cantidad.Size = new Size(189, 23);
            Tbox_Cantidad.TabIndex = 6;
            // 
            // Tbox_Material
            // 
            Tbox_Material.Location = new Point(93, 54);
            Tbox_Material.Name = "Tbox_Material";
            Tbox_Material.Size = new Size(344, 23);
            Tbox_Material.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 125);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 2;
            label3.Text = "Medida:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 91);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Cantidad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 57);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Material:";
            // 
            // Tbox_Paso
            // 
            Tbox_Paso.Location = new Point(93, 25);
            Tbox_Paso.Name = "Tbox_Paso";
            Tbox_Paso.Size = new Size(189, 23);
            Tbox_Paso.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 61);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 4;
            label5.Text = "Instrucción:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 28);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 3;
            label4.Text = "Paso:";
            // 
            // Dgv_Mats
            // 
            Dgv_Mats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Mats.Location = new Point(12, 12);
            Dgv_Mats.Name = "Dgv_Mats";
            Dgv_Mats.Size = new Size(318, 256);
            Dgv_Mats.TabIndex = 1;
            Dgv_Mats.CellDoubleClick += Dgv_Mats_CellDoubleClick;
            // 
            // Dgv_Pasos
            // 
            Dgv_Pasos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Pasos.Location = new Point(12, 274);
            Dgv_Pasos.Name = "Dgv_Pasos";
            Dgv_Pasos.Size = new Size(318, 256);
            Dgv_Pasos.TabIndex = 2;
            Dgv_Pasos.CellDoubleClick += Dgv_Pasos_CellDoubleClick;
            // 
            // Dgv_Alimentos
            // 
            Dgv_Alimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Alimentos.Location = new Point(336, 12);
            Dgv_Alimentos.Name = "Dgv_Alimentos";
            Dgv_Alimentos.Size = new Size(452, 139);
            Dgv_Alimentos.TabIndex = 3;
            Dgv_Alimentos.CellDoubleClick += Dgv_Alimentos_CellDoubleClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Tbox_Instruccion);
            groupBox2.Controls.Add(Btn_PasEdit);
            groupBox2.Controls.Add(Btn_PasAdd);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(Tbox_Paso);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(336, 363);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(452, 168);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle Pasos:";
            // 
            // Tbox_Instruccion
            // 
            Tbox_Instruccion.Location = new Point(104, 61);
            Tbox_Instruccion.Multiline = true;
            Tbox_Instruccion.Name = "Tbox_Instruccion";
            Tbox_Instruccion.ScrollBars = ScrollBars.Vertical;
            Tbox_Instruccion.Size = new Size(312, 68);
            Tbox_Instruccion.TabIndex = 12;
            // 
            // Btn_PasEdit
            // 
            Btn_PasEdit.Location = new Point(241, 135);
            Btn_PasEdit.Name = "Btn_PasEdit";
            Btn_PasEdit.Size = new Size(175, 23);
            Btn_PasEdit.TabIndex = 11;
            Btn_PasEdit.Text = "Modificar";
            Btn_PasEdit.UseVisualStyleBackColor = true;
            Btn_PasEdit.Click += Btn_PasEdit_Click;
            // 
            // Btn_PasAdd
            // 
            Btn_PasAdd.Location = new Point(43, 135);
            Btn_PasAdd.Name = "Btn_PasAdd";
            Btn_PasAdd.Size = new Size(175, 23);
            Btn_PasAdd.TabIndex = 11;
            Btn_PasAdd.Text = "Agregar";
            Btn_PasAdd.UseVisualStyleBackColor = true;
            Btn_PasAdd.Click += Btn_PasAdd_Click;
            // 
            // Recetas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 541);
            Controls.Add(groupBox2);
            Controls.Add(Dgv_Alimentos);
            Controls.Add(Dgv_Pasos);
            Controls.Add(Dgv_Mats);
            Controls.Add(groupBox1);
            Name = "Recetas";
            Text = "D";
            Load += Recetas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_Mats).EndInit();
            ((System.ComponentModel.ISupportInitialize)Dgv_Pasos).EndInit();
            ((System.ComponentModel.ISupportInitialize)Dgv_Alimentos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView Dgv_Mats;
        private DataGridView Dgv_Pasos;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView Dgv_Alimentos;
        private TextBox Tbox_Paso;
        private TextBox Tbox_Medida;
        private TextBox Tbox_Cantidad;
        private TextBox Tbox_Material;
        private Button Btn_MatEdit;
        private Button Btn_MatAdd;
        private Label label6;
        private GroupBox groupBox2;
        private Button Btn_PasEdit;
        private Button Btn_PasAdd;
        private Label Lbl_Alimento;
        private TextBox Tbox_Instruccion;
    }
}