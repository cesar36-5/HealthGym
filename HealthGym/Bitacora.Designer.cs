namespace HealthGym
{
    partial class Bitacora
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
            groupBox1 = new GroupBox();
            Lbl_Edad = new Label();
            Lbl_Sexo = new Label();
            Lbl_Nombre = new Label();
            groupBox2 = new GroupBox();
            btnRegistar = new Button();
            button2 = new Button();
            labelCalObje = new Label();
            label4 = new Label();
            label28 = new Label();
            label27 = new Label();
            label26 = new Label();
            label25 = new Label();
            label24 = new Label();
            txtPecho = new TextBox();
            txtBrazo = new TextBox();
            txtGluteo = new TextBox();
            txtCintura = new TextBox();
            txtPierna = new TextBox();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            cboFrecuencia = new ComboBox();
            label16 = new Label();
            cboNivel = new ComboBox();
            label15 = new Label();
            lbCalimc = new Label();
            lbImc = new Label();
            label14 = new Label();
            txtEstatura = new TextBox();
            label13 = new Label();
            label12 = new Label();
            txtPeso = new TextBox();
            label11 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Tbox_DNI
            // 
            Tbox_DNI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tbox_DNI.Location = new Point(12, 12);
            Tbox_DNI.Name = "Tbox_DNI";
            Tbox_DNI.Size = new Size(119, 29);
            Tbox_DNI.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(137, 7);
            button1.Name = "button1";
            button1.Size = new Size(90, 34);
            button1.TabIndex = 1;
            button1.Text = "Cargar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Lbl_Edad);
            groupBox1.Controls.Add(Lbl_Sexo);
            groupBox1.Controls.Add(Lbl_Nombre);
            groupBox1.Location = new Point(12, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(487, 92);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del miembro";
            // 
            // Lbl_Edad
            // 
            Lbl_Edad.AutoSize = true;
            Lbl_Edad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Edad.Location = new Point(125, 50);
            Lbl_Edad.Name = "Lbl_Edad";
            Lbl_Edad.Size = new Size(47, 21);
            Lbl_Edad.TabIndex = 2;
            Lbl_Edad.Text = "Edad:";
            // 
            // Lbl_Sexo
            // 
            Lbl_Sexo.AutoSize = true;
            Lbl_Sexo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Sexo.Location = new Point(19, 50);
            Lbl_Sexo.Name = "Lbl_Sexo";
            Lbl_Sexo.Size = new Size(46, 21);
            Lbl_Sexo.TabIndex = 1;
            Lbl_Sexo.Text = "Sexo:";
            // 
            // Lbl_Nombre
            // 
            Lbl_Nombre.AutoSize = true;
            Lbl_Nombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Nombre.Location = new Point(19, 20);
            Lbl_Nombre.Name = "Lbl_Nombre";
            Lbl_Nombre.Size = new Size(71, 21);
            Lbl_Nombre.TabIndex = 0;
            Lbl_Nombre.Text = "Nombre:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRegistar);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(labelCalObje);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label28);
            groupBox2.Controls.Add(label27);
            groupBox2.Controls.Add(label26);
            groupBox2.Controls.Add(label25);
            groupBox2.Controls.Add(label24);
            groupBox2.Controls.Add(txtPecho);
            groupBox2.Controls.Add(txtBrazo);
            groupBox2.Controls.Add(txtGluteo);
            groupBox2.Controls.Add(txtCintura);
            groupBox2.Controls.Add(txtPierna);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(cboFrecuencia);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(cboNivel);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(lbCalimc);
            groupBox2.Controls.Add(lbImc);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(txtEstatura);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(txtPeso);
            groupBox2.Controls.Add(label11);
            groupBox2.Location = new Point(12, 145);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(861, 244);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos de la bitacora";
            // 
            // btnRegistar
            // 
            btnRegistar.Location = new Point(757, 204);
            btnRegistar.Margin = new Padding(3, 2, 3, 2);
            btnRegistar.Name = "btnRegistar";
            btnRegistar.Size = new Size(98, 22);
            btnRegistar.TabIndex = 66;
            btnRegistar.Text = "Registrar";
            btnRegistar.UseVisualStyleBackColor = true;
            btnRegistar.Click += btnRegistar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(676, 204);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 65;
            button2.Text = "Calcular";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // labelCalObje
            // 
            labelCalObje.AutoSize = true;
            labelCalObje.Location = new Point(254, 165);
            labelCalObje.Name = "labelCalObje";
            labelCalObje.Size = new Size(69, 15);
            labelCalObje.TabIndex = 64;
            labelCalObje.Text = "ObjetivoCal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(153, 163);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 63;
            label4.Text = "Objetivo Calorico:";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(556, 117);
            label28.Name = "label28";
            label28.Size = new Size(27, 15);
            label28.TabIndex = 62;
            label28.Text = "cm.";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(830, 68);
            label27.Name = "label27";
            label27.Size = new Size(27, 15);
            label27.TabIndex = 61;
            label27.Text = "cm.";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(830, 121);
            label26.Name = "label26";
            label26.Size = new Size(27, 15);
            label26.TabIndex = 60;
            label26.Text = "cm.";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(619, 166);
            label25.Name = "label25";
            label25.Size = new Size(27, 15);
            label25.TabIndex = 59;
            label25.Text = "cm.";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(557, 72);
            label24.Name = "label24";
            label24.Size = new Size(27, 15);
            label24.TabIndex = 58;
            label24.Text = "cm.";
            // 
            // txtPecho
            // 
            txtPecho.Location = new Point(432, 114);
            txtPecho.Margin = new Padding(3, 2, 3, 2);
            txtPecho.Name = "txtPecho";
            txtPecho.Size = new Size(125, 23);
            txtPecho.TabIndex = 57;
            // 
            // txtBrazo
            // 
            txtBrazo.Location = new Point(700, 66);
            txtBrazo.Margin = new Padding(3, 2, 3, 2);
            txtBrazo.Name = "txtBrazo";
            txtBrazo.Size = new Size(128, 23);
            txtBrazo.TabIndex = 56;
            // 
            // txtGluteo
            // 
            txtGluteo.Location = new Point(711, 116);
            txtGluteo.Margin = new Padding(3, 2, 3, 2);
            txtGluteo.Name = "txtGluteo";
            txtGluteo.Size = new Size(118, 23);
            txtGluteo.TabIndex = 55;
            // 
            // txtCintura
            // 
            txtCintura.Location = new Point(498, 163);
            txtCintura.Margin = new Padding(3, 2, 3, 2);
            txtCintura.Name = "txtCintura";
            txtCintura.Size = new Size(121, 23);
            txtCintura.TabIndex = 54;
            // 
            // txtPierna
            // 
            txtPierna.Location = new Point(433, 68);
            txtPierna.Margin = new Padding(3, 2, 3, 2);
            txtPierna.Name = "txtPierna";
            txtPierna.Size = new Size(125, 23);
            txtPierna.TabIndex = 53;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(438, 164);
            label21.Name = "label21";
            label21.Size = new Size(49, 15);
            label21.TabIndex = 52;
            label21.Text = "Cintura:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(650, 71);
            label20.Name = "label20";
            label20.Size = new Size(39, 15);
            label20.TabIndex = 51;
            label20.Text = "Brazo:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(650, 122);
            label19.Name = "label19";
            label19.Size = new Size(50, 15);
            label19.TabIndex = 50;
            label19.Text = "Gluteos:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(378, 116);
            label18.Name = "label18";
            label18.Size = new Size(43, 15);
            label18.TabIndex = 49;
            label18.Text = "Pecho:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(378, 68);
            label17.Name = "label17";
            label17.Size = new Size(43, 15);
            label17.TabIndex = 48;
            label17.Text = "Pierna:";
            // 
            // cboFrecuencia
            // 
            cboFrecuencia.FormattingEnabled = true;
            cboFrecuencia.Location = new Point(166, 116);
            cboFrecuencia.Margin = new Padding(3, 2, 3, 2);
            cboFrecuencia.Name = "cboFrecuencia";
            cboFrecuencia.Size = new Size(117, 23);
            cboFrecuencia.TabIndex = 47;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(12, 122);
            label16.Name = "label16";
            label16.Size = new Size(136, 15);
            label16.TabIndex = 46;
            label16.Text = "Frecuencia de Actividad:";
            // 
            // cboNivel
            // 
            cboNivel.FormattingEnabled = true;
            cboNivel.Location = new Point(143, 66);
            cboNivel.Margin = new Padding(3, 2, 3, 2);
            cboNivel.Name = "cboNivel";
            cboNivel.Size = new Size(140, 23);
            cboNivel.TabIndex = 45;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(12, 68);
            label15.Name = "label15";
            label15.Size = new Size(104, 15);
            label15.TabIndex = 44;
            label15.Text = "Nivel de actividad:";
            // 
            // lbCalimc
            // 
            lbCalimc.AutoSize = true;
            lbCalimc.Location = new Point(513, 26);
            lbCalimc.Name = "lbCalimc";
            lbCalimc.Size = new Size(27, 15);
            lbCalimc.TabIndex = 41;
            lbCalimc.Text = "imc";
            // 
            // lbImc
            // 
            lbImc.AutoSize = true;
            lbImc.Location = new Point(459, 26);
            lbImc.Name = "lbImc";
            lbImc.Size = new Size(32, 15);
            lbImc.TabIndex = 40;
            lbImc.Text = "IMC:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(412, 25);
            label14.Name = "label14";
            label14.Size = new Size(27, 15);
            label14.TabIndex = 16;
            label14.Text = "cm.";
            // 
            // txtEstatura
            // 
            txtEstatura.Location = new Point(287, 23);
            txtEstatura.Margin = new Padding(3, 2, 3, 2);
            txtEstatura.Name = "txtEstatura";
            txtEstatura.Size = new Size(120, 23);
            txtEstatura.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(224, 26);
            label13.Name = "label13";
            label13.Size = new Size(52, 15);
            label13.TabIndex = 14;
            label13.Text = "Estatura:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(198, 26);
            label12.Name = "label12";
            label12.Size = new Size(23, 15);
            label12.TabIndex = 13;
            label12.Text = "kg.";
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(57, 21);
            txtPeso.Margin = new Padding(3, 2, 3, 2);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(136, 23);
            txtPeso.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 23);
            label11.Name = "label11";
            label11.Size = new Size(35, 15);
            label11.TabIndex = 11;
            label11.Text = "Peso:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(688, 28);
            label2.Name = "label2";
            label2.Size = new Size(114, 19);
            label2.TabIndex = 68;
            label2.Text = "Nota de avance";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(778, 47);
            label1.Name = "label1";
            label1.Size = new Size(47, 65);
            label1.TabIndex = 67;
            label1.Text = "-";
            // 
            // Bitacora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 396);
            Controls.Add(label2);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(Tbox_DNI);
            Name = "Bitacora";
            Text = "Bitacora";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Tbox_DNI;
        private Button button1;
        private GroupBox groupBox1;
        private Label Lbl_Nombre;
        private Label Lbl_Sexo;
        private Label Lbl_Edad;
        private GroupBox groupBox2;
        private Label label12;
        private TextBox txtPeso;
        private Label label11;
        private Label label14;
        private TextBox txtEstatura;
        private Label label13;
        private Label lbCalimc;
        private Label lbImc;
        private Label labelCalObje;
        private Label label4;
        private Label label28;
        private Label label27;
        private Label label26;
        private Label label25;
        private Label label24;
        private TextBox txtPecho;
        private TextBox txtBrazo;
        private TextBox txtGluteo;
        private TextBox txtCintura;
        private TextBox txtPierna;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private ComboBox cboFrecuencia;
        private Label label16;
        private ComboBox cboNivel;
        private Label label15;
        private Button button2;
        private Button btnRegistar;
        private Label label2;
        private Label label1;
    }
}