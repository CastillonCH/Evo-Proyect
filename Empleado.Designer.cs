namespace RESTAURANTEFINAL
{
    partial class Empleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empleado));
            this.label6 = new System.Windows.Forms.Label();
            this.txt_empleado_buscar = new System.Windows.Forms.TextBox();
            this.btn_empleado_eliminar = new System.Windows.Forms.Button();
            this.dataGridView_Empleado = new System.Windows.Forms.DataGridView();
            this.btn_empleado_guardar = new System.Windows.Forms.Button();
            this.btn_empleado_nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_empleado_email = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_fecha_contra = new System.Windows.Forms.DateTimePicker();
            this.txt_empleado_tel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_empleado_cod = new System.Windows.Forms.ComboBox();
            this.txt_empleado_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_empleado_nom = new System.Windows.Forms.TextBox();
            this.txt_empleado_ape = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Empleado)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Buscar:";
            // 
            // txt_empleado_buscar
            // 
            this.txt_empleado_buscar.Location = new System.Drawing.Point(15, 61);
            this.txt_empleado_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_empleado_buscar.Name = "txt_empleado_buscar";
            this.txt_empleado_buscar.Size = new System.Drawing.Size(453, 23);
            this.txt_empleado_buscar.TabIndex = 36;
            this.txt_empleado_buscar.TextChanged += new System.EventHandler(this.txt_empleado_buscar_TextChanged);
            // 
            // btn_empleado_eliminar
            // 
            this.btn_empleado_eliminar.Location = new System.Drawing.Point(244, 389);
            this.btn_empleado_eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_empleado_eliminar.Name = "btn_empleado_eliminar";
            this.btn_empleado_eliminar.Size = new System.Drawing.Size(100, 30);
            this.btn_empleado_eliminar.TabIndex = 35;
            this.btn_empleado_eliminar.Text = "Eliminar";
            this.btn_empleado_eliminar.UseVisualStyleBackColor = true;
            this.btn_empleado_eliminar.Click += new System.EventHandler(this.btn_empleado_eliminar_Click);
            // 
            // dataGridView_Empleado
            // 
            this.dataGridView_Empleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Empleado.Location = new System.Drawing.Point(15, 92);
            this.dataGridView_Empleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_Empleado.Name = "dataGridView_Empleado";
            this.dataGridView_Empleado.RowHeadersWidth = 51;
            this.dataGridView_Empleado.Size = new System.Drawing.Size(467, 407);
            this.dataGridView_Empleado.TabIndex = 34;
            this.dataGridView_Empleado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Empleado_CellClick);
            // 
            // btn_empleado_nuevo
            // 
            this.btn_empleado_nuevo.Location = new System.Drawing.Point(24, 389);
            this.btn_empleado_nuevo.Name = "btn_empleado_nuevo";
            this.btn_empleado_nuevo.Size = new System.Drawing.Size(100, 30);
            this.btn_empleado_nuevo.TabIndex = 20;
            this.btn_empleado_nuevo.Text = "Nuevo";
            this.btn_empleado_nuevo.UseVisualStyleBackColor = true;
            this.btn_empleado_nuevo.Click += new System.EventHandler(this.btn_empleado_nuevo_Click);
            // 
            // btn_empleado_guardar
            // 
            this.btn_empleado_guardar.Location = new System.Drawing.Point(134, 389);
            this.btn_empleado_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_empleado_guardar.Name = "btn_empleado_guardar";
            this.btn_empleado_guardar.Size = new System.Drawing.Size(100, 30);
            this.btn_empleado_guardar.TabIndex = 33;
            this.btn_empleado_guardar.Text = "Guardar";
            this.btn_empleado_guardar.UseVisualStyleBackColor = true;
            this.btn_empleado_guardar.Click += new System.EventHandler(this.btn_empleado_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_empleado_email);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btn_empleado_eliminar);
            this.groupBox1.Controls.Add(this.dtp_fecha_contra);
            this.groupBox1.Controls.Add(this.txt_empleado_tel);
            this.groupBox1.Controls.Add(this.btn_empleado_nuevo);
            this.groupBox1.Controls.Add(this.btn_empleado_guardar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbx_empleado_cod);
            this.groupBox1.Controls.Add(this.txt_empleado_cod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_empleado_nom);
            this.groupBox1.Controls.Add(this.txt_empleado_ape);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(513, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(369, 440);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Empleado";
            // 
            // txt_empleado_email
            // 
            this.txt_empleado_email.Location = new System.Drawing.Point(191, 261);
            this.txt_empleado_email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_empleado_email.Name = "txt_empleado_email";
            this.txt_empleado_email.Size = new System.Drawing.Size(132, 23);
            this.txt_empleado_email.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 266);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "Email:";
            // 
            // dtp_fecha_contra
            // 
            this.dtp_fecha_contra.AllowDrop = true;
            this.dtp_fecha_contra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha_contra.Location = new System.Drawing.Point(191, 306);
            this.dtp_fecha_contra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_fecha_contra.Name = "dtp_fecha_contra";
            this.dtp_fecha_contra.Size = new System.Drawing.Size(132, 23);
            this.dtp_fecha_contra.TabIndex = 38;
            // 
            // txt_empleado_tel
            // 
            this.txt_empleado_tel.Location = new System.Drawing.Point(191, 215);
            this.txt_empleado_tel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_empleado_tel.Name = "txt_empleado_tel";
            this.txt_empleado_tel.Size = new System.Drawing.Size(132, 23);
            this.txt_empleado_tel.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 357);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Código Rol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 170);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Apellido:";
            // 
            // cbx_empleado_cod
            // 
            this.cbx_empleado_cod.FormattingEnabled = true;
            this.cbx_empleado_cod.Location = new System.Drawing.Point(191, 346);
            this.cbx_empleado_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_empleado_cod.Name = "cbx_empleado_cod";
            this.cbx_empleado_cod.Size = new System.Drawing.Size(132, 25);
            this.cbx_empleado_cod.TabIndex = 24;
            // 
            // txt_empleado_cod
            // 
            this.txt_empleado_cod.Location = new System.Drawing.Point(191, 40);
            this.txt_empleado_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_empleado_cod.Name = "txt_empleado_cod";
            this.txt_empleado_cod.ReadOnly = true;
            this.txt_empleado_cod.Size = new System.Drawing.Size(132, 23);
            this.txt_empleado_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 313);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Contratación:";
            // 
            // txt_empleado_nom
            // 
            this.txt_empleado_nom.Location = new System.Drawing.Point(191, 103);
            this.txt_empleado_nom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_empleado_nom.Name = "txt_empleado_nom";
            this.txt_empleado_nom.Size = new System.Drawing.Size(132, 23);
            this.txt_empleado_nom.TabIndex = 3;
            // 
            // txt_empleado_ape
            // 
            this.txt_empleado_ape.Location = new System.Drawing.Point(191, 164);
            this.txt_empleado_ape.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_empleado_ape.Name = "txt_empleado_ape";
            this.txt_empleado_ape.Size = new System.Drawing.Size(132, 23);
            this.txt_empleado_ape.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Telefono:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(446, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 515);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_empleado_buscar);
            this.Controls.Add(this.dataGridView_Empleado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Empleado";
            this.Text = "\"EMPLEADO\"";
            this.Load += new System.EventHandler(this.Empleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Empleado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_empleado_buscar;
        private System.Windows.Forms.Button btn_empleado_eliminar;
        private System.Windows.Forms.DataGridView dataGridView_Empleado;
        private System.Windows.Forms.Button btn_empleado_guardar;
        private System.Windows.Forms.Button btn_empleado_nuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_empleado_cod;
        private System.Windows.Forms.TextBox txt_empleado_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_empleado_nom;
        private System.Windows.Forms.TextBox txt_empleado_ape;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_fecha_contra;
        private System.Windows.Forms.TextBox txt_empleado_tel;
        private System.Windows.Forms.TextBox txt_empleado_email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}