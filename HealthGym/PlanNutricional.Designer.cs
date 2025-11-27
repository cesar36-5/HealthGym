namespace HealthGym
{
    partial class PlanNutricional
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
            Tbox_DNI = new TextBox();
            label1 = new Label();
            Btn_Cargar = new Button();
            Dgv_Plan = new DataGridView();
            Gbox = new GroupBox();
            Btn_Guardar = new Button();
            Cbox_Platillo = new ComboBox();
            label6 = new Label();
            Lbl_protes = new Label();
            Lbl_papu = new Label();
            Lbl_carbos = new Label();
            Lbl_Calorias = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)Dgv_Plan).BeginInit();
            Gbox.SuspendLayout();
            SuspendLayout();
            // 
            // Tbox_DNI
            // 
            Tbox_DNI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tbox_DNI.Location = new Point(55, 6);
            Tbox_DNI.Name = "Tbox_DNI";
            Tbox_DNI.Size = new Size(83, 29);
            Tbox_DNI.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(37, 21);
            label1.TabIndex = 1;
            label1.Text = "DNI";
            // 
            // Btn_Cargar
            // 
            Btn_Cargar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Cargar.Location = new Point(144, 6);
            Btn_Cargar.Name = "Btn_Cargar";
            Btn_Cargar.Size = new Size(75, 33);
            Btn_Cargar.TabIndex = 2;
            Btn_Cargar.Text = "Cargar";
            Btn_Cargar.UseVisualStyleBackColor = true;
            Btn_Cargar.Click += Btn_Cargar_Click;
            // 
            // Dgv_Plan
            // 
            Dgv_Plan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Plan.Location = new Point(225, 6);
            Dgv_Plan.Name = "Dgv_Plan";
            Dgv_Plan.Size = new Size(563, 432);
            Dgv_Plan.TabIndex = 3;
            // 
            // Gbox
            // 
            Gbox.Controls.Add(label2);
            Gbox.Controls.Add(Btn_Guardar);
            Gbox.Controls.Add(Cbox_Platillo);
            Gbox.Controls.Add(label6);
            Gbox.Controls.Add(Lbl_protes);
            Gbox.Controls.Add(Lbl_papu);
            Gbox.Controls.Add(Lbl_carbos);
            Gbox.Controls.Add(Lbl_Calorias);
            Gbox.Controls.Add(comboBox1);
            Gbox.Location = new Point(12, 45);
            Gbox.Name = "Gbox";
            Gbox.Size = new Size(200, 393);
            Gbox.TabIndex = 4;
            Gbox.TabStop = false;
            // 
            // Btn_Guardar
            // 
            Btn_Guardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Guardar.Location = new Point(6, 354);
            Btn_Guardar.Name = "Btn_Guardar";
            Btn_Guardar.Size = new Size(188, 33);
            Btn_Guardar.TabIndex = 5;
            Btn_Guardar.Text = "Guardar";
            Btn_Guardar.UseVisualStyleBackColor = true;
            // 
            // Cbox_Platillo
            // 
            Cbox_Platillo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cbox_Platillo.FormattingEnabled = true;
            Cbox_Platillo.Location = new Point(6, 262);
            Cbox_Platillo.Name = "Cbox_Platillo";
            Cbox_Platillo.Size = new Size(188, 29);
            Cbox_Platillo.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 238);
            label6.Name = "label6";
            label6.Size = new Size(60, 21);
            label6.TabIndex = 5;
            label6.Text = "Platillo:";
            // 
            // Lbl_protes
            // 
            Lbl_protes.AutoSize = true;
            Lbl_protes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_protes.Location = new Point(6, 177);
            Lbl_protes.Name = "Lbl_protes";
            Lbl_protes.Size = new Size(78, 21);
            Lbl_protes.TabIndex = 4;
            Lbl_protes.Text = "Proteinas:";
            // 
            // Lbl_papu
            // 
            Lbl_papu.AutoSize = true;
            Lbl_papu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_papu.Location = new Point(6, 156);
            Lbl_papu.Name = "Lbl_papu";
            Lbl_papu.Size = new Size(60, 21);
            Lbl_papu.TabIndex = 3;
            Lbl_papu.Text = "Grasas:";
            // 
            // Lbl_carbos
            // 
            Lbl_carbos.AutoSize = true;
            Lbl_carbos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_carbos.Location = new Point(6, 135);
            Lbl_carbos.Name = "Lbl_carbos";
            Lbl_carbos.Size = new Size(112, 21);
            Lbl_carbos.TabIndex = 2;
            Lbl_carbos.Text = "Carbohidratos:";
            // 
            // Lbl_Calorias
            // 
            Lbl_Calorias.AutoSize = true;
            Lbl_Calorias.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Calorias.Location = new Point(5, 114);
            Lbl_Calorias.Name = "Lbl_Calorias";
            Lbl_Calorias.Size = new Size(69, 21);
            Lbl_Calorias.TabIndex = 1;
            Lbl_Calorias.Text = "Calorias:";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(188, 29);
            comboBox1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 7;
            label2.Text = "Nombre";
            // 
            // PlanNutricional
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Gbox);
            Controls.Add(Dgv_Plan);
            Controls.Add(Btn_Cargar);
            Controls.Add(label1);
            Controls.Add(Tbox_DNI);
            Name = "PlanNutricional";
            Text = "PlanNutricional";
            Load += PlanNutricional_Load;
            ((System.ComponentModel.ISupportInitialize)Dgv_Plan).EndInit();
            Gbox.ResumeLayout(false);
            Gbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Tbox_DNI;
        private Label label1;
        private Button Btn_Cargar;
        private DataGridView Dgv_Plan;
        private GroupBox Gbox;
        private Button Btn_Guardar;
        private ComboBox Cbox_Platillo;
        private Label label6;
        private Label Lbl_protes;
        private Label Lbl_papu;
        private Label Lbl_carbos;
        private Label Lbl_Calorias;
        private ComboBox comboBox1;
        private Label label2;
    }
}