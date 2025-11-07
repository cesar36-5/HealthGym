namespace HealthGym
{
    partial class MenuPlaceholder
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(431, 105);
            button1.Name = "button1";
            button1.Size = new Size(102, 32);
            button1.TabIndex = 0;
            button1.Text = "Alimentos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(431, 143);
            button2.Name = "button2";
            button2.Size = new Size(102, 32);
            button2.TabIndex = 1;
            button2.Text = "Enfermedades";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(431, 181);
            button3.Name = "button3";
            button3.Size = new Size(102, 32);
            button3.TabIndex = 2;
            button3.Text = "Objetivos";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(539, 105);
            button4.Name = "button4";
            button4.Size = new Size(102, 32);
            button4.TabIndex = 3;
            button4.Text = "Evaluacion";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(539, 143);
            button5.Name = "button5";
            button5.Size = new Size(102, 32);
            button5.TabIndex = 4;
            button5.Text = "Monitoreo";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(539, 181);
            button6.Name = "button6";
            button6.Size = new Size(102, 50);
            button6.TabIndex = 5;
            button6.Text = "Plan nutricional";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.Location = new Point(431, 219);
            button7.Name = "button7";
            button7.Size = new Size(102, 32);
            button7.TabIndex = 6;
            button7.Text = "Alergias";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // MenuPlaceholder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Propuesta_gatitos;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(717, 450);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MenuPlaceholder";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
