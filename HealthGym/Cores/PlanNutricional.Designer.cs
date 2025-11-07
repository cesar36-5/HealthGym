namespace HealthGym.CORE
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
            dataGridView1 = new DataGridView();
            Lunes = new DataGridViewTextBoxColumn();
            Martes = new DataGridViewTextBoxColumn();
            Miercoles = new DataGridViewTextBoxColumn();
            Jueves = new DataGridViewTextBoxColumn();
            Viernes = new DataGridViewTextBoxColumn();
            Sábado = new DataGridViewTextBoxColumn();
            Domingo = new DataGridViewTextBoxColumn();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Lunes, Martes, Miercoles, Jueves, Viernes, Sábado, Domingo });
            dataGridView1.Location = new Point(36, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(740, 218);
            dataGridView1.TabIndex = 0;
            // 
            // Lunes
            // 
            Lunes.HeaderText = "Lunes";
            Lunes.Name = "Lunes";
            // 
            // Martes
            // 
            Martes.HeaderText = "Martes";
            Martes.Name = "Martes";
            // 
            // Miercoles
            // 
            Miercoles.HeaderText = "Miércoles";
            Miercoles.Name = "Miercoles";
            // 
            // Jueves
            // 
            Jueves.HeaderText = "Jueves";
            Jueves.Name = "Jueves";
            // 
            // Viernes
            // 
            Viernes.HeaderText = "Viernes";
            Viernes.Name = "Viernes";
            // 
            // Sábado
            // 
            Sábado.HeaderText = "Sábado";
            Sábado.Name = "Sábado";
            // 
            // Domingo
            // 
            Domingo.HeaderText = "Domingo";
            Domingo.Name = "Domingo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 250);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 1;
            label1.Text = "DNI del miembro:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 247);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(172, 23);
            textBox1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(347, 250);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 8;
            label2.Text = "Nombre del Miembro:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(478, 250);
            label3.Name = "label3";
            label3.Size = new Size(136, 15);
            label3.TabIndex = 9;
            label3.Text = "NOMBRE DEL MIEMBRO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 284);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 10;
            label4.Text = "Alimento:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(86, 281);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(430, 23);
            textBox2.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(587, 281);
            button2.Name = "button2";
            button2.Size = new Size(175, 23);
            button2.TabIndex = 12;
            button2.Text = "Modificar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(211, 320);
            button1.Name = "button1";
            button1.Size = new Size(415, 23);
            button1.TabIndex = 13;
            button1.Text = "Guardar Plan Nutricional";
            button1.UseVisualStyleBackColor = true;
            // 
            // PlanNutricional
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 354);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "PlanNutricional";
            Text = "PlanNutricional";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Lunes;
        private DataGridViewTextBoxColumn Martes;
        private DataGridViewTextBoxColumn Miercoles;
        private DataGridViewTextBoxColumn Jueves;
        private DataGridViewTextBoxColumn Viernes;
        private DataGridViewTextBoxColumn Sábado;
        private DataGridViewTextBoxColumn Domingo;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Button button2;
        private Button button1;
    }
}