namespace HealthGym.Consultas
{
    partial class ConsultarPlanes
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
            Btn_Cargar = new Button();
            Cbox_Planes = new ComboBox();
            DGV = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // Tbox_DNI
            // 
            Tbox_DNI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tbox_DNI.Location = new Point(12, 12);
            Tbox_DNI.Name = "Tbox_DNI";
            Tbox_DNI.Size = new Size(132, 29);
            Tbox_DNI.TabIndex = 0;
            // 
            // Btn_Cargar
            // 
            Btn_Cargar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Cargar.Location = new Point(12, 47);
            Btn_Cargar.Name = "Btn_Cargar";
            Btn_Cargar.Size = new Size(132, 30);
            Btn_Cargar.TabIndex = 1;
            Btn_Cargar.Text = "Cargar";
            Btn_Cargar.UseVisualStyleBackColor = true;
            Btn_Cargar.Click += Btn_Cargar_Click;
            // 
            // Cbox_Planes
            // 
            Cbox_Planes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cbox_Planes.FormattingEnabled = true;
            Cbox_Planes.Location = new Point(12, 83);
            Cbox_Planes.Name = "Cbox_Planes";
            Cbox_Planes.Size = new Size(132, 29);
            Cbox_Planes.TabIndex = 2;
            Cbox_Planes.SelectedIndexChanged += Cbox_Planes_SelectedIndexChanged;
            // 
            // DGV
            // 
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(150, 12);
            DGV.Name = "DGV";
            DGV.Size = new Size(638, 426);
            DGV.TabIndex = 3;
            // 
            // ConsultarPlanes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DGV);
            Controls.Add(Cbox_Planes);
            Controls.Add(Btn_Cargar);
            Controls.Add(Tbox_DNI);
            Name = "ConsultarPlanes";
            Text = "ConsultarPlanes";
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Tbox_DNI;
        private Button Btn_Cargar;
        private ComboBox Cbox_Planes;
        private DataGridView DGV;
    }
}