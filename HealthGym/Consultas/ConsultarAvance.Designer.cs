namespace HealthGym.Consultas
{
    partial class ConsultarAvance
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
            button1 = new Button();
            DGV = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // Tbox_DNI
            // 
            Tbox_DNI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tbox_DNI.Location = new Point(12, 12);
            Tbox_DNI.Name = "Tbox_DNI";
            Tbox_DNI.Size = new Size(128, 29);
            Tbox_DNI.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(146, 10);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 1;
            button1.Text = "Cargar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DGV
            // 
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(12, 47);
            DGV.Name = "DGV";
            DGV.Size = new Size(776, 391);
            DGV.TabIndex = 2;
            // 
            // ConsultarAvance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DGV);
            Controls.Add(button1);
            Controls.Add(Tbox_DNI);
            Name = "ConsultarAvance";
            Text = "ConsultarAvance";
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Tbox_DNI;
        private Button button1;
        private DataGridView DGV;
    }
}