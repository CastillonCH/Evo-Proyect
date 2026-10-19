namespace RESTAURANTEFINAL
{
    partial class Promocion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Promocion));
            this.btn_promocion_guardar = new System.Windows.Forms.Button();
            this.btn_promocion_nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date_promocion_fin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.date_promocion_inicio = new System.Windows.Forms.DateTimePicker();
            this.txt_promocion_desc = new System.Windows.Forms.TextBox();
            this.txt_promocion_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_promocion_nom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_promocion_buscar = new System.Windows.Forms.TextBox();
            this.btn_promocion_eliminar = new System.Windows.Forms.Button();
            this.dataGridView_Promocion = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Promocion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_promocion_nuevo
            // 
            this.btn_promocion_nuevo.Location = new System.Drawing.Point(18, 292);
            this.btn_promocion_nuevo.Name = "btn_promocion_nuevo";
            this.btn_promocion_nuevo.Size = new System.Drawing.Size(100, 28);
            this.btn_promocion_nuevo.TabIndex = 20;
            this.btn_promocion_nuevo.Text = "Nuevo";
            this.btn_promocion_nuevo.UseVisualStyleBackColor = true;
            this.btn_promocion_nuevo.Click += new System.EventHandler(this.btn_promocion_nuevo_Click);
            // 
            // btn_promocion_guardar
            // 
            this.btn_promocion_guardar.Location = new System.Drawing.Point(128, 292);
            this.btn_promocion_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_promocion_guardar.Name = "btn_promocion_guardar";
            this.btn_promocion_guardar.Size = new System.Drawing.Size(100, 28);
            this.btn_promocion_guardar.TabIndex = 22;
            this.btn_promocion_guardar.Text = "Guardar";
            this.btn_promocion_guardar.UseVisualStyleBackColor = true;
            this.btn_promocion_guardar.Click += new System.EventHandler(this.btn_promocion_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_promocion_fin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_promocion_eliminar);
            this.groupBox1.Controls.Add(this.date_promocion_inicio);
            this.groupBox1.Controls.Add(this.txt_promocion_desc);
            this.groupBox1.Controls.Add(this.btn_promocion_nuevo);
            this.groupBox1.Controls.Add(this.btn_promocion_guardar);
            this.groupBox1.Controls.Add(this.txt_promocion_cod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_promocion_nom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(572, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(357, 373);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Promoción";
            // 
            // date_promocion_fin
            // 
            this.date_promocion_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_promocion_fin.Location = new System.Drawing.Point(181, 185);
            this.date_promocion_fin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date_promocion_fin.Name = "date_promocion_fin";
            this.date_promocion_fin.Size = new System.Drawing.Size(132, 22);
            this.date_promocion_fin.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Fecha Final";
            // 
            // date_promocion_inicio
            // 
            this.date_promocion_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_promocion_inicio.Location = new System.Drawing.Point(181, 137);
            this.date_promocion_inicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date_promocion_inicio.Name = "date_promocion_inicio";
            this.date_promocion_inicio.Size = new System.Drawing.Size(132, 22);
            this.date_promocion_inicio.TabIndex = 39;
            // 
            // txt_promocion_desc
            // 
            this.txt_promocion_desc.Location = new System.Drawing.Point(181, 243);
            this.txt_promocion_desc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_promocion_desc.Name = "txt_promocion_desc";
            this.txt_promocion_desc.Size = new System.Drawing.Size(132, 22);
            this.txt_promocion_desc.TabIndex = 26;
            // 
            // txt_promocion_cod
            // 
            this.txt_promocion_cod.Location = new System.Drawing.Point(181, 37);
            this.txt_promocion_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_promocion_cod.Name = "txt_promocion_cod";
            this.txt_promocion_cod.ReadOnly = true;
            this.txt_promocion_cod.Size = new System.Drawing.Size(132, 22);
            this.txt_promocion_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Inicio";
            // 
            // txt_promocion_nom
            // 
            this.txt_promocion_nom.Location = new System.Drawing.Point(181, 80);
            this.txt_promocion_nom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_promocion_nom.Name = "txt_promocion_nom";
            this.txt_promocion_nom.Size = new System.Drawing.Size(132, 22);
            this.txt_promocion_nom.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 243);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Descuento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "Buscar:";
            // 
            // txt_promocion_buscar
            // 
            this.txt_promocion_buscar.Location = new System.Drawing.Point(13, 64);
            this.txt_promocion_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_promocion_buscar.Name = "txt_promocion_buscar";
            this.txt_promocion_buscar.Size = new System.Drawing.Size(453, 22);
            this.txt_promocion_buscar.TabIndex = 37;
            this.txt_promocion_buscar.TextChanged += new System.EventHandler(this.txt_promocion_buscar_TextChanged);
            // 
            // btn_promocion_eliminar
            // 
            this.btn_promocion_eliminar.Location = new System.Drawing.Point(238, 292);
            this.btn_promocion_eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_promocion_eliminar.Name = "btn_promocion_eliminar";
            this.btn_promocion_eliminar.Size = new System.Drawing.Size(100, 28);
            this.btn_promocion_eliminar.TabIndex = 36;
            this.btn_promocion_eliminar.Text = "Eliminar";
            this.btn_promocion_eliminar.UseVisualStyleBackColor = true;
            this.btn_promocion_eliminar.Click += new System.EventHandler(this.btn_promocion_eliminar_Click);
            // 
            // dataGridView_Promocion
            // 
            this.dataGridView_Promocion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Promocion.Location = new System.Drawing.Point(13, 94);
            this.dataGridView_Promocion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_Promocion.Name = "dataGridView_Promocion";
            this.dataGridView_Promocion.RowHeadersWidth = 51;
            this.dataGridView_Promocion.Size = new System.Drawing.Size(513, 358);
            this.dataGridView_Promocion.TabIndex = 35;
            this.dataGridView_Promocion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Promocion_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(473, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // Promocion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 472);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_promocion_buscar);
            this.Controls.Add(this.dataGridView_Promocion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Promocion";
            this.Text = "\"PROMOCION\"";
            this.Load += new System.EventHandler(this.Promocion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Promocion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_promocion_guardar;
        private System.Windows.Forms.Button btn_promocion_nuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_promocion_desc;
        private System.Windows.Forms.TextBox txt_promocion_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_promocion_nom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_promocion_buscar;
        private System.Windows.Forms.Button btn_promocion_eliminar;
        private System.Windows.Forms.DataGridView dataGridView_Promocion;
        private System.Windows.Forms.DateTimePicker date_promocion_inicio;
        private System.Windows.Forms.DateTimePicker date_promocion_fin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}